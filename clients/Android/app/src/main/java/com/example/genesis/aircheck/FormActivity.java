package com.example.genesis.aircheck;

import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Color;
import android.location.Location;
import android.os.Bundle;
import android.provider.Settings;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.android.gms.maps.model.LatLng;

import java.text.DecimalFormat;

public class FormActivity extends AppCompatActivity implements View.OnClickListener, SendData.OnAsyncRequestComplete, GPSTracker.LocationUpdateListener {


    private RadioGroup radioGroup;
    SendData sendData;

    String rate;
    ProgressDialog progressDialog;
    ConnectionCheck conChk;
    private AlertDialog.Builder builder;
    private AlertDialog alert;
    private Context context;
    Button bt1, bt2, bt3, bt4;
    ImageButton submit;
    RateActivity rateActivity;
    double latitude, longitude;
    LatLng myLatLng;
    GetUserLocation getUserLocation;
    GPSTracker gps;
    public static boolean isUpdated = false;
    private EditText et1, et2, et3, et4, et5, et6;
    private Spinner spinner;


    Button bt;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_form);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);


        radioGroup = (RadioGroup) findViewById(R.id.radioGroup);

        bt1 = (Button) findViewById(R.id.submit);
        bt2 = (Button) findViewById(R.id.bt1);
        bt3 = (Button) findViewById(R.id.bt2);
        bt4 = (Button) findViewById(R.id.bt3);

        bt1.setOnClickListener(this);
        bt2.setOnClickListener(this);
        bt3.setOnClickListener(this);
        bt4.setOnClickListener(this);

        conChk = new ConnectionCheck(this);


        bt2.setBackgroundColor(Color.GRAY);
        bt3.setBackgroundColor(Color.GRAY);
        bt4.setBackgroundColor(Color.GRAY);

    }

    @Override
    public void onClick(View v) {


            int selectedId = radioGroup.getCheckedRadioButtonId();
            //radioSexButton = (RadioButton) findViewById(selectedId);
            RadioButton r = (RadioButton) findViewById(selectedId);



            String selectedtext = r.getText().toString();
            Log.v("ok",selectedtext);
            AppUtil.saveVersionCode(this, selectedtext);
//            AppUtil.startNewActivity(FormActivity.this, RateActivity.class);




        if (v == bt1) {

            gps = new GPSTracker(this, this);

            getUserLocation();

        } else {

            if (v == bt2) {
                rate = "1";
                bt2.setBackgroundColor(Color.CYAN);
                bt3.setBackgroundColor(Color.GRAY);
                bt4.setBackgroundColor(Color.GRAY);
            } else if (v == bt3) {
                rate = "2";
                bt3.setBackgroundColor(Color.CYAN);
                bt2.setBackgroundColor(Color.GRAY);
                bt4.setBackgroundColor(Color.GRAY);
            }else if (v == bt4) {
                rate = "3";
                bt4.setBackgroundColor(Color.CYAN);
                bt2.setBackgroundColor(Color.GRAY);
                bt3.setBackgroundColor(Color.GRAY);
            }
            Log.v("ok",  "rate============ "+rate);


        }

    }

    public void sendData() {
        sendData = new SendData(FormActivity.this);

        Log.v("ok", ""+latitude+" "+longitude + " "+AppUtil.getText(this)+ " "+rate);
        sendData.execute(""+latitude, ""+longitude, AppUtil.getText(this), rate) ;
    }

    @Override
    public void asyncQuizResponse(int version) {

    }

    @Override
    public void asyncError(int id) {
        AppUtil.showServiceError(FormActivity.this, id);
    }



    public void showError(String result, int id) {
        // if no Internet connection is available show the user
        // position
        // if (id == -1)
        // drawMapDefault();
        //
        // else if (id == 0) {
        // drawMap();
        // }
        builder = new AlertDialog.Builder(this);
        builder.setPositiveButton("OK", new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int which) {
                dialog.cancel();
            }
        });
        // builder.setIcon()
        builder.setTitle("Error");
        builder.setMessage(result);
        alert = builder.create();
        alert.setCancelable(false);
        alert.show();
    }

    @Override
    public void onLocationUpdated(Location location) {

        if (isUpdated == false) {

            latitude = location.getLatitude();
            longitude = location.getLongitude();

            if (latitude == 0 && longitude == 0) {
                showError(
                        "Current Location Is Unavailable, Please try later. (hint: requires sky view)",
                        -1);
            } else {

                isUpdated = true;
                DecimalFormat df = new DecimalFormat("#.##");

                et3.setText("" + df.format(latitude) + ", "
                        + df.format(longitude));
                gps.stopUsingGPS();

            }

        }

    }

    public void showSettingsAlert() {
        AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);

        // Setting Dialog Title
        alertDialog.setTitle("GPS Settings");

        // Setting Dialog Message
        alertDialog
                .setMessage("GPS or Location and Google search not enabled. Do you want to go to settings menu?");

        // On pressing Settings button
        alertDialog.setPositiveButton("Enable",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Intent intent = new Intent(
                                Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                        FormActivity.this.startActivity(intent);
                    }
                });

        // on pressing cancel button
        alertDialog.setNegativeButton("Cancel",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.cancel();
                        // finish();
                    }
                });

        // Showing Alert Message
        alertDialog.show();
    }




    public void showLocationError(int id) {
        if (id == -1) {
            showError(
                    "Current Location Is Unavailable, Please try later. (hint: requires sky view)",
                    id);
        } else if (id == -2) {
            // can't get location
            // GPS or Network is not enabled
            // Ask user to enable GPS/network in settings
            showSettingsAlert();
        } else if (id == 0) {
            showError("Check your Internet connection", id);
        }
    }



    public void updateUserLocation(double lat, double lon) {

        if (isUpdated == false) {

            latitude = lat;
            longitude = lon;

            if (latitude == 0 && longitude == 0) {
                showError(
                        "Your current location is Unavailable, Please try later. (hint: requires sky view)",
                        -1);

            } else {
                // canGetPlacesList = true;
                isUpdated = true;
                sendData();
            }

            // if (canGetPlacesList)
            // getPlaceList(latitude, longitude);

            Log.v("MainActivity", "latitude" + latitude + " longitude "
                    + longitude);

            Toast.makeText(
                    this,
                    "Your Location is - \nLat: " + latitude + "\nLong: "
                            + longitude, Toast.LENGTH_LONG).show();
        } else {

            latitude = lat;
            longitude = lon;

            sendData();
        }

    }

    public void getUserLocation() {
        progressDialog = new ProgressDialog(this);
        progressDialog.setMessage("Searching your Location...");
        progressDialog.setCancelable(false);
        getUserLocation = new GetUserLocation(FormActivity.this,
                progressDialog, gps);
        getUserLocation.execute(); // go to GetPlaceList class
    }
}
