package com.homer.imovel.app.models

import com.google.gson.annotations.SerializedName
import java.util.*

data class RequestResult (
    @SerializedName("entity")
    var Entity : Any,
    @SerializedName("listEntities")
    var ListEntities : Array<Object>,
    @SerializedName("success")
    var Success : Boolean,
    @SerializedName("message")
    var Message : String

)
