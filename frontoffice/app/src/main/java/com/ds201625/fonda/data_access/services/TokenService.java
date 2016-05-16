package com.ds201625.fonda.data_access.services;

import android.content.Context;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;

/**
 * Created by rrodriguez on 5/16/16.
 */
public interface TokenService {

    Token getToken(Context context);

    Token createToken(Context context);
}
