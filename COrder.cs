using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using Config;

namespace SushimasterTests
{

    public class COrder
    {
        public string orderNum;
        public CClient client;
        public string deliveryType;
        public CClientAddress address;
        public string iikoDeliveryTerminalName;
        public string city;
        public string comment;
        public List<CSKU> products;
        public double totalPrice;
        public double deliveryPrice;
        public double productsPrice;
        public List<CPayment> payments;

        public COrder()
        {
            products = new List<CSKU>();
            client = new CClient();
            payments = new List<CPayment>();

        }

    }   

}