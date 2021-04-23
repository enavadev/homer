package com.homer.imovel.app.models

import com.google.gson.annotations.SerializedName

data class ImovelImagens (
    @SerializedName("id")
    var id : Int,
    @SerializedName("imovelid")
    var imovelId : Int,
    @SerializedName("descricao")
    var Descricao : String,
    @SerializedName("imagem")
    var Imagem : String

)