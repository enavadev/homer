package com.homer.imovel.app

import android.os.Bundle
import android.view.LayoutInflater
import android.view.Menu
import android.view.MenuInflater
import android.view.View
import android.view.ViewGroup
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.homer.imovel.app.network.ImovelEntry
import kotlinx.android.synthetic.main.hmr_imovel_grid_fragment.view.*

class ImovelGridFragment(val listaImoveis: List<ImovelEntry>) : Fragment() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setHasOptionsMenu(true)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val view = inflater.inflate(R.layout.hmr_imovel_grid_fragment, container, false)

        (activity as AppCompatActivity).setSupportActionBar(view.app_bar)

        view.recycler_view.setHasFixedSize(true)
        view.recycler_view.layoutManager = GridLayoutManager(context, 2, RecyclerView.VERTICAL, false)

        val adapter = ImovelCardViewAdapter(listaImoveis)

        view.recycler_view.adapter = adapter
        val largePadding = resources.getDimensionPixelSize(R.dimen.hmr_imoveis_grid_spacing)
        val smallPadding = resources.getDimensionPixelSize(R.dimen.hmr_imoveis_grid_spacing_small)
        view.recycler_view.addItemDecoration(ImovelGridItemDecor(largePadding, smallPadding))

        return view;
    }

    override fun onCreateOptionsMenu(menu: Menu, menuInflater: MenuInflater) {
        menuInflater.inflate(R.menu.hmr_toolbar_menu, menu)
        super.onCreateOptionsMenu(menu, menuInflater)
    }

}