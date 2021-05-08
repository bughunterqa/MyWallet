using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0
{
    class Total
    {
        public int id { get; set; }

        private double totalMoney;

        private string billName;

        public double TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }

        public string BillName
        {
            get { return billName; }
            set { billName = value; }
        }

        public Total() { }

        public Total(double totalMoney, string billName)
        {
            this.totalMoney = totalMoney;
            this.billName = billName;
        }
        public override string ToString()
        {
            return billName + "";
        }

    }
}
