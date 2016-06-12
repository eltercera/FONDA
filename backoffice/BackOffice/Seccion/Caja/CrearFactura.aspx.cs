using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.Domain;
using System.Web.Services;
using System.Web.Script.Serialization;
using com.ds201625.fonda.DataAccess.Exceptions;
using BackOffice.Content;
using BackOffice.Seccion.Restaurant;

namespace BackOffice.Seccion.Caja
{
    public partial class CrearFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            AlertSuccess_AgregarFactura.Visible = false;
            LoadTable();
            fillDropDown(id);


        }

        protected void LoadTable()
        {
            int id = int.Parse(Request.QueryString["id"]);
            CleanTable();


            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IOrderAccountDao _OrderAccountDAO = factoryDAO.GetOrderAccountDAO();
            IList<DishOrder> listDishOrder = (_OrderAccountDAO.FindById(id)).ListDish;

            int totalRows = listDishOrder.Count;
            int totalColumns = 4; //numero de columnas de la tabla





            //Seteo los label de la cabecera , falta restaurante y su direccion con la fecha.
            Label1.Text = id.ToString();
            Label2.Text = _OrderAccountDAO.FindById(id).Commensal.Email;

            //Recorremos la lista
            for (int i = 0; i <= totalRows - 1; i++)
            {


                //Crea una nueva fila de la tabla
                TableRow tRow = new TableRow();
                //Le asigna el Id a cada fila de la tabla
                tRow.Attributes["data-id"] = listDishOrder[i].Id.ToString();
                //Agrega la fila a la tabla existente
                Pago.Rows.Add(tRow);


                for (int j = 0; j <= totalColumns; j++)
                {
                    //Crea una nueva celda de la tabla
                    TableCell tCell = new TableCell();
                    //Agrega el nombre de la categoria

                    if (j.Equals(0))
                        tCell.Text = listDishOrder[i].Dish.Name;
                    //Agrega las acciones de la tabla
                    else if (j.Equals(1))
                    {
                        tCell.Text = listDishOrder[i].Count.ToString();
                    }
                    else if (j.Equals(2))
                    {
                        tCell.Text = listDishOrder[i].Dish.Cost.ToString();
                    }
                    else if (j.Equals(3))
                    {
                        tCell.Text = "10%";
                    }
                    else if (j.Equals(4))
                    {
                        tCell.Text = ((listDishOrder[i].Dish.Cost * 0.1) + listDishOrder[i].Dish.Cost).ToString();
                    }
                    //Agrega la 
                    tRow.Cells.Add(tCell);

                }

            }
        
            
                LabelMontoTotal.Text = "MONTO TOTAL: " + _OrderAccountDAO.FindById(id).GetAmount().ToString();
            


            //Agrega el encabezado a la Tabla
            TableHeaderRow header = GenerateTableHeader();
            Pago.Rows.AddAt(0, header);

        }


        /// <summary>
        /// Genera el encabezado de la tabla Categoria
        /// </summary>
        /// <returns>Returna un objeto de tipo TableHeaderRow</returns>
        private TableHeaderRow GenerateTableHeader()
        {
            //Se crea la fila en donde se insertara el header
            TableHeaderRow header = new TableHeaderRow();

            //Se crean las columnas del header
            TableHeaderCell h1 = new TableHeaderCell();
            TableHeaderCell h2 = new TableHeaderCell();
            TableHeaderCell h3 = new TableHeaderCell();
            TableHeaderCell h4 = new TableHeaderCell();
            TableHeaderCell h5 = new TableHeaderCell();

            //Se indica que se trabajara en el header y se asignan los valores a las columnas
            header.TableSection = TableRowSection.TableHeader;
            h1.Text = "Plato";
            h1.Scope = TableHeaderScope.Column;
            h2.Text = "Cantidad";
            h2.Scope = TableHeaderScope.Column;
            h3.Text = "Precio";
            h3.Scope = TableHeaderScope.Column;
            h4.Text = "IVA";
            h4.Scope = TableHeaderScope.Column;
            h5.Text = "Total";
            h5.Scope = TableHeaderScope.Column;

            //Se asignan las columnas a la fila
            header.Cells.Add(h1);
            header.Cells.Add(h2);
            header.Cells.Add(h3);
            header.Cells.Add(h4);
            header.Cells.Add(h5);

            return header;
        }

        public void CleanTable()
        {
            Pago.Rows.Clear();

        }
        protected void ButtonCloseOrder_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            //Genero los objetos para la consulta
            //Genero la lista de la consulta
            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IOrderAccountDao _OrderAccountDAO = factoryDAO.GetOrderAccountDAO();
            // cambio el estado de la cuenta a cerrada

            Account orderAccount = _OrderAccountDAO.FindById(id);
            //MALENA REVISA ESTO, PORQUE EN LA SIGUIENTE LINEA SE LE CAMBIA EL STATUS CUANDO SE CIERRA
            //LA ORDEN
            //orderAccount.Status = factoryDAO.GetClosedAccountStatus();
            try
            {
                _OrderAccountDAO.Save(orderAccount);
            }
            catch (SaveEntityFondaDAOException ex)
            {
                Console.WriteLine(ex.ToString());
            }


            AlertSuccess_AgregarFactura.Visible = true;

            //genero objetos para guardar factura
            // y pago
            IInvoiceDao _invoiceDAO = factoryDAO.GetInvoiceDao();
            Invoice _invoice = new Invoice();
            IPaymentDao<CreditCarPayment> _creditCardPaymentDAO = factoryDAO.GetCreditCardPaymentDAO();
            CreditCarPayment _creditCardPayment = new CreditCarPayment();

            int numCard = int.Parse(NumCard.Text);
            //agrego el pago
            _creditCardPayment.LastCardDigits = numCard;
            _creditCardPayment.Amount = _OrderAccountDAO.FindById(id).GetAmount();
            _creditCardPaymentDAO.Save(_creditCardPayment);
            // agrego la factura


            IList<Profile> profiles = orderAccount.Commensal.Profiles;
            String selectedProfile = DropDownProfiles.Text;
            int count = profiles.Count();
            Profile profile = new Profile();
            for (int i = 0; i < count; i++)
            {
                if (profiles[i].ProfileName == selectedProfile)
                {
                    profile = profiles[i];
                }
            }
            string idRestaurant = Session[RestaurantResource.SessionRestaurant].ToString();
            IRestaurantDAO _restaurant = factoryDAO.GetRestaurantDAO();


            /*

            _invoice.Restaurant = _restaurant.FindById(1);
            _invoice.Tip = 10;
            _invoice.Tax = 10;
            _invoice.Total = _OrderAccountDAO.FindById(id).getMonto();
            _invoice.Date = DateTime.Now;
            _invoice.Account = _OrderAccountDAO.FindById(id);
            _invoice.Status = GeneratedInvoiceStatus.Instance;
            _invoice.Payment = _creditCardPayment;
            _invoice.Profile = profile;
            _invoiceDAO.Save(_invoice);

            */
        }

        public void fillDropDown(int id)
        {

            FactoryDAO factoryDAO = FactoryDAO.Intance;
            IOrderAccountDao _OrderAccountDAO = factoryDAO.GetOrderAccountDAO();
            Commensal comensal = _OrderAccountDAO.FindById(id).Commensal;
            IList<Profile> profiles = comensal.Profiles;

            foreach (Profile profile in profiles)
            {
                DropDownProfiles.Items.Add(profile.ProfileName);

            }
        }

    }
}