package com.example.genesis.aircheck;

/* Author: S.Mahbub-Uz-Zaman */

import android.app.AlertDialog.Builder;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.provider.Settings;

public class ConnectionCheck {

	Builder alertDialog;
	Context context;
	ConnectivityManager cm;
	NetworkInfo netInfo;

	public ConnectionCheck(Context context) {
		this.context = context;
	}

	// handle connected but can not access the Internet !
	public boolean isNetworkUp() {
		cm = (ConnectivityManager) context
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		netInfo = cm.getActiveNetworkInfo();
		if (netInfo != null && netInfo.isConnectedOrConnecting()) {
			return true;
		}
		return false;
	}

	public void showNetworkError(String msg) {

		alertDialog = new Builder(context);

		// Setting Dialog Title
		alertDialog.setTitle("Connection Error");

		// Setting Dialog Message
		alertDialog.setMessage(msg);

		// On pressing Settings button
		alertDialog.setNegativeButton("Settings",
				new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int which) {
						Intent intent = new Intent(Settings.ACTION_SETTINGS);
						context.startActivity(intent);
					}
				});

		// on pressing cancel button
		alertDialog.setPositiveButton("Cancel",
				new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int which) {
						dialog.cancel();
					}
				});

		// Showing Alert Message
		alertDialog.show();
	}

	public void error(String msg) {
		Builder bd = new Builder(context);
		bd.setTitle("Error");
		bd.setMessage(msg);
		bd.setNeutralButton("OK", null);
		bd.show();

	}
}
