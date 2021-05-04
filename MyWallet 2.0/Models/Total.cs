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

        public double TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; }
        }

        public Total() { }

        public Total(double totalMoney)
        {
            this.totalMoney = totalMoney;

        }
    }
}
