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
    public class Providers
    {
        public static List<Models.Fornecedor> ListaFornecedores()
        {


            StdBELista objList;

            List<Models.Fornecedor> listFornecedores = new List<Models.Fornecedor>();

            if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Fornecedores.Fornecedor, Fornecedores.Nome, Fornecedores.Moeda, Fornecedores.NumContrib, Fornecedores.Morada, Fornecedores.Idioma, Fornecedores.Tel, sum(Pendentes.ValorTotal) as Encomendas, sum(Pendentes.ValorPendente) as PorPagar FROM  FORNECEDORES, Pendentes Where Pendentes.Entidade = Fornecedores.Fornecedor GROUP BY Fornecedores.Fornecedor, Fornecedores.Nome, Fornecedores.Moeda, Fornecedores.NumContrib, Fornecedores.Morada, Fornecedores.Idioma, Fornecedores.Tel");


                while (!objList.NoFim())
                {
                    listFornecedores.Add(new Models.Fornecedor
                    {
                        fornecedor_id = objList.Valor("Fornecedor"),
                        name = objList.Valor("Nome"),
                        currency = objList.Valor("Moeda"),
                        tax_number = objList.Valor("NumContrib"),
                        address = objList.Valor("Morada"),
                        language = objList.Valor("Idioma"),
                        phone = objList.Valor("Tel"),
                        valorEncomendas = objList.Valor("Encomendas"),
                        porPagar = objList.Valor("PorPagar")
                    });
                    objList.Seguinte();

                }

                return listFornecedores;
            }
            else
                return null;
        }
    }
}