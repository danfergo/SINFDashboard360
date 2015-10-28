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



        public static List<Departamento> getListaDepartamentos()
        {


            StdBELista objList;

            List<Departamento> listClientes = new List<Departamento>();

            if (Lib_Primavera.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Lib_Primavera.PriEngine.Engine.Consulta("SELECT * FROM Departamentos");


                while (!objList.NoFim())
                {
                    listClientes.Add(new Departamento
                    {
                        department_id = objList.Valor("Departamento"),
                        description = objList.Valor("Descricao")
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }
    
    }
}