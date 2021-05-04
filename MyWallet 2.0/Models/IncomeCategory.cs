using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0.Models
{
    class IncomeCategory
    {
        public int id { get; set; }

        private string categoryName;


        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }


        public IncomeCategory() { }


        public IncomeCategory(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public override string ToString()
        {
            return id + "";
        }
    }
}
