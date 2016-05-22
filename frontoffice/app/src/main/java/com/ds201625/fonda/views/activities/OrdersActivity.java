package com.ds201625.fonda.views.activities;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AlertDialog;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.FrameLayout;
import android.widget.RadioButton;
import android.widget.Spinner;
import android.widget.Toast;
import com.ds201625.fonda.R;
import com.ds201625.fonda.data_access.factory.FondaServiceFactory;
import com.ds201625.fonda.data_access.services.ProfileService;
import com.ds201625.fonda.domains.Profile;
import com.ds201625.fonda.logic.LogicPayment;
import com.ds201625.fonda.views.adapters.BaseSectionsPagerAdapter;
import com.ds201625.fonda.views.fragments.BaseFragment;
import com.ds201625.fonda.views.fragments.CloseAccountFragment;
import com.ds201625.fonda.views.fragments.CreditCardFragment;
import com.ds201625.fonda.views.fragments.CurrentOrderFragment;
import com.ds201625.fonda.views.fragments.InvoiceFragment;
import com.ds201625.fonda.views.fragments.HistoryVisitFragment;
import com.ds201625.fonda.views.fragments.OrderPaymentFragment;
import com.ds201625.fonda.views.fragments.ProfileListFragment;
import java.util.ArrayList;
import java.util.List;

