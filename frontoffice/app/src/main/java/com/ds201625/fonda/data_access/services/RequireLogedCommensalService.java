package com.ds201625.fonda.data_access.services;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.domains.Commensal;

/**
 * Interfaz para el servicio de Comensal logueado
 */
public interface RequireLogedCommensalService {

    Commensal getLogedCommensal(String email) throws RestClientException;

}
