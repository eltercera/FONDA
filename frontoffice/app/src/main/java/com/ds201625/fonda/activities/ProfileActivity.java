package com.ds201625.fonda.activities;

import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ListView;

import com.ds201625.fonda.R;

public class ProfileActivity extends BaseNavigationActivity {

    MenuItem saveBotton;
    ListView profiles;
    ProfileViewItemList profileList;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_profile);

        profiles = (ListView)findViewById(R.id.lvProfileList);

        profileList = new ProfileViewItemList(this);

        profileList.add(new ProfileViewItem("Profile 1","Nombew 1","J-1544152214"));
        profileList.add(new ProfileViewItem("Profile 2","Nombew 2","J-1544152214"));
        profileList.add(new ProfileViewItem("Profile 3","Nombew 3","J-1544152214"));
        profileList.add(new ProfileViewItem("Profile 4","Nombew 4","J-1544152214"));

        profiles.setAdapter(profileList);

        super.onCreate(savedInstanceState);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.profile, menu);

        saveBotton = menu.findItem(R.id.action_favorite_save);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_favorite_save:
                save();
                break;
        }
        return true;
    }

    private void save() {
        AlertDialog dialog = buildSingleDialog("Actualización de perfil",
                "La actualización fue satisfactoria.");
        dialog.show();
    }
}
