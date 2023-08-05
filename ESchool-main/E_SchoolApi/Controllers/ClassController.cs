using E_SchoolApi.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_SchoolApi.Controllers
{
    public class ClassController : ApiController
    {


        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetClasses")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        public HttpResponseMessage GetClasses()
        {
            Sch_Class srvice = new Sch_Class();
            var listClass = srvice.GetClasss();
            return Request.CreateResponse(listClass);

        }


        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("SetClasses")]
        //[SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(string))]
        public HttpResponseMessage SetSection(string Name, int ID)
        {
            Sch_Class srvice = new Sch_Class();
            var listClass = srvice.SetClasss(Name, ID);
            return Request.CreateResponse(true);
        }






    }
}
