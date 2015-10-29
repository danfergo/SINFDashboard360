using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SINFDashboard360.Lib_Primavera.Model;
using Interop.StdBE800;
using SINFDashboard360.Lib_Primavera;


namespace SINFDashboard360.Controllers
{
    public class ClientsController : ApiController
    {

        // GET: /Clientes/

        public IEnumerable<Lib_Primavera.Model.Cliente> Get()
        {
            return Lib_Primavera.PriIntegration.ListaClientes();
        }

        [HttpGet]
        // GET api/cliente/5    
        public Lib_Primavera.Model.Cliente Get(string id)
        {
            System.Diagnostics.Debug.WriteLine(id);
            Lib_Primavera.Model.Cliente cliente = Lib_Primavera.PriIntegration.GetCliente(id);
            if (cliente == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return cliente;
            }
        }


        [HttpGet]
        public IEnumerable<Lib_Primavera.Model.Factura> GetClientInvoices(string id)
        {

            //return Lib_Primavera.PriIntegration.ListaFacturas();
            StdBELista objList;
            Factura factura = new Factura();
            List<Factura> listaFacturas = new List<Factura>();

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT Entidade, TipoDoc, NumDoc, DataDoc, DataLiq, DataVenc, ValorTotal, ValorDesconto, ModoPag, CondPag, Moeda, TotalIva FROM Historico WHERE TipoDoc = 'FA' and Entidade = '" + id + "'");
                while (!objList.NoFim())
                {
                    listaFacturas.Add(parseFacturaObj(objList));
                    objList.Seguinte();
                }
                return listaFacturas;
            }
            else return null;
        }



        private static Factura parseFacturaObj(StdBELista obj)
        {
            Factura factura = new Factura();

            factura.entidade = obj.Valor("Entidade");
            factura.tipoDocumento = obj.Valor("Tipodoc");
            factura.numDocumento = obj.Valor("NumDoc");

            //Console.WriteLine("objecto: " + obj.Valor("DataDoc"));

            if (obj.Valor("DataDoc") != null)
                factura.dataDocumento = obj.Valor("DataDoc");
            if (obj.Valor("DataVenc") != null)
                factura.dataVencimento = obj.Valor("DataVenc");
            // if (obj.Valor("DataLiq") != null)
            //     factura.dataLiquidacao = obj.Valor("DataLiq");

            factura.valorTotal = obj.Valor("ValorTotal");
            // if (obj.Valor("ValorDesconto") != null)
            // factura.valorDesconto = obj.Valor("ValorDesconto");
            factura.modoPagamento = obj.Valor("ModoPag");
            factura.condPagamento = obj.Valor("CondPag");
            factura.moeda = obj.Valor("Moeda");
            factura.totalIva = obj.Valor("TotalIva");

            return factura;
        }
    }
}
