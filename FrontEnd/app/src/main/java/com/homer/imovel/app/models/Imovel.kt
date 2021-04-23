package com.homer.imovel.app.models

import com.google.gson.annotations.SerializedName


data class Imovel (
    @SerializedName("id")
    var id : Int,
    @SerializedName("descricao")
    var Descricao : String,
    @SerializedName("localizacao")
    var Localizacao : String,
    @SerializedName("imagemCapa")
    var ImagemCapa : String,
    @SerializedName("imagens")
    var Imagens : MutableList<ImovelImagens> = TODO()
)