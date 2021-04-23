package com.homer.imovel.app.Helpers

import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.util.concurrent.TimeUnit


class RestUtils {

    companion object {

        private const val apiUrl: String = "http://10.0.2.2:7001"

        fun getRestClient() : Retrofit {
            val httpClient: OkHttpClient.Builder = OkHttpClient.Builder()
                .readTimeout(60, TimeUnit.SECONDS)
                .connectTimeout(60, TimeUnit.SECONDS)
            val client: OkHttpClient = httpClient.build()

            return Retrofit.Builder()
                .baseUrl(this.apiUrl)
                .addConverterFactory(GsonConverterFactory.create())
                .client(client)
                .build()
        }
    }
}