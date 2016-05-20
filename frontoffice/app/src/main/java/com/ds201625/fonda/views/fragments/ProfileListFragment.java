package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.ActionMode;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.adapters.ProfileViewItemList;
import com.ds201625.fonda.domains.Profile;

import java.util.ArrayList;
import java.util.List;

/**
 * Fragment que contiene la lista de Perfiles.
 */
public class ProfileListFragment extends BaseFragment
        implements SwipeRefreshLayout.OnRefreshListener{

    //Interface de comunicaciond contra la activity
    profileListFragmentListener mCallBack;

    //Elementos de la vista.
    private ListView profiles;
    private SwipeRefreshLayout swipeRefreshLayout;
    private ProfileViewItemList profileList;

    //Para configurar si la lista es multiples secciones o no
    private boolean multi;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        //TODO: agregar try/catch en caso de que no se pase el argumento.
        multi = getArguments().getBoolean("multiSelect");
        profileList = new ProfileViewItemList(getContext());
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View layout = inflater.inflate(R.layout.fragment_profile_list,container,false);

        profiles = (ListView)layout.findViewById(R.id.lvProfileList);
        swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
        swipeRefreshLayout.setOnRefreshListener(this);
        profiles.setAdapter(profileList);
        if(multi) {
            profiles.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE_MODAL);
            profiles.setMultiChoiceModeListener(new AbsListView.MultiChoiceModeListener() {
                @Override
                public void onItemCheckedStateChanged(ActionMode mode, int position, long id,
                                                      boolean checked) {
                    Log.d("Messahe:", position + " Is StateChanged");
                    profileList.setSelectedItem(position, checked);
                    mode.setTitle(profileList.countSelected() + " Selected");
                }

                @Override
                public boolean onCreateActionMode(ActionMode mode, Menu menu) {
                    mCallBack.OnProfileSelectionMode();
                    mode.getMenuInflater().inflate(R.menu.profile_multiselet, menu);
                    return true;
                }

                @Override
                public boolean onPrepareActionMode(ActionMode mode, Menu menu) {
                    return false;
                }

                @Override
                public boolean onActionItemClicked(ActionMode mode, MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.deleteProfile:
                            String sal = "Fueron eliminados los perfiles.";
                            for (Profile p : profileList.getAllSeletedItems()) {
                                ProfileService ps = FondaServiceFactory.getInstance()
                                        .getProfileService(SessionData.getInstance().getToken());
                                try {
                                    ps.deleteProfile(p.getId());
                                }
                                catch (RestClientException e) {
                                    e.printStackTrace();
                                }
                            }
                            Log.v("Perfiles eliminados: ", sal);
                            profileList.cleanSelected();
                            break;

                        default:
                            return false;
                    }
                    return true;
                }

                @Override
                public void onDestroyActionMode(ActionMode mode) {
                    mCallBack.OnProfileSelectionModeExit();
                    profileList.cleanSelected();
                }
            });
        }

        profiles.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Profile item = profileList.getItem(position);
                mCallBack.OnProfileSelect(item);
            }


        });

        return layout ;
    }

    @Override
    public void onRefresh() {
        updateList();
    }

    public void updateList() {
        swipeRefreshLayout.setRefreshing(true);
        profileList.update();
        profiles.refreshDrawableState();
        swipeRefreshLayout.setRefreshing(false);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            mCallBack = (profileListFragmentListener) context;
        } catch (ClassCastException e) {
            throw new ClassCastException(context.toString()
                    + " must implement OnHeadlineSelectedListener");
        }
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }

    /**
     * Interface de la comunicacion contra una Activity
     */
    public interface profileListFragmentListener {
        /**
         * Cuando es seleccionado un perfil
         * @param profile
         */
        void OnProfileSelect(Profile profile);

        /**
         * Cuando Son seleccionados varios.
         * @param profile
         */
        void OnProfilesSelected(ArrayList<Profile> profile);

        /**
         * Cuando el modo se seleccion inicia
         */
        void OnProfileSelectionMode();

        /**
         * Cuando el modo de seleccion finaliza
         */
        void OnProfileSelectionModeExit();
    }
}
