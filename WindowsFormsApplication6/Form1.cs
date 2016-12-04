using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{
    public partial class frmItemFile : Form
    {
        public frmItemFile()
        {
            InitializeComponent();
        }

        private List<Product> products = null;

        private void frmItemFile_Load(object sender, EventArgs e)
        {
            products = ProductDB.GetProducts();
            FillProductListBox();
        }

        private void FillProductListBox()
        {
            lstProducts.Items.Clear();
            foreach (Product p in products)
            {
                lstProducts.Items.Add(p.GetDisplayText("\t"));
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmItemEntry newProductForm = new frmItemEntry();
            Product product = newProductForm.GetNewProduct();

            if (product != null)
            {
                products.Add(product);
                ProductDB.SaveProducts(products);
                FillProductListBox();
            }      
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            int i = lstProducts.SelectedIndex;
            if (i != -1)
            {
                Product product = products[i];
                string message = "Are you sure you want to delete " + product.Description + "?";
                DialogResult button =
                    MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    products.Remove(product);
                    ProductDB.SaveProducts(products);
                    FillProductListBox();
                }

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
