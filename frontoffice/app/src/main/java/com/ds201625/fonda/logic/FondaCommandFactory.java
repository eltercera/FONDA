package com.ds201625.fonda.logic;

import com.ds201625.fonda.logic.Commands.FavoriteCommands.AddFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.CreateProfileCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.AllRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.DeleteFavoriteRestaurantCommand;
import com.ds201625.fonda.logic.Commands.FavoriteCommands.RequireLogedCommensalCommand;

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
    public Command createCreateProfileCommand() {
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
    public static Command allFavoriteRestaurantCommand() {
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
}
