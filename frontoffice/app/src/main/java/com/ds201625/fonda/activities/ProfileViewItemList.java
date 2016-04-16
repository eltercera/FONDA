package com.ds201625.fonda.activities;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;


import com.ds201625.fonda.R;

import java.util.ArrayList;


public class ProfileViewItemList extends ArrayAdapter<ProfileViewItem> {

    public ProfileViewItemList(Context context) {
        super(context, R.layout.profile_item,R.id.tvProfile,new ArrayList<ProfileViewItem>());
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        if (convertView == null) {
            LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();

            convertView = inflater.inflate(R.layout.profile_item, null, true);

            TextView tvProfile = (TextView) convertView.findViewById(R.id.tvProfile);
            TextView tvProfileName = (TextView) convertView.findViewById(R.id.tvProfileName);
            TextView tvProfileRif = (TextView) convertView.findViewById(R.id.tvProfileRif);

            ProfileViewItem item = getItem(position);

            tvProfile.setText(item.getProfile());
            tvProfileName.setText(item.getProfileName());
            tvProfileRif.setText(item.getProfileRif());
        }

        return convertView;
    }
}
