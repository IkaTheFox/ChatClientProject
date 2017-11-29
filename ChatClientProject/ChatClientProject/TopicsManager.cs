using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatClientProject
{
    public class TopicsManager : TopicsManagerInterface
    {
        Dictionary<String, ChatRoom> topicsList;
        public List<String> listTopics()
        {
            Dictionary<String, ChatRoom>.KeyCollection list = topicsList.Keys;
            List<String> returnedList = new List<string>();
            foreach (String topic in list)
            {
                returnedList.Add(topic);
            }
            System.Console.WriteLine("Listing topics :");
            foreach(String topic in returnedList)
            {
                System.Console.WriteLine(topic);
            }
            System.Console.WriteLine("--------------");
            return returnedList;
        }

        public ChatRoom joinTopic(String topic)
        {
            if (topicsList.ContainsKey(topic))
            {
                return topicsList[topic];
            } else
            {
                createTopic(topic);
                return topicsList[topic];
            }
        }
        public bool createTopic(String topic)
        {
            if (topicsList.ContainsKey(topic))
            {
                return false;
            } else
            {
                ChatRoom newcr = new ChatRoom(topic);
                topicsList[topic] = newcr;
                return true;
            }

        }
        public bool closeChatroom(String topic)
        {
            if (topicsList.ContainsKey(topic))
            {
                topicsList.Remove(topic);
                return true;
            }else
            {
                return false;
            }
        }
        public TopicsManager()
        {
            topicsList = new Dictionary<string, ChatRoom>();
        }
    }
    public class TextGestTopics : TopicsManager
    {

    }
}
