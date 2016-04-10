# FONDA
FONDA - PROYECTO DE DESARROLLO DE SOFTWARE 1516B - SECCIÓN 1

Fonda es un sistema que pretende automatizar toda la gestión de un restaurante, no solo
desde el punto de vista administrativo, sino también desde el punto de vista
del cliente ofreciendo a través de las tecnologías una nueva experiencia de
avanzada desde un dispositivo inteligente.

# FrontOffice

## Estructura del Proyecto - Directorios

## Estandar de Diseño y UI

# BackOffice

## Estructura del Proyecto - Directorios
```
├── App_Data/
├── App_Start/
├── Content/
│   ├── css/
│   │   ├── styles.css    //Este es el documento donde se añadirán los estilos que necesiten crear.
│   ├── js/               //En esta carpeta va cualquier script de JS que necesiten para sus vistas. Si son varios archivos por herramienta, agruparlos en un directorio.
│   ├── img/              //En esta carpeta va cualquier imagen que necesiten incluir en el proyecto.
│   ├── MasterUI.master   //Esta es la MasterPage. NO modificar.
├── Controllers/          //Aqui iran todos los controladores del servicio web.
├── Models/               
├── scripts/              //Esto es propio del proyecto base creado por Visual.
├── Seccion/              //Aqui se encuentran todas las vistas, divididas por secciones del menu. Aqui van TODAS las interfaces de la 1ra entrega.
│   ├── Caja
│   ├── Configuracion
│   ├── Menu
│   ├── Restaurante
├── Default.aspx          //Pagina Principal
├── Login.aspx            //Pagina de Inicio de Sesión
├── Recuperacion.aspx     //Pagina de Recuperacion de Contraseña
```

## Estandar de Diseño y UI

### Demo
* [BackOffice] [demo]

### General
- Todos los elementos deben seguir el estandar de los documentos CSS.
- Para aplicar las clases en los WebControls de ASP se realiza con el atributo CssClass
### Utilizar la MasterPage

Para incluir la MasterPage en cada una de las paginas a elaborar, se debe indicar en la siguiente etiqueta donde indica **'MasterPageFile'**, como se muestra a continuación:

```html
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ejemplo.aspx.cs" Inherits="ejemplo" MasterPageFile="MasterUI.master" %>
```
Es indispensable establecer el contenido de los contenedores de la Master Page con las siguientes etiquetas:
```html
<asp:Content runat="server" ContentPlaceHolderId="pagina"></asp:Content>
```

> SOLO TEXTO. Etiqueta para definir el titulo de la pestaña o ventana del browser. Cualquier texto ingresado se concatenara con "FONDA - " resultando en "FONDA - #########"

```html
<asp:Content runat="server" ContentPlaceHolderId="titulo"></asp:Content>
```

> SOLO TEXTO. Etiqueta para definir el titulo de la sección en que se encuentra el usuario. Debe corresponder con alguna de las opciones PRINCIPALES del menu. Ej: Menu

```html
<asp:Content runat="server" ContentPlaceHolderId="subtitulo"></asp:Content>
```

> SOLO TEXTO. Etiqueta para definir el subtitulo de la seccion en que se encuentre el usuario. Debe corresponder con las acciones que se lleven a cabo en la pagina. Ej: Modificar menu

```html
<asp:Content runat="server" ContentPlaceHolderId="migas"></asp:Content>
```

> ETIQUETAS < li > CON ICONO < i > Y TEXTO. Etiqueta para definir las migas de pan de la pagina. Las migas de pan deben indicar la ruta que habria seguido el usuario para llegar a la pagina actual. Todos los elementos, exceptuando el que indica la pagina actual, deben ser un enlace.

```html
<asp:Content runat="server" ContentPlaceHolderId="contenido"></asp:Content>
```

> CONTENIDO HTML. Etiqueta para incrustar todo el codigo HTML correspondiente a la pagina.

### Maquetación
- La maquetación de la interfaz se realizará con el sistema de grillas (grid) de Bootstrap.

### Botones, Alerts y Paneles
- Las clases btn-info y label-info aunque estan definidas, NO se usaran, pues no guardan relacion con la paleta de colores.
- Los botones de acción por defecto serán del tipo Primary 'btn-primary'
- Los botones de éxito por defecto serán del tipo Success 'btn-success'
- Los botones de éxito en pantallas de modificación tendrán el texto 'Aceptar'
- Los botones de éxito en creación o ingreso de información tendrán el texto 'Agregar'
- Los botones de cancelación serán del tipo Danger 'btn-danger' y tendrán el texto 'Cancelar'
- Los botones de los formularios van en la parte inferior derecha de los mismos. El Cancelar a la derecha del boton de tipo Success
- Las clases panel-success, panel-warning, panel-info, panel-danger, aunque estan declaradas, no se usarán, pues no guardan relación con la paleta de colores.
- La clase panel default es el panel por defecto si el mismo no tiene ninguna intención en especial, mas que decoración o maquetación.
- Las clases panel-blue, panel-green, panel-yellow y panel-red corresponden en uso a lo que seria panel-info, panel-success, panel-warning y panel-danger respectivamente. Por lo tanto blue es para informar, green para indicar exito, yellow para advertir y red para indicar error.
- Se debe indicar cuando el envío de un formulario fue realizado correctamente con un alert-success
- Se debe indicar cuando el envío de un formulario no pudo ser completado con un alert-danger
- Para realizar advertencias se debe usar el alert-warning
- Para proveer información 'extra' en el llenado de formularios o en la interfaz en general se debe usar alert-info

### Texto
- No se modificarán los tamaños definidos, el color, ni las fuentes utilizadas.
- Para resaltar palabras claves de un texto, se usará la etiqueta < strong >

### Colores
En el caso del FrontEnd del BackOffice, ya estan todos los que utilizaremos establecidos en los archivos CSS, si llegara a faltar en algun elemento que utilicen o no se ha cambiado y se rompe el diseño, avisar por Slack. Aqui se indican los colores para ser utilizados en el FrontEnd del FrontOffice:

- Azul: #C5E0DC - Oscuro: #31708f
- Verde: #ACD691 - Oscuro: #3d8b3d
- Amarillo: #F1D4AF - Oscuro: #df8a13
- Rojo: #E08E79 - Oscuro: #b52b27
- Beige: #ECE5CE


[demo]: <http://gbsojo.github.io/BackOfficeTemplate>
