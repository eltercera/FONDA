package com.ds201625.fonda.logic;

/**
 * Interfaz de un comando
 */
public interface Command {

    /**
     * Ejecución de un comando
     */
    void run() throws Exception;

    /**
     * Asignar el valor a un parametro
     * @param index posición del parametro
     * @param data objeto a contener
     */
    void setParameter(int index, Object data) throws Exception;

    /**
     * Obtiene el resultado del commando
     * @return objeto que resulta de la ejecución
     */
    Object getResult();

}
