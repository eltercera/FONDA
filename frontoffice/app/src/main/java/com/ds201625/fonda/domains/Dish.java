package com.ds201625.fonda.domains;

/**
 * Created by Katherina Molina on 10/05/2016.
 */
public class Dish extends NounBaseEntity{

    private String description;
    private float cost;
    private String image;
    private Boolean suggestion;


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

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public float getCost() {
        return cost;
    }

    public void setCost(Float cost) {
        this.cost = cost;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public Boolean getSuggestion() {
        return suggestion;
    }

    public void setSuggestion(Boolean suggestion) {
        this.suggestion = suggestion;
    }

}
