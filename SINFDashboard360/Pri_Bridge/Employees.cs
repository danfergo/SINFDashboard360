using Interop.StdBE800;
using SINFDashboard360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Pri_Bridge
{
    public class Employees
    {
        public static List<Funcionario> getListaDepartamentosPeloCodigo(String CodDepartamento)
        {

            StdBELista objList;

            List<Funcionario> listFuncionarios = new List<Funcionario>();

            if (Pri_Bridge.Engine.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT * FROM Funcionarios WHERE CodDepartamento='" + CodDepartamento + "'");


                while (!objList.NoFim())
                {
                    listFuncionarios.Add(new Funcionario
                    {
                        id = objList.Valor("Codigo"),
                        name = objList.Valor("Nome"),
                        birthDate = objList.Valor("DataNascimento"),
                        sex = objList.Valor("Sexo"),
                        qualificacao = objList.Valor("Qualificacao"),
                        salary = objList.Valor("VencimentoMensal"),
                        subAlimentar =objList.Valor("ValorSubsAlim"),
                        subEsp = objList.Valor("ValorSubsEsp"),
                        vencimento = objList.Valor("Vencimento")
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