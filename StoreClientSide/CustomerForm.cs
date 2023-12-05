using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreClient
{
    public partial class CustomerForm : Form
    {
        public CustomerForm(StoreDataInterface shopper)
        {
            InitializeComponent();
            m_shopper = shopper;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (Connect())
                InitFormInfo();
            else
                Application.Exit();
        }

        private void InitFormInfo()
        {
            timerGetOrders.Start();
            GetOrders();
            GetProducts();
            Text += ": ";
            Text += m_shopper.Username;
            Console.WriteLine(m_shopper.Username);
        }

        private void CustomerForm_FormClosed(object sender, FormClosedEventArgs e) => m_shopper.DisconnectAsync();

        private bool Connect() => new LoginForm(m_shopper).ShowDialog(this) == DialogResult.OK;

        private async void btnPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                await m_shopper.PurchaseAsync(comboBoxProducts.Text.ToString());
                GetOrders();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tmrGetOrders_Tick(object sender, EventArgs e) { }

        private async void GetOrders()
        {
            IList<Order> orders = await m_shopper.GetOrdersAsync();
            listBoxOrders.Items.Clear();
            foreach (Order order in orders)
                listBoxOrders.Items.Add(order.ToString());
        }

        private async void GetProducts()
        {
            IList<Product> products = await m_shopper.GetProductsAsync();
            listBoxOrders.Items.Clear();
            foreach (Product order in products)
                comboBoxProducts.Items.Add(order.Name);
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e) => buttonPurchase.Enabled = !string.IsNullOrEmpty(comboBoxProducts.SelectedItem?.ToString());
    }
}
