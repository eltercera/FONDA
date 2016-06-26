package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.views.contracts.IProfileViewContract;
import com.ds201625.fonda.views.presenters.ProfilePresenter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.ProfileEmptyFragment;
import com.ds201625.fonda.views.fragments.ProfileFormFragment;
import com.ds201625.fonda.views.fragments.ProfileListFragment;

import java.util.ArrayList;
import java.util.List;

/**
 * Activity de Perfil de usuario
 */
public class ProfileActivity extends BaseNavigationActivity
    implements ProfileListFragment.profileListFragmentListener, IProfileViewContract {

    private String TAG = "ProfileActivity";
    /**
     * Iten del Menu para guardar
     */
    private MenuItem saveBotton;

    /**
     * Fragment del formulario
     */
    private ProfileFormFragment profileFormFrag;

    /**
     * Fragment de la lista
     */
    private ProfileListFragment profileListFrag;
    /**
     * Fragment vacio
     */
    private ProfileEmptyFragment profileemptyFrag;

    /**
     * Boton Flotante
     */
    private FloatingActionButton fab;

    /**
     * Administrador de Fragments
     */
    private FragmentManager fm;

    /**
     * ToolBar
     */
    private Toolbar tb;

    /**
     * Presentador
     */
    private ProfilePresenter presenter;

    /**
     * Solo para prueba de la interface
     */
    private List<Profile> p;

    private boolean onForm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        Log.d(TAG,"Metodo onCreate");
        setContentView(R.layout.activity_profile);
        super.onCreate(savedInstanceState);

        //inicializar el presentador
        presenter = new ProfilePresenter(this);

        // Obtencion de los componentes necesaios de la vista
        fab = (FloatingActionButton)findViewById(R.id.fab);
        tb = (Toolbar)findViewById(R.id.toolbar);
        fm = getSupportFragmentManager();

        // Creacion de fragmen y pase argumento
        profileFormFrag = new ProfileFormFragment();
        profileListFrag = new ProfileListFragment();
        profileemptyFrag = new ProfileEmptyFragment();

        Bundle args = new Bundle();
     if(!isEmptyProfile())
     {
         args.putBoolean("multiSelect",true);
         profileListFrag.setArguments(args);
         //Lanzamiento de profileListFrag como el principal
         fm.beginTransaction()
                 .replace(R.id.fragment_container,profileListFrag)
                 .commit();
     }
        else{
         //Lanzamiento de profile vacio
         fm.beginTransaction()
                 .replace(R.id.fragment_container, profileemptyFrag)
                 .commit();
     }

        // Asegura que almenos onCreate se ejecuto en el fragment
        fm.executePendingTransactions();

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showFragment(profileFormFrag);
                profileFormFrag.setProfile();
            }
        });
        Log.d(TAG,"Cierre del Metodo onCreate");
    }

    /**
     * Realiza el intercambio de vistas de fragments
     * @param fragment el fragment que se quiere mostrar
     */
    private void showFragment(BaseFragment fragment) {
        Log.d(TAG,"Metodo showFragment");
        fm.beginTransaction()
                .replace(R.id.fragment_container,fragment)
                .commit();
        fm.executePendingTransactions();

        //Muestra y oculta compnentes.
        if(fragment.equals(profileListFrag)){
            if(saveBotton != null)
                saveBotton.setVisible(false);
            fab.setVisibility(View.VISIBLE);
            onForm = false;
        } else {
            onForm = true;
            if(saveBotton != null)
                saveBotton.setVisible(true);
            fab.setVisibility(View.GONE);
        }

        Log.d(TAG,"Cierre del Metodo showFragment");
    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        Log.d(TAG,"Metodo onCreateOptionsMenu");
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.profile, menu);

        saveBotton = menu.findItem(R.id.action_favorite_save);
        Log.d(TAG,"Cierre del Metodo onCreateOptionsMenu");
        return true;

    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        Log.d(TAG,"Metodo onOptionsItemSelected");
        switch (item.getItemId()) {
            case R.id.action_favorite_save:
                save();
                break;
        }
        Log.d(TAG,"Cierre del Metodo onOptionsItemSelected");
        return true;
    }

    private void save() {
        Log.d(TAG,"Metodo save");
        profileFormFrag.changeProfile();

        Profile profile = profileFormFrag.getProfile();
        try
        {
            if (profile.getId() == 0) {
                createProfile(profile);
                Log.d(TAG,"Se agrego el perfil"+profile.getProfileName());

            } else {
                updateProfile(profile);
                Log.d(TAG,"Se modifico el perfil"+profile.getId());
            }
        } catch (Exception e) {
            Log.e(TAG,"Error al salvar el perfil",e);
            e.printStackTrace();
        }
        try
        {
        profileListFrag.updateList();
        profileListFrag.updateList();
        showFragment(profileListFrag);
        hideKyboard();}
    catch (Exception e) {
        e.printStackTrace();
        Bundle args = new Bundle();
        args.putBoolean("multiSelect",true);
        profileListFrag.setArguments(args);
        //Lanzamiento de profileListFrag como el principal
        fm.beginTransaction()
                .replace(R.id.fragment_container,profileListFrag)
                .commit();
    }}


    /**
     * Implementaciones de comunicacion con los fragments
     * @param profile
     */
    @Override
    public void OnProfileSelect(Profile profile) {
        showFragment(profileFormFrag);
        profileFormFrag.setProfile(profile);
    }

    @Override
    public void OnProfilesSelected(ArrayList<Profile> profile) {

    }

    @Override
    public void OnProfileSelectionMode() {
        tb.setVisibility(View.GONE);
        fab.setVisibility(View.GONE);
    }

    @Override
    public void OnProfileSelectionModeExit() {
        tb.setVisibility(View.VISIBLE);
        fab.setVisibility(View.VISIBLE);
    }

    @Override
    public void onBackPressed() {
        if (!onForm) {
            super.onBackPressed();
        } else {
            showFragment(profileListFrag);
        }
    }

    @Override
    public Boolean createProfile(Profile profile) {
        Log.d(TAG,"Metodo createProfile");
        Boolean resp = false;
        try {
            resp = presenter.createProfile(profile);
            Log.d(TAG,"Se agrego el perfil "+ profile.getProfileName());
        }catch (Exception e)
        {
            Log.e(TAG,"Error al crear Perfil",e);
        }
        return resp;
    }

    @Override
    public Boolean updateProfile(Profile profile) {
        Log.d(TAG,"Metodo updateProfile");
        Boolean resp = false;
        try {
            resp = presenter.updateProfile(profile);
            Log.d(TAG,"Se modifico el perfil "+ profile.getId());
        }catch (Exception e)
        {
            Log.e(TAG,"Error al modificar Perfil",e);
        }
        return resp;
    }

    /**
     * Metodo que valida si el comensal logeado posee perfil
     * @return true si posee perfil
     */
    public boolean isEmptyProfile() {
        try {
            List<Profile> profilesList = presenter.getProfiles();

            if (profilesList != null) {
                if (profilesList.size() != 0)
                    return false;
            }

        }
        catch (Exception e) {
            Log.e(TAG,"Error al determinar si el commensal tiene perfiles",e);
        }
        return true;
    }

}
