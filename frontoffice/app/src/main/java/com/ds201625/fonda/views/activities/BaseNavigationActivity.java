package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.widget.Toolbar;
import android.view.MenuItem;
import android.widget.TextView;

import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.CommensalService;
import com.ds201625.fonda.logic.SessionData;

/**
 * Clase Base para Activity con el navegador a la izquierda.
 */
public abstract class BaseNavigationActivity extends BaseActivity
    implements NavigationView.OnNavigationItemSelectedListener{

    private TextView headerEmail;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = this.getDrawer();

        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        headerEmail = (TextView) navigationView.getHeaderView(0).findViewById(R.id.tvHeaderEmail);

        // todo: Hay un error en el activity de Orders
        if (this.getClass() != OrdersActivity.class)
            headerEmail.setText(SessionData.getInstance().getCommensal().getEmail());

        if (this.getClass() == FavoritesActivity.class) {
            setCheckedItem(R.id.nav_favorites);
        } else if (this.getClass() == RestauranstsActivity.class) {
            setCheckedItem(R.id.nav_rest);
        } else if (this.getClass() == OrdersActivity.class) {
            setCheckedItem(R.id.nav_order);
        } else if (this.getClass() == ProfileActivity.class) {
            setCheckedItem(R.id.nav_profile);
        } else if (this.getClass() == ReserveActivity.class) {
            setCheckedItem(R.id.nav_reserve);
        }
    }

    protected void setCheckedItem(int id) {
        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.getMenu().findItem(id).setChecked(true);
    }

    @Override
    protected void onStop() {
        super.onStop();
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
    }

    @Override
    protected void onPause() {
        super.onPause();
    }

    @Override
    protected void onResume() {
        super.onResume();
    }

    @Override
    protected void onStart() {
        super.onStart();
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        //Acciones de las opciones.
        if (id == R.id.nav_favorites) {
            if (this.getClass() != FavoritesActivity.class)
                startFondaActivity("FavoritesActivity");
        } else if (id == R.id.nav_rest) {
            if (this.getClass() != RestauranstsActivity.class)
                startFondaActivity("RestauranstsActivity");
        } else if (id == R.id.nav_order) {
            if (this.getClass() != OrdersActivity.class)
                startFondaActivity("OrdersActivity");
        } else if (id == R.id.nav_profile) {
            if (this.getClass() != ProfileActivity.class)
                startFondaActivity("ProfileActivity");
        } else if (id == R.id.nav_reserve) {
            if (this.getClass() != ReserveActivity.class)
                startFondaActivity("ReserveActivity");
        } else if (id == R.id.nav_logout) {
            try {
                SessionData.getInstance().logoutCommensal();
                this.startActivity(new Intent(this,Class.forName("com.ds201625.fonda.views.activities.LoginActivity")));
            }
            catch (Exception e){
                e.printStackTrace();
            }

        }

        this.getDrawer().closeDrawer(GravityCompat.START);
        return true;
    }

    protected void startFondaActivity(String name) {
        try {
            this.startActivity(new Intent(this,Class.forName("com.ds201625.fonda.views.activities."+name)));
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    protected DrawerLayout getDrawer() {
        return (DrawerLayout) findViewById(R.id.drawer_layout);
    }
}
