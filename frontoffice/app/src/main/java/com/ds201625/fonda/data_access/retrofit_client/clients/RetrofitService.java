package com.ds201625.fonda.data_access.retrofit_client.clients;

import android.util.Base64;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import java.io.IOException;
import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/**
 * Fabrica de servicios de Retrofit
 */
public class RetrofitService {

    /**
     * Instancia unica
     */
    private static RetrofitService instance;

    /**
     * Obtener la instancia unica
     * @return
     */
    public static RetrofitService getInstance(){
        if ( instance == null)
            instance = new RetrofitService();

        return instance;
    }

    /**
     * Direccion de base del sevicio web.
     * todo Ver como colocar esto usando el /etc/hosts del telefono.
     */
    
    private final String API_BASE_URL = "http://192.168.1.105:5300/api/";

    /**
     * Cliente http
     */
    private OkHttpClient.Builder httpClient = new OkHttpClient.Builder();

    /**
     * Constructor de los servicios
     */
    private Retrofit.Builder builder;
    public RetrofitService() {
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy-MM-dd'T'HH:mm:ss")
                .create();
        this.builder = new Retrofit.Builder()
                .baseUrl(API_BASE_URL)
                .addConverterFactory(GsonConverterFactory.create(gson));
    }

    /**
     * Crea servicio que no requieran autentificacion
     * @param serviceClass
     * @param <S>
     * @return
     */
    public <S> S createService(Class<S> serviceClass) {
        Retrofit retrofit = builder.client(httpClient.build()).build();
        return retrofit.create(serviceClass);
    }

    /**
     * Crea servicio que requieran autentificacion basica.
     * @param serviceClass
     * @param user usuario
     * @param password contraseña
     * @param <S>
     * @return
     */
    public <S> S createService(Class<S> serviceClass, String user, String password) {
        if (user != null && password != null) {
            String credentials = user + ":" + password;
            final String basic =
                    "Basic " + Base64.encodeToString(credentials.getBytes(), Base64.NO_WRAP);
            setInspector(basic);

        }
        Retrofit retrofit = builder.client(httpClient.build()).build();
        return retrofit.create(serviceClass);
    }

    /**
     * Crea servicio que requieran autentificacion Fonda token
     * @param serviceClass
     * @param token Token del susuairo
     * @param <S>
     * @return
     */
    public <S> S createService(Class<S> serviceClass, String token) {
        if (token!= null) {
            final String basic =
                    "Fonda " + token;
            setInspector(basic);

        }
        Retrofit retrofit = builder.client(httpClient.build()).build();
        return retrofit.create(serviceClass);
    }


    private void setInspector(final String auth) {
        httpClient.addInterceptor(new Interceptor() {
            @Override
            public Response intercept(Interceptor.Chain chain) throws IOException {
                Request original = chain.request();

                Request.Builder requestBuilder = original.newBuilder()
                        .header("Authorization", auth)
                        .header("Accept", "application/json")
                        .method(original.method(), original.body());
                Request request = requestBuilder.build();
                return chain.proceed(request);
            }
        });
    }

}
