package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.views.contracts.DetailRestaurantActivityContract;
import com.ds201625.fonda.views.fragments.DetailSearchRestaurantFragment;
import com.ds201625.fonda.views.presenters.DetailSearchRestaurantActivityPresenter;


public class DetailSearchRestaurantActivity extends BaseNavigationActivity
    implements DetailRestaurantActivityContract{

    /**
     * Componentes de vista
     */
    private View mainContent;
    private MenuItem favoriteMenuItem;
    private MenuItem reserveMenuItem;
    private DetailSearchRestaurantFragment restaurantFragment;
    private Toolbar tb;
    private FragmentManager fm;

    /**
     * Que tipo de icono de favorito se muestra
     */
    private boolean fab;

    private DetailSearchRestaurantActivityPresenter presenter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_detail_restaurant);
        super.onCreate(savedInstanceState);

        //obtencion de componentes
        this.mainContent = findViewById(R.id.fragment_container);
        this.tb = (Toolbar)findViewById(R.id.toolbar);
        this.fm = getSupportFragmentManager();
        tb.setVisibility(View.VISIBLE);

        this.presenter = new DetailSearchRestaurantActivityPresenter
                ((Restaurant) getIntent().getSerializableExtra("restaurant"),this);

        this.presenter.onCreate();
    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);

        //obtencion de componenes
        this.favoriteMenuItem = menu.findItem(R.id.action_set_favorite);
        this.reserveMenuItem = menu.findItem(R.id.action_make_order);

        this.favoriteMenuItem.setVisible(true);
        this.reserveMenuItem.setVisible(true);
        this.updateFab();
        return true;

    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if (item == this.favoriteMenuItem){
            presenter.setFavorite();
        } else if (item == this.reserveMenuItem){
            // En espera por que va aqui
            // Deberia de enviar a la pantalla de realizar unareserva
            // al restaurante.
        }
        return true;
    }

    @Override
    public void setDetailsViewOf(Restaurant restaurant) {
        if (this.restaurantFragment == null)
            this.restaurantFragment = new DetailSearchRestaurantFragment();

        this.restaurantFragment.setRestaurant(restaurant);

        fm.beginTransaction()
            .replace(R.id.fragment_container,this.restaurantFragment)
            .commit();
        fm.executePendingTransactions();

    }

    @Override
    public void setIconFavorite(boolean fab) {
        this.fab = fab;
        this.updateFab();
    }

    private void updateFab() {
        if (this.favoriteMenuItem == null)
            return;

        if (fab)
            this.favoriteMenuItem.setIcon(R.drawable.ic_star_yellow);
        else
            this.favoriteMenuItem.setIcon(R.drawable.ic_grade_creme_24dp);
    }
}

