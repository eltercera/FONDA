package com.ds201625.fonda.domains.entities;

/**
 * Created by Katherina Molina on 10/05/2016.
 */

/*
 Clase quee representa el plato del restaurant
 */
public class Dish extends NounBaseEntity {

    /**
     * String que define la descripcion del plato
     */
    private String description;

    /**
     * Float que define el costo del plato
     */
    private float cost;

    /**
     * String que define la imagen del plato
     */
    private String image;

    /**
     * Boolean que define si plato es la sugerencia del dia o no
     */
    private Boolean suggestion;


    /**
     Contructor de la clase plato
     */
    public Dish() {
        super();
    }

    public Dish(String description, float cost, String image, Boolean suggestion ) {
        this.description = description;
        this.cost = cost;
        this.image = image;
        this.suggestion = suggestion;
    }

    public Dish(String name,String description, float cost,String image) {
        this.setName(name);
        this.description = description;
        this.cost = cost;
        this.image = image;
    }

    /**
     * Metodo que obtiene la description del plato
     * @return description
     */
    public String getDescription() {
        return description;
    }

    /**
     * Metodo que asigna la description del plato
     * @param description
     */
    public void setDescription(String description) {
        this.description = description;
    }

    /**
     * Metodo que obtiene el costo del plato
     * @return cost
     */
    public float getCost() {
        return cost;
    }

    /**
     * Metodo que asigna la costo del plato
     * @param cost
     */
    public void setCost(Float cost) {
        this.cost = cost;
    }

    /**
     * Metodo que obtiene la imagen del plato
     * @return image
     */
    public String getImage() {
        return image;
    }

    /**
     * Metodo que asigna la imagen del plato
     * @param image
     */
    public void setImage(String image) {
        this.image = image;
    }

    /**
     * Metodo que obtiene la sugerencia del plato
     * @return suggestion
     */
    public Boolean getSuggestion() {
        return suggestion;
    }

    /**
     * Metodo que asigna la sugerencia del plato
     * @param suggestion
     */
    public void setSuggestion(Boolean suggestion) {
        this.suggestion = suggestion;
    }

}
