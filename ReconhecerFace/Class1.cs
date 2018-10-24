using System;
using System.IO;    
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using System.Drawing;


namespace ReconhecerFace
{
    public class ReconhecerFace
    {
        const string subscriptionKey = "";
        //const string uriBase = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";
        const string uriBase = "https://southcentralus.api.cognitive.microsoft.com/face/v1.0";


        public string IdentificaFace(string imagem, string localgravacao, string Arquivo)
        {
            MakeAnalysisRequest(imagem, localgravacao,Arquivo);
            return "";
        }
        static async void MakeAnalysisRequest(string imageFilePath, string localgravacao, string Arquivo)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            
            string uri = @"https://southcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
            
            HttpResponseMessage response;
                        
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (ByteArrayContent content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);

                string contentString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("\nResponse:\n");
                Console.WriteLine(JsonPrettyPrint(contentString));
                contentString = contentString.Trim();
                contentString = contentString.Substring(1);
                contentString = contentString.Substring(0, contentString.Length -1);
                contentString = "{" + '"' + "Pessoas" + '"' + ": [" + contentString + "]}";
                File.WriteAllText(imageFilePath.Replace("png","json"), contentString);
                GravaRetangulos(imageFilePath);
            }
        }

        static void GravaRetangulos(string Arq)
        {
            if (!File.Exists(Arq)){ return; }
            if (!File.Exists(Arq.Replace("png", "json"))) { return; }

            string filePath = Arq.Replace("png", "json");
            string json = File.ReadAllText(filePath);

            var expandoConverter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(json, expandoConverter);

            ///string a = obj.Pessoas[0].faceId;
            var NumeroPessoas = obj.Pessoas.Count;

            if (!(NumeroPessoas>0))
            {
                return;
            }

            MemoryStream ms = new MemoryStream();
            using (FileStream fs = new FileStream(Arq, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ms.Write(buffer, 0, buffer.Length);
            }
            //Bitmap bitmap = new Bitmap(ms);


            Bitmap orig = new Bitmap(ms);
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
            dest.Save(Arq);
        }
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
        static string JsonPrettyPrint(string json)
        {
            if (string.IsNullOrEmpty(json))
                return string.Empty;

            json = json.Replace(Environment.NewLine, "").Replace("\t", "");

            StringBuilder sb = new StringBuilder();
            bool quote = false;
            bool ignore = false;
            int offset = 0;
            int indentLength = 3;

            foreach (char ch in json)
            {
                switch (ch)
                {
                    case '"':
                        if (!ignore) quote = !quote;
                        break;
                    case '\'':
                        if (quote) ignore = !ignore;
                        break;
                }

                if (quote)
                    sb.Append(ch);
                else
                {
                    switch (ch)
                    {
                        case '{':
                        case '[':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', ++offset * indentLength));
                            break;
                        case '}':
                        case ']':
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', --offset * indentLength));
                            sb.Append(ch);
                            break;
                        case ',':
                            sb.Append(ch);
                            sb.Append(Environment.NewLine);
                            sb.Append(new string(' ', offset * indentLength));
                            break;
                        case ':':
                            sb.Append(ch);
                            sb.Append(' ');
                            break;
                        default:
                            if (ch != ' ') sb.Append(ch);
                            break;
                    }
                }
            }

            return sb.ToString().Trim();
        }

    }
}
