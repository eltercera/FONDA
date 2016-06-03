package com.ds201625.fonda.logic;

import com.ds201625.fonda.logic.Commands.CreateProfileCommand;

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

}
