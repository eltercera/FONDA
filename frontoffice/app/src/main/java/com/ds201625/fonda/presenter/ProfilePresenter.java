package com.ds201625.fonda.presenter;

import android.util.Log;

import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.interfaces.IProfileItemView;
import com.ds201625.fonda.interfaces.IProfileListView;
import com.ds201625.fonda.interfaces.IProfileView;
import com.ds201625.fonda.interfaces.IProfileViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;

import java.util.List;

/**
 * Created by jessi_ds930h9 on 22/6/2016.
 */
public class ProfilePresenter implements IProfileViewPresenter {

    private IProfileListView profileListView;
    private IProfileView profileView;
    private IProfileItemView profileItemView;
    private String TAG = "ProfilePresenter";
    /**
     * Constructor para la vita de ProfileListFraggment
     * @param view
     */
    public ProfilePresenter (IProfileListView view){ profileListView = view;}

    /**
     * Constructor para la vita de ProfileActivity
     * @param view
     */
    public ProfilePresenter (IProfileView view){ profileView = view;}

        @Override
        public Boolean createProfile(Profile profile) {
            Boolean resp = false;
            try {
                Command commandoCreateProfile = FondaCommandFactory.createProfileCommand();
                commandoCreateProfile.setParameter(0, profile);
                commandoCreateProfile.run();
                resp = (boolean) commandoCreateProfile.getResult();
            } catch (Exception e)
            {
                Log.e(TAG,"Error al crear Perfil",e);
            }
            return resp;
        }

        @Override
        public Boolean updateProfile(Profile profile) {
            Boolean resp = false;
            try {
                Command commandoUpdateProfile = FondaCommandFactory.updateProfileCommand();
                commandoUpdateProfile.setParameter(0,profile);
                commandoUpdateProfile.run();
                resp = (boolean) commandoUpdateProfile.getResult();
            } catch (Exception e)
            {
                Log.e(TAG,"Error al crear Perfil",e);
            }
            return resp;
        }

        @Override
        public Boolean deleteProfile(Profile profile) {
            Boolean resp = false;
            try {
                Command commandoDeleteProfile = FondaCommandFactory.
                        deleteProfileCommand();
                commandoDeleteProfile.setParameter(0,profile);
                commandoDeleteProfile.run();
                resp = (boolean) commandoDeleteProfile.getResult();
            } catch (Exception e)
            {
                Log.e(TAG,"Error al eliminar el Perfil",e);
            }
            return resp;
        }

        @Override
        public List<Profile> getProfiles() {
            List<Profile> resp = null;
            try {
                Command commandoGetProfiles = FondaCommandFactory.getProfilesCommand();
                commandoGetProfiles.run();
                resp = (List<Profile>) commandoGetProfiles.getResult();
            } catch (Exception e)
            {
                Log.e(TAG,"Error al eliminar el Perfil",e);
            }
            return resp;
        }

}
