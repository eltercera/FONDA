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
using com.ds201625.fonda.Resources.FondaResources.Login;

public partial class MasterUI : System.Web.UI.MasterPage
{
    private Dictionary<string, string> opcionMenu = new Dictionary<string, string>();
    private Dictionary<string, string[,]> subpositionOpcinonMenu = new Dictionary<string, string[,]>(); //Se guardaran las sub opciones del menú
    /// <summary>
    /// metodo encargado de setear las opciones dle menu
    /// </summary>
    public Dictionary<string, string> OpcionMenu
    {
        get { return opcionMenu; }
        set { opcionMenu = value; }
    }
    /// <summary>
    /// metodo encargado de setear las subopciones del menu
    /// </summary>
    public Dictionary<string, string[,]> SubpositionOpcinonMenu
    {
        get { return subpositionOpcinonMenu; }
        set { subpositionOpcinonMenu = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        System.Diagnostics.Debug.WriteLine("entre modify code behind");
        try
        {
            ///verifica si un usuario esta en el sistema
            if (Session[ResourceLogin.sessionUserID] != null)
            {
                DropDownMenu();
            }
            else
                Response.Redirect(RecursoMaster.addressLogin);
        }
        catch (NullReferenceException ex)
        {
            
        }
        catch (Exception ex)
        {

        }
    }
    /// <summary>
    /// Metodo que permite permite hacer la carga del Menu lateral 
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
    /// <summary>
    /// Metodo que permite el cierre de secion
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void closesecion(object sender, EventArgs e)
    {

        Session[ResourceLogin.sessionRol] = null;
        Session[ResourceLogin.sessionName] = null;
        Session[ResourceLogin.sessionLastname] = null;
        Session[ResourceLogin.sessionUserID] = null;
        Session[ResourceLogin.sessionRestaurantID] = null;
        Response.Redirect("~/Login.aspx");

    }


}


