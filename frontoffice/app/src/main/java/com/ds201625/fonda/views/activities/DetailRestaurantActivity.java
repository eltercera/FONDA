package com.ds201625.fonda.views.activities;

import android.os.Bundle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.ds201625.fonda.R;

/**
 * Created by jesus on 20/04/16.
 */
public class DetailRestaurantActivity extends BaseNavigationActivity{

    //Variables Declaration
    private MenuItem setAsFavorite;
    private Toolbar tb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_detail_restaurant);
        super.onCreate(savedInstanceState);

    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.detail_restaurant, menu);

        setAsFavorite = menu.findItem(R.id.action_favorite_save);
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        return true;
    }

    /**
     * Opciones y acciones del menu en el toolbars
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_favorite_save:
                break;
        }
        return true;
    }

}
