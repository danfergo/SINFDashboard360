using Interop.StdBE800;
using SINFDashboard360.Models;
using SINFDashboard360.Pri_Bridge.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Pri_Bridge
{
    public class Categories
    {

        public static List<Category> getCategories()
        {


            StdBELista objList;

            List<Category> listCategorias = new List<Category>();


            if (Pri_Bridge.Engine.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT * FROM Familias");


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