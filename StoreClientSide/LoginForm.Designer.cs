
namespace StoreClient
{
    partial class LoginForm
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelHostName = new System.Windows.Forms.Label();
            this.labelAccountNumber = new System.Windows.Forms.Label();
            this.textBoxHostName = new System.Windows.Forms.TextBox();
            this.textBoxAccountNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(251, 93);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(91, 34);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHostName.Location = new System.Drawing.Point(12, 9);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(93, 20);
            this.labelHostName.TabIndex = 1;
            this.labelHostName.Text = "Host Name:";
            this.labelHostName.Click += new System.EventHandler(this.labelHostName_Click);
            // 
            // labelAccountNumber
            // 
            this.labelAccountNumber.AutoSize = true;
            this.labelAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccountNumber.Location = new System.Drawing.Point(12, 52);
            this.labelAccountNumber.Name = "labelAccountNumber";
            this.labelAccountNumber.Size = new System.Drawing.Size(91, 20);
            this.labelAccountNumber.TabIndex = 2;
            this.labelAccountNumber.Text = "Account №:";
            this.labelAccountNumber.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxHostName
            // 
            this.textBoxHostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxHostName.Location = new System.Drawing.Point(111, 6);
            this.textBoxHostName.Name = "textBoxHostName";
            this.textBoxHostName.Size = new System.Drawing.Size(174, 26);
            this.textBoxHostName.TabIndex = 3;
            this.textBoxHostName.Text = "localhost";
            this.textBoxHostName.TextChanged += new System.EventHandler(this.textBoxHostName_TextChanged);
            // 
            // textBoxAccountNumber
            // 
            this.textBoxAccountNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAccountNumber.Location = new System.Drawing.Point(111, 46);
            this.textBoxAccountNumber.Name = "textBoxAccountNumber";
            this.textBoxAccountNumber.Size = new System.Drawing.Size(174, 26);
            this.textBoxAccountNumber.TabIndex = 4;
            this.textBoxAccountNumber.TextChanged += new System.EventHandler(this.textBoxAccountNumber_TextChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 139);
            this.Controls.Add(this.textBoxAccountNumber);
            this.Controls.Add(this.textBoxHostName);
            this.Controls.Add(this.labelAccountNumber);
            this.Controls.Add(this.labelHostName);
            this.Controls.Add(this.buttonConnect);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.textBoxAccountNumber_TextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private readonly StoreDataInterface m_session;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.Label labelAccountNumber;
        private System.Windows.Forms.TextBox textBoxHostName;
        private System.Windows.Forms.TextBox textBoxAccountNumber;
    }
}