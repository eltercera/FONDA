package com.ds201625.fonda.views.activities;

import android.app.Activity;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Reservation;

import java.util.List;


public class ReserveList extends ArrayAdapter<Reservation> {
    private final Activity context;
    private final String[] number;
    private final String[] dateReser;
    private final String[] commensalN;
    private final List<Reservation> mReservaList;

    public ReserveList(Activity context,
                       String[] number, String[] dateReser, String[] commensal, List<Reservation> resevaList) {
        super(context, R.layout.list_reservations, resevaList);
        this.context = context;
        this.number = number;
        this.dateReser = dateReser;
        this.commensalN = commensal;
        this.mReservaList = resevaList;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        LayoutInflater inflater = context.getLayoutInflater();
        View rowView = inflater.inflate(R.layout.list_reservations, null, true);
        TextView txtTitle = (TextView) rowView.findViewById(R.id.tvDateR);
        TextView txtTitle2 = (TextView) rowView.findViewById(R.id.tvNumberC);


        int contador = 0;


        for (Reservation reservation : this.mReservaList) {
            if (contador == position) {
                txtTitle.setText(reservation.getReserveDate().toString());
                txtTitle2.setText(reservation.getCommensalNumber());

                Log.v("WEBSERVICEList", reservation.getId() + "");
                Log.v("WEBSERVICEList", reservation.getReserveDate().toString());


            }
            contador++;
        }
        return rowView;

    }


}
