using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet_2._0.Models
{
    public class Image
    {
        public int id { get; set; }

        private string imagePuth;

        public string ImagePuth
        {
            get { return imagePuth; }
            set { imagePuth = value; }
        }

        public Image() { }

        public Image(string imagePuth)
        {
            this.imagePuth = imagePuth;
        }

        public override string ToString()
        {
            return id + "";
        }
    }
}
