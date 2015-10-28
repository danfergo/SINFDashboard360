using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SINFDashboard360.Lib_Primavera.Model;

using Interop.StdBE800;
using SINFDashboard360.Lib_Primavera;
using System.Globalization;

namespace SINFDashboard360.Models
{
    public class Purchases
    {


        public static IEnumerable<DocCompra> queryPurchasesByDate(DateTime min_date, DateTime max_date)
        {

            StdBELista objListCab;
            StdBELista objListLin;
            DocCompra dc = new DocCompra();
            List<DocCompra> listdc = new List<DocCompra>();
            LinhaDocCompra lindc = new LinhaDocCompra();
            List<LinhaDocCompra> listlindc = new List<LinhaDocCompra>();

            //System.Diagnostics.Debug.WriteLine(min_date);

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras " +
                    "where TipoDoc='VGR' AND DataDoc > '" + min_date.ToString("yyyy-MM-dd HH:mm:ss") + "' AND DataDoc < '" + max_date.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                //AND DataDoc > '" + min_date + "' AND DataDoc < '" + max_date + "'
                while (!objListCab.NoFim())
                {
                    dc = new DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }
    }
}