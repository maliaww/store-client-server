
namespace StoreClient
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxOrders = new System.Windows.Forms.ListBox();
            this.buttonPurchase = new System.Windows.Forms.Button();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.timerGetOrders = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBoxOrders
            // 
            this.listBoxOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxOrders.FormattingEnabled = true;
            this.listBoxOrders.ItemHeight = 20;
            this.listBoxOrders.Location = new System.Drawing.Point(12, 12);
            this.listBoxOrders.Name = "listBoxOrders";
            this.listBoxOrders.Size = new System.Drawing.Size(271, 264);
            this.listBoxOrders.TabIndex = 0;
            this.listBoxOrders.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            // 
            // buttonPurchase
            // 
            this.buttonPurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPurchase.Location = new System.Drawing.Point(382, 243);
            this.buttonPurchase.Name = "buttonPurchase";
            this.buttonPurchase.Size = new System.Drawing.Size(91, 28);
            this.buttonPurchase.TabIndex = 1;
            this.buttonPurchase.Text = "Purchase";
            this.buttonPurchase.UseVisualStyleBackColor = true;
            this.buttonPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(289, 12);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(184, 28);
            this.comboBoxProducts.TabIndex = 2;
            // 
            // timerGetOrders
            // 
            this.timerGetOrders.Tick += new System.EventHandler(this.tmrGetOrders_Tick);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 283);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.buttonPurchase);
            this.Controls.Add(this.listBoxOrders);
            this.Name = "CustomerForm";
            this.Text = "StoreClient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerForm_FormClosed);
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private readonly StoreDataInterface m_shopper;
        private System.Windows.Forms.ListBox listBoxOrders;
        private System.Windows.Forms.Button buttonPurchase;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Timer timerGetOrders;
    }
}