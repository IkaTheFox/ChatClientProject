using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ChatClientProject
{
    class Program
    {
        public static void Main(String[] args)
        {
            /*Chatter bob = new TextChatter("Bob");
            Chatter joe = new TextChatter("Joe");
            TopicsManager gt = new TextGestTopics();
            gt.createTopic("java");
            gt.createTopic("UML");
            gt.listTopics();
            gt.createTopic("jeux");
            gt.listTopics();
            ChatRoom cr = gt.joinTopic("jeux");
            cr.join(bob);
            cr.post("Je suis seul ou quoi ?", bob);
            cr.join(joe);
            cr.post("Tiens, salut Joe !", bob);
            cr.post("Toi aussi tu chat sur les forums de jeux pendant les TP, Bob ? ",joe);*/
            ThreadStart serverchildref = new ThreadStart(AsynchronousSocketListener.run);
            Thread serverThread = new Thread(serverchildref);
            serverThread.Start();
        }
    }
}
