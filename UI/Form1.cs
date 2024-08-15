using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.AspNetCore.SignalR.Client;
using UI.Properties;

namespace UI
{
    public partial class Form1 : Form
    {
        //private string _url = "http://127.0.0.1:5001/coraxwideHub";
        private string _url = "http://127.0.0.1:5010/myHub";
        private HubConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        public class FAA_AfwSignalRDto
        {
            public List<FAA_AfwGetListDetailDto> AfwGetListDetailDtos { get; set; }
        }

        public class FAA_AfwGetListDetailDto
        {
            public long ProductId { get; set; }

            [Display(Name = "Panel")]
            public string DeviceName { get; set; }
            public int AfwAddress { get; set; }

            [Display(Name = "Çevrim")]
            public int LoopAddress { get; set; }

            [Display(Name = "Uç Birim")]
            public int DeviceAddress { get; set; }

            [Display(Name = "Bölge")]
            public int ZoneAddress { get; set; }

            public int PanelAddress { get; set; }
            public int ReturnType { get; set; }

            [Display(Name = "Tür")]
            public string EventTypeName { get; set; }

            [Display(Name = "Durum")]
            public string EventStatusCodeName { get; set; }

            [Display(Name = "Olay Türü")]
            public string AfwTypeName { get; set; }

            public int EventType { get; set; }
            public int EventStatusCode { get; set; }
            public int AfwType { get; set; }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder()
                .WithUrl(_url)
                .Build();

            connection.On<object>("Mw301_OnlineDeviceStatus", result =>
            {
                listBox1.Items.Add("OnlineDeviceStatus");
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