public class OrdersActivity extends BaseNavigationActivity implements
        ProfileListFragment.profileListFragmentListener {

    private static int pos;
    /**
     * Item del Menu
     */
    private static MenuItem closeBotton;
    private static MenuItem sendBotton;
    private static MenuItem cancelBotton;
    private static MenuItem searchBotton;
    private static MenuItem sendPayBotton;
    private static MenuItem cancelPayBotton;
    private static MenuItem downloadBotton;
    /**
     * Button that accepts the credit card selected
     */
    private static MenuItem acceptCCButton;
    /**
     * Button that saves a new credit card
     */
    private static MenuItem saveCCButton;
    /**
     * Fragment de la lista de platos
     */
    private static CurrentOrderFragment orderListFrag;

    /**
     * Interface for the Credit Card
     */
    private EditText number, name,idOwner,expiration,cvv;
    private RadioButton rBVisa,rBMaster;
    private Spinner spinner;
    /**
     * Amount of the check (subtotal+tax)
     */
    private float a;
    /**
     * Administrador de Fragments
     */
    private static FragmentManager fm;
    /**
     * Variable par usar el TabLayout
     */
    private BaseSectionsPagerAdapter mSectionsPagerAdapter;

    private ViewPager mViewPager;

    /**
     * Variable del TabLayout
     */
    private static TabLayout tb;

    private FrameLayout prueba;

    /**
     * Fragment de Cierre de cuenta
     */
    private static CloseAccountFragment closeAccFrag;

    /**
     * Fragment de pago de orden
     */
    private static OrderPaymentFragment ordPay;

    /**
     * Fragment de factura
     */
    private static InvoiceFragment factFrag;
    /**
     * Fragment for saving Credit Card
     */
    private static CreditCardFragment ccFrag;
    /**
     * Fragment of the List of Profiles
     */
    private static ProfileListFragment profFrag;

    /**
     * Fragment de historial de visitas
     */
    private static HistoryVisitFragment histVisFrag;


    /**
     * Assigns the elements of interface
     */
    private void getAllElements(){
        mViewPager = (ViewPager) findViewById(R.id.containerO);
        number = (EditText)findViewById(R.id.eT_number);
        name = (EditText) findViewById(R.id.eT_name);
        idOwner = (EditText) findViewById(R.id.eT_idOwner);
        expiration = (EditText) findViewById(R.id.eT_expiring);
        cvv = (EditText) findViewById(R.id.eT_cvv);
        rBMaster = (RadioButton) findViewById(R.id.rBMaster);
        rBVisa = (RadioButton) findViewById(R.id.rBVisa);
        spinner = (Spinner) findViewById(R.id.spinnerCC);

    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_orders);
        super.onCreate(savedInstanceState);


        //Importante Primero obtener el Tablayout
        tb = (TabLayout) findViewById(R.id.tabsO);

        prueba = (FrameLayout) findViewById(R.id.fragment_container2);

        //Inyectarlo al BaseSectionsPagerAdapter
        mSectionsPagerAdapter = new BaseSectionsPagerAdapter(getSupportFragmentManager(), tb);

        this.getAllElements();

        mViewPager.setAdapter(mSectionsPagerAdapter);
        tb.setupWithViewPager(mViewPager);

        orderListFrag = new CurrentOrderFragment();

        histVisFrag = new HistoryVisitFragment();

        //Tab con solo un String como titulo
        mSectionsPagerAdapter.addFragment("Orden Actual", orderListFrag);
        mSectionsPagerAdapter.addFragment("Historial de Visitas", histVisFrag);


        //Importante ejecutar esto para que se creen los iconos en el tab.
        mSectionsPagerAdapter.iconsSetup();

        fm = getSupportFragmentManager();

       // Probando que desaparesca el buscar
        //changeTab(mSectionsPagerAdapter);

    }

    /**
     * Sobre escritura para la iniciacion del menu en el toolbars
     *
     * @param menu
     * @return
     */
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {

        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.orders, menu);
        closeBotton = menu.findItem(R.id.close);
        sendBotton = menu.findItem(R.id.action_favorite_send);
        cancelBotton = menu.findItem(R.id.action_favorite_cancel);
        searchBotton = menu.findItem(R.id.action_favorite_search);
        sendPayBotton = menu.findItem(R.id.action_favorite_send_pay);
        cancelPayBotton = menu.findItem(R.id.action_favorite_cancel_pay);
        downloadBotton = menu.findItem(R.id.action_favorite_download);
        acceptCCButton = menu.findItem(R.id.action_favorite_accept_cc);
        saveCCButton = menu.findItem(R.id.action_favorite_save_cc);
        return true;
    }

    /**
     * Realiza el intercambio de vistas de fragments
     *
     * @param fragment el fragment que se quiere mostrar
     */
    public static void showFragment(BaseFragment fragment) {
        fm.beginTransaction()
                .replace(R.id.fragment_container2, fragment)
                .commit();
        fm.executePendingTransactions();
        tb.setVisibility(View.GONE);

        //Muestra y oculta compnentes.

        if (fragment.equals(orderListFrag)) {
            if (closeBotton != null)
                closeBotton.setVisible(true);
            if (searchBotton != null)
                searchBotton.setVisible(false);
        }
        else if (fragment.equals(histVisFrag)) {
            if (searchBotton != null)
                searchBotton.setVisible(true);
            if (closeBotton != null)
                closeBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)) {
                sendBotton.setVisible(false);
                cancelBotton.setVisible(false);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(false);
                cancelPayBotton.setVisible(false);
            }
            if ((acceptCCButton != null) && (saveCCButton != null)) {
                acceptCCButton.setVisible(false);
                saveCCButton.setVisible(false);
            }
        }
        else if (fragment.equals(closeAccFrag)) {
            if (closeBotton != null)
                closeBotton.setVisible(false);
            if (searchBotton != null)
                searchBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)) {
                sendBotton.setVisible(true);
                cancelBotton.setVisible(true);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(false);
                cancelPayBotton.setVisible(false);
            }
            if ((acceptCCButton != null) && (saveCCButton != null)) {
                acceptCCButton.setVisible(false);
                saveCCButton.setVisible(false);
            }
        } else if (fragment.equals(ordPay)) {
            if (closeBotton != null)
                closeBotton.setVisible(false);
            if (searchBotton != null)
                searchBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)) {
                sendBotton.setVisible(false);
                cancelBotton.setVisible(false);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(true);
                cancelPayBotton.setVisible(true);
            }
            if ((acceptCCButton != null) && (saveCCButton != null)) {
                acceptCCButton.setVisible(false);
                saveCCButton.setVisible(false);
            }
        } else if (fragment.equals(ccFrag)) {
                if (closeBotton != null)
                    closeBotton.setVisible(false);
            if (searchBotton != null)
                searchBotton.setVisible(false);
                if ((sendBotton != null) && (cancelBotton != null)) {
                    sendBotton.setVisible(false);
                    cancelBotton.setVisible(false);
                }
                if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                    sendPayBotton.setVisible(false);
                    cancelPayBotton.setVisible(false);
                }
                if ((acceptCCButton != null) && (saveCCButton != null)) {
                    acceptCCButton.setVisible(true);
                    saveCCButton.setVisible(true);
             }
            }else if (fragment.equals(factFrag)) {
            if (closeBotton != null)
                closeBotton.setVisible(false);
            if (searchBotton != null)
                searchBotton.setVisible(false);
            if ((sendBotton != null) && (cancelBotton != null)) {
                sendBotton.setVisible(false);
                cancelBotton.setVisible(false);
            }
            if ((sendPayBotton != null) && (cancelPayBotton != null)) {
                sendPayBotton.setVisible(false);
                cancelPayBotton.setVisible(false);
            }
            if ((acceptCCButton != null) && (saveCCButton != null)) {
                acceptCCButton.setVisible(false);
                saveCCButton.setVisible(false);
            }
            if (downloadBotton != null)
                downloadBotton.setVisible(true);
        } else {
            if (downloadBotton != null)
                downloadBotton.setVisible(false);
        }


    }

    /**
     * Opciones y acciones del menu en el toolbars
     *
     * @param item
     * @return
     */
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.close:
                close();
                break;
            case R.id.action_favorite_search:
                buscar();
                break;
            case R.id.action_favorite_send:
                cambiarPa();
                a = amount();
                System.out.println(a);
                break;
            case R.id.action_favorite_cancel:
                exit();
                break;
            case R.id.action_favorite_send_pay:
                try {
                    cambiarFac();
                }
                catch(NullPointerException n){

                }
                break;
            case R.id.action_favorite_cancel_pay:
                close();
                break;
            case R.id.action_favorite_download:
                download();
                break;
            case R.id.action_favorite_save_cc:
                validationCC();
                break;
            case R.id.action_favorite_accept_cc:
                acceptCC();
                break;
        }
        return true;
    }

    private void close() {
     /*   AlertDialog dialog = buildSingleDialog("Cierre de Cuenta",
                "Se puede proceder con el cierre.");
        dialog.show();
    */
        if (closeAccFrag == null)
            closeAccFrag = new CloseAccountFragment();
        showFragment(closeAccFrag);
    }


    private void exit() {

        Intent cambio = new Intent(this, OrdersActivity.class);
        startActivity(cambio);
    }

    public void cambiarPa() {
        if (ordPay == null)
            ordPay = new OrderPaymentFragment();
        showFragment(ordPay);
    }


    private void buscar() {

        //Metodo para el boton de buscar
        AlertDialog dialog = buildSingleDialog("Historial",
                "Busqueda");
        dialog.show();
    }

    public void cambiarFac() {
        getAllElements();
        try {
            String cc = spinner.getSelectedItem().toString();
            String[] numbers = cc.split("-");
            String numberCC = numbers[0].toString();
            int profile = 1;
            if (factFrag == null)
                try {
                    LogicPayment.getInstance().registerPayment(profile, a, numberCC);
                } catch (Exception e) {
                    e.getMessage();
                }
        }
        catch(NullPointerException e){
            e.getMessage();
            System.out.println("Spinner vacio");
        }
        factFrag = new InvoiceFragment();
        showFragment(factFrag);
    }


    public void download() {
        exit();
    }

    /**
     * Allows to select only one radio button
     * @param view
     */
    public void onRadioButtonClicked(View view) {
        // Is the button now checked?
        String typeOfCC = null;
        boolean checked = ((RadioButton) view).isChecked();

        // Check which radio button was clicked
        switch (view.getId()) {
            case R.id.rBVisa:
                if (checked)
                    typeOfCC = "Visa";
                Toast.makeText(this, "Tipo de tarjeta " + typeOfCC, Toast.LENGTH_SHORT).show();
                break;
            case R.id.rBMaster:
                if (checked)
                    typeOfCC = "MasterCard";
                Toast.makeText(this, "Tipo de tarjeta " + typeOfCC, Toast.LENGTH_SHORT).show();
                break;
        }
    }

    /**
     * Saves the credit card on SqLite Database
     */
    public void saveCC(){
        getAllElements();
        HandlerSQLite handlerSQLite = new HandlerSQLite(this);
        String numberCC = number.getText().toString();
        String nameCC = name.getText().toString();
        int idOwnerCC = Integer.parseInt(idOwner.getText().toString());
        String expCC = expiration.getText().toString();
        int cvvCC = Integer.parseInt(cvv.getText().toString());
        boolean typeMaster = rBMaster.isChecked();
        boolean typeVisa = rBVisa.isChecked();
        if(typeMaster) {
            handlerSQLite.save(numberCC, nameCC, idOwnerCC, expCC, cvvCC, "Mastercard");
        }
        else if(typeVisa) {
            handlerSQLite.save(numberCC, nameCC, idOwnerCC, expCC, cvvCC, "Visa");
        }
        ArrayAdapter<String> LTRadapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item,
                handlerSQLite.read());
        LTRadapter.setDropDownViewResource(android.R.layout.simple_dropdown_item_1line);
        spinner.setAdapter(LTRadapter);
        Toast.makeText(this, "Agregado ", Toast.LENGTH_SHORT).show();

    }

    /**
     * Gets the credit card selected
     */
    public void acceptCC (){
        getAllElements();
        Bundle args = new Bundle();
        String cc = spinner.getSelectedItem().toString();
            ordPay = new OrderPaymentFragment();
            args.putFloat("amount",a);
            args.putString("creditC", cc);
            ordPay.setArguments(args);
            showFragment(ordPay);
    }

    /**
     * Obtains the total amount (subtotal + tax) from the previous fragment
     * @return amountT amount of the bill
     */
    public float amount (){
        Bundle args = new Bundle();
        CloseAccountFragment cls = new CloseAccountFragment();
        float amountT = cls.getAmount();
        ordPay = new OrderPaymentFragment();
        args.putFloat("amount", amountT);
        ordPay.setArguments(args);
        showFragment(ordPay);
        return amountT;
    }

    /**
     * Validates all fields on fragment Credit Card
     */
    public void validationCC (){
        getAllElements();
        saveCCButton.setOnMenuItemClickListener(new MenuItem.OnMenuItemClickListener() {
            @Override
            public boolean onMenuItemClick(MenuItem item) {
                validate();
                return false;
            }
        });

    }

    /**
     * Contains the methods that validate the fields
     */
    public void validate(){
        String numberCC = number.getText().toString();
        String nameCC = name.getText().toString();
        String idOwnerCC = idOwner.getText().toString();
        String expCC = expiration.getText().toString();
        String cvvCC = cvv.getText().toString();
        boolean typeMaster = rBMaster.isChecked();
        boolean typeVisa = rBVisa.isChecked();

        boolean nu = validateCCNumber(numberCC);
        boolean na = validateNameOwner(nameCC);
        boolean id = validateIdOwner(idOwnerCC);
        boolean ex = validateDate(expCC);
        boolean cv = validateCvv(cvvCC);

        if (nu && na && id && cv && ex || typeMaster || typeVisa){

            saveCC();
        }
        else
        {
            Toast.makeText(this, "Debe seleccionar tipo tarjeta", Toast.LENGTH_SHORT).show();

        }

    }

    /**
     * validates that the Credit Card number is larger that 20 numbers
     * @param numberC number of credit card
     * @return true if its not 20 digits and false if it is
     */
    public boolean validateCCNumber(String numberC){
        boolean op = true;
            if (numberC.isEmpty() || numberC.length() < 20) {
                op = false;
                number.setError("Debe contener 20 dígitos");
            }
        return op;
    }

    /**
     * Validates if the field is empty
     * @param nameO name of the owner
     * @return true if its not empty and false if it is
     */
    private boolean validateNameOwner(String nameO){
        boolean op = true;
        if(nameO.isEmpty()){
          op = false;
        name.setError("Campo obligatorio");
    }
        return op;
    }

    /**
     * Validates if the field is empty
     * @param id id of the owner
     * @return op true if its not empty and false if it is
     */
    private boolean validateIdOwner(String id){
        boolean op = true;
        if(id.isEmpty()) {
            op = false;
            idOwner.setError("Campo obligatorio");
        }
        return op;
    }

    /**
     * Validates if the field is empty
     * @param dateC date of expiring
     * @return op true if its not empty and false if it is
     */
    private boolean validateDate(String dateC){
        boolean op = true;
        if(dateC.isEmpty()) {
            op = false;
            expiration.setError("Campo obligatorio");
        }
        return op;
    }

    /**
     * Validates if the field is empty
     * @param cvvC
     * @return op true if its not empty and false if it is
     */
     private boolean validateCvv(String cvvC){
        boolean op = true;
        if(cvvC.isEmpty() || cvvC.length() < 3 ) {
            op = false;
            cvv.setError("Debe contener 3 digitos");
        }
        return op;
    }

    /**
     * Methods implemented of the profile
     * @param profile profiles saved
     */
    @Override
    public void OnProfileSelect(Profile profile) {
        Bundle args = new Bundle();
        String nameProf = profile.getProfileName();
        ordPay = new OrderPaymentFragment();
        args.putString("profile", nameProf);
        ordPay.setArguments(args);
        showFragment(ordPay);
    }

    @Override
    public void OnProfilesSelected(ArrayList<Profile> profile) {

    }

    @Override
    public void OnProfileSelectionMode() {

    }

    @Override
    public void OnProfileSelectionModeExit() {

    }

    /**
     * changes the fragment depending of the parameter
     * @param opc
     */
    public static void changeFrag (int opc){
        if(opc == 1){
            List<Profile> p;
            profFrag = new ProfileListFragment();
            Bundle args = new Bundle();
            args.putBoolean("multiSelect",true);
            profFrag.setArguments(args);

        }
        if(opc == 2) {
            ccFrag = new CreditCardFragment();
            showFragment(ccFrag);
        }
    }


    public void changeTab(BaseSectionsPagerAdapter mSectionsPagerAdapter){
        if(mSectionsPagerAdapter.getItem(0).isAdded()){
            if (searchBotton != null)
            searchBotton.setVisible(false);
        }else if(mSectionsPagerAdapter.getItem(1).isAdded()){
            if (searchBotton != null)
            searchBotton.setVisible(true);
        }
    }


}