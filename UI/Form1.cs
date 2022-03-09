using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace UI
{
    public partial class Form1 : Form
    {
        private string _url = "http://localhost:27949/myHub";
        private HubConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, System.EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(_url)
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            connection.On<string>("ReceiveMessage", (data) =>
            {
                this.Invoke((Action)delegate
                {
                    listBox1.Items.Add(data);
                });
            });
            try
            {
                await connection.StartAsync();
                listBox1.Items.Add("Connection started");
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
        }
    }
}
