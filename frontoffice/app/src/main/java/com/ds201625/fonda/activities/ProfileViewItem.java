package com.ds201625.fonda.activities;

import android.app.Activity;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;

/**
 * Created by rrodriguez on 4/15/16.
 */
public class ProfileViewItem {

    View rowView;

    String profile;
    String profileName;
    String profileRif;

    public String getProfile() {
        return profile;
    }

    public String getProfileName() {
        return profileName;
    }

    public String getProfileRif() {
        return profileRif;
    }

    public ProfileViewItem(String profileName, String name, String ssn) {

        profile = profileName;
        this.profileName = name;
        this.profileRif = ssn;
    }

    public View getView() {
        return rowView;
    }
}
