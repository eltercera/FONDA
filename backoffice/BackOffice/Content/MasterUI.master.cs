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

        /*  try
            {
            ///verifica si un usuario esta en el sistema
       if (Session[RecursoMaster.sessionUserID] != null)
                {*/
        Session[RecursoMaster.sessionRol] = "Sistema";// rol del usuario log solo para control de prueba
                    DropDownMenu();
               /* }
         else   
             Response.Redirect(RecursoMaster.addressLogin);
         }
     catch (NullReferenceException ex)
     {
         //Response.Redirect(RecursoMaster.addressLogin);
     }
     catch (Exception ex)
     {

     } */
    }

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
            permisos = node.Attributes[sessionTag.rolTag].InnerText.Split(char.Parse(RecursoMaster.splitRoles));
               if (validateRol(permisos, rol))
                {
            icon = node.Attributes[sessionTag.imgTag].Value;
            string[,] positionOpcinon = new string[2, node.ChildNodes.Count];
            foreach (XmlNode subNode in node.ChildNodes)
            {

                positionOpcinon[0, i] = (string)subNode.Attributes[sessionTag.nameTag].InnerText.ToString();
                positionOpcinon[1, i] = subNode.Attributes[sessionTag.linkTag].InnerText.ToString();
                i++;

            }

            subpositionOpcinonMenu[node.Attributes[sessionTag.nameTag].InnerText + ":" + node.Attributes[sessionTag.imgTag].InnerText] = positionOpcinon;
        }

        }
    }

    protected Boolean validateRol(string[] permisos, string rolUser)
        {
            foreach (string rol in permisos)
            {
                if (rol == rolUser)
                    return true;
            }
            return false;
        }
    

}
        
   
