using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Update
{
    public partial class Form1 : Form
    {
        private readonly string _directoryPath;
        private Boutique GSHOP;       
        private SortedList item_id_index_map;
        private SortedList itemDescriptions;


        public Form1()
        {
            InitializeComponent();
            // Obtém o diretório do aplicativo
            _directoryPath = Path.GetDirectoryName(Application.StartupPath);
            comboBox_dbSource.Text = _directoryPath;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define as opções do comboBox_dbSource
            comboBox_dbSource.DataSource = new List<string>
            {
                 "item_ext_desc.txt",
                 "pwdatabase.com/pwi",
                 "pwdatabase.com/my",
                 "pwdatabase.com/ms",
                 "pwdatabase.com/ru"
            };

            // Define o valor padrão do comboBox_dbSource
            comboBox_dbSource.SelectedItem = "item_ext_desc.txt";
        }

        private void ComboBox_dbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtém a opção selecionada pelo usuário
            string selectedOption = comboBox_dbSource.SelectedItem.ToString();

            // Define a opção selecionada no comboBox
            comboBox_dbSource.Text = selectedOption;
        }

        private void EditItem(object sender, EventArgs e)
        {
            if (listBox_Items.SelectedIndex > -1)
            {
                int id = int.Parse(listBox_Items.SelectedItem.ToString().Substring(1, listBox_Items.SelectedItem.ToString().IndexOf("]") - 1));
                int current_item_index = (int)item_id_index_map[id];
                int current_sale_index = comboBox_sale_option.SelectedIndex;

                if (sender is Control control)
                {
                    if (control == checkBox_active)
                    {
                        GSHOP.items[current_item_index].activate = checkBox_active.Checked;
                    }
                    else if (control == numericUpDown_itemID)
                    {
                        GSHOP.items[current_item_index].item_id = (int)numericUpDown_itemID.Value;
                    }
                    else if (control == numericUpDown_amount)
                    {
                        GSHOP.items[current_item_index].item_amount = (int)numericUpDown_amount.Value;
                    }
                    else if (control == textBox_name)
                    {
                        GSHOP.items[current_item_index].name = Encoding.Unicode.GetBytes(textBox_name.Text);
                        listBox_Items.Items[listBox_Items.SelectedIndex] = "[" + GSHOP.items[current_item_index].shop_id + "] " + textBox_name.Text;
                    }
                    else if (control == textBox_description)
                    {
                        GSHOP.items[current_item_index].description = Encoding.Unicode.GetBytes(textBox_description.Text);
                    }
                    // Mais verificações para outros campos...
                }
            }
        }


        private void button_autoDetect_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;

            if (comboBox_dbSource.SelectedIndex < 1)
            {
                string description = itemDescriptions[numericUpDown_itemID.Value.ToString()] as string;
                if (!string.IsNullOrEmpty(description))
                {
                    description = description.Replace("\\r", " \\r");
                    textBox_description.Text = description;
                }

                EditItem(textBox_description, null);
            }
            else
            {
                try
                {
                    int index;
                    int length;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www." + comboBox_dbSource.SelectedItem.ToString() + "/items/" + numericUpDown_itemID.Value.ToString());
                    request.Proxy = null;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader wr = new StreamReader(response.GetResponseStream());
                    string content = wr.ReadToEnd();
                    wr.Close();

                    // Find Item Name
                    index = content.IndexOf("<th class=\"itemHeader\"") + 35;
                    if (index > 34)
                    {
                        length = content.IndexOf("<a href", index) - index;
                        string name = content.Substring(index, length);
                        // Remove span + color
                        if (name.Contains("<"))
                        {
                            name = name.Substring(name.IndexOf(">") + 1);
                            name = name.Substring(0, name.IndexOf("</"));
                        }
                        name = name.Replace("&#9734;", "★");
                        textBox_name.Text = name;
                        EditItem(textBox_name, null);
                    }

                    // Find if Item Contains Shop Info
                    index = content.IndexOf("<a href=\"shopitem/", index) + 18;

                    if (index > 18)
                    {
                        length = content.IndexOf("\">", index) - index;
                        string shop_id = content.Substring(index, length);

                        // Load Shop Description
                        request = (HttpWebRequest)WebRequest.Create("http://www." + comboBox_dbSource.SelectedItem.ToString() + "/shopitem/" + shop_id);
                        request.Proxy = null;
                        response = (HttpWebResponse)request.GetResponse();
                        wr = new StreamReader(response.GetResponseStream());
                        content = wr.ReadToEnd();
                        wr.Close();

                        index = content.IndexOf("<h3>Description</h3><p>") + 23;
                        if (index > 22)
                        {
                            length = content.IndexOf("</p>", index) - index;
                            string description = content.Substring(index, length);

                            description = description.Replace("<span style='color:", "");
                            description = description.Replace("#", "^");
                            description = description.Replace(";", "");
                            description = description.Replace("'>", "");
                            description = description.Replace("<br />", "\\r");
                            description = description.Replace("<br/>", "\\r");
                            description = description.Replace("<br>", "\\r");
                            description = description.Replace("</span>", "");
                            description = description.Replace("\\r", " \\r");

                            textBox_description.Text = description;
                        }
                    }

                    EditItem(textBox_description, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Failed!");
                }
            }

            Cursor = Cursors.Default;
        }
    }

    public class Item
    {
        internal bool activate;
        internal int item_id;
        internal int item_amount;
        internal byte[] name;
        internal byte[] description;
        internal string shop_id;

        public int LocalId { get; set; }
        public int MainType { get; set; }
        public int SubType { get; set; }
        public int Id { get; set; }
        public int Num { get; set; }
        public SaleOption[] Buy { get; set; }
        public int IdGift { get; set; }
        public int GiftNum { get; set; }
        public int GiftTime { get; set; }
        public int LogPrice { get; set; }
    }

    public class SaleOption
    {
        public int Price { get; set; }
        public int EndTime { get; set; }
        public int Time { get; set; }
        public int StartTime { get; set; }
        public int Type { get; set; }
        public int Day { get; set; }
        public int Status { get; set; }
        public int Flag { get; set; }
    }

    public class Category
    {
        public byte[] Name { get; set; } // 128 bytes in Unicode
        public int SubCategoriesCount { get; set; }
        public byte[][] SubCategories { get; set; } // Array [max 8] of 128 Byte Unicode

        public Category()
        {
            SubCategories = new byte[8][];
        }
    }

    public class Boutique
    {
        public int Timestamp { get; set; }
        public int ItemCount { get; set; }
        public Item[] items { get; set; }
        public Category[] Categories { get; set; }

        public Boutique()
        {
            items = new Item[0];
            Categories = new Category[0];
        }
    }
}
