package com.example.genesis.aircheck;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;

import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.NameValuePair;
import org.apache.http.NoHttpResponseException;
import org.apache.http.client.HttpClient;
import org.apache.http.client.entity.UrlEncodedFormEntity;
import org.apache.http.client.methods.HttpPost;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.message.BasicNameValuePair;
import org.apache.http.params.BasicHttpParams;
import org.apache.http.params.HttpConnectionParams;
import org.apache.http.params.HttpParams;
import org.apache.http.util.EntityUtils;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by genesis on 23/04/2016.
 */
public class SendData  extends AsyncTask<String, Integer, Integer> {


    public static String TAG = SendData.class.getSimpleName();

    UrlEncodedFormEntity form;
    String resId;
    int id = -2;
    JSONObject jsonObject;
    ArrayList<HashMap<String, String>> dataList;
    HttpClient client;
    ProgressDialog pDialog = null;
    OnAsyncRequestComplete caller;
    Context context;
    int retries;
    int version;

    public SendData(Activity a) {
        caller = (OnAsyncRequestComplete) a;
        context = a;
    }

    /**
     * Before starting background thread Show Progress Dialog
     */
    @Override
    public void onPreExecute() {
        pDialog = new ProgressDialog(context);
        pDialog.setMessage("Loading data..");
        pDialog.setCancelable(false);
        pDialog.show();
    }

    @Override
    protected void onProgressUpdate(Integer... values) {
        super.onProgressUpdate(values[0]);
        pDialog.setMessage("Loading data..." + values[0]);
    }

    @Override
    protected Integer doInBackground(String... args) {

        //version = Integer.parseInt(args[3]);

        for (retries = 1; retries <= AppConstants.MAX_TRY; ++retries) {
            try {
                // Setup the parameters
                ArrayList<NameValuePair> nameValuePairs = new ArrayList<NameValuePair>();
                nameValuePairs.add(new BasicNameValuePair("longitude", args[0]));
                nameValuePairs.add(new BasicNameValuePair("latitude", args[1]));
                nameValuePairs.add(new BasicNameValuePair("event", args[2]));
                nameValuePairs.add(new BasicNameValuePair("rating", args[3]));
                //nameValuePairs.add(new BasicNameValuePair("timeStamp", args[2]));


                // Create the HTTP request
                HttpParams httpParameters = new BasicHttpParams();

                // Setup timeouts

                // old
                // HttpConnectionParams.setConnectionTimeout(httpParameters, 15000);
                HttpConnectionParams.setConnectionTimeout(httpParameters, 10000);

                // old
                // HttpConnectionParams.setSoTimeout(httpParameters, 15000);
                HttpConnectionParams.setSoTimeout(httpParameters, 10000 + 12000);

                // old
                // client = new DefaultHttpClient(httpParameters);
                client = new DefaultHttpClient();


                HttpPost httppost = new HttpPost(
                        AppConstants.REQ_URL_QUIZ);

                form = new UrlEncodedFormEntity(nameValuePairs, "UTF-8");
                httppost.setEntity(form);

                // new
                httppost.setParams(httpParameters);

                // httppost.setEntity(new UrlEncodedFormEntity(nameValuePairs));

                HttpResponse response = client.execute(httppost);
                HttpEntity entity = response.getEntity();


                if (response.getStatusLine().getStatusCode() == 200) {

                    String responseStr = EntityUtils.toString(entity);
                    jsonObject = new JSONObject(responseStr);


                    id = 1;
                    //resId = jsonObject.getString("success");


//                    if (resId.equalsIgnoreCase("1"))
//                        id = 1;
//                    else if (resId.equalsIgnoreCase("0"))
//                        id = 0;
//                    else if (resId.equalsIgnoreCase("-1"))
//                        id = -1;

                    if (id == 1) {


                        Log.v(TAG, jsonObject.toString());

                    }
                }

                if (MyDebug.LOG)
                    Log.v(TAG, jsonObject.toString());

                return id;

            } catch (ConnectTimeoutException e) {

                if (MyDebug.LOG)
                    Log.v(TAG, Log.getStackTraceString(e));

            } catch (NoHttpResponseException e) {

                if (MyDebug.LOG)
                    Log.v(TAG, Log.getStackTraceString(e));

            } catch (Exception e) {

                if (MyDebug.LOG)
                    Log.v(TAG, Log.getStackTraceString(e));
                id = -2;

            } finally {

                publishProgress(retries);
            }
        }
        return id;
    }

    @Override
    protected void onPostExecute(Integer valid) {

        // java.lang.IllegalArgumentException: View not attached to window
        // manager
        try {
            if (pDialog != null && pDialog.isShowing()) {
                pDialog.dismiss();
            }
        } catch (Exception e) {
            // nothing
        }

        if (valid == 0 || valid == -1 || valid == -2) {

            caller.asyncError(valid);

        } else if (valid == 1) {

            caller.asyncQuizResponse(version);
            //mainActivity.Succsess(Integer.parseInt(version));

        }

    }

    // Interface to be implemented by calling activity
    public interface OnAsyncRequestComplete {
        public void asyncQuizResponse(int version);

        public void asyncError(int id);
    }

}
