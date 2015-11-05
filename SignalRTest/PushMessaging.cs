using SignalRTest.Models;
using SignalRTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTest
{
    class PushMessaging
    {
        static PushMessaging _instance = null;
        NewMessageNotifier _newMessageNotifier;
        Action<IEnumerable<string>> _dispatcher;
        string _connString;
        string _selectQuery;

        public static PushMessaging GetInstance(Action<IEnumerable<string>> dispatcher)
        {
            if (_instance == null)
                _instance = new PushMessaging(dispatcher);

            return _instance;
        }
        private PushMessaging(Action<IEnumerable<string>> dispatcher)
        {
            _dispatcher = dispatcher;
            _connString = Constants.CONNECTIONSTRING;
            _selectQuery = Constants.DBTABLE_MESSAGE_SELECT_ALL;
            _newMessageNotifier = new NewMessageNotifier(_connString, _selectQuery);
            _newMessageNotifier.NewMessage += NewMessageRecieved;
        }

        internal void NewMessageRecieved(object sender, SqlNotificationEventArgs e)
        {
            IEnumerable<Message> newMessages = FetchMessagesFromDb();
            _dispatcher(newMessages.Select(lm => lm.MessageTest));
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                //Mark all dispatched messages as sent
                newMessages.ToList().ForEach(lm => { db.Messages.Attach(lm); lm.IsSend = true; });
                db.SaveChanges();
            }
        }

        private IEnumerable<Message> FetchMessagesFromDb()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Messages.Where(lm => lm.IsSend == false).ToList();
            }
        }
    }
}
