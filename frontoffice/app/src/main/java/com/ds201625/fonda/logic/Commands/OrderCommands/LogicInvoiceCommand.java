package com.ds201625.fonda.logic.Commands.OrderCommands;

import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.OrderExceptions.LogicInvoiceWebApiControllerException;
import com.ds201625.fonda.data_access.services.InvoiceService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Invoice;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.domains.factory_entity.FondaEntityFactory;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;

/**
 * Created by Jessica on 22/6/2016.
 */
/**
 * Comando que controla la logica de la factura
 */
public class LogicInvoiceCommand extends BaseCommand{
    private String TAG = "LogicInvoiceCommand";
    /**
     * variable de tipo InvoiceService
     */
    private Invoice invoiceService;
    private Profile idProfile;

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[1];
        parameters[0] = new Parameter(Profile.class, true);

        return parameters;
    }

    /**
     * Metodo de invoke implementado: Comando para mostrar la factura
     */
    @Override
    protected void invoke() throws LogicInvoiceWebApiControllerException {

        Log.d(TAG, "Comando para ver la factura");
        InvoiceService serviceInvoice = FondaServiceFactory.getInstance().getInvoiceService();

        idProfile = FondaEntityFactory.getInstance().GetProfile();
        try {
            idProfile = FondaEntityFactory.getInstance().GetProfile();
            invoiceService = serviceInvoice.getCurrentInvoice(idProfile.getId());
        }catch (LogicInvoiceWebApiControllerException e){
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicInvoiceWebApiControllerException(e);
        } catch (RestClientException e) {
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicInvoiceWebApiControllerException(e);
        }catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicInvoiceWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado un error obteniendo la factura", e);
            throw new LogicInvoiceWebApiControllerException(e);
        }
        setResult(invoiceService);
    }
}
