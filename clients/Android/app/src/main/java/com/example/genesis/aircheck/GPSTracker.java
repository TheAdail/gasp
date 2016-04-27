package com.example.genesis.aircheck;

/* TANJINA ISLAM */

import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.IBinder;
import android.util.Log;

public class GPSTracker extends Service implements LocationListener {

	Intent intent;

	private final Context mContext;

	// flag for GPS status
	boolean isGPSEnabled = false;

	// flag for network status
	boolean isNetworkEnabled = false;

	// flag for GPS status
	boolean canGetLocation = false;

	Location location = null; // location
	double latitude; // latitude
	double longitude; // longitude

	// The minimum distance to change Updates in meters
	private static final long MIN_DISTANCE_CHANGE_FOR_UPDATES = 10; // 10 meters

	// The minimum time between updates in milliseconds
	private static final long MIN_TIME_BW_UPDATES = 1000 * 60 * 1; // 1 minute

	// Declaring a Location Manager
	protected LocationManager locationManager;

	LocationUpdateListener mListener;

	public GPSTracker(Context context, LocationUpdateListener listener) {
		this.mContext = context;
		mListener = listener;
		getLocation();
	}

	public GPSTracker(Context context) {
		this.mContext = context;
		getLocation();
	}

	public Location getLocation() {
		try {
			locationManager = (LocationManager) mContext
					.getSystemService(LOCATION_SERVICE);

			// getting GPS status
			isGPSEnabled = locationManager
					.isProviderEnabled(LocationManager.GPS_PROVIDER);

			// getting network status
			isNetworkEnabled = locationManager
					.isProviderEnabled(LocationManager.NETWORK_PROVIDER);

			if (isGPSEnabled == true && isNetworkEnabled == true) {
				this.canGetLocation = true;

				if (isNetworkEnabled) {
					locationManager.requestLocationUpdates(
							LocationManager.NETWORK_PROVIDER,
							MIN_TIME_BW_UPDATES,
							MIN_DISTANCE_CHANGE_FOR_UPDATES, this);
					Log.d("GPSTracker", "Network Enabled");
					if (locationManager != null) {
						// location = locationManager
						// .getLastKnownLocation(LocationManager.NETWORK_PROVIDER);
						if (location != null) {
							latitude = location.getLatitude();
							longitude = location.getLongitude();
							Log.v("GPSTracker", "inside isNetworkEnabled "
									+ location.getProvider() + "lat "
									+ latitude + "long " + longitude);
							return location;
						}
					}
				}

				// if GPS Enabled get lat/long using GPS Services

				if (isGPSEnabled) {

					if (location == null) {
						locationManager.requestLocationUpdates(
								LocationManager.GPS_PROVIDER,
								MIN_TIME_BW_UPDATES,
								MIN_DISTANCE_CHANGE_FOR_UPDATES, this);
						Log.d("GPSTracker", "GPS Enabled");
						if (locationManager != null) {
							// location = locationManager
							// .getLastKnownLocation(LocationManager.GPS_PROVIDER);

							if (location != null) {
								latitude = location.getLatitude();
								longitude = location.getLongitude();
								latitude = location.getLatitude();
								Log.v("GPSTracker", "inside isGPSEnabled "
										+ location.getProvider() + "lat "
										+ latitude + "long " + longitude);
								return location;
							}
						}
					}
				}
			}

		} catch (Exception e) {
			e.printStackTrace();
		}

		return location; // return 0 0
	}

	/**
	 * Stop using GPS listener Calling this function will stop using GPS in your
	 * app
	 * */
	public void stopUsingGPS() {
		if (locationManager != null) {
			locationManager.removeUpdates(GPSTracker.this);
		}
	}

	/**
	 * Function to get latitude
	 * */
	public double getLatitude() {
		if (location != null) {
			latitude = location.getLatitude();
		}

		// return latitude
		return latitude;
	}

	/**
	 * Function to get longitude
	 * */
	public double getLongitude() {
		if (location != null) {
			longitude = location.getLongitude();
		}

		// return longitude
		return longitude;
	}

	/**
	 * Function to check GPS/wifi enabled
	 * 
	 * @return boolean
	 * */
	public boolean canGetLocation() {
		return this.canGetLocation;
	}

	@Override
	public void onLocationChanged(Location location) {
		if (location != null) {
			mListener.onLocationUpdated(location);
			latitude = location.getLatitude();
			longitude = location.getLongitude();
			Log.v("GPSTracker",
					"inside onLocationChanged" + location.getProvider()
							+ "lat " + latitude + "long " + longitude);

		}

	}

	@Override
	public void onProviderDisabled(String provider) {
	}

	@Override
	public void onProviderEnabled(String provider) {
		Log.d("GPSTracker", "onProviderEnabled: provider enabled " + provider);
	}

	@Override
	public void onStatusChanged(String provider, int status, Bundle extras) {
		Log.d("GPSTracker", "onStatusChanged: provider " + provider
				+ " status " + status);
	}

	@Override
	public IBinder onBind(Intent arg0) {
		return null;
	}

	public interface LocationUpdateListener {
		public void onLocationUpdated(Location location);
	}

}