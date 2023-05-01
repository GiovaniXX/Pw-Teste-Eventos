using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Update
{
    public partial class Form1 : Form
    {
        private readonly string _directoryPath;

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
    }
}
