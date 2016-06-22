package com.ds201625.fonda.views.adapters;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.interfaces.FavoriteView;
import com.ds201625.fonda.interfaces.FavoriteViewPresenter;
import com.ds201625.fonda.presenter.FavoritesPresenter;

import java.util.ArrayList;
import java.util.List;

/**
 * Adapter para la vista de la lista de restaurantes favoritos
 */
public class FavoriteRestViewItemList extends BaseArrayAdapter<Restaurant> implements FavoriteView {
    private FavoriteViewPresenter presenter;
    private String TAG = "FavoriteViewItemList";

    /**
     * Constructor
     * @param context
     */
    public FavoriteRestViewItemList(Context context) {
        super(context, R.layout.list_restaurant,R.id.txt,new ArrayList<Restaurant>());
        presenter = new FavoritesPresenter(this);
 }


    /**
     * Crea la vista
     * @param item elemento a construir la vista
     * @return
     */
    @Override
    public View createView(Restaurant item) {
        View convertView;
        LayoutInflater inflater = ((Activity) getContext()).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_restaurant, null, true);

        TextView txtName = (TextView) convertView.findViewById(R.id.txt);
        TextView txtAdd = (TextView) convertView.findViewById(R.id.txt2);
        TextView txtCategory = (TextView) convertView.findViewById(R.id.txt3);
        ImageView icon = (ImageView) convertView.findViewById(R.id.imageRest);


            txtName.setText(item.getName());
            txtAdd.setText(item.getAddress());
            txtCategory.setText(item.getRestaurantCategory().getName());
            String image = item.getLogo();
            Context context = icon.getContext();
            int idImage = context.getResources().getIdentifier(image, "mipmap", context.getPackageName());
            icon.setImageResource(idImage);

        return convertView;

    }


    /**
     * Obtiene la vista seleccionada
     * @param item item seleccionado
     * @param convertView vista ya creada
     * @return
     */
    @Override
    public View getSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(getContext().getResources()
                .getColor(R.color.creme));
        return convertView;
    }

    /**
     * Obtiene la vista no seleccionada
     * @param item item no seleccionado
     * @param convertView vista ya creada
     * @return
     */
    @Override
    public View getNotSelectedView(Restaurant item, View convertView) {

        convertView.setBackgroundColor(0x00000000);
        return convertView;
    }


    /**
     * Lista de todos los restaurantes favoritos
     *
     * @return restauraantes favoritos
     */
    @Override
    public List<Restaurant> getListSW() {
        return null;
    }

    /**
     * Actualiza la lista luego de eliminar
     */
    @Override
    public void updateList() {
        List<Restaurant> list = null;
        clear();
        try {
            presenter.findLoggedComensal();
            list = presenter.findAllFavoriteRestaurant();
        } catch (Exception e) {
            Log.e(TAG,"Error al refrescar los favoritos",e);
        }
        if (list != null)
            addAll(list);
        notifyDataSetChanged();
    }
}
