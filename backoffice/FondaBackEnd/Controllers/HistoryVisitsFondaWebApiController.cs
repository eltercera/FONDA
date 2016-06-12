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
using com.ds201625.fonda.Factory;

namespace com.ds201625.fonda.BackEnd.Controllers
{
    
    [RoutePrefix("api")]
    /// <summary>
    /// clase que controla la api del ws
    /// </summary>
    public class HistoryVisitsFondaWebApiController : FondaWebApi
    {
        /// <summary>
        /// Metodo que controla la lista de pagos de una persona en restaurant
        /// </summary>
        public HistoryVisitsFondaWebApiController() : base() { }

        [Route("historyVisits")]
        [HttpGet]
        /// <summary>
        ///Metodo que obtiene la lista del historial de pagos del restaurant
        /// </summary>
        /// <returns> lista de pagos</returns>
          public IHttpActionResult getHistoryVisits()
          {

             
              DateTime date1 = new DateTime(2016, 06, 10);

              /*   Person person = new Person();
                 person.Name = "Adriana";
                 person.LastName = "Da Rocha";
               */

              Profile profile = new Profile();
              //   profile.Person = person;
              profile.ProfileName = "Adriana Da Rocha";
           
              RestaurantCategory category1 = new RestaurantCategory();
              category1.Name = "Romantico";

              RestaurantCategory category2 = new RestaurantCategory();
              category2.Name = "Casual";

              RestaurantCategory category3 = new RestaurantCategory();
              category3.Name = "Italiano";

              RestaurantCategory category4 = new RestaurantCategory();
              category4.Name = "Americano";


              Restaurant restaurant1 = new Restaurant();
           
              restaurant1.Name = "The dining room";
              restaurant1.Address = "La Castellana";
              restaurant1.RestaurantCategory = category2;
              restaurant1.Logo = "ic_restaurant001";

              Restaurant restaurant2 = new Restaurant();
              restaurant2.Name = "Mogi Mirin";
              restaurant2.Address = "Los Dos Caminos";
              restaurant2.RestaurantCategory = category1;
              restaurant2.Logo = "ic_restaurant002";

              Restaurant restaurant3 = new Restaurant();
              restaurant3.Name = "Gordo & Magro";
              restaurant3.Address = "La California";
              restaurant3.RestaurantCategory = category3;
              restaurant3.Logo = "ic_restaurant003";

              Restaurant restaurant4 = new Restaurant();
              restaurant4.Name = "La Casona";
              restaurant4.Address = "Parque Central";
              restaurant4.RestaurantCategory = category3;
              restaurant4.Logo = "ic_restaurant004";

              Restaurant restaurant5 = new Restaurant();
              restaurant5.Name = "Tony's";
              restaurant5.Address = "El Rosal";
              restaurant5.RestaurantCategory = category4;
              restaurant5.Logo = "ic_restaurant005";


              Invoice invoice1 = (Invoice)EntityFactory.GetInvoice(restaurant1, null,
                null, profile, 350, 50, null, 1);


              Invoice invoice2 = (Invoice)EntityFactory.GetInvoice(restaurant2, null,

                null, profile, 300, 350, 50, null, 2);

              Invoice invoice3 = (Invoice)EntityFactory.GetInvoice(restaurant3, null,

                null, profile, 300, 350, 50, null, 3);

              Invoice invoice4 = (Invoice)EntityFactory.GetInvoice(restaurant4, null,

                null, profile, 300, 350, 50, null, 4);


              Invoice invoice5 = (Invoice)EntityFactory.GetInvoice(restaurant5, null,

                null, profile, 300, 350, 50, null, 5);


              Invoice invoice6 = (Invoice)EntityFactory.GetInvoice(restaurant1, null,

                null, profile, 300, 350, 50, null, 6);

              List<Invoice> lista = new List<Invoice>();
              lista.Add(invoice1);
              lista.Add(invoice2);
              lista.Add(invoice3);
              lista.Add(invoice4);
              lista.Add(invoice5);
              lista.Add(invoice6);
              
              return Ok(lista);
          }
    }
    
}
