using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BankApp : Window
    {
        public BankApp ( )
        {
            InitializeComponent();
        }

        private NetworkStream output; // stream for receiving data           
        private BinaryWriter writer; // facilitates writing to the stream    
        private BinaryReader reader; // facilitates reading from the stream  
        private Thread readThread; // Thread for processing incoming messages
        private int logInCounter = 5;
        private int scriptCounter = 12;
        private int cardCounter = 12;
        private string card=null;
        private string script=null;
        public void RunClient ( )
        {
            TcpClient client;

            // instantiate TcpClient for sending data to server
            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1" , 50000);

                output = client.GetStream();

                writer = new BinaryWriter(output);
                reader = new BinaryReader(output);
            } // end try
            catch(Exception error)
            {
                // handle exception if error in establishing connection
                MessageBox.Show(error.ToString() , "Connection Error" ,
                   MessageBoxButton.OK , MessageBoxImage.Error);
                System.Environment.Exit(System.Environment.ExitCode);
            } // end catch
        } // end method RunClient
        private void BankApp_Closing ( object sender , System.ComponentModel.CancelEventArgs e )
        {
            writer.Write("The app is closing!");
            System.Environment.Exit(System.Environment.ExitCode);
        }
        private void BankApp_Load ( object sender , RoutedEventArgs e )
        {
            readThread = new Thread(new ThreadStart(RunClient));
            readThread.Start();
        }

        private bool AreValid ( string userText , string passText )
        {
            writer.Write(String.Format($"Register: {userText} {passText}"));
            string reply = reader.ReadString();
            if(reply.Contains("true"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtnEnter_Click ( object sender , RoutedEventArgs e )
        {
            if(AreValid(txtbUser.Text , txtbPass.Password))
            {
                txtbScript.IsReadOnly = false;
                txtbCard.IsReadOnly = false;
            }
            else
            {
                MessageBox.Show(String.Format($"Invalid username or password!\nRemaining tries {logInCounter}"));
                if(logInCounter==0)
                {
                    Close();
                }
                logInCounter--;
            }
        }

        private void BtnScript_Click ( object sender , RoutedEventArgs e )
        {
            if(card==null||card!=txtbCard.Text)
            {
                card = txtbCard.Text;
                cardCounter = 12;
            }
            else
            {
                cardCounter--;
            }
            if(cardCounter==0)
            {
                MessageBox.Show("Error! Too many tries!");
            }
            writer.Write(String.Format($"Card: {txtbCard.Text}"));
            string reply = reader.ReadString();
            if(reply.Contains("Invalid"))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                txtbReturnScript.Text = reply;
            }
        }

        private void BtnCard_Click ( object sender , RoutedEventArgs e )
        {
            if(script == null || script != txtbScript.Text)
            {
                script = txtbScript.Text;
                scriptCounter = 12;
            }
            else
            {
                scriptCounter--;
            }
            if(scriptCounter == 0)
            {
                MessageBox.Show("Error! Too many tries!");
            }
            writer.Write(String.Format($"Cypher: {txtbScript.Text}"));
            string reply = reader.ReadString();
            if(reply.Contains("Invalid"))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                txtbReturnCard.Text = reply;
            }
        }
    }
}
