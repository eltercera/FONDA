
package com.ds201625.fonda.data_access.services;

import android.content.Context;

import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.data_access.retrofit_client.InvalidDataRetrofitException;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.AddCommensalWebApiControllerException;
import com.ds201625.fonda.domains.Commensal;

/**
 * Inserfaz de servicio de commensal
 */
public interface CommensalService {

    /**
     * Registra un commensal
     * @param user Usuario
     * @param password Clave
     * @param context Contexto para el guardado local
     * @return
     * @throws InvalidDataRetrofitException
     * @throws RestClientException
     * @throws LocalStorageException
     */
    Commensal RegisterCommensal(String user, String password, Context context)
            throws InvalidDataRetrofitException, RestClientException, LocalStorageException, AddCommensalWebApiControllerException;



    /**
     * Borra el commenal guardado localmente si existe
     * @param context Contexto para el borrado local
     * @return Booleano de si se elimino o no.
     * @throws LocalStorageException
     */
    void deleteCommensal(Context context) throws LocalStorageException;

    /**
     * Obtiene el commensal guardado localmente si existe
     * @param context Contexto para el guardado local
     * @return el commensal.
     * @throws LocalStorageException
     */
    Commensal getCommensal(Context context) throws LocalStorageException;

    /**
     * Guardar un commensal localmente.
     * @param comeCommensal el commensal
     * @param context Contexto para el guardado local.
     * @throws LocalStorageException
     */
    void saveCommensal(Commensal comeCommensal,Context context) throws LocalStorageException;
}
