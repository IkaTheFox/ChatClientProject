using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectS7
{
    public class Chatter
    {
        private string nickname;
        private int auth;
        private static int number_of_users = 0;

        public string Nickname
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
            this.Nickname = nick;
            this.auth = number_of_users;
            number_of_users++;
        }
        public Chatter(int authNumber, string nick)
        {
            this.Nickname = nick;
            this.auth = authNumber;
        }
        public string ToString()
        {
            return this.Nickname;
        }
    }
}
