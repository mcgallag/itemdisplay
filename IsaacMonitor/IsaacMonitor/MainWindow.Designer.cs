namespace IsaacMonitor
{
    partial class MainWindow
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
            this.rocksBox = new System.Windows.Forms.TextBox();
            this.tintedBox = new System.Windows.Forms.TextBox();
            this.poopsBox = new System.Windows.Forms.TextBox();
            this.shopKeepersBox = new System.Windows.Forms.TextBox();
            this.devilsBox = new System.Windows.Forms.TextBox();
            this.donationBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.attachButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.detachButton = new System.Windows.Forms.Button();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rocksBox
            // 
            this.rocksBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rocksBox.Location = new System.Drawing.Point(141, 12);
            this.rocksBox.Name = "rocksBox";
            this.rocksBox.ReadOnly = true;
            this.rocksBox.Size = new System.Drawing.Size(100, 20);
            this.rocksBox.TabIndex = 0;
            // 
            // tintedBox
            // 
            this.tintedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tintedBox.Location = new System.Drawing.Point(141, 38);
            this.tintedBox.Name = "tintedBox";
            this.tintedBox.ReadOnly = true;
            this.tintedBox.Size = new System.Drawing.Size(100, 20);
            this.tintedBox.TabIndex = 1;
            // 
            // poopsBox
            // 
            this.poopsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.poopsBox.Location = new System.Drawing.Point(141, 64);
            this.poopsBox.Name = "poopsBox";
            this.poopsBox.ReadOnly = true;
            this.poopsBox.Size = new System.Drawing.Size(100, 20);
            this.poopsBox.TabIndex = 2;
            // 
            // shopKeepersBox
            // 
            this.shopKeepersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopKeepersBox.Location = new System.Drawing.Point(141, 90);
            this.shopKeepersBox.Name = "shopKeepersBox";
            this.shopKeepersBox.ReadOnly = true;
            this.shopKeepersBox.Size = new System.Drawing.Size(100, 20);
            this.shopKeepersBox.TabIndex = 3;
            // 
            // devilsBox
            // 
            this.devilsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devilsBox.Location = new System.Drawing.Point(141, 116);
            this.devilsBox.Name = "devilsBox";
            this.devilsBox.ReadOnly = true;
            this.devilsBox.Size = new System.Drawing.Size(100, 20);
            this.devilsBox.TabIndex = 4;
            // 
            // donationBox
            // 
            this.donationBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donationBox.Location = new System.Drawing.Point(141, 142);
            this.donationBox.Name = "donationBox";
            this.donationBox.ReadOnly = true;
            this.donationBox.Size = new System.Drawing.Size(100, 20);
            this.donationBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Rocks Destroyed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tinted Rocks Destroyed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Poops Destroyed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Shopkeeps Destroyed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Devil Deals Taken";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Total Donations";
            // 
            // attachButton
            // 
            this.attachButton.Location = new System.Drawing.Point(15, 180);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(69, 23);
            this.attachButton.TabIndex = 12;
            this.attachButton.Text = "Attach";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.AttachButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(90, 180);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(69, 23);
            this.searchButton.TabIndex = 13;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // detachButton
            // 
            this.detachButton.Enabled = false;
            this.detachButton.Location = new System.Drawing.Point(165, 180);
            this.detachButton.Name = "detachButton";
            this.detachButton.Size = new System.Drawing.Size(69, 23);
            this.detachButton.TabIndex = 14;
            this.detachButton.Text = "Detach";
            this.detachButton.UseVisualStyleBackColor = true;
            this.detachButton.Click += new System.EventHandler(this.DetachButton_Click);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 215);
            this.Controls.Add(this.detachButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.donationBox);
            this.Controls.Add(this.devilsBox);
            this.Controls.Add(this.shopKeepersBox);
            this.Controls.Add(this.poopsBox);
            this.Controls.Add(this.tintedBox);
            this.Controls.Add(this.rocksBox);
            this.Name = "MainWindow";
            this.Text = "Mike\'s Isaac Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox rocksBox;
        private System.Windows.Forms.TextBox tintedBox;
        private System.Windows.Forms.TextBox poopsBox;
        private System.Windows.Forms.TextBox shopKeepersBox;
        private System.Windows.Forms.TextBox devilsBox;
        private System.Windows.Forms.TextBox donationBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button detachButton;
        private System.Windows.Forms.Timer updateTimer;
    }
}

