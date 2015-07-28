using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using DotNetNuke.Web.Api;
using System.Web.Http;
using System.Net;
using DotNetNuke.Services.Exceptions;

using TAC.Modules.HelloWorld.Components;

namespace TAC.Modules.HelloWorld.Services
{
    public class HelloController: ControllerBase
    {
        #region "Web Methods"
        [AllowAnonymous()]
        [HttpGet()]
        public HttpResponseMessage HelloWorld()
        {
            try
            {
                 var tc = new ItemController();
                 var defaultvalue=tc.GetItems().First();
                 return Request.CreateResponse(HttpStatusCode.OK, defaultvalue.HelloText);
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //For demo only, as it is not good idea to use httpget. 
        [AllowAnonymous()]
        [HttpGet()]
        public HttpResponseMessage UpdateHelloText(string HelloText)
        {
            try
            {
                //Item parameter parameter.HelloText
                var tc = new ItemController();
                var defaultvalue = tc.GetItems().First();
                defaultvalue.HelloText = HelloText;
                tc.UpdateItem(defaultvalue);
                // return Request.CreateResponse(HttpStatusCode.OK, defaultvalue.HelloText);
                return Request.CreateResponse(HttpStatusCode.OK, "Update successfully");
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //The following code is only for posting data to server.
        //

        [AllowAnonymous()]
        [HttpPost()]
        public HttpResponseMessage UpdateHelloTextByPost(string HelloText)
        {
            try
            {
                var tc = new ItemController();
                var defaultvalue = tc.GetItems().First();
                defaultvalue.HelloText =HelloText;
                tc.UpdateItem(defaultvalue);
                return Request.CreateResponse(HttpStatusCode.OK, "Update successfully");
            }
            catch (System.Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,"post"+ ex.Message);
            }
        }
       
        #endregion
    }
}