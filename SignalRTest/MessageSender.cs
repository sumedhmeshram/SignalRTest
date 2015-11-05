using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTest
{
    public class MessageSender : Hub
    {
        public void DispatchToClient(IEnumerable<string> messages)
        {
            foreach (string message in messages)
                Clients.All.broadcastMessage(message);
        }
        public MessageSender()
        {
            Action<IEnumerable<string>> dispatcher = (messages) => { DispatchToClient(messages); };
            //We create a singleton instance of PushMessaging
            PushMessaging.GetInstance(dispatcher);
        }
    }
}
