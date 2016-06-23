package com.ds201625.fonda.domains;

import java.util.List;

/**
 * Clase dominio de Commansal
 */
public class Commensal extends UserAccount {

    private List<Reservation> reservations;

    private List<Restaurant> favoritesRestaurants;

    // Esto no es necesario
    //private List<Profile> profiles;

    public Commensal() {
        super();
    }

    public Commensal(int id) {
        this.setId(id);
    }


    public List<Reservation> getReservations() {
        return reservations;
    }

    public void setReservations(List<Reservation> reservations) {
        this.reservations = reservations;
    }

    public void addReservation(Reservation reservation) {
        this.reservations.add(reservation);
    }

    public  void removeReservation(Reservation reservation){
        this.reservations.remove(reservation);
    }

    // Esto no es necesario
    /*public List<Profile> getProfiles() {
        return profiles;
    }

    public void setProfiles(List<Profile> profiles) {
        this.profiles = profiles;
    }

    public void addProfile(Profile profile) {
        this.profiles.add(profile);
    }

    public  void removeProfile(Profile profile){
        this.profiles.remove(profile);
    }*/

    public List<Restaurant> getFavoritesRestaurants() {
        return favoritesRestaurants;
    }

    public void setFavoritesRestaurants(List<Restaurant> favoritesRestaurants) {
        this.favoritesRestaurants = favoritesRestaurants;
    }

    public void addfavoritesRestaurant(Restaurant restaurant) {
        this.favoritesRestaurants.add(restaurant);
    }

    public  void removeFavoritesRestaurant(Restaurant restaurant){
        this.favoritesRestaurants.remove(restaurant);
    }

}
