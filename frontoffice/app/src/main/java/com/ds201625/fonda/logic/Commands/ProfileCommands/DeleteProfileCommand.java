package com.ds201625.fonda.logic.Commands.ProfileCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
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
    protected void invoke() throws DeleteProfileFondaWebApiControllerException {

        Log.d(TAG, "Comando para eliminar un perfil a un commensal");
        int idProfile;
        Profile profile;

        ProfileService profileService = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
        try
        {
            profile = (Profile) getParameter(0);
            idProfile = profile.getId();
            profileService.deleteProfile(idProfile);
        }catch(DeleteProfileFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al eliminar un Perfil", e);
            throw  new DeleteProfileFondaWebApiControllerException(e);
        }
        catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar un Perfil", e);
            throw  new DeleteProfileFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar un Perfil", e);
            throw  new DeleteProfileFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar un Perfil");
            throw  new DeleteProfileFondaWebApiControllerException(e);
        }

        setResult(true);
    }
}
