package com.ds201625.fonda.logic.Commands.ProfileCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.CommandInternalErrorException;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.ParameterOutOfIndexException;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para eliminar un perfil
 */
public class DeleteProfileCommand extends BaseCommand {

    private String TAG = "DeleteProfileCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro id Profile
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Profile.class, true);

        return parameters;
    }

    @Override
    protected void invoke() throws Exception {

        Log.d(TAG, "Comando para eliminar un perfil de un commensal logeado");
        int idProfile;
        Profile profile;

        ProfileService profileService = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
        try
        {
            profile = (Profile) getParameter(0);
            idProfile = profile.getId();
            profileService.deleteProfile(idProfile);
            Log.d(TAG, "Se elimino el Perfil: " + profile.getProfileName());
        }
        catch (ParameterOutOfIndexException e) {
            Log.e("Fonda Command",e.getMessage());
            throw CommandInternalErrorException.generate(this.getClass().toString(),e);
        }

        setResult(true);
        Log.d(TAG, "Se elimino con exito el Perfil. Result: " + getResult().toString());
        Log.d(TAG, "Se elimino con exito el Perfil");
    }
}
