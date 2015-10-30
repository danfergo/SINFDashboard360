using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Lib_Primavera.Model
{
    public class Factura
    {
        public string tipoEntidade
        {
            get;
            set;
        }

        public string entidade
        {
            get;
            set;
        }

        public string tipoDocumento
        {
            get;
            set;
        }

        public string numDocumento
        {
            get;
            set;
        }

        public DateTime dataDocumento
        {
            get;
            set;
        }

        public DateTime dataVencimento
        {
            get;
            set;
        }

        public string dataLiquidacao
        {
            get;
            set;
        }

        public double valorTotal
        {
            get;
            set;
        }

        public double valorDesconto
        {
            set;
            get;
        }

        public string modoPagamento
        {
            get;
            set;
        }

        public string condPagamento
        {
            set;
            get;
        }

        public string moeda
        {
            set;
            get;
        }

        public double totalIva
        {
            get;
            set;
        }

    }
}