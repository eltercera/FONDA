package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Profile;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Adapter para la vista de la lista de Profiles
 */
public class ProfileViewItemList extends BaseArrayAdapter<Profile> {

    public ProfileViewItemList(Context context) {
        super(context, R.layout.item_profile,R.id.tvProfile,new ArrayList<Profile>());
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
        tvProfileName.setText(item.getPerson().getName());
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
