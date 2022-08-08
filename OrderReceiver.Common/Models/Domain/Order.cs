using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderReceiver.Common.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverAddress { get; set; }
        public int Weight { get; set; }
        public DateTime CargoAcceptanceDate { get; set; }        
    }
}
