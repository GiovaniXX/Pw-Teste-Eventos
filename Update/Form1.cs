using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Update
{
    public partial class Form1 : Form
    {
        private string directoryPath = Path.GetDirectoryName(Application.StartupPath);

        public Form1()
        {
            InitializeComponent();
            comboBox_dbSource.Text = "item_ext_desc.txt";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Crie uma lista de opções para o comboBox_dbSource
            List<string> dbSourceOptions = new List<string>();
            dbSourceOptions.Add("item_ext_desc.txt");
            dbSourceOptions.Add("pwdatabase.com/pwi");
            dbSourceOptions.Add("pwdatabase.com/my");
            dbSourceOptions.Add("pwdatabase.com/ms");
            dbSourceOptions.Add("pwdatabase.com/ru");

            // Defina as opções do comboBox_dbSource com a lista criada acima
            comboBox_dbSource.DataSource = dbSourceOptions;
        }
    }
}
