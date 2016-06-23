using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using FondaResources.OrderAccount;
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
        private object Server;

        public CommandPrintInvoice(Object receiver) : base(receiver) {

        }

        public override void Execute()
        {
            
            //try
            //{
                _list = (IList<int>)Receiver;
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

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream()) ;
                
                String ruta = @"~\Factura_" + _invoice.Number.ToString() + "_" + _restaurant.Name + ".pdf";
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta,FileMode.Create));
            //FileStream file = new FileStream(Server.MapPath("~/Files/") + "Test.PDF", FileMode.Create, System.IO.FileAccess.Write);
            //PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/Files/Pdf/test.pdf"), FileMode.Create));
            //PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
            //@"C:\Factura_"+_invoice.Number+/*"_"+_restaurant.Name+*/".pdf"
            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Factura");
                //doc.AddCreator("Roberto Torres");

                // Abrimos el archivo
                doc.Open();

                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                // Escribimos el encabezamiento en el documento
                doc.Add(new Paragraph("Factura Restaurante "+_restaurant.Name));
                doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá la información 
            // de nuestros visitante.
            #region Llenado de la tabla
            PdfPTable tblPrueba1 = new PdfPTable(5);
                tblPrueba1.WidthPercentage = 100;

                PdfPTable tblPrueba2 = new PdfPTable(4);
                tblPrueba2.WidthPercentage = 100;

                PdfPTable tblPrueba3 = new PdfPTable(3);
                //tblPrueba3.WidthPercentage = 100;

                PdfPTable tblPrueba4 = new PdfPTable(4);
                tblPrueba4.WidthPercentage = 100;

                // Configuramos el título de las columnas de la tabla
                PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", _standardFont));
                clFecha.BorderWidth = 0;
                clFecha.BorderWidthBottom = 0.75f;

                PdfPCell clNOrden = new PdfPCell(new Phrase("#Orden", _standardFont));
                clNOrden.BorderWidth = 0;
                clNOrden.BorderWidthBottom = 0.75f;

                PdfPCell clNFactura = new PdfPCell(new Phrase("#Factura", _standardFont));
                clNFactura.BorderWidth = 0;
                clNFactura.BorderWidthBottom = 0.75f;

                PdfPCell clRestaurante = new PdfPCell(new Phrase("Restaurante", _standardFont));
                clRestaurante.BorderWidth = 0;
                clRestaurante.BorderWidthBottom = 0.75f;

                PdfPCell clDireccion = new PdfPCell(new Phrase("Direccion", _standardFont));
                clDireccion.BorderWidth = 0;
                clDireccion.BorderWidthBottom = 0.75f;

                PdfPCell clRif = new PdfPCell(new Phrase("Rif", _standardFont));
                clRif.BorderWidth = 0;
                clRif.BorderWidthBottom = 0.75f;

                PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
                clNombre.BorderWidth = 0;
                clNombre.BorderWidthBottom = 0.75f;

                PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
                clApellido.BorderWidth = 0;
                clApellido.BorderWidthBottom = 0.75f;

                PdfPCell clCedula = new PdfPCell(new Phrase("C.I", _standardFont));
                clCedula.BorderWidth = 0;
                clCedula.BorderWidthBottom = 0.75f;

                PdfPCell clPropina = new PdfPCell(new Phrase("Propina", _standardFont));
                clPropina.BorderWidth = 0;
                clPropina.BorderWidthBottom = 0.75f;

                PdfPCell clIVA = new PdfPCell(new Phrase("IVA (12%)", _standardFont));
                clIVA.BorderWidth = 0;
                clIVA.BorderWidthBottom = 0.75f;

                PdfPCell clTotal = new PdfPCell(new Phrase("Total", _standardFont));
                clTotal.BorderWidth = 0;
                clTotal.BorderWidthBottom = 0.75f;

                PdfPCell clTotalIva = new PdfPCell(new Phrase("Total + IVA + Propina", _standardFont));
                clTotalIva.BorderWidth = 0;
                clTotalIva.BorderWidthBottom = 0.75f;

                // Añadimos las celdas a la tabla
                tblPrueba1.AddCell(clFecha);
                tblPrueba1.AddCell(clRestaurante);
                tblPrueba1.AddCell(clRif);
                tblPrueba1.AddCell(clDireccion);
                tblPrueba1.AddCell(clNFactura);
                tblPrueba2.AddCell(clNOrden);
                tblPrueba2.AddCell(clNombre);
                tblPrueba2.AddCell(clApellido);
                tblPrueba2.AddCell(clCedula);
                tblPrueba4.AddCell(clPropina);
                tblPrueba4.AddCell(clTotal); 
                tblPrueba4.AddCell(clIVA);
                tblPrueba4.AddCell(clTotalIva);

                // Llenamos la tabla con información
                clFecha = new PdfPCell(new Phrase(_invoice.Date.ToString(), _standardFont));
                clFecha.BorderWidth = 0;

                clNOrden = new PdfPCell(new Phrase(_account.Number.ToString(), _standardFont));
                clNOrden.BorderWidth = 0;

                clNFactura = new PdfPCell(new Phrase(_invoice.Number.ToString(), _standardFont));
                clNFactura.BorderWidth = 0;

                clRestaurante = new PdfPCell(new Phrase(_restaurant.Name, _standardFont));
                clRestaurante.BorderWidth = 0;

                clDireccion = new PdfPCell(new Phrase(_restaurant.Address, _standardFont));
                clDireccion.BorderWidth = 0;

                clRif = new PdfPCell(new Phrase(_restaurant.Ssn, _standardFont));
                clRif.BorderWidth = 0;

                clNombre = new PdfPCell(new Phrase(_person.Name, _standardFont));
                clNombre.BorderWidth = 0;

                clApellido = new PdfPCell(new Phrase(_person.LastName, _standardFont));
                clApellido.BorderWidth = 0;

                clCedula = new PdfPCell(new Phrase(_person.Ssn, _standardFont));
                clCedula.BorderWidth = 0;

                clPropina = new PdfPCell(new Phrase(tip.ToString(), _standardFont));
                clPropina.BorderWidth = 0;

                PdfPCell clPlatillo = new PdfPCell(new Phrase("Platillo", _standardFont));
                clPlatillo.BorderWidth = 0;
                clPlatillo.BorderWidthBottom = 0.75f;

                PdfPCell clCantidad = new PdfPCell(new Phrase("Cantidad", _standardFont));
                clCantidad.BorderWidth = 0;
                clCantidad.BorderWidthBottom = 0.75f;

                PdfPCell clPrecio = new PdfPCell(new Phrase("Precio", _standardFont));
                clPrecio.BorderWidth = 0;
                clPrecio.BorderWidthBottom = 0.75f;
                tblPrueba3.AddCell(clPlatillo);
                tblPrueba3.AddCell(clCantidad);
                tblPrueba3.AddCell(clPrecio);

                for (int j = 0; j < _listDishOrder.Count; j++)
                {
                    clPlatillo = new PdfPCell(new Phrase(_listDishOrder[j].Dish.Name, _standardFont));
                    clPlatillo.BorderWidth = 0;

                    clCantidad = new PdfPCell(new Phrase(_listDishOrder[j].Count.ToString(), _standardFont));
                    clCantidad.BorderWidth = 0;

                    clPrecio = new PdfPCell(new Phrase(_listDishOrder[j].Dish.Cost.ToString(), _standardFont));
                    clPrecio.BorderWidth = 0;
                    totaDishOrder = (_listDishOrder[j].Dish.Cost * _listDishOrder[j].Count) + totaDishOrder;
                    tblPrueba3.AddCell(clPlatillo);
                    tblPrueba3.AddCell(clCantidad);
                    tblPrueba3.AddCell(clPrecio);

                }

                tax = totaDishOrder * 0.12f;

                clIVA = new PdfPCell(new Phrase(tax.ToString(), _standardFont));
                clIVA.BorderWidth = 0;

                clTotal = new PdfPCell(new Phrase((totaDishOrder).ToString(), _standardFont));
                clTotal.BorderWidth = 0;

                totalFactura = totaDishOrder + tip + tax;

                clTotalIva = new PdfPCell(new Phrase(totalFactura.ToString(), _standardFont));
                clTotalIva.BorderWidth = 0;


                // Añadimos las celdas a la tabla
                tblPrueba1.AddCell(clFecha);
                tblPrueba1.AddCell(clRestaurante);
                tblPrueba1.AddCell(clRif);
                tblPrueba1.AddCell(clDireccion);
                tblPrueba1.AddCell(clNFactura);
                tblPrueba2.AddCell(clNOrden);
                tblPrueba2.AddCell(clNombre);
                tblPrueba2.AddCell(clApellido);
                tblPrueba2.AddCell(clCedula);
                tblPrueba4.AddCell(clPropina);
                tblPrueba4.AddCell(clTotal); 
                tblPrueba4.AddCell(clIVA);
                tblPrueba4.AddCell(clTotalIva);


                // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
                doc.Add(tblPrueba1);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblPrueba2);
                //doc.Add(Chunk.NEWLINE);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblPrueba3);
                doc.Add(Chunk.NEWLINE);
                doc.Add(tblPrueba4);
            #endregion
            doc.Close();

            //byte[] bytes = memoryStream.ToArray();
            //memoryStream.Close();
            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment; filename=Employee.pdf");
            //Response.ContentType = "application/pdf";
            //Response.Buffer = true;
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.BinaryWrite(bytes);
            //Response.End();
            //Response.Close();

            writer.Close();


            //}
            //catch (NullReferenceException ex)
            //{
            //    CommandExceptionPrintInvoice exception = new CommandExceptionPrintInvoice(
            //        OrderAccountResources.CommandExceptionPrintInvoiceCode,
            //        OrderAccountResources.ClassNamePrintInvoice,
            //        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            //        OrderAccountResources.MessageCommandExceptionPrintInvoice,
            //        ex);

            //    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
            //    throw exception;

            //}
            //catch (Exception ex)
            //{
            //    CommandExceptionPrintInvoice exception = new CommandExceptionPrintInvoice(
            //        OrderAccountResources.CommandExceptionPrintInvoiceCode,
            //        OrderAccountResources.ClassNamePrintInvoice,
            //        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            //        OrderAccountResources.MessageCommandExceptionPrintInvoice,
            //        ex);

            //    Logger.WriteErrorLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, exception);
            //    throw exception;
            //}


            //Logger.WriteSuccessLog(OrderAccountResources.ClassNamePrintInvoice
            //        , OrderAccountResources.SuccessMessageCommandPrintInvoice
            //        , System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
            //        );
        }



    }
}
