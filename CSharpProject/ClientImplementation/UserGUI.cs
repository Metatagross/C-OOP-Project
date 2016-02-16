using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientImplementation
{
    public partial class UserGUI : Form
    {
        public UserGUI ( )
        {
            InitializeComponent();
        }

        private NetworkStream output; // stream for receiving data           
        private BinaryWriter writer; // facilitates writing to the stream    
        private BinaryReader reader; // facilitates reading from the stream  
        private Thread readThread; // Thread for processing incoming messages
        private string message = "";

        public void RunClient ( )
        {
            TcpClient client;

            // instantiate TcpClient for sending data to server
            try
            {
                //DisplayMessage("Attempting connection\r\n");

                // Step 1: create TcpClient and connect to server
                client = new TcpClient();
                client.Connect("127.0.0.1" , 50000);

                // Step 2: get NetworkStream associated with TcpClient
                output = client.GetStream();

                // create objects for writing and reading across stream
                writer = new BinaryWriter(output);
                reader = new BinaryReader(output);

                //DisplayMessage("\r\nGot I/O streams\r\n");
                //DisableInput(false); // enable inputTextBox

                // loop until server signals termination
                do
                {
                    // Step 3: processing phase
                    try
                    {
                        // read message from server        
                        // message = reader.ReadString();
                        // DisplayMessage("\r\n" + message);
                    } // end try
                    catch(Exception)
                    {
                        // handle exception if error in reading server data
                        System.Environment.Exit(System.Environment.ExitCode);
                    } // end catch
                } while(message != "SERVER>>> TERMINATE");

                // Step 4: close connection
                writer.Close();
                reader.Close();
                output.Close();
                client.Close();

                Application.Exit();
            } // end try
            catch(Exception error)
            {
                // handle exception if error in establishing connection
                MessageBox.Show(error.ToString() , "Connection Error" ,
                   MessageBoxButtons.OK , MessageBoxIcon.Error);
                System.Environment.Exit(System.Environment.ExitCode);
            } // end catch
        } // end method RunClient
        private void UserGUI_FormClosing ( object sender ,
      FormClosingEventArgs e )
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
        private void UserGUI_Load ( object sender , EventArgs e )
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

        private void btnEnter_Click ( object sender , EventArgs e )
        {
            if(AreValid(txtbUser.Text , txtbPass.Text))
            {
                txtbCipher.ReadOnly = false;
                txtbGet.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
                Close();
            }
        }

        private void btnCrypt_Click ( object sender , EventArgs e )
        {
            writer.Write(String.Format($"Card: {txtbCipher.Text}"));
            string reply = reader.ReadString();
            if(reply.Contains("Invalid"))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                txtbReturnCypher.Text = reply;
            }
        }

        private void btnGetCard_Click ( object sender , EventArgs e )
        {
            writer.Write(String.Format($"Cypher: {txtbGet.Text}"));
            string reply = reader.ReadString();
            if(reply.Contains("Invalid"))
            {
                MessageBox.Show("Invalid input");
            }
            else
            {
                txtbReturnBank.Text = reply;
            }
        }
    }
}
