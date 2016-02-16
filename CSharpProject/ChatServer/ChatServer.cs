// Fig. 23.1: ChatServer.cs
// Set up a server that will receive a connection from a client, send a
// string to the client, chat with the client and close the connection.
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

public partial class ChatServerForm : Form
{
    private string path = @"C:\Users\User\Documents\Visual Studio 2015\Projects\CSharpProject\Archive.txt";
    public ChatServerForm()
    {
        InitializeComponent();
        writers = new Dictionary<Thread, BinaryWriter>();
        sockets = new Dictionary<Thread, Socket>();
    } // end constructor


    private Thread readThread; // Thread for processing incoming messages
    private Dictionary<Thread, BinaryWriter> writers; // facilitates writing to the stream    
    private Dictionary<Thread, Socket> sockets;

    // initialize thread for reading
    private void ChatServerForm_Load(object sender, EventArgs e)
    {
        readThread = new Thread(new ThreadStart(RunServer));
        readThread.Start();
    } // end method CharServerForm_Load

    // close all threads associated with this application
    private void ChatServerForm_FormClosing(object sender,
       FormClosingEventArgs e)
    {
        System.Environment.Exit(System.Environment.ExitCode);
    } // end method CharServerForm_FormClosing

    // delegate that allows method DisplayMessage to be called
    // in the thread that creates and maintains the GUI       
    private delegate void DisplayDelegate(string message);

    // method DisplayMessage sets displayTextBox's Text property
    // in a thread-safe manner
    private void DisplayMessage(string message)
    {
        // if modifying displayTextBox is not thread safe
        if (displayTextBox.InvokeRequired)
        {
            // use inherited method Invoke to execute DisplayMessage
            // via a delegate                                       
            Invoke(new DisplayDelegate(DisplayMessage),
               new object[] { message });
        } // end if
        else // OK to modify displayTextBox in current thread
            displayTextBox.Text += message;
    } // end method DisplayMessage


    // in a thread-safe manner

    // allows a client to connect; displays text the client sends
    public void RunServer()
    {
        Socket connection;
        TcpListener listener;
        int counter = 1;

        // wait for a client connection and display the text
        // that the client sends
        try
        {
            // Step 1: create TcpListener                    
            IPAddress local = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(local, 50000);

            // Step 2: TcpListener waits for connection request
            listener.Start();

            // Step 3: establish connection upon client request
            while (true)
            {
                DisplayMessage("Waiting for connection\r\n");

                // accept an incoming connection     
                connection = listener.AcceptSocket();
                DisplayMessage("Connection " + counter + " received.\r\n");
                ThreadPool.QueueUserWorkItem(ProcessClient, connection);
                counter++;
                // create NetworkStream object associated with socket

            } // end while
        } // end try
        catch (Exception error)
        {
            MessageBox.Show(error.ToString());
        } // end catch
    }
    public void ProcessClient(object socket)
    {
        NetworkStream socketStream; // network data stream           
        BinaryWriter writer; // facilitates writing to the stream    
        BinaryReader reader;
        Socket connection = (Socket)socket;
        socketStream = new NetworkStream(connection);
        // create objects for transferring data across stream
        writer = new BinaryWriter(socketStream);
        reader = new BinaryReader(socketStream);
        if (connection != null)
        {
            sockets.Add(Thread.CurrentThread, connection);
        }
        writers.Add(Thread.CurrentThread, writer);

        // inform client that connection was successfull  
        //writer.Write("SERVER>>> Connection successful");
        string theReply = "";

        // Step 4: read string data sent from client
        do
        {
            try
            {
                // read the string sent to the server
                theReply = reader.ReadString();
                string[] words = theReply.Split('\r','\t',' ');
                if(words[0].Contains("Register"))
                {
                    User user = new User(words[1] , words[2]);
                    List<User> list = new List<User>();
                    if(!File.Exists(path))
                    {
                    }
                    else
                    {
                        var bFormatter = new BinaryFormatter();
                        using(var stream = File.OpenRead(path))
                        {
                            list.AddRange((ICollection<User>)bFormatter.Deserialize(stream));
                            if(list.Contains(user))
                            {
                                DisplayMessage("\r\n" + theReply+" true");
                                writer.Write(" true ");
                            }
                            else
                            {
                                DisplayMessage("\r\n" + theReply+" false");
                                writer.Write(" false ");
                            }
                        }
                    }
                }
                else if(words[0].Contains("Card"))
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
                // display the message
            } // end try
            catch (Exception)
            {
                // handle exception if error reading data
                break;
            } // end catch
        } while (theReply != "CLIENT>>> TERMINATE" &&
           connection.Connected);

        DisplayMessage("\r\nUser terminated connection\r\n");

        // Step 5: close connection  
        writer.Close();
        reader.Close();
        socketStream.Close();
        connection.Close();

        writers.Remove(Thread.CurrentThread);
    }

    private string Transform ( string bankNum)
    {
        StringBuilder sb = new StringBuilder();
        foreach(var digit in bankNum)
        {
            short num;
            if(Int16.TryParse(digit.ToString(),out num))
            {
                sb.Append((num-5<0)?(10+(num-5)):(num-5));
            }
            else
            {
                sb.Append('-');
            }
        }
        return sb.ToString();
    }

    private void displayTextBox_TextChanged(object sender, EventArgs e)
    {

    } // end method RunServer
} // end class ChatServerForm

/**************************************************************************
 * (C) Copyright 1992-2006 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 *************************************************************************/