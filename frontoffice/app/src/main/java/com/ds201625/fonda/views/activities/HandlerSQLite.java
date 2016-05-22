package com.ds201625.fonda.views.activities;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.widget.Toast;

import java.util.ArrayList;

import static android.provider.BaseColumns._ID;
/**
 * Created by Hp on 14/05/2016.
 */
public class HandlerSQLite extends SQLiteOpenHelper {

    private static HandlerSQLite instance;

    /**
     * Table on the data base
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
     * When is created
     * @param db
     */
    @Override
    public void onCreate(SQLiteDatabase db) {

        db.execSQL(table);

    }

    /**
     * When its upgraded
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
     * Saves the Credit card on SQLite Database
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
     * Reads all the credit cards saved an shows the number of credit card and the name of the owner
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
     * Erase the data base
     */
    public void erase (){
        SQLiteDatabase db = this.getReadableDatabase();
        db.beginTransaction();
        ContentValues addReg = new ContentValues();
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
