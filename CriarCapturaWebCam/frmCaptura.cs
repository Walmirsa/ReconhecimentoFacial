using AForge.Video.DirectShow;
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
  

    public partial class frmCaptura : Form
    {
        private VideoCaptureDevice videoSource;
        public string pathCapturadas = @"C:\Testes\SSI\Capturada\";
        public frmCaptura()
        {
            InitializeComponent();
            var videoSources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoSources != null && videoSources.Count > 0)
            {
                videoSource = new VideoCaptureDevice(videoSources[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
            }
        }
        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (pbWebcam.Image != null)
                pbWebcam.Image.Dispose();
            pbWebcam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btLigarDesligar_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                pbWebcam.Image = null;
            }
            else
            {
                videoSource.Start();
            }
        }

        private void btCapturar_Click(object sender, EventArgs e)
        {
            if (pbWebcam.Image != null)
            {
                try
                {
                    videoSource.NewFrame -= VideoSource_NewFrame;

                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.DefaultExt = "png";
                        dialog.AddExtension = true;

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            pbWebcam.Image.Save(dialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
                finally
                {
                    videoSource.NewFrame += VideoSource_NewFrame;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (videoSource.IsRunning)
            //{
            //    videoSource.Stop();
            //}
            //base.OnFormClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Atlfotos()
        {   
            int i = 0;
            string Arq;
            DirectoryInfo dir = new DirectoryInfo(pathCapturadas);
            FileInfo[] files = dir.GetFiles("*.png").OrderByDescending(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                //i++;
                //Arq = pathCapturadas + file.Name;
                //if (i == 1) {
                //    MemoryStream ms = new MemoryStream();
                //    using (FileStream fs = new FileStream(Arq, FileMode.Open))
                //    {
                //        byte[] buffer = new byte[fs.Length];
                //        fs.Read(buffer, 0, buffer.Length);
                //        ms.Write(buffer, 0, buffer.Length);
                //    }
                //    Bitmap bitmap = new Bitmap(ms);

                //    pic1.Image = bitmap;
                //}
                ////if (i == 2) { pic2.Load(pathCapturadas + file.Name); }
                ////if (i == 3) { pic3.Load(pathCapturadas + file.Name); }
                ////if (i == 4) { pic4.Load(pathCapturadas + file.Name); }
                ////if (i > 4) { break; }

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                pbWebcam.Image = null;
            }
            else
            {
                videoSource.Start();
            }

            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbWebcam.Image != null)
            {
                try
                {
                    videoSource.NewFrame -= VideoSource_NewFrame;
                   

                    string arquivo = "img_"+DateTime.Now.ToString("yyyyMMddHHmmss")+".png";
                    pbWebcam.Image.Save(pathCapturadas + arquivo, System.Drawing.Imaging.ImageFormat.Png);

                    ReconhecerFace.ReconhecerFace a = new ReconhecerFace.ReconhecerFace();
                    a.IdentificaFace(pathCapturadas + arquivo, "", arquivo);


                    //Atlfotos();
                }
                finally
                {
                    videoSource.NewFrame += VideoSource_NewFrame;
                }
            }
        }
    }
}
