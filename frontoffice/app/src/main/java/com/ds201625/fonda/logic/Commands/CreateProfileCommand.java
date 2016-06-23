package com.ds201625.fonda.logic.Commands;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para crear un perfil
 */
public class CreateProfileCommand extends BaseCommand {

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Profile.class, true);

        return parameters;
    }

    @Override
    protected void invoke() {

        Profile profile = null;
        try {
            profile = (Profile) getParameter(0);
        } catch (Exception e) {
            e.printStackTrace();
        }
        try {
            profile = (Profile) this.getParameter(1);
        } catch (Exception e) {
            e.printStackTrace();
        }

        ProfileService ps = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());

        try {
            ps.addProfile(profile);
        } catch (RestClientException e) {
            e.printStackTrace();
        }

        setResult(true);
    }

    @Override
    protected void invokeF() {
    }
    }
