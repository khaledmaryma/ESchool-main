using E_SchoolApi.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_SchoolApi.Controllers
{
    public class SectionController : ApiController
    {


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetSection")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        public HttpResponseMessage GetClasses()
        {
            Sch_Section srvice = new Sch_Section();
            var listClass = srvice.GetSections();
            return Request.CreateResponse(listClass);
        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SetSection")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        public HttpResponseMessage SetSection(string Name, int ID)
        {
            Sch_Section srvice = new Sch_Section();
            var listClass = srvice.SetSections(Name, ID);
            return Request.CreateResponse(true);
        }




    }
}
