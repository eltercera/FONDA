using com.ds201625.fonda.Domain;

namespace com.ds201625.fonda.Factory
{
    /// <summary>
    /// Fabricada que instancia las entidades del dominio
    /// </summary>
    public class EntityFactory
    {
        #region OrderAccount

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        public static Entity GetOrderAccount()
        {
            return new Account();
        }

        public static Entity GetPayment()
        {
            return new Payment();
        }

        #endregion

        #region Restaurant

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad
        public static Entity GetRestaurant()
        {
            return new Restaurant();
        }

        #endregion

        #region Menu

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        #endregion

        #region Login

        //Instancia los objetos del dominio invocando al constructor(es) de la entidad

        #endregion
    }
}
