package com.homer.imovel.app.application

import android.app.Application
import androidx.appcompat.app.AppCompatDelegate

class HmrViewerApp : Application() {
    companion object {
        lateinit var instance: HmrViewerApp
            private set
    }

    override fun onCreate() {
        super.onCreate()
        instance = this

        AppCompatDelegate.setCompatVectorFromResourcesEnabled(true)
    }

}