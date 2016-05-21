package com.ds201625.fonda.views.activities;

import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.ActionMode;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Toast;

import com.ds201625.fonda.R;
import com.ds201625.fonda.domains.Profile;

/**
 * Created by Jessica on 15/5/2016.
 */
public class CancelReserveActivity extends BaseNavigationActivity {

    private MenuItem cancelReserve;
    private Toolbar tb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_cancel_reserve);
        super.onCreate(savedInstanceState);
    }

    public boolean onActionItemClicked(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_cancel_reserve:
                ConfirmDialog();
            break;
           // return false;
        }
        return true;
    }

    public void accept() {
        Toast t=Toast.makeText(this,"Su reservación fue cancelada", Toast.LENGTH_SHORT);
        t.show();
    }

    public void cancel() {
        finish();
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.cancel_reserve, menu);

        cancelReserve = menu.findItem(R.id.action_cancel_reserve);
        tb = (Toolbar)findViewById(R.id.toolbar);
        tb.setVisibility(View.VISIBLE);

        onActionItemClicked(cancelReserve);
        return true;
    }

    public void ConfirmDialog(){
        AlertDialog.Builder confirmCancelDialog = new AlertDialog.Builder(this);
        confirmCancelDialog.setTitle("Cancelar Reservación");
        confirmCancelDialog.setMessage("¿Desea cancelar la reservación?");
        confirmCancelDialog.setCancelable(false);
        confirmCancelDialog.setPositiveButton("Confirmar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface confirmCancelDialog, int id) {
                accept();
            }
        });
        confirmCancelDialog.setNegativeButton("Cancelar", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface confirmCancelDialog, int id) {
                cancel();
            }
        });
        confirmCancelDialog.show();
    }
}
