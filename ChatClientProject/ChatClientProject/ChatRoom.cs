using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatClientProject
{
    class ChatRoom
    {

        private int roomNumber;
        static private int roomCount;
        private List<Chatter> usrList;
        private string topic;
        public delegate void Handler(object sender, msg m);
        public event Handler msgHandler;

        public string Topic
        {
            get
            {
                return topic;
            }

            set
            {
                topic = value;
            }
        }

        protected virtual void onMsgReceive(object sender, msg m)
        {
            if (msgHandler != null)
            {
                System.Console.WriteLine("Subscription found");
                msgHandler(sender, m);
            }
        }

        public void RaiseMsgReceive(msg Message)
        {
            System.Console.WriteLine("Raising msg event");
            onMsgReceive(this, Message);
        }

        public ChatRoom()
        {
            roomCount++;
            this.roomNumber = roomCount;
            usrList = new List<Chatter>();
            msgHandler += new Handler(msgReceived);
        }

        public bool join(Chatter joining_user)
        {
            foreach (Chatter usr in usrList)
            {
                if (usr.Nickname == joining_user.Nickname)
                {
                    return false;
                }
            }
            usrList.Add(joining_user);
            //myDelegateClass = Handler
            //MyDel = msgHandler
            //HEREBY subscription
            return true;
        }

        public bool quit(Chatter leaving_user)
        {
            usrList.Remove(leaving_user);
            return true;
        }

        public void msgReceived(object sender, msg m)
        {
            System.Console.WriteLine(m.Sender.ToString() + " > " + m.Message);
        }
        public void sendMsg(Chatter sender, string message)
        {
            msg packet = new msg(sender, message);
            RaiseMsgReceive(packet);
        }

    }
    public class msg : EventArgs
    {
        Chatter sender;
        string message;

        internal Chatter Sender
        {
            get
            {
                return sender;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }
        public msg(Chatter sender, string message) : base()
        {
            this.sender = sender;
            this.message = message;

        }
    }
}
