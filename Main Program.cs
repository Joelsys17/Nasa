using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace NasaProjekt
{
    public partial class MainProgram : Form
    {
        public MainProgram()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            webBrowser4.Navigate("https://www.nasa.gov/calendar/");
            webBrowser4.ScriptErrorsSuppressed = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)

        {

            webBrowser1.Navigate("https://www.youtube.com/embed/qzMQza8xZCc?autoplay=1");
            webBrowser2.Navigate("https://www.youtube.com/embed/UdmHHpAsMVw?autoplay=1");
        }

       
        
        private void APODButton(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel7.Visible = false;
            panel4.Visible = true;         
            panel4.Refresh();

            }

        private void CalendarButton(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = false;
            panel7.Visible = false;
            panel2.Visible = true;
            panel2.Location =  new Point (151, 11);

        }

    


        private void StreamButton2(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel7.Visible = true;
            panel7.Location = new Point(151, 11);
        }

        private void ForumButton(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = false;
            panel7.Visible = false;
            panel3.Visible = true;
            panel3.Location = new Point(151, 11);

           
        }

        public void Apod()
        {
            var url = "https://api.nasa.gov/planetary/apod?api_key=OVsPMKMSQrgvBJ0Q14jiTx0jvMkmaRgJD1CbCVRL";
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var Data = response.Content.ReadAsStringAsync().Result;
            var parsedData = JsonConvert.DeserializeObject<Nasa>(Data);

            if (parsedData.media_type.Equals("image"))
            {
                pictureBox1.ImageLocation = parsedData.url.ToString();
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                richTextBox1.Text = parsedData.explanation.ToString();
        }
        }

        public class Nasa
        {
            public string copyright { get; set; }
            public string date { get; set; }
            public string explanation { get; set; }
            public string hdurl { get; set; }
            public string media_type { get; set; }
            public string service_version { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }

        private void MinimizeWindow(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            Environment.Exit(1);
            Close();
        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser3.Navigate("localhost");
        }

        private void webBrowser4_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
        }

        private void webBrowser5_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadButton(object sender, EventArgs e)
        {
            Apod();
        }
        public void CreateImage(Nasa parseddata)
        {
            pictureBox1.ImageLocation = parseddata.ToString();
        }
    }
}
