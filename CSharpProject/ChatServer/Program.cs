using ChatServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main ( )
    {
        //var path = @"C:\Users\User\Documents\Visual Studio 2015\Projects\CSharpProject\Archive.txt";
        //List<User> listOfUsers = new List<User>() {new User("maria_9578", "mariaPos"),
        //new User("kaloyan.dimitrov", "koko8754"),
        //new User("metodi_48", "metodiA"),
        //new User("porimia.banana", "bananaM8"),
        //new User("kompana_bora", "boraBora"),
        //new User("ivan_ivanov", "van4o4o4o")};
        //var bFormatter2 = new BinaryFormatter();
        //using(var stream = File.OpenWrite(path))
        //{  // serialize
        //    bFormatter2.Serialize(stream , listOfUsers);
        //    stream.Close();
        //}
        Application.EnableVisualStyles();
        Application.Run(new ChatServerForm());
    }
}
