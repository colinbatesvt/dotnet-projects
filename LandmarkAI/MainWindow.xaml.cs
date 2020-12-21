using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LandmarkAI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png; *.jpg)|*.png; *.jpg; *.jpeg|All files (*.*)|*.*";
            dialog.InitialDirectory = "C:\\Users\\Colin\\Desktop\\Code\\.net";
            if(dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

                MakePredictionAsync(fileName);
            }
        }

        //custom vision refuses our request, so can't do anything with this at the moment. Not gonna take the time to really debug it.
        private async void MakePredictionAsync(string fileName)
        {
            string url = "https://eastus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/66169007-0577-47e1-898f-fb07b3398e81/classify/iterations/LandmarkAI/image";
            string prediction_key = "9edc6b0580ae40f69a18cb591d7c0c6f";
            string content_type = "application/octet-stream";

            byte[] file = File.ReadAllBytes(fileName);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Predicion-Key", prediction_key);
                using(var content = new ByteArrayContent(file))
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(content_type);
                    var response = await client.PostAsync(url, content);

                    var responseString = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
