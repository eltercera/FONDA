package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Person;
import com.ds201625.fonda.domains.Profile;


/**
 * Fragment que contiene el formulario de para un perfil
 */
public class ProfileFormFragment extends BaseFragment {

    //Elementos de la vista
    private Profile profile;
    private TextView tvProfileName;
    private TextView tvNames;
    private TextView tvLastNames;
    private TextView tvSsn;
    private TextView tvPhone;
    private TextView tvDirecction;
    private View form;

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        form = inflater.inflate(R.layout.fragment_form_profile, container, false);
        tvProfileName = (TextView) form.findViewById(R.id.profile_name);
        tvNames = (TextView) form.findViewById(R.id.profile_names);
        tvSsn = (TextView) form.findViewById(R.id.profile_ci_rif);
        tvPhone = (TextView) form.findViewById(R.id.profile_phone);
        tvDirecction = (TextView) form.findViewById(R.id.profile_dir);
        tvLastNames = (TextView) form.findViewById(R.id.profile_lastnames);
        return form;
    }

    /**
     * Asigna los valores de un Profile a los elementos de la vista.
     * @param profile Profile a mostrar
     */
    public void setProfile(Profile profile) {
        tvProfileName.setText(profile.getProfileName());
        tvNames.setText(profile.getPerson().getName());
        tvLastNames.setText(profile.getPerson().getLastName());
        tvSsn.setText(profile.getPerson().getSsn());
        tvPhone.setText(profile.getPerson().getPhoneNumber());
        tvDirecction.setText(profile.getPerson().getAddress());
        this.profile = profile;
    }

    public void setProfile() {
        Profile profile = new Profile();
        profile.setPerson(new Person());
        tvProfileName.setText("");
        tvNames.setText("");
        tvLastNames.setText("");
        tvSsn.setText("");
        tvPhone.setText("");
        tvDirecction.setText("");
        this.profile = profile;
    }

    public Profile getProfile() {
        return profile;
    }

    /**
     * Realiza los cambios del Profile con respecto a los que se encuentre en
     * el formulario.
     */
    public void changeProfile() {
        this.profile.setProfileName(tvProfileName.getText().toString());
        this.profile.getPerson().setName(tvNames.getText().toString());
        this.profile.getPerson().setLastName(tvLastNames.getText().toString());
        this. profile.getPerson().setSsn(tvSsn.getText().toString());
        this.profile.getPerson().setPhoneNumber(tvPhone.getText().toString());
        this.profile.getPerson().setAddress(tvDirecction.getText().toString());
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }

}
