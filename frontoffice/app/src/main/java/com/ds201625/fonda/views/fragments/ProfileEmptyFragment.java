package com.ds201625.fonda.views.fragments;



import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import com.ds201625.fonda.R;
import com.ds201625.fonda.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class ProfileEmptyFragment extends BaseFragment {



    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    /**
     * Crea la vista
     * @param inflater
     * @param container
     * @param savedInstanceState
     * @return
     */
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {
        //Indicar el layout que va a usar el fragment
        View view= inflater.inflate(R.layout.fragment_profile_empty,container,false);

        return view;

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
