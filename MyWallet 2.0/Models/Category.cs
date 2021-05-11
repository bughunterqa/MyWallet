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

        private int imageId;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public int ImageId
        {
            get { return imageId; }
            set { imageId = value; }
        }

        public virtual Image Image { get; set; }


        public Category() { }


        public Category(string categoryName, int imageId)
        {
            this.categoryName = categoryName;
            this.imageId = imageId;
        }

        public override string ToString()
        {
            return id + "";
        }
    }
}
