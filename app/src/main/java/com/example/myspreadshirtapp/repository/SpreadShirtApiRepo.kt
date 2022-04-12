package com.example.myspreadshirtapp.repository

import com.google.gson.GsonBuilder
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


class SpreadShirtApiRepo {
    companion object{
        val BASE_URL = "https://spreadshirtappserver.azurewebsites.net/api/"
    }

    var gson = GsonBuilder().setLenient().setDateFormat("yyyy-MM-dd'T'HH:mm:ssZ").create()

    var retrofit =
        Retrofit.Builder().baseUrl(BASE_URL).addConverterFactory(GsonConverterFactory.create(gson))
            .build()
    var api:MyApiEndpointInterface = retrofit.create(MyApiEndpointInterface::class.java)
}