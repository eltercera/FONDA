package com.ds201625.fonda.data_access.local_storage;

import android.content.Context;
import android.util.Log;

import com.ds201625.fonda.domains.Commensal;
import com.google.gson.Gson;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Created by rrodriguez on 5/16/16.
 */
public class JsonFile <T>{

    private String fileName;

    private Context context;

    private Gson gson;

    private Class classType;

    public JsonFile(String fileName, Context context,Class clasType) {
        this.fileName = fileName;
        this.context = context;
        this.gson = new Gson();
        this.classType = clasType;

    }

    public void save(T obj) {

        String data = gson.toJson(obj);

        try {
            FileOutputStream fos = context.openFileOutput(this.fileName,Context.MODE_PRIVATE);
            fos.write(data.getBytes());
            fos.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    public T getObj()
    {
        T obj = null;
        String data = "";

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
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

        Log.v("Fooondaaaa: ","asdasd"+data);
        obj = (T) gson.fromJson(data,classType);
        return obj;
    }


}
