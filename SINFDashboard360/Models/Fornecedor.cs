﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Fornecedor
    {
        public string fornecedor_id;
        public string name;
        public string currency;
        public string tax_number;
        public string address;
        public string language;
        public string phone;
        public double valorEncomendas;
        public double porPagar;
    }
}