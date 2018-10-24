using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.IO.Ports;

namespace CriarCapturaWebCam
{
    public partial class frmRobo : Form
    {
        public frmRobo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //File.WriteAllText(@"C:\Testes\SSI\Capturada\img_20180421204408.png.txt", "aaa");
            ReconhecerFace.ReconhecerFace a = new ReconhecerFace.ReconhecerFace();
            a.IdentificaFace(@"C:\Testes\SSI\Capturada\img_20180421204408.png",
                @"C:\Testes\SSI\Identificados\", "img_20180421204408.png");
        }

        private void frmRobo_Load(object sender, EventArgs e)
        {

        }
            
        private void button2_Click(object sender, EventArgs e)
        {
            
            string filePath = @"C:\Testes\SSI\Capturada\teste\img_20180426192513.json";
            string json = File.ReadAllText(filePath);

            var expandoConverter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(json, expandoConverter);

            string a = obj.Pessoas[0].faceId;
            var NumeroPessoas = obj.Pessoas.Count;
  
            Bitmap orig = new Bitmap(@"C:\Testes\SSI\Capturada\teste\img_20180426192513.png");
            int dim = Math.Max(orig.Width, orig.Height);
            Bitmap dest;
            using (Graphics origG = Graphics.FromImage(orig))
            {
                dest = new Bitmap(dim, 720, origG);
            }
            using (Graphics g = Graphics.FromImage(dest))
            {
                Pen white = new Pen(Color.White, 1);
                g.DrawImage(orig, 0, 0, 1200, 720);

                for (int i = 0; i < NumeroPessoas; i++)
                {
                    var itop = obj.Pessoas[i].faceRectangle.top;
                    var ileft = obj.Pessoas[i].faceRectangle.left;
                    var iwidth = obj.Pessoas[i].faceRectangle.width;
                    var iheight = obj.Pessoas[i].faceRectangle.height;

                    Rectangle r = new Rectangle(Convert.ToInt32(ileft), Convert.ToInt32(itop), Convert.ToInt32(iheight), Convert.ToInt32(iwidth));
                    Pen p = new Pen(Brushes.Red, 3);

                    g.DrawRectangle(p, r);
                    g.DrawString(i.ToString(), new Font("Tahoma", 20), Brushes.GreenYellow, r);


                }

            }
            dest.Save(@"C:\Testes\SSI\Capturada\teste\img_20180426192523_2.png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //    FaceServiceClient faceServiceClient = new FaceServiceClient("<Subscription Key>");
        //    faceServiceClient.
        //    MakeRequest();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReconhecerFace.Class2 a = new ReconhecerFace.Class2();
            a.Recorte(@"C:\Testes\SSI\Capturada\teste\1.png");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ReconhecerFace.Class2 a = new ReconhecerFace.Class2();
            a.TreinaGrupo();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReconhecerFace.Class2 a = new ReconhecerFace.Class2();
            a.CriaGrupo();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = "COM3";
                    serialPort1.BaudRate = 9600;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.DataBits = 8;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.RtsEnable = true;

                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);



                    serialPort1.Open();

                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Write("A");
                    }

                }
                catch
                {
                    return;

                }
               
            }
            else
            {

                try
                {
                    serialPort1.Close();
                    //comboBox1.Enabled = true;
                    //btConectar.Text = "Conectar";
                }
                catch
                {
                    return;
                }

            }

        }
        delegate void SetTextCallback(string texto);
        private void DefinirTexto(string texto)
        {
         
        }
        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();

            SetTextCallback d = new SetTextCallback(DefinirTexto);
            this.Invoke(d, new object[] { indata });
            
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
        //static async void MakeRequest()
        //{
        //    var client = new HttpClient();
        //    var queryString = HttpUtility.ParseQueryString(string.Empty);

        //    // Request headers
        //    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

        //    var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify?" + queryString;

        //    HttpResponseMessage response;

        //    // Request body
        //    byte[] byteData = Encoding.UTF8.GetBytes("{body}");

        //    using (var content = new ByteArrayContent(byteData))
        //    {
        //        content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >");
        //        response = await client.PostAsync(uri, content);
        //    }
        //}
    }
}
