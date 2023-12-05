using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace StoreClient
{
    public partial class LoginForm : Form
    {
        public LoginForm(StoreDataInterface session)
        {
            InitializeComponent();
            m_session = session;
        }

        private void labelHostName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private async void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                buttonConnect.Enabled = textBoxHostName.Enabled = false;
                if (!m_session.IsDisconnected && textBoxHostName.Text != m_session.Host)
                    await m_session.DisconnectAsync();
                if (m_session.IsDisconnected)
                {
                    m_session.Host = textBoxHostName.Text;
                    m_session.AccountNumber = int.Parse(textBoxAccountNumber.Text);
                    await m_session.StartAsync();
                }
                buttonConnect.Enabled = textBoxHostName.Enabled = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.Cancel;
                Close();
            }

        }

        private void textBoxHostName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxHostName.Text))
            {
                buttonConnect.Enabled = false;
            }
            else
            {
                buttonConnect.Enabled = true;
            }
        }

        private void textBoxAccountNumber_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountNumber.Text))
            {
                buttonConnect.Enabled = false;
            }
            else
            {
                buttonConnect.Enabled = true;
            }
        }
    }
}
