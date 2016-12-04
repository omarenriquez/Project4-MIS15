using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication6
{
    public class Product
    {
        private string code;
        private string description;
        private string manufacturer;
        private decimal price; 

        public Product() { }

        public Product(string code, string description, string manufacturer, decimal price)
        {
            this.Code = code;
            this.Description = description;
            this.Manufacturer = manufacturer;
            this.Price = price;
        }

        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public string GetDisplayText(string sep)
        {
            return code + sep +  price.ToString("c") + sep + description + sep + manufacturer;
        }
    }
}
