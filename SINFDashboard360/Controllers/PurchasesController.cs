﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SINFDashboard360.Lib_Primavera.Model;
using SINFDashboard360.Models;

using Interop.StdBE800;
using SINFDashboard360.Lib_Primavera;
using System.Globalization;

namespace SINFDashboard360.Controllers
{
    public class PurchasesController : ApiController
    {


        public Object Get(String min_date, String max_date)
        {

            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine(min_date);
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");

            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine(max_date);
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------");

            DateTime min_date_s = new DateTime();
            DateTime max_date_s = new DateTime();
            try
            {
                min_date_s = DateTime.ParseExact(min_date, "dd-MM-yyyyThh:mm:ss", CultureInfo.InvariantCulture);
                max_date_s = DateTime.ParseExact(max_date, "dd-MM-yyyyThh:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return new Error("Bad date format. Error: " + e + ";");
            }

            return Purchases.queryPurchasesByDate(min_date_s, max_date_s);
        }

        /*
        // GET api/cliente/5    
        public Lib_Primavera.Model.DocCompra Get(string id)
        {
            Lib_Primavera.Model.DocVenda doccompra = Lib_Primavera.Comercial.GR_List(id);
            if (docvenda == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return docvenda;
            }
        }
        */


        public HttpResponseMessage Post(DocCompra dc)
        {
            RespostaErro erro = new RespostaErro();
            erro = PriIntegration.VGR_New(dc);

            if (erro.Erro == 0)
            {
                var response = Request.CreateResponse(
                   HttpStatusCode.Created, dc.id);
                string uri = Url.Link("DefaultApi", new { DocId = dc.id });
                response.Headers.Location = new Uri(uri);
                return response;
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
    }
}