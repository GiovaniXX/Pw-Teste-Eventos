using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Pw_pictureBox
{
    public partial class Form1 : Form
    {
        private string directoryPath = @"E:\PROJETOS DEV-GIOVANI\PROJETOS VISUAL STUDIO 2022\C#\Pw_pictureBox\Pw_pictureBox\bin\Debug\surfaces\百宝阁\";

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
    }
}
