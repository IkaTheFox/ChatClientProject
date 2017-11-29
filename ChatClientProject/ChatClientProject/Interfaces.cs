using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatClientProject
{
    interface ChatterInterface
    {
        void receiveAMessage(String message, Chatter sender);
        String Alias
        {
            get;
        }
    }
    interface ChatRoomInterface
    {
        void post(String msg, Chatter sender);
        bool quit(Chatter leaving_user);
        bool join(Chatter joining_user);
        String Topic
        {
            get;
        }
    }
    interface TopicsManagerInterface
    {
        List<String> listTopics();
        ChatRoom joinTopic(String topic);
        bool createTopic(String topic);
    }
}
