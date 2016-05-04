package com.ds201625.fonda.domains;

import java.util.List;

/**
 * Created by rrodriguez on 5/4/16.
 */
public class Commensal extends UserAccount {

    private List<Reservation> reservarions;

    private List<Restaurant> favoritesRestaurants;

    private List<Profile> profiles;

    public Commensal() {
        super();
    }

    public List<Reservation> getReservarions() {
        return reservarions;
    }

    public void setReservarions(List<Reservation> reservarions) {
        this.reservarions = reservarions;
    }

    public void addReservation(Reservation reservation) {
        this.reservarions.add(reservation);
    }

    public  void removeReservation(Reservation reservation){
        this.reservarions.remove(reservation);
    }

    public List<Profile> getProfiles() {
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
    }

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
