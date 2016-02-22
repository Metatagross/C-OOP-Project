using System;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using ChatServer;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Text;
using System.Xml.Serialization;

public partial class ChatServerForm : Form
{
    private string path = Path.Combine(Directory.GetCurrentDirectory(),"ArchiveUsers.xml");
    public ChatServerForm ( )
    {
        InitializeComponent();
        writers = new Dictionary<Thread , BinaryWriter>();
        sockets = new Dictionary<Thread , Socket>();
    }

    private Thread readThread;
    private Dictionary<Thread , BinaryWriter> writers;
    private Dictionary<Thread , Socket> sockets;

    private void ChatServerForm_Load ( object sender , EventArgs e )
    {
        readThread = new Thread(new ThreadStart(RunServer));
        readThread.Start();
    }
    private void ChatServerForm_FormClosing ( object sender ,
       FormClosingEventArgs e )
    {
        System.Environment.Exit(System.Environment.ExitCode);
    }
    private delegate void DisplayDelegate ( string message );


    private void DisplayMessage ( string message )
    {
        if(displayTextBox.InvokeRequired)
        {
            Invoke(new DisplayDelegate(DisplayMessage) ,
               new object[] { message });
        }
        else
        {
            displayTextBox.Text += message;
        }
    }

    public void RunServer ( )
    {
        Socket connection;
        TcpListener listener;
        int counter = 1;

        try
        {               
            IPAddress local = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(local , 50000);

            listener.Start();

            while(true)
            {
                DisplayMessage("Waiting for connection\r\n");

                connection = listener.AcceptSocket();
                DisplayMessage("Connection " + counter + " received.\r\n");
                ThreadPool.QueueUserWorkItem(ProcessClient , connection);
                counter++;
            }
        }
        catch(Exception error)
        {
            MessageBox.Show(error.ToString());
        }
    }
    public void ProcessClient ( object socket )
    {
        Socket connection = (Socket)socket;
        NetworkStream socketStream=new NetworkStream(connection);
        BinaryWriter writer = new BinaryWriter(socketStream);
        BinaryReader reader = new BinaryReader(socketStream);
 
        if(connection != null)
        {
            sockets.Add(Thread.CurrentThread , connection);
        }
        writers.Add(Thread.CurrentThread , writer);

        string theReply = "";

        do
        {
            try
            {
                theReply = reader.ReadString();
                string[] words = theReply.Split('\r' , '\t' , ' ');
                if(words[0].Contains("Register"))
                {
                    User user = new User(words[1] , words[2]);
                    List<User> list = new List<User>();
                    if(!File.Exists(path))
                    {
                    }
                    else
                    {
                        XmlSerializer xmlSer = new XmlSerializer(typeof(UserCollection));
                        //var sr = new StreamReader(path);
                        using(var stream = File.OpenRead(path))
                        {
                            list=((UserCollection)xmlSer.Deserialize(stream)).Users;
                            if(list.Contains(user))
                            {
                                DisplayMessage("\r\n" + theReply + " true");
                                writer.Write(" true ");
                            }
                            else
                            {
                                DisplayMessage("\r\n" + theReply + " false");
                                writer.Write(" false ");
                            }
                        }
                    }
                }
                else if(words[0].Contains("Card"))
                {
                    Regex r = new Regex(@"\d{4}-\d{4}-\d{4}-\d{4}");
                    if(r.IsMatch(words[1])&&LuhnCheck(words[1]))
                    {
                        string scrypt = Transform(words[1]);
                        writer.Write(scrypt);
                    }
                    else
                    {
                        writer.Write("Invalid input");
                    }
                }
                else if(words[0].Contains("Cypher"))
                {
                    Regex r = new Regex(@"\d{4}-\d{4}-\d{4}-\d{4}");
                    if(r.IsMatch(words[1]))
                    {
                        string scrypt = Transform(words[1]);
                        writer.Write(scrypt);
                    }
                    else
                    {
                        writer.Write("Invalid input");
                    }
                }
                else
                {
                    writer.Write("Error");
                }
            } 
            catch(Exception)
            {
                break;
            } 
        } while(true);

        DisplayMessage("\r\nUser terminated connection\r\n");

        writer.Close();
        reader.Close();
        socketStream.Close();
        connection.Close();
        writers.Remove(Thread.CurrentThread);
        sockets.Remove(Thread.CurrentThread);
    }

    private bool LuhnCheck ( string v )
    {
        int sum = 0;
        bool isOddPos = true;
        foreach(char item in v)
        {
            short num;
            if(Int16.TryParse(item.ToString() , out num))
            {
                if(isOddPos)
                {
                    sum += num;
                }
                else
                {
                    sum += (2 * num) % 10 + (2 * num) / 10;
                }
                isOddPos = !isOddPos;
            }
        }
        return sum % 10 == 0;
    }

    private string Transform ( string bankNum )
    {
        StringBuilder sb = new StringBuilder();
        foreach(var digit in bankNum)
        {
            short num;
            if(Int16.TryParse(digit.ToString() , out num))
            {
                sb.Append((num - 5 < 0) ? (10 + (num - 5)) : (num - 5));
            }
            else
            {
                sb.Append('-');
            }
        }
        return sb.ToString();
    }

    private void displayTextBox_TextChanged ( object sender , EventArgs e )
    {

    }
}