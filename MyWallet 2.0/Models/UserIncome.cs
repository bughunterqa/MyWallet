using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0.Models
{
    class UserIncome
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

        [ForeignKey("IncomeCategory")]
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

        public virtual IncomeCategory IncomeCategory { get; set; }



        public UserIncome() { }

        public UserIncome(double amountSpent, int categoryId, string comment = null)
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
