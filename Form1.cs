using System;
using System.Net;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GetWebPage
{
    public partial class Form1 : Form
    {              
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            { 
                try
                {
                    // WebRequest — базовый класс abstract модели "запрос-ответ" платформы .NET Framework для доступа к данным из Интернета.
                    // Выполняет запрос к универсальному коду ресурса (URI). 
                    // HttpWebRequest предоставляет ориентированную на HTTP-протокол реализацию класса WebRequest.
                    string query = "https://learn.microsoft.com/ru-ru/dotnet/api/system.net.httprequestheader?view=netframework-4.8";

                    // Create инициализирует новый экземпляр HttpWebRequest для заданной схемы URI.
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(query /* URI, определяющий интернет-ресурс */);

                    // GetResponse возвращает ответ от интернет-ресурса.
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    // GetResponseStream возвращает поток, используемый для чтения основного текста ответа с сервера
                    StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                    // считываем данные из потока в строку
                    string data = sr.ReadToEnd();

                    // сохраняем полученные данные в файл
                    StreamWriter sw = new StreamWriter("../../MicrosoftLearn.html", false);
                    sw.WriteLine(data);
                    MessageBox.Show("Файл успешно загружен с сервера: " + response.Server);
                    sw.Close();
                    response.Close();
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    // WebClient предоставляет общие методы обмена данными с ресурсом, заданным URI
                    //обертка для более старого HttpWebRequest.
                    WebClient client = new WebClient();

                    //  DownloadData загружает данные с указанным URI в байтовый массив.
                    byte[] urlData = client.DownloadData("https://learn.microsoft.com/ru-ru/azure/rtos/netx-duo/netx-duo-web-http/chapter1");

                    // преобразуем данные в строку
                    string data = Encoding.UTF8.GetString(urlData);

                    // сохраняем полученные данные в файл
                    StreamWriter sw = new StreamWriter("../../HTTP.html", false);
                    sw.WriteLine(data);
                    sw.Close();
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
            
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    string siteURL = "https://download.microsoft.com/download/B/A/5/BA57BADE-D558-4693-8F82-29E64E4084AB/HDI-ITPro-MSDN-winvideo-CodeFirstNewDatabase.wmv";
                    string fileName = "../../GoToDefinition1.wmv";
                    WebClient client = new WebClient();

                    // Загружаем Web-ресурс и сохраняем его на диске
                    client.DownloadFile(siteURL, fileName);
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });    
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    string siteURL = "https://dou.ua/";
                    WebClient client = new WebClient();

                    // Копируем Web-ресурс из RemoteURL
                    Stream stmData = client.OpenRead(siteURL);
                    StreamReader srData = new StreamReader(stmData, Encoding.UTF8);
                    FileInfo fiData = new FileInfo("../../dou.html");
                    StreamWriter st = fiData.CreateText(); // создаем новый файл
                    st.WriteLine(srData.ReadToEnd()); // записываем в него строку
                    st.Close();
                    stmData.Close();
                    MessageBox.Show("Файл успешно загружен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });      
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    // URI, определяющий интернет-ресурс 
                    // URI (англ. Uniform Resource Identifier) — единообразный идентификатор ресурса
                    string h = "https://avatars.mds.yandex.net/i?id=780d2c468744cd49c6a4d10557b6d37370ec2126-10451794-images-thumbs&n=13";

                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(h /* URI, определяющий интернет-ресурс */);

                    // Получим ответ на интернет-запрос
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    // Возвращаем поток данных из полученного интернет-ресурса.
                    Stream stream = response.GetResponseStream();

                    MemoryStream ms = new MemoryStream();
                    stream.CopyTo(ms);
                    byte[] b = ms.ToArray();


                    


                    // сохраняем полученные данные в файл
                    FileStream st = new FileStream("../../Img.jpg", FileMode.OpenOrCreate);
                    BinaryWriter writer = new BinaryWriter(st);
                    writer.Write(b);
                    writer.Close();
                    MessageBox.Show("Файл успешно загружен с сервера: " + response.Server);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });          
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                try
                {
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://ftp.logitech.com");

                    // ListDirectoryDetails представляет метод протокола FTP LIST, 
                    // который возвращает подробный список файлов на FTP-сервере.
                    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                    // Получим ответ на ftp-запрос
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                    // Возвращаем поток данных из полученного интернет-ресурса
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string res = reader.ReadToEnd();
                    // сохраняем полученные данные в файл
                    StreamWriter sw = new StreamWriter("../../list.txt", false);

                    sw.WriteLine(res);
                    sw.Close();
                    MessageBox.Show("Список директорий сохранен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });         
        }

        
    }
}