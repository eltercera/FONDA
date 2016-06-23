package com.ds201625.fonda.logic.Commands.ProfileCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PostProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para crear un perfil
 */
public class CreateProfileCommand extends BaseCommand {

    private String TAG = "CreateProfileCommand";

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
    protected void invoke() throws PostProfileFondaWebApiControllerException {

        Log.d(TAG, "Comando para agregar un perfil a un commensal");
        Profile profile;

        ProfileService profileService = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
        try
        {
            profile = (Profile) getParameter(0);
            profileService.addProfile(profile);
        }catch(PostProfileFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            throw  new PostProfileFondaWebApiControllerException(e);
        }
        catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            throw  new PostProfileFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil", e);
            throw  new PostProfileFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al agregar un Perfil");
            throw  new PostProfileFondaWebApiControllerException(e);
        }

        setResult(true);
    }
}
