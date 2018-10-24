using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriarCapturaWebCam
{
    public partial class frmVisualizacao : Form
    {
        public string pathCapturadas = @"C:\Testes\SSI\Capturada\";
        public frmVisualizacao()
        {
            InitializeComponent();
        }

        private void frmVisualizacao_Load(object sender, EventArgs e)
        {
            Carregar();
        }
        private void Carregar()
        {
            int i = 0;
            DirectoryInfo dir = new DirectoryInfo(pathCapturadas);
            FileInfo[] files = dir.GetFiles("*.png").OrderByDescending(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                i++;
                lstArquivos.Items.Add(file.Name);
            }
        }

        private void lstArquivos_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (File.Exists(pathCapturadas + lstArquivos.Text))
            {
                pic1.Load(pathCapturadas + lstArquivos.Text);
            }

            treeView1.Nodes.Clear();

            string arquivoj = pathCapturadas + lstArquivos.Text;
            arquivoj = arquivoj.Replace(".png", ".json");
            if (File.Exists(arquivoj))
            {
                string contents = File.ReadAllText(arquivoj);
               
                JsonTreeViewLoader.LoadJsonToTreeView(treeView1, contents);
            }

        }
       
    }
}
