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

                DateTime anterior = new DateTime(Int32.Parse(DateTime.Now.Year.ToString()), Int32.Parse(DateTime.Now.Month.ToString()), 1, 0,0,0);
                DateTime atual = new DateTime(Int32.Parse(DateTime.Now.Year.ToString()), Int32.Parse(DateTime.Now.Month.ToString()), 1, 0, 0, 0);

                anterior = anterior.AddMonths(-1);

                var anteriorString = anterior.ToString("yyyy-MM-dd HH:mm:ss");
                var atualString = atual.ToString("yyyy-MM-dd HH:mm:ss");

               objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT Funcionarios.Codigo, Funcionarios.Nome, Funcionarios.DataNascimento, Funcionarios.Sexo, Funcionarios.Qualificacao, Funcionarios.VencimentoMensal, Funcionarios.ValorSubsAlim, Funcionarios.ValorSubsEsp, sum(Recibos.TotalLiquido) as ValorTotal FROM Funcionarios, Recibos WHERE Funcionarios.Codigo=Recibos.CodFunc and (Recibos.DataMovimento between '"+anteriorString+"' and '"+atualString+"') and CodDepartamento='" + CodDepartamento + "' GROUP BY  Funcionarios.Codigo, Funcionarios.Nome, Funcionarios.DataNascimento, Funcionarios.Sexo, Funcionarios.Qualificacao, Funcionarios.VencimentoMensal, Funcionarios.ValorSubsAlim, Funcionarios.ValorSubsEsp");


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
                        vencimento = objList.Valor("ValorTotal")
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