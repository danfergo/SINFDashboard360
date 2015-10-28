using Interop.StdBE800;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Funcionario
    {
        public string name;
        public string id;


        public static List<Funcionario> getListaDepartamentosPeloCodigo(String CodDepartamento)
        {


            StdBELista objList;

            List<Funcionario> listFuncionarios = new List<Funcionario>();

            if (Lib_Primavera.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Lib_Primavera.PriEngine.Engine.Consulta("SELECT * FROM Funcionarios WHERE CodDepartamento='" + CodDepartamento + "'");


                while (!objList.NoFim())
                {
                    listFuncionarios.Add(new Funcionario
                    {
                        id = objList.Valor("Codigo"),
                        name = objList.Valor("Nome")
                    });
                    objList.Seguinte();

                }

                return listFuncionarios;
            }
            else
                return null;
        }
    
    }
}