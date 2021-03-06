﻿using Interop.StdBE800;
using SINFDashboard360.Models;
using SINFDashboard360.Pri_Bridge.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SINFDashboard360.Pri_Bridge
{
    public class Products
    {
        public static List<Produto> getListaProdutos()
        {

            StdBELista objList;

            List<Produto> listProdutos = new List<Produto>();

            if (Pri_Bridge.Engine.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT * FROM Artigo, ArtigoMoeda WHERE Artigo.Artigo = ArtigoMoeda.Artigo");


                while (!objList.NoFim())
                {
                    listProdutos.Add(new Produto
                    {
                        product_id = objList.Valor("Artigo"),
                        description = objList.Valor("Descricao"),
                        price = objList.Valor("PVP1"),
                        category_id = objList.Valor("Familia"),
                        stock = objList.Valor("STKActual"),
                        marca = objList.Valor("Marca")
                    });
                    objList.Seguinte();

                }

                return listProdutos;
            }
            else
                return null;

        }

        public static List<Produto> getListaProdutosByCategory(string category)
        {

            StdBELista objList;

            List<Produto> listProdutos = new List<Produto>();

            if (Pri_Bridge.Engine.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Artigo.Descricao,PVP1,STKActual,Marca FROM Artigo, ArtigoMoeda WHERE Artigo.Artigo = ArtigoMoeda.Artigo and Artigo.Familia='"+category+"'");


                while (!objList.NoFim())
                {
                    listProdutos.Add(new Produto
                    {
                        product_id = objList.Valor("Artigo"),
                        description = objList.Valor("Descricao"),
                        price = objList.Valor("PVP1"),
                        category_id = category,
                        stock = objList.Valor("STKActual"),
                        marca = objList.Valor("Marca")
                    });
                    objList.Seguinte();

                }

                return listProdutos;
            }
            else
                return null;

        }

        public static List<Produto> getListaProdutosBaixoStock()
        {

            StdBELista objList;

            List<Produto> listProdutos = new List<Produto>();

            if (Pri_Bridge.Engine.PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = Pri_Bridge.Engine.PriEngine.Engine.Consulta("SELECT Artigo.Artigo, Artigo.Descricao, ArtigoMoeda.PVP1, Artigo.Familia, Artigo.STKActual, Artigo.STKMinimo, Artigo.STKMaximo, Artigo.Marca FROM Artigo, ArtigoMoeda WHERE Artigo.Artigo = ArtigoMoeda.Artigo AND Artigo.STKActual < Artigo.STKMinimo");


                while (!objList.NoFim())
                {
                    listProdutos.Add(new Produto
                    {
                        product_id = objList.Valor("Artigo"),
                        description = objList.Valor("Descricao"),
                        price = objList.Valor("PVP1"),
                        category_id = objList.Valor("Familia"),
                        stock = objList.Valor("STKActual"),
                        stockMin = objList.Valor("STKMinimo"),
                        stockMax = objList.Valor("STKMaximo"),
                        marca = objList.Valor("Marca")
                    });
                    objList.Seguinte();

                }

                return listProdutos;
            }
            else
                return null;

        }

        //public static List<Produto> getComponentesDoProdutoPeloId(String id)
        //{


        //    StdBELista objList;

        //    List<Produto> listProdutos = new List<Produto>();

        //    if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
        //    {

                
        //        objList = PriEngine.Engine.Consulta("SELECT * FROM ComponentesArtigos,Artigo,ArtigoMoeda WHERE ComponentesArtigos.ArtigoComposto = '" + id + "' AND ComponentesArtigos.Componente = Artigo.Artigo AND ArtigoMoeda.Artigo  = Artigo.Artigo");


        //        while (!objList.NoFim())
        //        {
        //            listProdutos.Add(new Produto
        //            {
        //                product_id = objList.Valor("Artigo"),
        //                description = objList.Valor("Descricao"),
        //                price = objList.Valor("PVP1")
        //            });
        //            objList.Seguinte();

        //        }

        //        return listProdutos;
        //    }
        //    else
        //        return null;
        //}



        //public static Produto getProdutoPeloId(String id)
        //{

        //    StdBELista objList;

        //    if (PriEngine.InitializeCompany(SINFDashboard360.Properties.Settings.Default.Company.Trim(), SINFDashboard360.Properties.Settings.Default.User.Trim(), SINFDashboard360.Properties.Settings.Default.Password.Trim()) == true)
        //    {

        //        objList = PriEngine.Engine.Consulta("SELECT * FROM Artigo,ArtigoMoeda WHERE Artigo.Artigo='" + id + "' AND ArtigoMoeda.Artigo = Artigo.Artigo");


        //        if (!objList.NoFim())
        //        {
        //            return new Produto
        //            {
        //                product_id = objList.Valor("Artigo"),
        //                description = objList.Valor("Descricao"),
        //                price = objList.Valor("PVP1"),
        //                category_id = objList.Valor("Familia"),
        //                //components = Produto.getComponentesDoProdutoPeloId(id)
        //            };
        //        }

        //        return null;
        //    }
        //    else
        //        return null;

        //}
    }
}