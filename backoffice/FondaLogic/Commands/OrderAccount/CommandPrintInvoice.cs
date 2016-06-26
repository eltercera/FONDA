using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using com.ds201625.fonda.Resources.FondaResources.OrderAccount;
using com.ds201625.fonda.Logic.FondaLogic.FondaCommandException;
using com.ds201625.fonda.Logic.FondaLogic.Log;

namespace com.ds201625.fonda.Logic.FondaLogic.Commands.OrderAccount
{
    public class CommandPrintInvoice : Command
    {
        private FactoryDAO _facDAO = FactoryDAO.Intance;
        private IList<int> _list;
        private IList<DishOrder> _listDishOrder;
        private Restaurant _restaurant;
        private Invoice _invoice;
        private Account _account;
        private UserAccount _userAccount;
        private Person _person;

        public CommandPrintInvoice(Object receiver) : base(receiver) {

        }

        public override void Execute()
        {
            float borderWidthBottom = 0.75f;
            float borderWidth = 0;
            float taxPercentage = 0.12f;

            try
            {
                
                _list = (IList<int>)Receiver;
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    float totalFactura = 0;
                IUserAccountDAO _userAccountDao = _facDAO.GetUserAccountDAO();
                ICommensalDAO _genericPersonDao = _facDAO.GetCommensalDAO();
                IPersonDAO _personDao = _facDAO.GetPersonDao();
                IDishOrderDAO _dishOrderDao = _facDAO.GetDishOrderDAO();
                IOrderAccountDao _accountDAO = _facDAO.GetOrderAccountDAO();
                IRestaurantDAO _restaurantDao = _facDAO.GetRestaurantDAO();
                IInvoiceDao _invoiceDao = _facDAO.GetInvoiceDao();
                float tip, totaDishOrder,tax;
                tip = totaDishOrder = tax = 0;
                CreditCardPayment _creditCardPayment;

                _account = _accountDAO.FindById(_list[0]);
                _restaurant = _restaurantDao.FindById(_list[1]);
                _invoice = _invoiceDao.FindGenerateInvoiceByAccount(_account.Id);
                _listDishOrder = _dishOrderDao.GetDishesByAccount(_account.Id);

                _person = _personDao.FindById(_invoice.Profile.Person.Id);
                _userAccount = _userAccountDao.FindById(_person.Id);

                if (_invoice.Payment.GetType().Name.Equals(OrderAccountResources.CreditCard))
                {
                    _creditCardPayment = (CreditCardPayment)_invoice.Payment;
                    tip = _creditCardPayment.Tip;
                }
                #region Declaraciones
                // Creamos el documento con el tamaño de página tradicional
                Document doc = new Document(PageSize.LETTER); 
                String name = string.Format(OrderAccountResources.filename, _invoice.Number.ToString(), _restaurant.Name );
            // Indicamos donde vamos a guardar el documento
            
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                // Le colocamos el título y el autor
                // **Nota: Esto no será visible en el documento
                doc.AddTitle(OrderAccountResources.Invoice);
                doc.AddCreator(string.Format(OrderAccountResources.InvoiceRestaurant, _restaurant.Name));

                // Abrimos el archivo
                doc.Open();

                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Escribimos el encabezamiento en el documento
                doc.Add(new Paragraph(string.Format(OrderAccountResources.header, _restaurant.Name)));
                doc.Add(Chunk.NEWLINE);
                #endregion

                #region Creamos una tabla que contendrá la información 


                PdfPTable tblHeaderInvoice = new PdfPTable(5);
                tblHeaderInvoice.WidthPercentage = 100;

                PdfPTable tblOrderDetail = new PdfPTable(4);
                tblOrderDetail.WidthPercentage = 100;

                PdfPTable tblDishDetail = new PdfPTable(3);

                PdfPTable tblInvoiceDetail = new PdfPTable(4);
                tblInvoiceDetail.WidthPercentage = 100;
                #endregion
                // Configuramos el título de las columnas de la tabla
                #region Encabezados 
                PdfPCell clDate = new PdfPCell(new Phrase(OrderAccountResources.DateColumn, _standardFont));
                clDate.BorderWidth = borderWidth;
                clDate.BorderWidthBottom = borderWidthBottom;

                PdfPCell clNOrder = new PdfPCell(new Phrase(OrderAccountResources.OrderNumberColumn, _standardFont));
                clNOrder.BorderWidth = borderWidth;
                clNOrder.BorderWidthBottom = borderWidthBottom;

                PdfPCell clNInvoice = new PdfPCell(new Phrase(OrderAccountResources.InvoiceNumberColumn, _standardFont));
                clNInvoice.BorderWidth = borderWidth;
                clNInvoice.BorderWidthBottom = borderWidthBottom;

                PdfPCell clRestaurant = new PdfPCell(new Phrase(OrderAccountResources.Restaurant, _standardFont));
                clRestaurant.BorderWidth = borderWidth;
                clRestaurant.BorderWidthBottom = borderWidthBottom;

                PdfPCell clAddress = new PdfPCell(new Phrase(OrderAccountResources.address, _standardFont));
                clAddress.BorderWidth = borderWidth;
                clAddress.BorderWidthBottom = borderWidthBottom;

                PdfPCell clSsn = new PdfPCell(new Phrase(OrderAccountResources.Ssn, _standardFont));
                clSsn.BorderWidth = borderWidth;
                clSsn.BorderWidthBottom = borderWidthBottom;

                PdfPCell clName = new PdfPCell(new Phrase(OrderAccountResources.Name, _standardFont));
                clName.BorderWidth = borderWidth;
                clName.BorderWidthBottom = borderWidthBottom;

                PdfPCell clLastName = new PdfPCell(new Phrase(OrderAccountResources.LastName, _standardFont));
                clLastName.BorderWidth = borderWidth;
                clLastName.BorderWidthBottom = borderWidthBottom;

                PdfPCell clUserSsn = new PdfPCell(new Phrase(OrderAccountResources.UId, _standardFont));
                clUserSsn.BorderWidth = borderWidth;
                clUserSsn.BorderWidthBottom = borderWidthBottom;

                PdfPCell clTip = new PdfPCell(new Phrase(OrderAccountResources.Tip, _standardFont));
                clTip.BorderWidth = borderWidth;
                clTip.BorderWidthBottom = borderWidthBottom;

                PdfPCell clTax = new PdfPCell(new Phrase(OrderAccountResources.Tax, _standardFont));
                clTax.BorderWidth = borderWidth;
                clTax.BorderWidthBottom = borderWidthBottom;

                PdfPCell clTotal = new PdfPCell(new Phrase(OrderAccountResources.Total, _standardFont));
                clTotal.BorderWidth = borderWidth;
                clTotal.BorderWidthBottom = borderWidthBottom;

                PdfPCell clTotalTax = new PdfPCell(new Phrase(OrderAccountResources.TotalCost, _standardFont));
                clTotalTax.BorderWidth = borderWidth;
                clTotalTax.BorderWidthBottom = borderWidthBottom;

                PdfPCell clDish = new PdfPCell(new Phrase(OrderAccountResources.Dish, _standardFont));
                clDish.BorderWidth = borderWidth;
                clDish.BorderWidthBottom = borderWidthBottom;

                PdfPCell clQuantity = new PdfPCell(new Phrase(OrderAccountResources.Quantity, _standardFont));
                clQuantity.BorderWidth = borderWidth;
                clQuantity.BorderWidthBottom = borderWidthBottom;

                PdfPCell clPrice = new PdfPCell(new Phrase(OrderAccountResources.Price, _standardFont));
                clPrice.BorderWidth = borderWidth;
                clPrice.BorderWidthBottom = borderWidthBottom;

                // Añadimos las celdas a la tabla
                tblHeaderInvoice.AddCell(clDate);
                tblHeaderInvoice.AddCell(clRestaurant);
                tblHeaderInvoice.AddCell(clSsn);
                tblHeaderInvoice.AddCell(clAddress);
                tblHeaderInvoice.AddCell(clNInvoice);
                tblOrderDetail.AddCell(clNOrder);
                tblOrderDetail.AddCell(clName);
                tblOrderDetail.AddCell(clLastName);
                tblOrderDetail.AddCell(clUserSsn);
                tblInvoiceDetail.AddCell(clTip);
                tblInvoiceDetail.AddCell(clTotal);
                tblInvoiceDetail.AddCell(clTax);
                tblInvoiceDetail.AddCell(clTotalTax);
                #endregion

                #region Llenamos la tabla con información
                clDate = new PdfPCell(new Phrase(_invoice.Date.ToString(), _standardFont));
                clDate.BorderWidth = borderWidth;

                clNOrder = new PdfPCell(new Phrase(_account.Number.ToString(), _standardFont));
                clNOrder.BorderWidth = borderWidth;

                clNInvoice = new PdfPCell(new Phrase(_invoice.Number.ToString(), _standardFont));
                clNInvoice.BorderWidth = borderWidth;

                clRestaurant = new PdfPCell(new Phrase(_restaurant.Name, _standardFont));
                clRestaurant.BorderWidth = borderWidth;

                clAddress = new PdfPCell(new Phrase(_restaurant.Address, _standardFont));
                clAddress.BorderWidth = borderWidth;

                clSsn = new PdfPCell(new Phrase(_restaurant.Ssn, _standardFont));
                clSsn.BorderWidth = borderWidth;

                clName = new PdfPCell(new Phrase(_person.Name, _standardFont));
                clName.BorderWidth = borderWidth;

                clLastName = new PdfPCell(new Phrase(_person.LastName, _standardFont));
                clLastName.BorderWidth = borderWidth;

                clUserSsn = new PdfPCell(new Phrase(_person.Ssn, _standardFont));
                clUserSsn.BorderWidth = borderWidth;

                clTip = new PdfPCell(new Phrase(tip.ToString(), _standardFont));
                clTip.BorderWidth = borderWidth;

                tblDishDetail.AddCell(clDish);
                tblDishDetail.AddCell(clQuantity);
                tblDishDetail.AddCell(clPrice);

                for (int j = 0; j < _listDishOrder.Count; j++)
                {
                    clDish = new PdfPCell(new Phrase(_listDishOrder[j].Dish.Name, _standardFont));
                    clDish.BorderWidth = borderWidth;

                    clQuantity = new PdfPCell(new Phrase(_listDishOrder[j].Count.ToString(), _standardFont));
                    clQuantity.BorderWidth = borderWidth;

                    clPrice = new PdfPCell(new Phrase(_listDishOrder[j].Dish.Cost.ToString(), _standardFont));
                    clPrice.BorderWidth = borderWidth;
                    totaDishOrder = (_listDishOrder[j].Dish.Cost * _listDishOrder[j].Count) + totaDishOrder;
                    tblDishDetail.AddCell(clDish);
                    tblDishDetail.AddCell(clQuantity);
                    tblDishDetail.AddCell(clPrice);

                }

                tax = totaDishOrder * taxPercentage;

                clTax = new PdfPCell(new Phrase(tax.ToString(), _standardFont));
                clTax.BorderWidth = borderWidth;

                clTotal = new PdfPCell(new Phrase((totaDishOrder).ToString(), _standardFont));
                clTotal.BorderWidth = borderWidth;

                totalFactura = totaDishOrder + tip + tax;

                clTotalTax = new PdfPCell(new Phrase(totalFactura.ToString(), _standardFont));
                clTotalTax.BorderWidth = borderWidth;


                // Añadimos las celdas a la tabla
                tblHeaderInvoice.AddCell(clDate);
                tblHeaderInvoice.AddCell(clRestaurant);
                tblHeaderInvoice.AddCell(clSsn);
                tblHeaderInvoice.AddCell(clAddress);
                tblHeaderInvoice.AddCell(clNInvoice);
                tblOrderDetail.AddCell(clNOrder);
                tblOrderDetail.AddCell(clName);
                tblOrderDetail.AddCell(clLastName);
                tblOrderDetail.AddCell(clUserSsn);
                tblInvoiceDetail.AddCell(clTip);
                tblInvoiceDetail.AddCell(clTotal);
                tblInvoiceDetail.AddCell(clTax);
                tblInvoiceDetail.AddCell(clTotalTax);
                #endregion

                #region Finalmente, añadimos la tabla al documento PDF y cerramos el documento
                doc.Add(tblHeaderInvoice);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblOrderDetail);
                //doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblDishDetail);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblInvoiceDetail);
                doc.Close();
                #endregion

                #region lo descargamos
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = OrderAccountResources.ContentType;
                HttpContext.Current.Response.AddHeader(OrderAccountResources.ContentDisposition,
                    string.Format(OrderAccountResources.ContentAttachment, _invoice.Number.ToString(), _restaurant.Name));
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                HttpContext.Current.Response.BinaryWrite(bytes);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                HttpContext.Current.Response.Close();
                #endregion
                    writer.Close();
            }

        }
            catch (NullReferenceException ex)
            {
                CommandExceptionPrintInvoice exception = new CommandExceptionPrintInvoice(
                    OrderAccountResources.CommandExceptionPrintInvoiceCode,
                    OrderAccountResources.ClassNamePrintInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionPrintInvoice,
                    ex);

        Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;

            }
            catch (Exception ex)
            {
                CommandExceptionPrintInvoice exception = new CommandExceptionPrintInvoice(
                    OrderAccountResources.CommandExceptionPrintInvoiceCode,
                    OrderAccountResources.ClassNamePrintInvoice,
                    System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    OrderAccountResources.MessageCommandExceptionPrintInvoice,
                    ex);

    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
                throw exception;
            }


Logger.WriteSuccessLog(OrderAccountResources.ClassNamePrintInvoice
                    , OrderAccountResources.SuccessMessageCommandPrintInvoice
                    , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                    );
        }



    }
}
