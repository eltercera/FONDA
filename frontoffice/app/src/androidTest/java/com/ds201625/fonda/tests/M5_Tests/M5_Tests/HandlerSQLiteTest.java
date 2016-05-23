package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import android.database.sqlite.SQLiteDatabase;
import android.test.AndroidTestCase;
import android.test.RenamingDelegatingContext;

import com.ds201625.fonda.logic.HandlerSQLite;

import java.util.ArrayList;

/**
 * Created by Hp on 21/05/2016.
 */

/**
 * Clase De pruebas unitarias del registro en BD
 */
public class HandlerSQLiteTest extends AndroidTestCase {

    /*
     Variable de tipo SQLiteDatabase
    */
    private SQLiteDatabase dbr;

    /*
    Variable de tipo SQLiteDatabase
   */
    private SQLiteDatabase dbw;

    /*
   Variable de tipo RenamingDelegatingContext
  */
    private RenamingDelegatingContext context;

    /*
    Variable de tipo ArrayList<String>
    */
    private ArrayList<String> cc;

    /*
   Variable de tipo HandlerSQLite
  */
    HandlerSQLite db;

    /*
  Variable de tipo SQLiteDatabase
    */
    private SQLiteDatabase bd;

    /**
     * Metodo que se encarga de instanciar los objetos de las pruebas unitarias
     * @throws Exception
     */
    protected void setUp() throws Exception{
        super.setUp();
        RenamingDelegatingContext context = new RenamingDelegatingContext(getContext(), "test_db");
        db = new HandlerSQLite(context);
        dbw = db.getWritableDatabase();
        dbr = db.getReadableDatabase();
    }

    /**
     * Metodo que prueba si se crea la BD
     */
    public void testCreateDB (){
        db.onCreate(dbw);
        assertNotNull(dbw);
    }

    /**
     * Metodo que prueba si se registra una tarjeta de credito
     */
    public void testSaveOnSQLite (){
        db.onCreate(dbw);
         db.save("4352243565789876", "Melanie Godoy", 21622433, "05/2020", 654,"Visa" );
         cc =  db.read();
        assertEquals(cc.get(0).toString(),"4352243565789876-Melanie Godoy");

    }

    /**
     * Metodo que prueba si se lee una tarjeta de credito
     */
    public void testReadDB(){
        db.save("4352243565789876", "Melanie Godoy", 21622433, "05/2020", 654,"Visa" );
        cc =  db.read();
        assertEquals(cc.get(0).toString(),"4352243565789876-Melanie Godoy");
    }

    /**
     * Metodo que prueba si la lista de tarjetas de credito queda vacia
     */
    public void testDropDB(){
        db.onCreate(dbw);
        db.erase();
        cc =  db.read();
       assertEquals(cc.isEmpty(),true);
    }

    /**
     * Metodo para limpiar los objetos de las pruebas unitarias
     * @throws Exception
     */
    public void tearDown() throws Exception {
        super.tearDown();
        db = null;
        dbw = null;
        dbr = null;
    }
}
