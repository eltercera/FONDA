package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RetrofitProfileService;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.ProfileFormFragment;
import com.ds201625.fonda.views.fragments.ProfileListFragment;

import java.util.ArrayList;
import java.util.List;

/**
 * Activity de Perfil de usuario
 */
public class ProfileActivity extends BaseNavigationActivity
    implements ProfileListFragment.profileListFragmentListener{

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
     * Solo para prueba de la interface
     */
    private List<Profile> p;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_profile);
        super.onCreate(savedInstanceState);

        // Obtencion de los componentes necesaios de la vista
        fab = (FloatingActionButton)findViewById(R.id.fab);
        tb = (Toolbar)findViewById(R.id.toolbar);
        fm = getSupportFragmentManager();

        // Creacion de fragmen y pase argumento
        profileFormFrag = new ProfileFormFragment();
        profileListFrag = new ProfileListFragment();
        Bundle args = new Bundle();
        args.putBoolean("multiSelect",true);
        profileListFrag.setArguments(args);

        //Lanzamiento de profileListFrag como el principal
        fm.beginTransaction()
            .replace(R.id.fragment_container,profileListFrag)
            .commit();

        // Asegura que almenos onCreate se ejecuto en el fragment
        fm.executePendingTransactions();

        //pruebas
        ProfileService ps = FondaServiceFactory.getInstance().getProfileService();
        p=ps.getProfiles();
        profileListFrag.seProfiles(p);

    }

    /**
     * Realiza el intercambio de vistas de fragments
     * @param fragment el fragment que se quiere mostrar
     */
    private void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container,fragment)
                .commit();
        fm.executePendingTransactions();

        //Muestra y oculta compnentes.
        if(fragment.equals(profileListFrag)){
            if(saveBotton != null)
                saveBotton.setVisible(false);
            fab.setVisibility(View.VISIBLE);
            profileListFrag.seProfiles(p);
        } else {
            if(saveBotton != null)
                saveBotton.setVisible(true);
            fab.setVisibility(View.GONE);
        }

    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.profile, menu);

        saveBotton = menu.findItem(R.id.action_favorite_save);
        return true;
    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_favorite_save:
                save();
                break;
        }
        return true;
    }

    private void save() {
        AlertDialog dialog = buildSingleDialog("Actualización de perfil",
                "La actualización fue satisfactoria.");
        dialog.show();
        profileFormFrag.changeProfile();
        showFragment(profileListFrag);
    }

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
}
