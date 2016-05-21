using System;
using System.Web.Http;
using System.Linq;
using System.Collections;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.BackEnd.ActionFilters;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    [RoutePrefix("api")]
    public class ZoneFilterFondaWebApiController : FondaWebApi
    {
        public ZoneFilterFondaWebApiController() : base() { }

        [Route("zoneFilter")]
        [HttpGet]
        public IHttpActionResult getZoneFilter()
        {
            /// <summary>
            /// Llamar al metodo mediante la interfaz
            /// para listar todas las zonas y devolverlo al ws
            /// </summary>
            /// <returns></returns>
            IZoneDAO zoneDAO = FactoryDAO.GetZoneDAO();


            IList<Zone> listZone = zoneDAO.allZone();


            return Ok(listZone);


        }
    }
}