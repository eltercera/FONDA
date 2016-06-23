<<<<<<< HEAD
package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.interfaces.ReservationView;
import com.ds201625.fonda.interfaces.ReservationViewPresenter;
import com.ds201625.fonda.presenter.ReservationPresenter;

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
        super(context, R.layout.list_reservations, R.id.tvDateR, new ArrayList<Reservation>());
        presenter =  new ReservationPresenter(this);
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


        DateR.setText(item.getReserveDate().toString());
        NumberC.setText(item.getCommensalNumber());



        return convertView;
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
=======
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
import com.ds201625.fonda.data_access.services.ReservationService;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.logic.SessionData;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Eduardo on 20-06-2016.
 */
public class ReserveViewIntemList extends BaseArrayAdapter<Reservation> {


    public ReserveViewIntemList(Context context) {
        super(context, R.layout.item_reserve,R.id.tvDateR,new ArrayList<Reservation>());
        update();
    }

    public void update() {
        ReservationService rs = FondaServiceFactory.getInstance()
                .getAllReservesService();
        List<Reservation> list = null;
        clear();
        try {
            list = rs.getReservarions(0);
        } catch (RestClientException e) {
            e.printStackTrace();
            Log.v("Fonda",e.toString());
        }
        if (list != null)
            addAll(list);
        notifyDataSetChanged();
    }

    @Override
    public View getSelectedView(Reservation item, View convertView) {
        return null;
    }

    @Override
    public View getNotSelectedView(Reservation item, View convertView) {
        return null;
    }

    @Override
    public View createView(Reservation item) {
        View convertView;

        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.item_reserve, null, true);

        TextView tvDateR = (TextView) convertView.findViewById(R.id.tvDateR);
        TextView tvNumberC = (TextView) convertView.findViewById(R.id.tvNumberC);


        tvDateR.setText(item.getReserveDate().toString());
        tvNumberC.setText(item.getCommensalNumber());


        return convertView;
    }


}
>>>>>>> e5c9b5ef424c5b4ab139b771037b47b05285d6e8
