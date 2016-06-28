package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicCurrentOrderFondaWebApiControllerException;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.DishOrder;

import java.util.List;

/**
 * Created by Jessica on 20/06/2016.
 */

/**
 * Interface de CurrentOrderService
 */
public interface EmailService {

Commensal getEmail (String email) throws RestClientException;

}
