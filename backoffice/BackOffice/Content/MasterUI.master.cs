using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Web.SessionState;
using BackOffice.Content;


public partial class MasterUI : System.Web.UI.MasterPage
{
    private string nombre;
    private Dictionary<string, string> opcionMenu = new Dictionary<string, string>();
    private Dictionary<string, string[,]> subpositionOpcinonMenu = new Dictionary<string, string[,]>(); //Se guardaran las sub opciones del menú

    public Dictionary<string, string> OpcionMenu
    {
        get { return opcionMenu; }
        set { opcionMenu = value; }
    }
    public Dictionary<string, string[,]> SubpositionOpcinonMenu
    {
        get { return subpositionOpcinonMenu; }
        set { subpositionOpcinonMenu = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {


        try
        {
            ///verifica si un usuario esta en el sistema
            if (Session[RecursoMaster.sessionUserID] != null)
            {
                //   Session[RecursoMaster.sessionRol] = "Sistema";// rol del usuario log solo para control de prueba
                DropDownMenu();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }
        catch (NullReferenceException ex)
        {
            //Response.Redirect(RecursoMaster.addressLogin);
        }
        catch (Exception ex)
        {

        }
    }
    /// <summary>
    /// Menu lateral ,permite hacer la carga del mismo
    /// </summary>
    protected void DropDownMenu()
    {
        string rol = (string)(Session[RecursoMaster.sessionRol]);
        string[] permisos;//se guardaran los permisos asociados a cada opcion del menu.xml
        XmlDocument doc = new XmlDocument();
        string icon;//se guardaran para cargarel icono del menu
        int i = 0; //iteracion de posicionOpciones
        doc.Load(Server.MapPath("~/Content/Menu.xml"));
        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
            i = 0;
            permisos = node.Attributes[RecursoMaster.rolTag].InnerText.Split(char.Parse(RecursoMaster.splitRoles));
            if (validateRol(permisos, rol))
            {
                icon = node.Attributes[RecursoMaster.imgTag].Value;
                string[,] positionOpcinon = new string[2, node.ChildNodes.Count];
                foreach (XmlNode subNode in node.ChildNodes)
                {

                    positionOpcinon[0, i] = (string)subNode.Attributes[RecursoMaster.nameTag].InnerText.ToString();
                    positionOpcinon[1, i] = subNode.Attributes[RecursoMaster.linkTag].InnerText.ToString();
                    i++;

                }

                subpositionOpcinonMenu[node.Attributes[RecursoMaster.nameTag].InnerText + ":" + node.Attributes[RecursoMaster.imgTag].InnerText] = positionOpcinon;
            }

        }
    }
    /// <summary>
    /// Valida si el Rol del usuario esta contenido en el menu 
    /// </summary>
    /// <param name="Rolm">Roles contenidos en el menu</param>
    /// <param name="rolUser">rol del usuario</param>
    /// <returns>true si el rol dle usuario esta en la opcion del menu ,false si no esta</returns>
    protected Boolean validateRol(string[] Rolm, string rolUser)
    {
        foreach (string rol in Rolm)
        {
            if (rol == rolUser)
                return true;
        }
        return false;
    }

    protected void closesecion(object sender, EventArgs e)
    {

        Session[RecursoMaster.sessionRol] = null;
        Session[RecursoMaster.sessionName] = null;
        Session[RecursoMaster.sessionLastname] = null;
        Session[RecursoMaster.sessionUserID] = null;
        Session[RecursoMaster.sessionRestaurantID] = null;
        Response.Redirect("~/Login.aspx");

    }


}


