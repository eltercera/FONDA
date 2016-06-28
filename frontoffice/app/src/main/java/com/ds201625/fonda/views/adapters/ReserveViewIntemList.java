
package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.views.contracts.ReservationView;
import com.ds201625.fonda.views.contracts.ReservationViewPresenter;
import com.ds201625.fonda.views.presenters.ReservationPresenter;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Andreina on 20-06-2016.
 */
public class ReserveViewIntemList extends BaseArrayAdapter<Reservation> implements ReservationView {

    private ReservationViewPresenter presenter;
    private String TAG = "ReserveViewIntemList";


    /**
     * Constructor
     *
     * @param context
     */

    public ReserveViewIntemList(Context context) {
        super(context, R.layout.list_reservations, R.id.tvNumber, new ArrayList<Reservation>());
        presenter =  new ReservationPresenter(this);
    }

    /**
     * Crea la vista
     *
     * @param item elemento a construir la vista
     * @return
     */

    @Override
    public View createView(Reservation item) {


        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_reservations, null, true);

        TextView DateR = (TextView) convertView.findViewById(R.id.tvDateR);
        TextView NumberC = (TextView) convertView.findViewById(R.id.tvNumberC);
        TextView DateC = (TextView) convertView.findViewById(R.id.tvCreationD);
        TextView Number = (TextView) convertView.findViewById(R.id.tvNumber);


        DateR.setText(item.getReserveDate().toString());
        NumberC.setText(item.getCommensalNumber());
        DateC.setText(item.getCreateDate().toString());
        Number.setText(item.getNumber_r());


        return convertView;
    }

    @Override
    public View getSelectedView(Reservation item, View convertView) {
        return null;
    }

    @Override
    public View getNotSelectedView(Reservation item, View convertView) {
        return null;
    }

        /**
         * Lista de toda las reservaciones
         *
         * @return reservaciones
         */

    @Override
    public List<Reservation> getListSW() {
        return null;
    }
}