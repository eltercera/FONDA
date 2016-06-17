package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.entities.Profile;
import com.ds201625.fonda.logic.SessionData;

import java.util.ArrayList;
import java.util.List;

/**
 * Adapter para la vista de la lista de Profiles
 */
public class ProfileViewItemList extends BaseArrayAdapter<Profile> {

    public ProfileViewItemList(Context context) {
        super(context, R.layout.item_profile,R.id.tvProfile,new ArrayList<Profile>());
        update();
    }

    public void update() {
        ProfileService ps = FondaServiceFactory.getInstance()
                .getProfileService(SessionData.getInstance().getToken());
        List<Profile> list = null;
        clear();
        try {
            list = ps.getProfiles();
        } catch (RestClientException e) {
            e.printStackTrace();
            Log.v("Fonda",e.toString());
        }
        if (list != null)
            addAll(list);
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

}
