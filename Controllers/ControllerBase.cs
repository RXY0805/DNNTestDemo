using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DotNetNuke.Web.Api;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using DotNetNuke.Services.Exceptions;


namespace TAC.Modules.HelloWorld.Services
{
    public class ControllerBase : DnnApiController
    {
        #region "KeepAlive"
        [AllowAnonymous()]
        [HttpGet()]
        public HttpResponseMessage KeepAlive()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "True");
            }
            catch (Exception ex)
            {
                //Log to DotNetNuke and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}