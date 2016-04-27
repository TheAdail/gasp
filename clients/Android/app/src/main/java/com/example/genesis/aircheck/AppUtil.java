package com.example.genesis.aircheck;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.text.InputType;
import android.util.Log;
import android.widget.EditText;
import android.widget.Toast;


import java.util.ArrayList;

public class AppUtil {

    public static String TAG = AppUtil.class.getSimpleName();



    public static void startNewActivity(Activity currentActivity,
                                        Class<? extends Activity> newTopActivityClass) {
        Intent intent = new Intent(currentActivity, newTopActivityClass);
        currentActivity.startActivity(intent);
        currentActivity.overridePendingTransition(R.anim.slide_out_right, R.anim.slide_out_left);
    }








    public static void showServiceError(Context context, int id) {

        String msg = "";

        if (id == -1) {

            msg = "could not complete query. Missing parameter";

        } else if (id == 0) {

            msg = "no data found";

        } else {
            msg = "something bad happend";
        }

        AlertDialog.Builder alert = new AlertDialog.Builder(
                context);

        // Setting Dialog Title
        alert.setTitle("Alarm");
        // Setting Dialog Message
        alert.setMessage(msg);

        alert.setPositiveButton("Try Again",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int whichButton) {
                        // chkVersionData();
                    }
                });

        alert.setNegativeButton("Cancel",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int whichButton) {
                        dialog.dismiss();
                    }
                });

        alert.setCancelable(false);
        alert.show();

    }

    public static SharedPreferences getPrefs(Context context) {
        return context.getSharedPreferences(AppConstants.PREF_NAME, Context.MODE_PRIVATE);
    }

    public static String getText(Context context) {
        String defaultValue = "";
        String version = getPrefs(context).getString(AppConstants.KEY_TEXT, defaultValue);
        return version;
    }

    public static void saveVersionCode(Context context, String text) {
        SharedPreferences.Editor editor = getPrefs(context).edit();
        editor.putString(AppConstants.KEY_TEXT, text);
        editor.commit();

    }

    public static void showToast(Context context, String msg) {
        Toast.makeText(context, msg, Toast.LENGTH_LONG).show();
    }


}
