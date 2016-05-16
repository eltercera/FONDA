package com.ds201625.fonda.data_access.services;

import android.content.Context;
import com.ds201625.fonda.domains.Commensal;


/**
 * Created by rrodriguez on 5/12/16.
 */
public interface CommensalService {

    Commensal RegisterCommensal(String user, String password, Context context);

    Commensal getCommensal(Context context);

}
