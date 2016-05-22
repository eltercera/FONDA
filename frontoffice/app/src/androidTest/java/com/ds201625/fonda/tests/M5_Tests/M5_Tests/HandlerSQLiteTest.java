package com.ds201625.fonda.tests.M5_Tests.M5_Tests;

import android.database.sqlite.SQLiteDatabase;
import android.test.AndroidTestCase;
import android.test.RenamingDelegatingContext;

import com.ds201625.fonda.logic.HandlerSQLite;

import java.util.ArrayList;

/**
 * Created by Hp on 21/05/2016.
 */
public class HandlerSQLiteTest extends AndroidTestCase {

    private SQLiteDatabase dbr;
    private SQLiteDatabase dbw;
    private RenamingDelegatingContext context;
    private ArrayList<String> cc;
    HandlerSQLite db;
    private SQLiteDatabase bd;

    protected void setUp() throws Exception{
        super.setUp();
        RenamingDelegatingContext context = new RenamingDelegatingContext(getContext(), "test_db");
        db = new HandlerSQLite(context);
        dbw = db.getWritableDatabase();
        dbr = db.getReadableDatabase();
    }

    public void testCreateDB (){
        db.onCreate(dbw);
        assertNotNull(dbw);
    }

    public void testSaveOnSQLite (){
        db.onCreate(dbw);
         db.save("4352243565789876", "Melanie Godoy", 21622433, "05/2020", 654,"Visa" );
         cc =  db.read();
        assertEquals(cc.get(0).toString(),"4352243565789876-Melanie Godoy");

    }

    public void testReadDB(){
        db.save("4352243565789876", "Melanie Godoy", 21622433, "05/2020", 654,"Visa" );
        cc =  db.read();
        assertEquals(cc.get(0).toString(),"4352243565789876-Melanie Godoy");
    }

    public void testDropDB(){
        db.onCreate(dbw);
        db.erase();
        cc =  db.read();
       assertEquals(cc.isEmpty(),true);
    }

    public void tearDown() throws Exception {
        super.tearDown();
        db = null;
        dbw = null;
        dbr = null;
    }
}
