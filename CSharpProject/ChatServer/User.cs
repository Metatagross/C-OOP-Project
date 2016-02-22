using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ChatServer
{
    [Serializable()]
    [XmlRoot("User")]
    public class User
    {
        private string name;
        private string pass;

        public User ( ):this("user", "pass")
        {

        }
        public User ( string name , string pass )
        {
            Name = name;
            Pass = pass;
        }
        [XmlElement("Username")]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        [XmlElement("Password")]
        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }
        public override bool Equals ( object obj )
        {
            if(obj!=null)
            {
                User u = (User)obj;
                if(u!=null)
                {
                    return u.Name == Name && u.Pass == Pass;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode ( )
        {
            return Name.GetHashCode()+Pass.GetHashCode();
        }
        public override string ToString ( )
        {
            return string.Format("Username: {0}  Password: {1}" , Name , Pass);
        }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("UserCollection")]
    public class UserCollection
    {
        [XmlArray("UserCollection")]
        [XmlArrayItem("User" , typeof(User))]
        public List<User> Users { get; set; }
    }
}
