package com.ds201625.fonda.logic;

/**
 * Clase que representa un parametro
 */
public class Parameter {

    /**
     * Tipo de dato a contener
     */
    private Class dataType;

    /**
     * Objeto que se contiene
     */
    private Object data;

    /**
     * Si el parametro es requerido
     */
    private boolean requiered;

    /**
     * Contructor completo
     * @param dataType tipo de dato
     * @param requiered si es requerido
     */
    public Parameter (Class dataType, boolean requiered) {
        this.data = null;
        this.dataType = dataType;
        this.requiered = requiered;
    }

    /**
     * Contructor a medias (requiered = false)
     * @param dataType tipo de dato
     */
    public Parameter (Class dataType) {
        this.data = null;
        this.dataType = dataType;
        this.requiered = false;
    }

    /**
     * Asigna el objeto a contener
     * @param data objeto a contener
     * @throws Exception
     */
    public void setData(Object data) throws Exception {
        if (data == null)
            return;
        if(!dataType.isAssignableFrom(data.getClass()))
            //TODO: Crear excepción personalizada
            throw new Exception("Se expera un tipo de datos " + dataType.toString()
                    + " y se paso un tipo " + data.getClass().toString());
        this.data = data;
    }

    /**
     * Obtiene el objeto contenido
     * @return objeto contenido
     */
    public Object getData() {
        return this.data;
    }

    /**
     * Si es requerido (true), de otro modo (false)
     * @return
     */
    public boolean isRequiered() {
        return requiered;
    }
}
