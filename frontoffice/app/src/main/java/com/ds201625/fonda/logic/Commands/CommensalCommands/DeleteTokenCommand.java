package com.ds201625.fonda.logic.Commands.CommensalCommands;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.retrofit_client.RestClientException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.DeleteTokenFondaWebApiControllerException;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.data_access.services.TokenService;
import com.ds201625.fonda.domains.Commensal;
import com.ds201625.fonda.domains.Token;
import com.ds201625.fonda.logic.BaseCommand;
import com.ds201625.fonda.logic.Parameter;
import com.ds201625.fonda.logic.SessionData;

/**
 * Comando para eliminar un Token
 */
public class DeleteTokenCommand extends BaseCommand {

    private String TAG = "DeleteTokenCommand";

    /**
     * Se asignan los parametros del commando
     * @return el parametro Context y commensal
     */

    @Override
    protected Parameter[] setParameters() {
        Parameter [] parameters = new Parameter[2];
        parameters[0] = new Parameter(Context.class, true);
        parameters[1] = new Parameter(Commensal.class, true);
        return parameters;
    }

    @Override
    protected void invoke() throws DeleteTokenFondaWebApiControllerException {

        Log.d(TAG, "Comando para eliminar un Token");
        Context context;
        Commensal commensal;

        try
        {
            context = (Context) getParameter(0);
            commensal = (Commensal) getParameter(1);
            TokenService tokenService = FondaServiceFactory.getInstance().getTokenService(commensal);
            Token tokenTest = tokenService.getToken(context);
            if (tokenTest != null) {
                tokenService.removeToken(context);
            }

        }
        catch(DeleteTokenFondaWebApiControllerException e){
            Log.e(TAG, "Se ha generado error en invoke al eliminar el Token", e);
            throw  new DeleteTokenFondaWebApiControllerException(e);
        }
        catch (RestClientException e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar el Token", e);
            throw  new DeleteTokenFondaWebApiControllerException(e);
        } catch (NullPointerException e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar el Token", e);
            throw  new DeleteTokenFondaWebApiControllerException(e);
        } catch (Exception e) {
            Log.e(TAG, "Se ha generado error en invoke al eliminar el Token");
            throw  new DeleteTokenFondaWebApiControllerException(e);
        }

        setResult(true);
    }
}
