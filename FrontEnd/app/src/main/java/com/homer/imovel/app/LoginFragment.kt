package com.homer.imovel.app

import android.os.Bundle
import android.text.Editable
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import com.homer.imovel.app.Helpers.RestUtils
import com.homer.imovel.app.controllers.EndPoints
import com.homer.imovel.app.models.Imovel
import com.homer.imovel.app.models.RequestResult
import com.homer.imovel.app.network.ImovelEntry
import kotlinx.android.synthetic.main.hmr_login_fragment.*
import kotlinx.android.synthetic.main.hmr_login_fragment.view.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class LoginFragment : Fragment() {
    var listaDados: MutableList<ImovelEntry> = mutableListOf()

    override fun onCreateView(
            inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View? {
        val view = inflater.inflate(R.layout.hmr_login_fragment, container, false)

        view.next_button.setOnClickListener {
            if (!isPasswordValid(password_edit_text.text)) {
                password_text_input.error = getString(R.string.hmr_error_senha)
            } else {
                password_text_input.error = null
                getImveis(view)
            }
        }

        view.password_edit_text.setOnKeyListener { _, _, _ ->
            if (isPasswordValid(password_edit_text.text)) {
                password_text_input.error = null
            }
            false
        }
        return view
    }

    private fun isPasswordValid(text: Editable?): Boolean {
        return text != null && text.length >= 8
    }
    fun setEsperaVisible(visivel: Boolean){
        if (visivel){
            espera_circle.visibility = View.VISIBLE;
            edUsuario.visibility = View.INVISIBLE;
            password_text_input.visibility = View.INVISIBLE;
            btnLayout.visibility = View.INVISIBLE;
        }
        else{
            espera_circle.visibility = View.INVISIBLE;
            btnLayout.visibility = View.VISIBLE;
            edUsuario.visibility = View.VISIBLE;
            password_text_input.visibility = View.VISIBLE;

        }
    }

    fun getImveis(view: View){
        val restClient = RestUtils.getRestClient()
        setEsperaVisible(true)

        val endpoint = restClient.create(EndPoints::class.java)
        val callback = endpoint.getTodosOsImoveis()

        callback.enqueue(object : Callback<RequestResult> {
            override fun onFailure(call: Call<RequestResult>, t: Throwable) {
                setEsperaVisible(false)
                password_text_input.error = "Houve uma instabilidade na comunicação com o servidor, tente mais tarde!"
            }
            override fun onResponse(call: Call<RequestResult>, response: Response<RequestResult>) {
                password_text_input.error = null
                if (response.body()?.Success == true) {
                    val listaImovel = response.body()?.ListEntities
                    val gson = Gson()
                    val jsonArray: String = gson.toJson(listaImovel)
                    println(jsonArray)
                    val listImoveisType = object : TypeToken<List<Imovel>>() {}.type

                    val listaImoveis: List<Imovel> = gson.fromJson(jsonArray, listImoveisType)

                    listaImoveis.forEach {
                        val imovel: ImovelEntry = ImovelEntry(it.Descricao,it.ImagemCapa, it.Localizacao)
                        listaDados.add(imovel)
                    }

                    (activity as NavigationHost).navigateTo(ImovelGridFragment(listaDados), false)
                    setEsperaVisible(false)
                }
            }
        })
    }
}
