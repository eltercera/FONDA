package com.ds201625.fonda.views.activities;

/**
 * Created by Jessica on 11/5/2016.
 */
import android.os.Bundle;
import com.ds201625.fonda.R;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

public class MenuActivity extends BaseNavigationActivity {
    ListView list;
    String[] category = {
            "Aves",
            "Carnes",
            "Pastas"};
    String[] plate = {
            "Arroz con Pollo",
            "Hamburguesa Extrema",
            "Pasta Bologna"};
    String[] information = {
            "Delicioso pollo acompañado de arroz y vegetales",
            "1/2 libra de carne, tomate, lechuga, queso, aguacate, cebollas caramelizadas, champiñones",
            "Pasta con salsa de carne y tomate"};
    String[] price = {
            "2000 BsF",
            "2500 BsF",
            "1500 BsF"};
    Integer[] picture = {
            R.mipmap.ic_restaurant001,
            R.mipmap.ic_restaurant002,
            R.mipmap.ic_restaurant003};

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_menu);
        super.onCreate(savedInstanceState);

        MenuList adapter = new
                MenuList (MenuActivity.this,category, plate,information,price, picture);
        list = (ListView)findViewById(R.id.menuList);
        list.setAdapter(adapter);
        list.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Toast.makeText(MenuActivity.this, "You Clicked at " + plate[+position], Toast.LENGTH_SHORT).show();
            }
        });
    }
}
