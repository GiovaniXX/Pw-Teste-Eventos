using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Pw_pictureBox
{
    public partial class Form1 : Form
    {
        private string directoryPath = "E:\\Projetos Dev Giovani\\PROJETOS VISUAL STUDIO 2022\\C#\\Pw_pictureBox\\Pw_pictureBox\\bin\\Debug\\surfaces\\百宝阁";

        public Form1()
        {
            InitializeComponent();
            LoadComboBoxItems();
            CriarLinha();
        }

        private void LoadComboBoxItems()
        {
            // Adiciona os arquivos do diretório no ComboBox
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                comboBox_surface.Items.Add(Path.GetFileNameWithoutExtension(file));
            }
        }

        private void Load_Surface(object sender, EventArgs e)
        {
            // Verifica se foi selecionado algum item no ComboBox
            if (comboBox_surface.SelectedIndex != -1)
            {
                // Obtém o caminho completo do arquivo de imagem
                string imagePath = Path.Combine(directoryPath, comboBox_surface.SelectedItem.ToString() + ".jpg");

                // Verifica se o arquivo de imagem existe
                if (File.Exists(imagePath))
                {
                    // Carrega a imagem no PictureBox
                    Image image = Image.FromFile(imagePath);
                    pictureBox_surface.Image = image;
                }
                else
                {
                    MessageBox.Show("O arquivo de imagem selecionado não existe.");
                }
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Define a URL que você deseja abrir
            string url = "https://www.pwdatabase.com/";

            // Cria um objeto ProcessStartInfo para configurar o navegador a ser usado
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "msedge.exe";
            psi.Arguments = url;

            // Abre a URL em um navegador da web padrão (Microsoft Edge)
            Process browserProcess = new Process();
            browserProcess.StartInfo = psi;

            if (!browserProcess.Start())
            {
                // Se não foi possível abrir o navegador, exiba uma mensagem de erro
                MessageBox.Show("Não foi possível abrir o navegador. Verifique se o Microsoft Edge está instalado em seu computador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarLinha()
        {
            Label linha = new Label();
            linha.AutoSize = false;
            linha.Width = groupBox1.Width - 10;
            linha.Height = 1;
            linha.BorderStyle = BorderStyle.Fixed3D;
            linha.Text = new string('_', linha.Width);
            linha.Location = new Point(5, 415);
            groupBox1.Controls.Add(linha);

            Label linha2 = new Label();
            linha2.AutoSize = false;
            linha2.Width = groupBox1.Width - 10;
            linha2.Height = 1;
            linha2.BorderStyle = BorderStyle.Fixed3D;
            linha2.Text = new string('_', linha2.Width);
            linha2.Location = new Point(6, 350);
            groupBox1.Controls.Add(linha2);
        }       
    }
}
