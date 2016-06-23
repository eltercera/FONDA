
package com.ds201625.fonda.logic;


import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.logic.Commands.CommensalCommands.CreateTokenCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AddFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.CreateProfileCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.DeleteFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.RequireLogedCommensalCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.DeleteProfileCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.GetProfilesCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.UpdateProfileCommand;
import com.ds201625.fonda.logic.Commands.CommensalCommands.CreateCommensalCommand;
import com.ds201625.fonda.logic.Commands.CommensalCommands.DeleteTokenCommand;
import com.ds201625.fonda.logic.Commands.ReservationCommands.AddReservationCommand;
import com.ds201625.fonda.logic.Commands.ReservationCommands.AllReservationCommand;

/**
 * Fabrica de comandos
 */
public class FondaCommandFactory {

    /**
     * Instancia Singelton de la fabrica
     */
    private static FondaCommandFactory instance;

    /**
     * Obtiene la instancio singelton de la fabrica
     * @return instancio singelton de la fabrica
     */
    public static FondaCommandFactory getInstance() {
        if (instance == null)
            instance = new FondaCommandFactory();

        return instance;
    }

    public FondaCommandFactory() {  }

    /**
     * Crea un CreateProfileCommand
     * @return comando CreateProfileCommand
     */
    public static Command createProfileCommand() {
        return  new CreateProfileCommand();
    }

    /**
     * Crea un AddFavoriteRestaurantCommand
     * @return comando AddFavoriteRestaurantCommand
     */
    public static Command addFavoriteRestaurantCommand() {
        return  new AddFavoriteRestaurantCommand();
    }

    /**
     * Crea un DeleteFavoriteRestaurantCommand
     * @return comando DeleteFavoriteRestaurantCommand
     */
    public static Command deleteFavoriteRestaurantCommand() {
        return  new DeleteFavoriteRestaurantCommand();
    }

    /**
     * Crea un AllFavoriteRestaurantCommand
     * @return comando AllFavoriteRestaurantCommand
     */
    public static Command allFavoriteRestaurantCommand() throws
            FindFavoriteRestaurantFondaWebApiControllerException {
        return  new AllFavoriteRestaurantCommand();
     }

    /**
     * Crea un AllRestaurantCommand
     * @return comando AllRestaurantCommand
     */
    public static Command allRestaurantCommand() {
        return  new AllRestaurantCommand();
    }

    /**
     * Crea un RequireLogedCommensalCommand
     * @return comando RequireLogedCommensalCommand
     */
    public static Command requireLogedCommensalCommand() {
        return  new RequireLogedCommensalCommand();
    }

    /**
     * Crea un updateProfileCommand
     * @return comando updateProfileCommand
     */
    public static Command updateProfileCommand() {
        return  new UpdateProfileCommand();
    }

    /**
     * Crea un deleteProfileCommand
     * @return comando deleteProfileCommand
     */
    public static Command deleteProfileCommand() {
        return  new DeleteProfileCommand();
    }

    /**
     * Crea un getProfilesCommand
     * @return comando getProfilesCommand
     */
    public static Command getProfilesCommand() { return  new GetProfilesCommand(); }

    /**
     * Crea un createCommensalCommand
     * @return comando createCommensalCommand
     */
    public static Command createCommensalCommand() { return  new CreateCommensalCommand(); }

    /**
     * Crea un deleteTokenCommand
     * @return comando deleteTokenCommand
     */
    public static Command deleteTokenCommand() { return  new DeleteTokenCommand();
    }

    /**
     * Crea un createTokenCommand
     * @return comando createTokenCommand
     */
    public static Command createTokenCommand() { return  new CreateTokenCommand();
    }


    /**
     * Crea un AddReservationCommand
     * @return comando AddReservationCommand
     */
    public static Command AddReservationCommand() {
        return  new AddReservationCommand();
    }

    /**
     * Crea un AllReservationCommand
     * @return comando AllReservationCommand
     */
    public static Command AllReservationCommand() {
        return  new AllReservationCommand();
    }
}

