using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChatClientProject
{
    public class ChatRoom : ChatRoomInterface
    {
        
        static Chatter chatbot = new Chatter(0,"Chat Bot");
        private int roomNumber;
        static private int roomCount;
        private List<Chatter> usrList;
        private String topic;

        public string Topic
        {
            get
            {
                return topic;
            }
        }

        public delegate void Handler(object sender, msg m);
        public event Handler msgHandler;
        

        protected virtual void onMsgReceive(object sender, msg m)
        {
            if (msgHandler != null)
            {
                //System.Console.WriteLine("Subscription found");
                msgHandler(sender, m);
            }
        }

        public void RaiseMsgReceive(msg Message)
        {
            //System.Console.WriteLine("Raising msg event");
            onMsgReceive(this, Message);
        }

        public ChatRoom()
        {
            roomCount++;
            this.roomNumber = roomCount;
            usrList = new List<Chatter>();
            msgHandler += new Handler(msgReceived);
        }

        public ChatRoom(String topic)
        {
            roomCount++;
            this.roomNumber = roomCount;
            usrList = new List<Chatter>();
            msgHandler += new Handler(msgReceived);
            this.topic = topic;
        }

        public bool join(Chatter joining_user)
        {
            if (usrList.Contains(joining_user))
            {
                return false;
            }
            usrList.Add(joining_user);
            //myDelegateClass = Handler
            //MyDel = msgHandler
            //HEREBY subscription
            post("(Message from Chatroom : "+Topic+") "+joining_user+" has joined the room.", chatbot);
            return true;
        }

        public bool quit(Chatter leaving_user)
        {
            usrList.Remove(leaving_user);
            return true;
        }

        public void msgReceived(object sender, msg m)
        {
            if (chatbot.Equals(m.Sender))
            {
                System.Console.WriteLine(m.Message);
            }
            else
            {
                System.Console.WriteLine(m.Sender.ToString() + " > " + m.Message);
            }
        }
        public void post(string message, Chatter sender)
        {
            msg packet = new msg(message,sender);
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
        public msg(string message, Chatter sender) : base()
        {
            this.sender = sender;
            this.message = message;

        }
    }
}
