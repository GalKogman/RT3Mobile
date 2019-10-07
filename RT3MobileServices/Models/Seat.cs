using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RT3MobileServices.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

        private string block;

        public string Block
        {
            get { return block; }
            set { block = value.Trim(); }
        }

        public int Price { get; set; }

        private string buyerName;

        public string BuyerName
        {
            get { return buyerName; }
            set { buyerName = value.Trim(); }
        }
        
        public bool Sold { get; set; }
        public int Discount { get; set; }
        public string Remark { get; set; }
    }
}
