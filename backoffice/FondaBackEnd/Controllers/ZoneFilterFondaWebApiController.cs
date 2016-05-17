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

            Zone zone1 = new Zone();

          zone1.Name = "Alta";

            Zone zone2 = new Zone();
            zone2.Name = "Alto Hatillo";

            Zone zone3 = new Zone();
            zone3.Name = "Bello Monte";

            Zone zone4 = new Zone();
            zone4.Name = "Boleita";

            Zone zone5 = new Zone();
            zone5.Name = "Chacao";
            
              List<Zone> lista = new List<Zone>();
              lista.Add(zone1);
              lista.Add(zone2);
              lista.Add(zone3);
              lista.Add(zone4);
              lista.Add(zone5);
              
              return Ok(lista);
          }
    }
}
