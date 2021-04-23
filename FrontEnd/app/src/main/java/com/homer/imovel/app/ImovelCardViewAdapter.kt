package com.homer.imovel.app

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import com.homer.imovel.app.network.ImageRequester

import com.homer.imovel.app.network.ImovelEntry

class ImovelCardViewAdapter internal constructor(private val imovelList: List<ImovelEntry>) : RecyclerView.Adapter<ImovelCardViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ImovelCardViewHolder {
        val layoutView = LayoutInflater.from(parent.context).inflate(R.layout.hmr_imovel_card, parent, false)
        return ImovelCardViewHolder(layoutView)
    }

    override fun onBindViewHolder(holder: ImovelCardViewHolder, position: Int) {
        try {
            if (position < imovelList.size) {
                val imovel = imovelList[position]
                holder.imovelTitulo.text = imovel.titulo
                holder.imovelLocal.text = imovel.local

                ImageRequester.setImageFromStrB64(holder.imovelImage, imovel.imagemBinStr)

            }
        } catch (e: Exception) {
            println("**** Ocorreu um erro:")
            println(e.message)
        }
    }

    override fun getItemCount(): Int {
        return imovelList.size
    }
}