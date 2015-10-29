using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;
using SINFDashboard360.Lib_Primavera.Model;
using SINFDashboard360.Lib_Primavera;

namespace SINFDashboard360.Controllers
{
    public class SalesController : ApiController
    {
        //// GET api/sales
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        public IEnumerable<DocVenda> Get(string min_date, string max_date)
        {
            return ListaFiltradaPorDatas(min_date, max_date);
        }

        // GET api/sales/5
        public DocVenda Get(int id)
        {
            string numdoc = id.ToString();
            return Lib_Primavera.PriIntegration.Encomenda_Get(numdoc);
        }

        private IEnumerable<DocVenda> ListaFiltradaPorDatas(string min_date, string max_date)
        {

            DateTime min = DateTime.ParseExact(min_date + " 00:00:00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            DateTime max = DateTime.ParseExact(max_date + " 00:00:00", "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

            var sqlMin = min.Date.ToString("yyyy-MM-ddTHH:mm:ss");
            var sqlMax = max.Date.ToString("yyyy-MM-ddTHH:mm:ss");


            StdBELista objListCab;
            StdBELista objListLin;
            DocVenda dv = new DocVenda();
            List<DocVenda> listdv = new List<DocVenda>();
            LinhaDocVenda lindv = new LinhaDocVenda();
            List<LinhaDocVenda> listlindv = new
            List<LinhaDocVenda>();

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and Data between '" + sqlMin + "' and '" + sqlMax + "'");
                while (!objListCab.NoFim())
                {
                    dv = new DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }
    }
}