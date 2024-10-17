using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            // Listeyi getiren metodu business'tan çağıracak   
            BusinessLogicLayer businessLayer = new BusinessLogicLayer();
            dgvCustomers.DataSource = businessLayer.Customers(); // listeyi getirir
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string customerID = string.Empty;   
            //customerID = dgvCustomers[e.ColumnIndex, e.RowIndex].ToString();
            customerID = dgvCustomers[0, e.RowIndex].Value.ToString();

            MessageBox.Show(customerID);
        }
    }
}
