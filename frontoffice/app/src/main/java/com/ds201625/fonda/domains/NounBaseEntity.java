package com.ds201625.fonda.domains;

import com.ds201625.fonda.domains.BaseEntity;

/**
 * Clase base Nombrada.
 */
public abstract class NounBaseEntity extends BaseEntity {

    /**
     * Sustantivo de la entidad
     */
    private String name;

    public NounBaseEntity() {
        super();
    }

    /**
     * Obtiene el sustantivo de la entidad
     * @return Sustantivo
     */
    public String getName() {
        return name;
    }

    /**
     * Asigna el susutantivo a la entidad
     * @param name el sustantivo
     */
    public void setName(String name) {
        this.name = name;
    }
}
