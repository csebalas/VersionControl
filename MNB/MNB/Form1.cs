﻿using MNB.Entities;
using MNB.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MNB
{
    public partial class Form1 : Form
    {
        public BindingList<RateData> rates = new BindingList<RateData>();
        public Form1()
        {
            InitializeComponent();
            CallWebService();
            dataGridView1.DataSource = rates;
        }

        private void CallWebService()
        {
            var mnbService = new MNBArfolyamServiceSoapClient();
            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = "EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };
            var response = mnbService.GetExchangeRates(request);
            var result = response.GetExchangeRatesResult;
            Console.WriteLine(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
        }
    }
}
