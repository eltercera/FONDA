package com.ds201625.fonda.logic;

import com.ds201625.fonda.data_access.retrofit_client.exceptions.FindFavoriteRestaurantFondaWebApiControllerException;
import com.ds201625.fonda.data_access.retrofit_client.exceptions.LoginExceptions.GetReservationFondaWebApiControllerException;
import com.ds201625.fonda.logic.Commands.CommensalCommands.CreateCommensalCommand;
import com.ds201625.fonda.logic.Commands.CommensalCommands.CreateTokenCommand;
import com.ds201625.fonda.logic.Commands.CommensalCommands.DeleteTokenCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AddFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.OrderCommands.LogicCurrentOrderCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.CreateProfileCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.DeleteFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.RequireLogedCommensalCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.DeleteProfileCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.GetProfilesCommand;
import com.ds201625.fonda.logic.Commands.ProfileCommands.UpdateProfileCommand;
import com.ds201625.fonda.logic.Commands.RestaurantCommands.*;
import com.ds201625.fonda.logic.Commands.ReservationCommands.*;

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

    public Command getCategoriesCommand() {
        return new GetCategoriesCommand();
    }

    public Command getZonesCommand() {
        return new GetZonesCommand();
    }

    public Command getRestaurantsCommand() {
        return new GetRestaurantsCommand();
    }

    public Command getSetFabRestaurantCommand() {
        return new SetFabRestaurantCommand();
    }

    public static Command createCommensalCommand() {
        return new CreateCommensalCommand();
    }

    public static Command createProfileCommand() {
        return new CreateProfileCommand();
    }

    public static Command deleteProfileCommand() {
        return new DeleteProfileCommand();
    }

    public static Command getProfilesCommand() {
        return new GetProfilesCommand();
    }

    public static Command updateProfileCommand() {
        return new UpdateProfileCommand();
    }

    public static Command createTokenCommand() {
        return new CreateTokenCommand();
    }

    public static Command deleteTokenCommand() {
        return new DeleteTokenCommand();
    }

    public static Command logicCurrentOrderCommand() {
        return new LogicCurrentOrderCommand();
    }

    public static Command addReservationCommand() {
        return new AddReservationCommand();
    }

    public static Command allReservationCommand() throws GetReservationFondaWebApiControllerException {
        return new AllReservationCommand();
    }
}
