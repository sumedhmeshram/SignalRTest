using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRTest.ViewModels
{
    public class Message
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string MessageTest { get; set; }

        public int UserId { get; set; }

        public bool IsSend { get; set; }


    }
}
