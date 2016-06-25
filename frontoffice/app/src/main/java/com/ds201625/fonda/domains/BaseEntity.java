package com.ds201625.fonda.domains;

import java.io.Serializable;

/**
 * Class base para las entidades.
 */
public abstract class BaseEntity extends Object implements Serializable {

    /**
     * Identificador de la entidad.
     */
    private int id;

    public BaseEntity() {
        super();
    }

    /**
     * Obtine el identificador de la entidad.
     * @return El identificador de la entidad.
     */
    public int getId() {
        return id;
    }

    /**
     * Asignacion de identificador de la entidad.
     * @param id El identificador a asignar.
     */
    protected void setId(int id) {
        this.id = id;
    }
}
