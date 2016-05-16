package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Profile;


/**
 * Fragment que contiene el formulario de para un perfil
 */
public class ProfileFormFragment extends BaseFragment {

    //Elementos de la vista
    private Profile profile;
    private TextView tvProfileName;
    private TextView tvNames;
    private TextView tvSsn;
    private TextView tvPhone;
    private TextView tvCellPhone;
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
        tvNames = (TextView) form.findViewById(R.id.profile_lastnames);
        tvSsn = (TextView) form.findViewById(R.id.profile_ci_rif);
        tvPhone = (TextView) form.findViewById(R.id.profile_phone);
        tvCellPhone = (TextView) form.findViewById(R.id.profile_cell);
        return form;
    }

    /**
     * Asigna los valores de un Profile a los elementos de la vista.
     * @param profile Profile a mostrar
     */
    public void setProfile(Profile profile) {
        tvProfileName.setText(profile.getProfileName());
        tvNames.setText(profile.getPerson().getName());
        tvSsn.setText(profile.getPerson().getSsn());
        tvPhone.setText(profile.getPerson().getPhoneNumber());
        this.profile = profile;
    }

    /**
     * Realiza los cambios del Profile con respecto a los que se encuentre en
     * el formulario.
     */
    public void changeProfile() {
        profile.setProfileName(tvProfileName.getText().toString());
        /*profile.setNames(tvNames.getText().toString());
        profile.setSsn(tvSsn.getText().toString());
        profile.setPhone(tvPhone.getText().toString());
        profile.setCellPhone(tvCellPhone.getText().toString());*/
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
