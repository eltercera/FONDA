using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.Tests.DataAccess
{ 
  /*[TestFixture()]
 
    class BODishTest
    {
       

      private FactoryDAO _facDAO;

      private IDishDAO _dishDAO;
      private Dish _dish;
      private int _dishID;

      /// <summary>
      /// Prueba de Dominio.
      /// crea un plato.
      /// </summary>
      [Test()]
      public void Dish()
      {
          generateDish();
          dishAssertions();
      }

      private void generateDish(bool edit = false)
      {
          if (_dish != null & !edit)
              return;

          if ((edit & _dish == null) | _dish == null)
              _dish = new Dish();

          string editadd = "";

          if (edit)
              editadd = "Editado";

          _dish.Name = "Rol de Canela" + editadd;
          _dish.Description = "Da diarrea" + editadd;
          _dish.Cost = 580;
          _dish.Image = null;
          _dish.Status =  ActiveSimpleStatus.Instance;
          _dish.Suggestion = true;
       


      }

      private void dishAssertions(bool edit = false)
      {
        
          Assert.IsNotNull(_dish);
          Assert.AreEqual(_dish.Name, "Rol de Canela");
          Assert.AreEqual(_dish.Description, "Da diarrea");
          Assert.AreEqual( _dish.Cost,580);
          Assert.AreEqual(_dish.Image, null);
          Assert.AreEqual(_dish.Status, ActiveSimpleStatus.Instance);
          Assert.AreEqual(_dish.Suggestion ,true);
      }

    }*/
}
