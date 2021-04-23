package com.homer.imovel.app.controllers

import com.homer.imovel.app.models.RequestResult

import retrofit2.Call
import retrofit2.http.POST

public interface  EndPoints {
    @POST("api/Imoveis/ListaDosImoveis")
    fun getListaDosImoveis() : Call<RequestResult>

    @POST("api/Imoveis/ObterTodos")
    fun getTodosOsImoveis() : Call<RequestResult>
}