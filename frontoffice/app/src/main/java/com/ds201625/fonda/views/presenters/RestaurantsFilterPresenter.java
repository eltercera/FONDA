package com.ds201625.fonda.views.presenters;

import com.ds201625.fonda.domains.NounBaseEntity;
import com.ds201625.fonda.domains.Restaurant;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.views.adapters.ItemFilterAdapter;
import com.ds201625.fonda.views.adapters.RestaurantAdapter;
import com.ds201625.fonda.views.contracts.RestaurantsFiltersContract;
import java.util.List;

/**
 * Presentador controlador para vista / fragment de busqueda de restaurantes
 */
public class RestaurantsFilterPresenter {

    /**
     * Fragment con la implementacion del contrato
     */
    private RestaurantsFiltersContract fragment;

    /**
     * Tipo de filtro a mostrar
     */
    private RestaurantsFilterPresenterType type;

    /**
     * Adaptador para lista de restaurante
     */
    private RestaurantAdapter restaurantAdapter;

    /**
     * Adaptador para lista de items de filtro
     */
    private ItemFilterAdapter itemFilterAdapter;

    /**
     * Control de pagina de lista
     */
    private int restPage = 1;
    private int itemPage = 1;
    private boolean listFull = false;

    /**
     * Control de filtros
     */
    private int idZone= 0;
    private int idCat = 0;
    private String textSearch = null;

    /**
     * Control del adaptador que se muestra
     */
    private boolean showRestaurant;



    public RestaurantsFilterPresenter
            (RestaurantsFiltersContract fragment, RestaurantsFilterPresenterType type) {
        this.fragment = fragment;
        this.type = type;
    }

    /**
     * Ejecutar en onCreateView del fragmente para inicializar los componentes
     */
    public void onCreateView() {

        // inicializacion de los adaptes
        if(this.restaurantAdapter == null)
            this.restaurantAdapter = new RestaurantAdapter(fragment.getContext());
        if(this.itemFilterAdapter == null)
            this.itemFilterAdapter = new ItemFilterAdapter(fragment.getContext());

        if (this.type == RestaurantsFilterPresenterType.GENERAL) {
            this.fragment.getListView().setAdapter(this.restaurantAdapter);
            this.showRestaurant = true;
        } else {
            this.fragment.getListView().setAdapter(this.itemFilterAdapter);
            this.showRestaurant = false;
        }
        onRefresh();
    }

    /**
     * Refresca / reinicia los adapters
     */
    public void onRefresh() {
        if (this.showRestaurant) {
            this.restaurantAdapter.clear();
            this.restPage = 1;
            this.restaurantAdapter.notifyDataSetChanged();
        } else {
            this.itemFilterAdapter.clear();
            this.itemPage = 1;
            this.itemFilterAdapter.notifyDataSetChanged();
        }
        this.listFull = false;
        fillList();
    }

    /**
     * Ejecutar cuando el listview esta al fundo
     */
    public void scrollOnBottom() {
        if(listFull)
            return;

        if (this.showRestaurant) {
            this.restPage++;
        } else {
            this.itemPage++;
        }
        fillList();
    }

    /**
     * Ejecutar el filtro de busqeda
     * @param text
     */
    public void search(String text) {
        this.textSearch = text;
        fillList();
    }

    /**
     * Llenado de lista
     */
    private void fillList() {
        Command cmd = null;

        if (this.showRestaurant) {
            cmd = FondaCommandFactory.getInstance().getRestaurantsCommand();
            try {
                cmd.setParameter(0,this.textSearch);
                cmd.setParameter(1,6);
                cmd.setParameter(2,this.restPage);
                cmd.setParameter(3,this.idZone);
                cmd.setParameter(4,this.idCat);
            } catch (Exception e) {
                e.printStackTrace();
            }

            try {
                cmd.run();
            } catch (Exception e) {
                e.printStackTrace();
            }

            if (cmd.getResult() != null) {
                if (((List<Restaurant>)cmd.getResult()).isEmpty())
                    this.listFull = true;
                else
                    restaurantAdapter.addAll((List<Restaurant>) cmd.getResult());
            }
        } else {
            switch (this.type) {
                case ZONE:
                    cmd = FondaCommandFactory.getInstance().getZonesCommand();
                    break;
                case CATEGORY:
                    cmd = FondaCommandFactory.getInstance().getCategoriesCommand();
                    break;
                default:

                    break;
            }

            try {
                cmd.setParameter(0,this.textSearch);
                cmd.setParameter(1,10);
                cmd.setParameter(2,this.itemPage);
            } catch (Exception e) {
                e.printStackTrace();
            }

            try {
                cmd.run();
            } catch (Exception e) {
                e.printStackTrace();
            }

            if (cmd.getResult() != null) {
                if (((List<NounBaseEntity>)cmd.getResult()).isEmpty())
                    this.listFull = true;
                else
                    itemFilterAdapter.addAll((List<NounBaseEntity>) cmd.getResult());
            }
        }
    }

    /**
     * Enumerador para tipo de lsita
     */
    public enum RestaurantsFilterPresenterType {
        GENERAL,
        ZONE,
        CATEGORY
    }
}
