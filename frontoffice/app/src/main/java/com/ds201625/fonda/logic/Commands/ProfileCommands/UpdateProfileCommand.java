package com.ds201625.fonda.logic.Commands.ProfileCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para crear un perfil
 */
public class UpdateProfileCommand extends BaseCommand {

    private String TAG = "UpdateProfileCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro Profile
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Profile.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {

        Log.d(TAG, "Comando para modificar un perfil a un commensal");
        Profile profile;

        ProfileService profileService = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
        try
        {
            profile = (Profile) getParameter(0);
            profileService.editProfile(profile);
        }
        catch (RestClientException e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            e.printStackTrace();
        }
        catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            e.printStackTrace();
        }
        catch (Exception e)
        {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            e.printStackTrace();
        }

        setResult(true);
    }
}
