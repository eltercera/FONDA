package com.ds201625.fonda.data_access.services;

import android.content.Context;

import com.ds201625.fonda.data_access.local_storage.LocalStorageException;
import com.ds201625.fonda.domains.Token;

/**
 * Interfaz para el servicio del token
 */
public interface TokenService {

    /**
     * Obtiene el token
     * @param context
     * @return
     */
    Token getToken(Context context) throws LocalStorageException, Exception;

    /**
     * Obtiene un nuevo token
     * @param context
     * @return
     * @throws Exception
     */
    Token createToken(Context context) throws Exception;

    /**
     * Elimina un token al cerrar sesion
     * @param context
     * @return
     * @throws Exception
     */
    void removeToken(Context context) throws Exception;

}
