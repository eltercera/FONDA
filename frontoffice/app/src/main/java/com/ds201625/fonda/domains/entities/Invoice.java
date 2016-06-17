package com.ds201625.fonda.domains.entities;

import com.ds201625.fonda.domains.BaseEntity;

import java.util.Date;

/**
 * Created by Adri on 06/05/2016.
 */

/*
 Clase quee representa la factura del restaurant
 */
public class Invoice extends BaseEntity {

    /**
     * Float que define la propina de la cuenta
     */
    private float tip;

    /**
     * Date que define la fecha de pago de la cuenta
     */
    private Date date;

    /**
     *Float que define el impuesto del pago de la cuenta
     */
    private float tax;

    /**
     * Float que define el total de la cuenta
     */
    private float total;

    /**
     * Restaurant que define el restaurant asociado a la cuenta
     */
    private Restaurant restaurant;

    /**
     *Profile que define el perfil asociado a la cuenta
     */
    private Profile profile;

    /**
     *Currency que deifne el tipo de moneda a usar en la cuenta
     */
    private Currency currency;

    /**
     *Payment que define el pago de la cuenta
     */
    private Payment payment;

    /**
     *Account que define la cuenta
     */
    private Account account;


    /**
   Contructor de la clase factura
     */
    public Invoice() {
        super();
    }

    public Invoice(float tip, float tax, float total, Restaurant restaurant, Date date,
        Profile profile) {
        this.tip = tip;
        this.tax = tax;
        this.total = total;
        this.restaurant = restaurant;
        this.date = date;
        this.profile= profile;
    }

    public Invoice(float tip, float tax, float total, Restaurant restaurant, Date date,
        Profile profile, Currency currency,Payment payment, Account account) {
        this.tip = tip;
        this.tax = tax;
        this.total = total;
        this.restaurant = restaurant;
        this.date = date;
        this.profile= profile;
        this.currency= currency;
        this.payment= payment;
        this.account= account;
    }

    /**
     * Metodo que obtiene la propina de la cuenta
     * @return propina
     */
    public float getTip() {
        return tip;
    }

    /**
     * Metodo que asigna la propina de la cuenta
     * @param tip
     */
    public void setTip(Float tip) {
        this.tip = tip;
    }

    /**
     * Metodo que obtiene el impuesto de la cuenta
     * @return impuesto
     */
    public float getTax() {return tax;}

    /**
     * Metodo que asigna el impuesto de la cuenta
     * @param tax
     */
    public void setTax(Float tax) {
        this.tax = tax;
    }

    /**
     * Metodo que obtiene el total de la cuenta
     * @return total
     */
    public float getTotal() {
        return total;
    }

    /**
     * Metodo que asigna el total de la cuenta
     * @param total
     */
    public void setTotal(Float total) {
        this.total = total;
    }

    /**
     * Metodo que obtiene la fecha del pago de la cuenta
     * @return fecha
     */
    public Date getDate() {
        return date;
    }

    /**
     * Metodo que asigna la fecha del pago de la cuenta
     * @param date
     */
    public void setDate(Date date) {
        this.date = date;
    }

    /**
     * Metodo que obtiene el Restaurant asociado a la cuenta
     * @return pestaurante
     */
    public Restaurant getRestaurant() {
        return restaurant;
    }

    /**
     * Metodo que asigna un restaurant a la cuenta
     * @param restaurant
     */
    public void setRestaurant(Restaurant restaurant) {this.restaurant = restaurant;}

    /**
     * Metodo que obtiene un perfil asociado a la cuenta
     * @return perfil
     */
    public Profile getProfile() {
        return profile;
    }

    /**
     * Metodo que asigna un perfil a la cuenta
     * @param profile
     */
    public void setProfile(Profile profile) {this.profile = profile;}

    /**
     * Metodo que obtiene la moneda del pago de la cuenta
     * @return moneda
     */
    public Currency getCurrency() {
        return currency;
    }

    /**
     * Metodo que asigna una moneda a la cuenta
     * @param currency
     */
    public void setCurrency(Currency currency) {
        this.currency = currency;
    }

    /**
     * Metodo que obtiene el pago de la cuenta
     * @return pago
     */
    public Payment getPayment() {
        return payment;
    }

    /**
     * Metodo que asigna el pago de la cuenta
     * @param payment
     */
    public void setPayment(Payment payment) {
        this.payment = payment;
    }

    /**
     * Metodo que obtiene la Cuenta
     * @return cuenta
     */
    public Account getAccount() {
        return account;
    }

    /**
     * Metodo que asigna la cuenta
     * @param account
     */
    public void setAccount(Account account) {
        this.account = account;
    }
}

