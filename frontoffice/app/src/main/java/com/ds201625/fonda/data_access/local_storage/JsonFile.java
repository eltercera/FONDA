package com.ds201625.fonda.data_access.local_storage;

import android.content.Context;
import com.google.gson.Gson;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Clase para guardar y obtener objetos de archivos
 * formato Json
 * @param <T>
 */
public class JsonFile <T>{

    /**
     * Nombre del archivo
     */
    private String fileName;

    /**
     * Contexto de la aplicación
     */
    private Context context;

    /**
     * Gson -> Serializador Json
     */
    private Gson gson;

    /**
     * Tipo del objeto a guardar
     */
    private Class classType;

    /**
     * Constructor unico
     * @param fileName Nombre del archivo
     * @param context Contecto de la aplicacion
     * @param clasType Class del T
     */
    public JsonFile(String fileName, Context context,Class clasType) {
        this.fileName = fileName;
        this.context = context;
        this.gson = new Gson();
        this.classType = clasType;

    }

    /**
     * Guarda o sobre-escribe el objeto en el archivo.
     * @param obj Objeto a guardar
     * @throws LocalStorageException
     */
    public void save(T obj) throws LocalStorageException {

        String data = gson.toJson(obj);

        try {
            FileOutputStream fos = context.openFileOutput(this.fileName,Context.MODE_PRIVATE);
            fos.write(data.getBytes());
            fos.close();
        } catch (FileNotFoundException e) {
            throw new LocalStorageException("Archivo no encontrado", e);
        } catch (IOException e) {
            throw new LocalStorageException("Error de IO", e);
        }

    }

    /**
     * Obtiene el bojeto del archivo.
     * @return Objeto creado.
     * @throws LocalStorageException
     */
    public T getObj() throws LocalStorageException {
        T obj;
        String data;

        try {
            FileInputStream fis = context.openFileInput(this.fileName);
            InputStreamReader isr = new InputStreamReader(fis);
            BufferedReader bufferedReader = new BufferedReader(isr);
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = bufferedReader.readLine()) != null) {
                sb.append(line);
            }
            data = sb.toString();
            fis.close();
        } catch (FileNotFoundException e) {
            throw new LocalStorageException("Archivo no encontrado", e);
        } catch (IOException e) {
            throw new LocalStorageException("Error de IO", e);
        }

        obj = (T) gson.fromJson(data,classType);
        return obj;
    }
}
