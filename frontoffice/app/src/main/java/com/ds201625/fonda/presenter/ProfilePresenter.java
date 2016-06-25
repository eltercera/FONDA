
package com.ds201625.fonda.presenter;

import android.util.Log;

import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetProfilesFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PostProfileFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.PutProfileFondaWebApiControllerException;
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
        public Boolean createProfile(Profile profile) throws PostProfileFondaWebApiControllerException {
            Log.d(TAG,"Metodo createProfile");
            Boolean resp = false;
            try {
                Command commandoCreateProfile = FondaCommandFactory.createProfileCommand();
                commandoCreateProfile.setParameter(0, profile);
                commandoCreateProfile.run();
                resp = (boolean) commandoCreateProfile.getResult();
            }catch(PostProfileFondaWebApiControllerException e){
                Log.e(TAG, "Se ha generado error al agregar un Perfil", e);
                throw  new PostProfileFondaWebApiControllerException(e);
            }
            catch (RestClientException e) {
                Log.e(TAG, "Se ha generado error al agregar un Perfil", e);
                throw  new PostProfileFondaWebApiControllerException(e);
            } catch (NullPointerException e) {
                Log.e(TAG, "Se ha generado error al agregar un Perfil", e);
                throw  new PostProfileFondaWebApiControllerException(e);
            } catch (Exception e) {
                Log.e(TAG, "Se ha generado error al agregar un Perfil");
                throw  new PostProfileFondaWebApiControllerException(e);
            }
            Log.d(TAG,"Cierre del Metodo createProfile");
            return resp;
        }

        @Override
        public Boolean updateProfile(Profile profile) throws PutProfileFondaWebApiControllerException {
            Log.d(TAG,"Metodo updateProfile");
            Boolean resp = false;
            try {
                Command commandoUpdateProfile = FondaCommandFactory.updateProfileCommand();
                commandoUpdateProfile.setParameter(0,profile);
                commandoUpdateProfile.run();
                resp = (boolean) commandoUpdateProfile.getResult();
            }catch(PutProfileFondaWebApiControllerException e){
                Log.e(TAG, "Se ha generado error al editar un Perfil", e);
                throw  new PutProfileFondaWebApiControllerException(e);
            }
            catch (RestClientException e) {
                Log.e(TAG, "Se ha generado error al editar un Perfil", e);
                throw  new PutProfileFondaWebApiControllerException(e);
            } catch (NullPointerException e) {
                Log.e(TAG, "Se ha generado error al editar un Perfil", e);
                throw  new PutProfileFondaWebApiControllerException(e);
            } catch (Exception e) {
                Log.e(TAG, "Se ha generado error al editar un Perfil");
                throw  new PutProfileFondaWebApiControllerException(e);
            }
            Log.d(TAG,"Cierre del Metodo updateProfile");
            return resp;
        }

        @Override
        public Boolean deleteProfile(Profile profile) throws DeleteProfileFondaWebApiControllerException {
            Log.d(TAG,"Metodo deleteProfile");
            Boolean resp = false;
            try {
                Command commandoDeleteProfile = FondaCommandFactory.
                        deleteProfileCommand();
                commandoDeleteProfile.setParameter(0,profile);
                commandoDeleteProfile.run();
                resp = (boolean) commandoDeleteProfile.getResult();
            }catch(DeleteProfileFondaWebApiControllerException e){
                Log.e(TAG, "Se ha generado error al eliminar un Perfil", e);
                throw  new DeleteProfileFondaWebApiControllerException(e);
            }
            catch (RestClientException e) {
                Log.e(TAG, "Se ha generado error al eliminar un Perfil", e);
                throw  new DeleteProfileFondaWebApiControllerException(e);
            } catch (NullPointerException e) {
                Log.e(TAG, "Se ha generado error al eliminar un Perfil", e);
                throw  new DeleteProfileFondaWebApiControllerException(e);
            } catch (Exception e) {
                Log.e(TAG, "Se ha generado error al eliminar un Perfil");
                throw  new DeleteProfileFondaWebApiControllerException(e);
            }
            Log.d(TAG,"Cierre del Metodo deleteProfile");
            return resp;
        }

        @Override
        public List<Profile> getProfiles() throws GetProfilesFondaWebApiControllerException {
            Log.d(TAG,"Metodo getProfiles");
            List<Profile> resp = null;
            try {
                Command commandoGetProfiles = FondaCommandFactory.getProfilesCommand();
                commandoGetProfiles.run();
                resp = (List<Profile>) commandoGetProfiles.getResult();
            }catch(GetProfilesFondaWebApiControllerException e){
                Log.e(TAG, "Se ha generado error al obtener los perfiles", e);
                throw  new GetProfilesFondaWebApiControllerException(e);
            }
            catch (RestClientException e) {
                Log.e(TAG, "Se ha generado error al obtener los perfiles", e);
                throw  new GetProfilesFondaWebApiControllerException(e);
            } catch (NullPointerException e) {
                Log.e(TAG, "Se ha generado error al obtener los perfiles", e);
                throw  new GetProfilesFondaWebApiControllerException(e);
            } catch (Exception e) {
                Log.e(TAG, "Se ha generado error al obtener los perfiles");
                throw  new GetProfilesFondaWebApiControllerException(e);
            }
            Log.d(TAG,"Cierre del Metodo getProfiles");
            return resp;
        }

}
