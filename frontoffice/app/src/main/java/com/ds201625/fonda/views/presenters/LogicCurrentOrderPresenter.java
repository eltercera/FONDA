package com.ds201625.fonda.views.presenters;

import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.DishOrder;
import com.ds201625.fonda.views.contracts.LogicCurrentOrderView;
import com.ds201625.fonda.views.contracts.LogicCurrentOrderViewPresenter;
import com.ds201625.fonda.logic.Command;
import com.ds201625.fonda.logic.FondaCommandFactory;
import com.ds201625.fonda.logic.SessionData;

import java.util.List;

/**
 * Created by Jessica on 22/6/2016.
 */
public class LogicCurrentOrderPresenter implements LogicCurrentOrderViewPresenter {

    private LogicCurrentOrderView logicCurrentOrderView;
    private Commensal logedComensal;
    private String emailToWebService;
    private FondaCommandFactory facCmd;
    private List<DishOrder> listDishOrderWS;
    private String TAG = "LogicCurrentOrderPresenter";

    /**
     * Constructor
     * @param view
     */
    public LogicCurrentOrderPresenter(LogicCurrentOrderView view){
        logicCurrentOrderView = view;
    }

    /**
     * Encuentra los platos ordenados
     *
     * @return
     */
    @Override
    public List<DishOrder> findAllDishOrder() {
        Log.d(TAG,"Ha entrado en findAllDishOrder");
        Command cmdAllCurrentOrder = facCmd.logicCurrentOrderCommand();
        try {
            cmdAllCurrentOrder.setParameter(0,logedComensal);
            cmdAllCurrentOrder.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findAllDishOrder al buscar los platos ordenados", e);
        }
        catch (Exception e) {
            Log.e(TAG,"Error en findAllDishOrder al buscar los platos ordenados", e);
        }
        listDishOrderWS = (List<DishOrder>) cmdAllCurrentOrder.getResult();
        Log.d(TAG,"Se retorna la lista de platos ordenados");
        Log.d(TAG,"Ha finalizado findAllDishOrder");
        return listDishOrderWS;
    }

    /**
     * Encuentra el comensal logueado
     */
    @Override
    public void findLoggedComensal() {
        Log.d(TAG,"Ha entrado en findLoggedComensal");
        Commensal log = SessionData.getInstance().getCommensal();

        emailToWebService=log.getEmail()+"/";
        facCmd = FondaCommandFactory.getInstance();
        //Llamo al comando de requireLogedCommensalCommand
        Command cmdRequireLoged = facCmd.requireLogedCommensalCommand();
        try {
            cmdRequireLoged.setParameter(0,emailToWebService);
            cmdRequireLoged.run();
        } catch (NullPointerException e){
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }catch (Exception e) {
            Log.e(TAG,"Error en findLoggedComensal al buscar el comensal logueado",
                    e);
        }

        logedComensal = (Commensal) cmdRequireLoged.getResult();
        Log.d(TAG,"Se obtiene el comensal logueado "+logedComensal.getId());
        Log.d(TAG,"Ha finalizado findLoggedComensal");
    }
}
