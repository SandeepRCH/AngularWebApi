using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void GetStudentsbyId_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                Thread.Sleep(5000);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:53864/api/values/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetStudentbyId/14003114");
                string str = await response.Content.ReadAsStringAsync();
                Action myDel = () => label1.Text = str;
                label1.Invoke(myDel);
            });
        }
        private async void GetStudents_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                Thread.Sleep(1000);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:53864/api/values/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetStudents");
                string str = await response.Content.ReadAsStringAsync();
                Action myDel = () => label2.Text = str;
                label2.Invoke(myDel);
            });
        }
        private async void GetGroupsbyId_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                Thread.Sleep(1000);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:53864/api/values/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetGroupbyId/14003114");
                string str = await response.Content.ReadAsStringAsync();
                Action myDel = () => label3.Text = str;
                label3.Invoke(myDel);
            });
        }
        private async void GetGroups_Click(object sender, EventArgs e)
        {
            await Task.Run(async () =>
            {
                Thread.Sleep(5000);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:53864/api/values/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetGroups");
                string str = await response.Content.ReadAsStringAsync();
                Action myDel = () => label4.Text = str;
                label4.Invoke(myDel);
            });
        }
        private void Result1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Action myDel;
                for (int i = 0; i < 1000; i++)
                {
                    Thread.Sleep(100);
                    label5.Invoke(myDel = () => label5.Text = i.ToString());
                }
            });
        }
    }
}