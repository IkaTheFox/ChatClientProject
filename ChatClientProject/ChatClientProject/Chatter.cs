using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientProject
{
    public class Chatter : ChatterInterface
    {
        private string nickname;
        private int auth;
        private static int number_of_users = 0;

        public string Alias
        {
            get
            {
                return nickname;
            }

            set
            {
                nickname = value;
            }
        }

        public int Auth
        {
            get
            {
                return auth;
            }
            
        }

        public Chatter(string nick)
        {
            this.Alias = nick;
            this.auth = number_of_users;
            number_of_users++;
        }
        public Chatter(int authNumber, string nick)
        {
            this.Alias = nick;
            this.auth = authNumber;
            number_of_users++;
        }
       
        override public string ToString()
        {
            return this.Alias;

        }
        public void receiveAMessage(String message, Chatter sender)
        {
            System.Console.WriteLine("TODO receive a message : Chatter");
        }
        /*public bool Equals(Chatter chatter)
        {
            if(chatter.Alias == this.Alias)
            {
                if(chatter.Auth == this.Auth)
                {
                    return true;
                }
            }
            return false;
        }*/
    }
    public class TextChatter : Chatter
    {
        public TextChatter(string nick) : base(nick)
        {

        }
    }
}
