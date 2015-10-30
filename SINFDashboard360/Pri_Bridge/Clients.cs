using Interop.GcpBE800;
using Interop.StdBE800;
using SINFDashboard360.Lib_Primavera.Model;
using SINFDashboard360.Pri_Bridge.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Pri_Bridge
{
    public class Clients
    {

        public static List<Models.Client> ListaClientes()
        {


            StdBELista objList;

            List<Models.Client> listClientes = new List<Models.Client>();

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome, Moeda, NumContrib as NumContribuinte, Fac_Mor AS campo_exemplo FROM  CLIENTES");


                while (!objList.NoFim())
                {
                    listClientes.Add(new Models.Client
                    {
                        client_id = objList.Valor("Cliente"),
                        name = objList.Valor("Nome"),
                        currency = objList.Valor("Moeda"),
                        tax_number = objList.Valor("NumContribuinte"),
                        address = objList.Valor("campo_exemplo")
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Models.Client GetCliente(string codCliente)
        {


            GcpBECliente objCli = new GcpBECliente();


            Models.Client myCli = new Models.Client();

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {
                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.client_id = objCli.get_Cliente();
                    myCli.name = objCli.get_Nome();
                    myCli.currency = objCli.get_Moeda();
                    myCli.tax_number = objCli.get_NumContribuinte();
                    myCli.address = objCli.get_Morada();
                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }





        public static IEnumerable<Lib_Primavera.Model.Factura> getClientInvoices(string id)
        {

            //return Lib_Primavera.PriIntegration.ListaFacturas();
            StdBELista objList;
            Factura factura = new Factura();
            List<Factura> listaFacturas = new List<Factura>();

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM Historico WHERE TipoDoc = 'FA' and Entidade = '" + id + "'");
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