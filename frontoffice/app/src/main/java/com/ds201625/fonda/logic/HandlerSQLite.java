package com.ds201625.fonda.logic;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;

import static android.provider.BaseColumns._ID;

/**
 * Clase que maneja la base de datos interna SQLite
 */
public class HandlerSQLite extends SQLiteOpenHelper {

    private static HandlerSQLite instance;

    /**
     * Tabla que se agrega en la BD
     */
    private  String table = "CREATE TABLE creditcard (" + _ID +" INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "number TEXT, owner TEXT, id_owner INTEGER, expiration TEXT, cvv INTEGER, type TEXT);";


    /**
     * Constructor
     * @param context
     */
    public HandlerSQLite(Context context) {

        super(context,"CreditCard", null, 1);
    }

    /**
     * Cuando se  crea
     * @param db
     */
    @Override
    public void onCreate(SQLiteDatabase db) {
        try {
            db.execSQL(table);
        }
        catch(SQLiteException s){
            System.out.println("Base de Datos ya existe");
        }

    }

    /**
     * Cuando se actualiza
     * @param db
     * @param oldVersion
     * @param newVersion
     */
    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

        db.execSQL("DROP TABLE IF EXISTS creditcard");
        onCreate(db);

    }

    /**
     * Guarda la TDC en SQLite Database
     * @param number
     * @param name
     * @param idOwner
     * @param expiration
     * @param cvv
     * @param type
     */
    public void save (String number, String name, Integer idOwner, String expiration, Integer cvv, String type){
        SQLiteDatabase db = this.getWritableDatabase();
        db.beginTransaction();
        ContentValues addReg = new ContentValues();
        try {
            addReg.put("number", number);
            addReg.put("owner", name);
            addReg.put("id_owner", idOwner);
            addReg.put("expiration", expiration);
            addReg.put("cvv", cvv);
            addReg.put("type", type);
            db.insert("creditcard", null, addReg);
            db.setTransactionSuccessful();
        }catch(Exception e){
            e.getMessage();
        } finally {
            db.endTransaction();
            db.close();
        }

    }

    /**
     * Lee la base de datos y muestra el numero de la tarjeta de credito y nombre del dueño
     * @return
     */
   public ArrayList<String> read (){
          ArrayList<String> numbers = new ArrayList<>();
          SQLiteDatabase db = this.getReadableDatabase();
       try {
          db.beginTransaction();
          String select = "SELECT number, owner FROM creditcard";
          Cursor c = db.rawQuery(select, null);
          if (c.getCount() > 0) {
              while (c.moveToNext()) {
                  String numb = c.getString(c.getColumnIndex("number"));
                  String name = c.getString(c.getColumnIndex("owner"));
                  numbers.add(numb+"-"+name);
              }
          }
          db.setTransactionSuccessful();
      } catch (Exception e){
          e.getMessage();
      }finally {
           db.endTransaction();
           db.close();
       }
       return numbers;
   }

    /**
     * Borra la base de datos
     */
    public void erase (){
        SQLiteDatabase db = this.getReadableDatabase();
        db.beginTransaction();
        try {
            db.execSQL("DROP TABLE IF EXISTS creditcard");
            db.setTransactionSuccessful();
        }catch(Exception e){
            e.getMessage();
        } finally {
            db.endTransaction();
            db.close();
        }
    }

    public static HandlerSQLite getInstance(Context context){
        return instance;
    }


}
