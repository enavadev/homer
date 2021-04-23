package com.homer.imovel.app

import androidx.fragment.app.Fragment

interface NavigationHost {
    fun navigateTo(fragment: Fragment, addToBackstack: Boolean)
}