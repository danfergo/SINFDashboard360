using Interop.StdBE800;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Departamento
    {
        public string department_id;
        public string description;
        public List<Funcionario> employees = new List<Funcionario>();



        public static List<Departamento> getListaDepartamentos()
        {


            StdBELista objList;

            List<Departamento> listDepartamentos = new List<Departamento>();

            if (Lib_Primavera.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Lib_Primavera.PriEngine.Engine.Consulta("SELECT * FROM Departamentos");


                while (!objList.NoFim())
                {
                    listDepartamentos.Add(new Departamento
                    {
                        department_id = objList.Valor("Departamento"),
                        description = objList.Valor("Descricao"),
                        employees = Funcionario.getListaDepartamentosPeloCodigo(objList.Valor("Departamento"))
                    });
                    objList.Seguinte();

                }

                return listDepartamentos;
            }
            else
                return null;
        }
    
    }
}