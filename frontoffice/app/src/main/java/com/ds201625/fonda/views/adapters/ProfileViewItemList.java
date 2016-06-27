package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.views.presenters.ProfilePresenter;

import java.util.ArrayList;
import java.util.List;

/**
 * Adapter para la vista de la lista de Profiles
 */
public class ProfileViewItemList extends BaseArrayAdapter<Profile> {


    private String TAG = "ProfileViewItemList";

    public ProfileViewItemList(Context context, ProfilePresenter presenter) {
        super(context, R.layout.item_profile,R.id.tvProfile,new ArrayList<Profile>());
        update(presenter);
    }

    public void update(ProfilePresenter presenter) {
        List<Profile> profiles = null;
        clear();
        try {
            profiles = getProfiles(presenter);
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        if (profiles != null)
            addAll(profiles);
        notifyDataSetChanged();
    }

    @Override
    public View createView(Profile item) {
        View convertView;

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_profile, null, true);

        TextView tvProfile = (TextView) convertView.findViewById(R.id.tvProfile);
        TextView tvProfileName = (TextView) convertView.findViewById(R.id.tvProfileName);
        TextView tvProfileRif = (TextView) convertView.findViewById(R.id.tvProfileRif);

        tvProfile.setText(item.getProfileName());
        tvProfileName.setText(item.getPerson().getName() + ", " + item.getPerson().getLastName());
        tvProfileRif.setText(item.getPerson().getSsn());

        return convertView;
    }

    @Override
    public View getSelectedView(Profile item, View convertView) {
        //TODO: Colocar un color desente
        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.colorPrimaryDark));
        return convertView;
    }

    @Override
    public View getNotSelectedView(Profile item, View convertView) {
        //TODO: Colocar un color desente
        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }

    public List<Profile> getProfiles(ProfilePresenter presenter) {
        Log.d(TAG,"Metodo getProfiles");
        List<Profile> resp = null;
        try {
            resp = presenter.getProfiles();
            Log.d(TAG,"Se realizo la busqueda de los perfiles ");
        }catch (Exception e)
        {
            Log.e(TAG,"Error al buscar los perfiles",e);
        }
        return resp;
    }
}
