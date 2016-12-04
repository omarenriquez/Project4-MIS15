using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;


namespace WindowsFormsApplication6
{
    public class ProductDB
    {
        private const string dir = @"C:\C# 2012\Files\";
        private const string path = dir + "Products.txt";

        public static List<Product> GetProducts()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            StreamReader textIn =
                new StreamReader(
                new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            List<Product> products = new List<Product>();
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                Product product = new Product();
                product.Code = columns[0];
                product.Price = Convert.ToDecimal(columns[1]);
                product.Description = columns[2];
                product.Manufacturer = columns[3];
                products.Add(product);
            }
            textIn.Close();

            return products;
        }

        public static void SaveProducts(List<Product> products)
        {
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (Product product in products)
            {
                textOut.Write(product.Code + "|");
                textOut.Write(product.Price + "|");
                textOut.Write(product.Description + "|");
                
                textOut.WriteLine(product.Manufacturer);
            }
            textOut.Close();
        }
    }
}
