package com.ds201625.fonda.domains;

/**
 * Created by Hp on 22/05/2016.
 */

/**
 * Class that represents the payment with credit card
 */
public class CreditCarPayment {

    /**
     * Last 4 digits of credit card
     */
    private int lastCardDigits;

    /**
     * Constructors of the class
     */
    public CreditCarPayment(){
        super();
    }
    public CreditCarPayment(int lastCardDigits) {
        this.lastCardDigits = lastCardDigits;
    }

    /**
     * Get the last 4 digits of the credit card
     * @return the last 4 digits
     */
    public int getLastCardDigits() {
        return lastCardDigits;
    }

    /**
     * Set the last 4 digits of the credit card
     * @param lastCardDigits receives the last 4 digits
     */
    public void setLastCardDigits(int lastCardDigits) {
        this.lastCardDigits = lastCardDigits;
    }
}
