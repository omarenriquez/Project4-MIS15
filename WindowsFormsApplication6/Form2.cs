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
    public partial class frmItemEntry : Form
    {
        public frmItemEntry()
        {
            InitializeComponent();
        }

        private Product product = null;

        public Product GetNewProduct()
        {
            this.ShowDialog();
            return product;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if(rdoFresh.Checked || rdoPackaged.Checked)
                    product = new Product(txtItemNumber.Text,
                    txtDescription.Text, txtManufacturer.Text,
                    Convert.ToDecimal(txtPrice.Text));

                this.Close();
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtItemNumber) &&
                    Validator.IsPresent(txtDescription) &&
                    Validator.IsPresent(txtManufacturer) &&
                    Validator.IsPresent(txtPrice) &&
                    Validator.IsDecimal(txtPrice);
                          
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
