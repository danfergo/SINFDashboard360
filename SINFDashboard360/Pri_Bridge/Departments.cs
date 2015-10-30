using Interop.StdBE800;
using SINFDashboard360.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Pri_Bridge
{
    public class Departments
    {
        
        public static List<Departament> getListaDepartamentos()
        {
            
            StdBELista objList;

            List<Departament> listDepartamentos = new List<Departament>();

            if (Pri_Bridge.Engine.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = Lib_Primavera.PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT * FROM Departamentos");


                while (!objList.NoFim())
                {
                    listDepartamentos.Add(new Departament
                    {
                        department_id = objList.Valor("Departamento"),
                        description = objList.Valor("Descricao"),
                        employees = Employees.getListaDepartamentosPeloCodigo(objList.Valor("Departamento"))
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