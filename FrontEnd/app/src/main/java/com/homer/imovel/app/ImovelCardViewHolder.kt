package com.homer.imovel.app

import android.view.View
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

import com.google.android.material.card.MaterialCardView

class ImovelCardViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
    var imovelCard: MaterialCardView = itemView.findViewById(R.id.imovel_card)
    var imovelImage: ImageView = itemView.findViewById(R.id.imovel_image)
    var imovelTitulo: TextView = itemView.findViewById(R.id.imovel_titulo)
    var imovelLocal: TextView = itemView.findViewById(R.id.imovel_local)
}