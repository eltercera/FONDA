<<<<<<< HEAD
package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.ActionMode;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.interfaces.ReservationView;
import com.ds201625.fonda.interfaces.ReservationViewPresenter;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.presenter.ReservationPresenter;
import com.ds201625.fonda.views.activities.ReserveActivity;
import com.ds201625.fonda.views.adapters.ReserveViewIntemList;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Andreina on 20-06-2016.
 */

    /**
     * Fragment que contiene la lista de Reserva.
     */
    public class ReserveListFragment extends BaseFragment
            implements ReservationView, SwipeRefreshLayout.OnRefreshListener{

        /**
         * String que indica la clase al logger
         */
        private String TAG = "ReserveListFragment";

        //Interface de comunicacion contra la activity
        reserveListFragmentListener mCallBack;

        //Elementos de la vista.

        private ListView reserve;
        private ReserveViewIntemList reserveList;
        private SwipeRefreshLayout swipeRefreshLayout;
        private List<Reservation> reservationList;
        private ReservationViewPresenter presenter;
        private ReserveActivity reserveActivity;
        private boolean empty;

        /**
         * Crea el fragment
         * @param savedInstanceState
         */
        @Override
        public void onCreate(@Nullable Bundle savedInstanceState) {
            Log.d(TAG,"Ha entrado en onCreate");
            super.onCreate(savedInstanceState);
            reserveList = new ReserveViewIntemList(getContext());
            presenter = new ReservationPresenter(this);
        }


        /**
         * Crea la vista del fragment
         * @param inflater
         * @param container
         * @param savedInstanceState
         * @return
         */
        @Nullable
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
            Log.d(TAG, "Ha entrado en onCreateView");
            View layout = inflater.inflate(R.layout.fragment_reserve, container, false);
            reserve = (ListView) layout.findViewById(R.id.lvReserveList);
            swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
            swipeRefreshLayout.setOnRefreshListener(this);

            try {
                reservationList = getListSW();
                reserveList.addAll(reservationList);
                reserve.setAdapter(reserveList);
            } catch (NullPointerException e) {
                Log.e(TAG, "Error al iniciar reserva", e);

            }
                return layout;
        }

        /**
         * Cuando se refresca la lista
         */
        @Override
        public void onRefresh() {
            Log.d(TAG,"Ha ingresado a onRefresh");

            Log.d(TAG,"Ha finalizado onRefresh");
        }



        @Override
        public void onAttach(Context context) {
            super.onAttach(context);
            try {
                mCallBack = (reserveListFragmentListener) context;
            } catch (ClassCastException e) {
                throw new ClassCastException(context.toString()
                        + " must implement OnHeadlineSelectedListener");
            }
        }

        @Override
        public void onDetach() {
            super.onDetach();
        }

        @Override
        public List<Reservation> getListSW() {
            List<Reservation> listReserWS;
            Log.d(TAG,"Ha ingresado a getListSW");
            try {
                //Llamo al comando de requireLogedCommensalCommand
                presenter.findLoggedComensal();
                //Llamo al comando de AllReservation
                listReserWS = presenter.AllReservation();
                return listReserWS;
            }
            catch (NullPointerException nu) {
                Log.e(TAG, "Error en getListSW al obtener reservas", nu);
            }
            Log.d(TAG,"Ha finalizado getListSW");
            return null;
        }

        /**
         * Interface de la comunicacion contra una Activity
         */
        public interface reserveListFragmentListener {
            /**
             * Cuando es seleccionado un perfil
            // * @param reserve
             */

        }
    }
=======
package com.ds201625.fonda.views.fragments;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.widget.SwipeRefreshLayout;
import android.util.Log;
import android.view.ActionMode;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.Reservation;
import com.ds201625.fonda.logic.SessionData;
import com.ds201625.fonda.views.adapters.ReserveViewIntemList;

import java.util.ArrayList;

/**
 * Created by Andreina on 20-06-2016.
 */

    /**
     * Fragment que contiene la lista de Reserva.
     */
    public class ReserveListFragment extends BaseFragment
            implements SwipeRefreshLayout.OnRefreshListener{

        //Interface de comunicacion contra la activity
        reserveListFragmentListener mCallBack;

        //Elementos de la vista.
        private ListView reserve;
        private SwipeRefreshLayout swipeRefreshLayout;
        private ReserveViewIntemList reserveList;

        @Override
        public void onCreate(@Nullable Bundle savedInstanceState) {
            super.onCreate(savedInstanceState);
            reserveList = new ReserveViewIntemList(getContext());
        }

        @Nullable
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState) {
            View layout = inflater.inflate(R.layout.fragment_reserve,container,false);

            reserve = (ListView)layout.findViewById(R.id.lvReserveList);
            swipeRefreshLayout = (SwipeRefreshLayout) layout.findViewById(R.id.srlUpdater);
            swipeRefreshLayout.setOnRefreshListener(this);
            reserve.setAdapter(reserveList);



            return layout ;
        }

        @Override
        public void onRefresh() {
            updateList();
        }

        public void updateList() {
            swipeRefreshLayout.setRefreshing(true);
            reserveList.update();
            reserve.refreshDrawableState();
            swipeRefreshLayout.setRefreshing(false);
        }

        @Override
        public void onAttach(Context context) {
            super.onAttach(context);
            try {
                mCallBack = (reserveListFragmentListener) context;
            } catch (ClassCastException e) {
                throw new ClassCastException(context.toString()
                        + " must implement OnHeadlineSelectedListener");
            }
        }

        @Override
        public void onDetach() {
            super.onDetach();
        }

        /**
         * Interface de la comunicacion contra una Activity
         */
        public interface reserveListFragmentListener {
            /**
             * Cuando es seleccionado un perfil
            // * @param reserve
             */

        }
    }
>>>>>>> e5c9b5ef424c5b4ab139b771037b47b05285d6e8
