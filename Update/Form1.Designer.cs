namespace Update
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_dbSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_autoDetect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_amount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_itemID = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_sale_option = new System.Windows.Forms.ComboBox();
            this.checkBox_active = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.listBox_Items = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemID)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_active);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.comboBox_sale_option);
            this.groupBox1.Controls.Add(this.numericUpDown_amount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDown_itemID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button_autoDetect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_description);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_dbSource);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(363, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 565);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ITEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 545);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "2023™ 01000111 01101001 01101111 01110110 01100001 01101110 01101001";
            // 
            // comboBox_dbSource
            // 
            this.comboBox_dbSource.FormattingEnabled = true;
            this.comboBox_dbSource.Location = new System.Drawing.Point(81, 67);
            this.comboBox_dbSource.Name = "comboBox_dbSource";
            this.comboBox_dbSource.Size = new System.Drawing.Size(133, 21);
            this.comboBox_dbSource.TabIndex = 1;
            this.comboBox_dbSource.SelectedIndexChanged += new System.EventHandler(this.ComboBox_dbSource_SelectedIndexChanged);
            this.comboBox_dbSource.TextChanged += new System.EventHandler(this.Form1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update.:";
            // 
            // button_autoDetect
            // 
            this.button_autoDetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_autoDetect.Location = new System.Drawing.Point(220, 67);
            this.button_autoDetect.Name = "button_autoDetect";
            this.button_autoDetect.Size = new System.Drawing.Size(65, 21);
            this.button_autoDetect.TabIndex = 11;
            this.button_autoDetect.Text = "Detect";
            this.button_autoDetect.UseVisualStyleBackColor = true;
            this.button_autoDetect.Click += new System.EventHandler(this.button_autoDetect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Description:";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(81, 120);
            this.textBox_description.MaxLength = 512;
            this.textBox_description.Multiline = true;
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_description.Size = new System.Drawing.Size(204, 52);
            this.textBox_description.TabIndex = 13;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(81, 94);
            this.textBox_name.MaxLength = 32;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(204, 20);
            this.textBox_name.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Name:";
            // 
            // numericUpDown_amount
            // 
            this.numericUpDown_amount.Location = new System.Drawing.Point(220, 42);
            this.numericUpDown_amount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_amount.Name = "numericUpDown_amount";
            this.numericUpDown_amount.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown_amount.TabIndex = 19;
            this.numericUpDown_amount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(168, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Amount:";
            // 
            // numericUpDown_itemID
            // 
            this.numericUpDown_itemID.Location = new System.Drawing.Point(81, 42);
            this.numericUpDown_itemID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_itemID.Name = "numericUpDown_itemID";
            this.numericUpDown_itemID.Size = new System.Drawing.Size(65, 20);
            this.numericUpDown_itemID.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Item ID:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Sale Option:";
            // 
            // comboBox_sale_option
            // 
            this.comboBox_sale_option.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sale_option.FormattingEnabled = true;
            this.comboBox_sale_option.Items.AddRange(new object[] {
            "Default",
            "Option 1",
            "Option 2",
            "Option 3"});
            this.comboBox_sale_option.Location = new System.Drawing.Point(81, 213);
            this.comboBox_sale_option.Name = "comboBox_sale_option";
            this.comboBox_sale_option.Size = new System.Drawing.Size(65, 21);
            this.comboBox_sale_option.TabIndex = 33;
            // 
            // checkBox_active
            // 
            this.checkBox_active.AutoSize = true;
            this.checkBox_active.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_active.ForeColor = System.Drawing.Color.Red;
            this.checkBox_active.Location = new System.Drawing.Point(9, 19);
            this.checkBox_active.Name = "checkBox_active";
            this.checkBox_active.Size = new System.Drawing.Size(156, 17);
            this.checkBox_active.TabIndex = 39;
            this.checkBox_active.Text = "Activate Item in Server";
            this.checkBox_active.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.listBox_Items);
            this.groupBox3.Location = new System.Drawing.Point(2, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(355, 539);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "GENERAL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(157, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 6;
            this.label18.Text = "Items:";
            // 
            // listBox_Items
            // 
            this.listBox_Items.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_Items.FormattingEnabled = true;
            this.listBox_Items.Location = new System.Drawing.Point(160, 61);
            this.listBox_Items.Name = "listBox_Items";
            this.listBox_Items.Size = new System.Drawing.Size(189, 472);
            this.listBox_Items.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 594);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 625);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_itemID)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_dbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_autoDetect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_amount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_itemID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_sale_option;
        private System.Windows.Forms.CheckBox checkBox_active;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox listBox_Items;
    }
}

