using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0.Models
{
    public class Category
    {
        public int id { get; set; }

        private string categoryName;



        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }


        public Category() { }


        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public override string ToString()
        {
            return id + "";
        }
    }
}
