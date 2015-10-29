using Interop.StdBE800;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Models
{
    public class Category
    {
        public string category_id;
        public string description;

        public static List<Category> getCategories()
        {


            StdBELista objList;

            List<Category> listCategorias = new List<Category>();

            if (Lib_Primavera.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Lib_Primavera.PriEngine.Engine.Consulta("SELECT * FROM Familias");


                while (!objList.NoFim())
                {
                    listCategorias.Add(new Category
                    {
                        category_id = objList.Valor("Familia"),
                        description = objList.Valor("Descricao"),
                    });
                    objList.Seguinte();

                }

                return listCategorias;
            }
            else
                return null;
        }

    }
}