
package com.ds201625.fonda.logic.Commands.ProfileCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetProfilesFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Comando para buscar los perfiles de un commensal
 */
public class GetProfilesCommand extends BaseCommand {

    private String TAG = "GetProfilesCommand";

    /**
     * No tiene Parametros
     * @return
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[0];
        return parameters;
    }

    @Override
    protected void invoke() throws GetProfilesFondaWebApiControllerException {

        Log.d(TAG, "Comando para buscar los perfiles de un commensal");
        List<Profile> profiles = null;

        ProfileService profileService = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
        try
        {
            profiles = profileService.getProfiles();
        }
        catch(GetProfilesFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al obtener los perfiles", e);
            throw  new GetProfilesFondaWebApiControllerException(e);
        }
        catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los perfiles", e);
            throw  new GetProfilesFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los perfiles", e);
            throw  new GetProfilesFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al obtener los perfiles");
            throw  new GetProfilesFondaWebApiControllerException(e);
        }

        setResult(profiles);
    }
}
