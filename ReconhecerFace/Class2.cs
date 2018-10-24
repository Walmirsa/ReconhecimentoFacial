using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;

namespace ReconhecerFace
{
    public class Class2
    {
        static readonly IFaceServiceClient faceServiceClient =
          new FaceServiceClient("", "https://southcentralus.api.cognitive.microsoft.com/face/v1.0");



        public void TreinaGrupo()
        {
            Treina();
        }
        static async void Treina()
        {

            Guid id = new Guid("4c5d9db2-12c0-40c5-8f85-71948fcad403");

            const string friend1ImageDir = @"C:\Testes\SSI\Capturada\teste\walmir\";

            foreach (string imagePath in Directory.GetFiles(friend1ImageDir, "*.png"))
            {
                using (Stream s = File.OpenRead(imagePath))
                {
                    // Detect faces in the image and add to Anna
                    await faceServiceClient.AddPersonFaceAsync(
                        "myfriends", id, s);
                }
            }

        }




            public void CriaGrupo()
        {
            criandoGrupoAsync();
        }
        static async void criandoGrupoAsync()
        {


            string personGroupId = "myfriends";
            await faceServiceClient.CreatePersonGroupAsync(personGroupId, "My Friends");

            // Define Anna
            CreatePersonResult friend1 = await faceServiceClient.CreatePersonAsync(
                // Id of the PersonGroup that the person belonged to
                personGroupId,
                // Name of the person
                "Walmir"
            );
        }


        public string Recorte(string imagem)
        {
            CriaRecorte(imagem);
            return "";
        }
        static async void CriaRecorte(string img)
        {
            using (Stream s = File.OpenRead(img))
            {
                var faces = await faceServiceClient.DetectAsync(s, true, true);

                foreach (var face in faces)
                {
                    var rect = face.FaceRectangle;
                    var landmarks = face.FaceLandmarks;
                }
            }
        }


    }
}
