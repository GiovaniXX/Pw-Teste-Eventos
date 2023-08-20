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
        private SortedList itemDescriptions;
        private string directoryPath = "E:\\Projetos Dev Giovani\\PROJETOS VISUAL STUDIO 2022\\C#\\Pw_pictureBox\\Update\\item_ext_desc.txt";

        public Form1()
        {
            InitializeComponent();
            LoadComboBoxItems();
        }

        private void LoadComboBoxItems()
        {
            // Adiciona os arquivos do diretório no ComboBox           
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                comboBox_dbSource.Items.Add(Path.GetFileNameWithoutExtension(file));
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
                    using (StreamReader wr = new StreamReader(response.GetResponseStream()))
                    {
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
                            using (StreamReader shopWr = new StreamReader(response.GetResponseStream()))
                            {
                                content = shopWr.ReadToEnd();
                                shopWr.Close();

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
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Connection Failed!");
                }
            }
        }
    }
}
