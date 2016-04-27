package com.example.genesis.aircheck;

/* TANJINA Islam */

import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.util.Log;

public class GetUserLocation extends AsyncTask<Void, Void, Integer> {

	double latitude, longitude;
	ProgressDialog progressDialog;

	// 1 = got loc
	// -1 = no loc
	// -2 = show error
	// 0 = exception

	// ATMBranchCDMAponShomoyMapIndividualActivity activity2;

	private int id = 0;

	String errMsg = "";

	GPSTracker gps;

	long t = 20;
	public FormActivity fragmentTab;

	public GetUserLocation(FormActivity fragmentTab1,
			ProgressDialog progressDialog, GPSTracker gps) {
		this.fragmentTab = fragmentTab1;
		this.progressDialog = progressDialog;
		this.gps = gps;
	}

	// public GetUserLocation(
	// ATMBranchCDMAponShomoyMapIndividualActivity activity2,
	// ProgressDialog progressDialog, GPSTracker gps) {
	// this.activity2 = activity2;
	// this.progressDialog = progressDialog;
	// this.gps = gps;
	// }

	@Override
	protected void onPreExecute() {
		super.onPreExecute();
		progressDialog.show();
	}

	@Override
	protected Integer doInBackground(Void... arguments) {
		// gps = new GPSTracker(activity);
		try {
			latitude = -1;
			longitude = -1;
			if (gps.canGetLocation()) {
				while (t-- > 0) {
					
					this.gps.canGetLocation();
//					latitude = this.gps.getLatitude();
//					longitude = this.gps.getLongitude();
					
					latitude = 19;
					longitude = 23;
					
					
					Log.v("gps", "latitude " + latitude + " longitude "
							+ longitude);
					if (latitude != 0 && longitude != 0) {

						id = 1;
						break;
					}
					Thread.sleep(1000);
				}
			} else {
				id = -2;
			}

		} catch (Exception e) {
			id = 0;
			Log.v("oai", "Exception khaichi");
			e.printStackTrace();
		}
		return id;
	}

	@Override
	protected void onPostExecute(Integer result) {
		super.onPostExecute(result);
		progressDialog.dismiss();

		if (fragmentTab != null) {
			if (latitude == 0 && longitude == 0) {
				id = -1;
				fragmentTab.showLocationError(id);
			} else if (result == 1) {
				fragmentTab.updateUserLocation(this.latitude, this.longitude);
			} else {
				fragmentTab.showLocationError(id);
			}
		}
		// else if (activity2 != null) {
		// if (latitude == 0 && longitude == 0) {
		// id = -1;
		// activity2.showLocationError(id);
		// } else if (result == 1) {
		// activity2.updateUserLocation(this.latitude, this.longitude);
		// } else {
		// activity2.showLocationError(id);
		// }
		//
		// }

	}

}
