using MyWallet_2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0
{
    public class UserSpend
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        private double amountSpent;
        private int categoryId;
        private string comment;


        public double AmountSpent
        {

            get { return amountSpent; }
            set { amountSpent = value; }
        }

        [ForeignKey("Category")]
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public string Comment
        {

            get { return comment; }
            set { comment = value; }
        }

        public virtual Category Category { get; set; }



        public UserSpend() { }

        public UserSpend(double amountSpent, int categoryId, string comment = null)
        {
            this.amountSpent = amountSpent;
            this.categoryId = categoryId;
            CreatedAt = DateTime.UtcNow;
            this.comment = comment;
        }


        public override string ToString()
        {
            return comment + "";
        }


    }
}
