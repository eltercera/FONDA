package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.AddFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.DeleteFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.GetAllRestaurantsFondaWebApiControllerException;

/**
 * Base para los comandos
 */
public abstract class BaseCommand implements Command {

    /**
     * Parametos
     */
    private Parameter[] parameters;

    /**
     * Para contener el resultado del la ejecucion
     */
    private Object result;

    /**
     * Constructor unico
     */
    public BaseCommand() {
        this.result = null;
        this.parameters = this.setParameters();
    }

    /**
     * Obtiene el resultado
     * @return resultado
     */
    public Object getResult() {
        return  this.result;
    }

    /**
     * Asigna el resultado
     * @param data
     */
    protected void setResult(Object data) {
        this.result = data;
    }

    /**
     * Invocacion a la ejecuncion del comando
     * @throws Exception
     */
    @Override
    public void run() throws Exception {
        this.validateParameters();
        this.invoke();
    }

    /**
     * Asignar parametros
     * @param index posición del parametro
     * @param data objeto a contener
     * @throws Exception
     */
    @Override
    public void setParameter(int index, Object data)
            throws ParameterOutOfIndexException,InvalidParameterTypeException {

        if (this.parameters == null) {
            return;
        }

        if ( index < 0 || index >= this.parameters.length)
            throw ParameterOutOfIndexException.generate(this.getClass().toString(),index);

        parameters[index].setData(data);
    }

    /**
     * Obtener un parametro
     * @param index posicion
     * @return Objeto que contiene el parametro
     * @throws Exception
     */
    protected Object getParameter(int index) throws ParameterOutOfIndexException {
        if (this.parameters == null)
            throw ParameterOutOfIndexException.generate(this.getClass().toString(),index);

        if ( index < 0 || index >= this.parameters.length)
            throw ParameterOutOfIndexException.generate(this.getClass().toString(),index);

        return parameters[index].getData();
    }

    /**
     * Para la inicializacion de los parametros
     * @return
     */
    protected abstract Parameter[] setParameters();

    /**
     * Invocacion de la acción del comando
     */
    protected abstract void invoke() throws Exception;


    /**
     * Valida los parametros requeridos
     * @throws Exception
     */
    private void validateParameters() throws EmptyRequieredParameterException {
        if (this.parameters == null) {
            return;
        }
        for (int i = 0; i < parameters.length; i++) {
            if (parameters[i].isRequiered() && parameters[i].getData() == null)
                throw EmptyRequieredParameterException.generate(this.getClass().toString(),i);
        }
    }
}

