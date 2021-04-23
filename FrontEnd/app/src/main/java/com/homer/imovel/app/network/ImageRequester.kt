package com.homer.imovel.app.network

import android.content.Context
import android.graphics.Bitmap
import android.util.LruCache

import com.android.volley.RequestQueue
import com.android.volley.toolbox.ImageLoader
import com.android.volley.toolbox.Volley
import com.homer.imovel.app.application.HmrViewerApp
import android.graphics.BitmapFactory
import android.util.Base64
import android.widget.ImageView

object ImageRequester {
    private val requestQueue: RequestQueue
    private val imageLoader: ImageLoader
    private val maxByteSize: Int

    init {
        val context = HmrViewerApp.instance
        this.requestQueue = Volley.newRequestQueue(context)
        this.requestQueue.start()
        this.maxByteSize = calculateMaxByteSize(context)
        this.imageLoader = ImageLoader(
            requestQueue,
            object : ImageLoader.ImageCache {
                private val lruCache = object : LruCache<String, Bitmap>(maxByteSize) {
                    override fun sizeOf(url: String, bitmap: Bitmap): Int {
                        return bitmap.byteCount
                    }
                }

                @Synchronized
                override fun getBitmap(url: String): Bitmap? {
                    return lruCache.get(url)
                }

                @Synchronized
                override fun putBitmap(url: String, bitmap: Bitmap) {
                    lruCache.put(url, bitmap)
                }
            })
    }

    fun setImageFromStrB64(networkImageView: ImageView, strImageB64: String) {
        val bm = convertString64ToImage(strImageB64)
        networkImageView.setImageBitmap(bm);
    }
    fun convertString64ToImage(base64String: String): Bitmap {
        val decodedString = Base64.decode(base64String, Base64.DEFAULT)
        return BitmapFactory.decodeByteArray(decodedString, 0, decodedString.size)
    }
    private fun calculateMaxByteSize(context: Context): Int {
        val displayMetrics = context.resources.displayMetrics
        val screenBytes = displayMetrics.widthPixels * displayMetrics.heightPixels * 4
        return screenBytes * 3
    }
}