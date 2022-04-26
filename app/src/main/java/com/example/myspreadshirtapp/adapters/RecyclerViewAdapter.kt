package com.example.myspreadshirtapp.adapters

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.databinding.ObservableArrayList
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.myspreadshirtapp.R
import com.example.myspreadshirtapp.repository.Sellable
import com.squareup.picasso.Picasso
import kotlin.math.roundToInt

class RecyclerViewAdapter(
    val images: ObservableArrayList<Sellable>
): RecyclerView.Adapter<RecyclerViewAdapter.RecyclerViewHolder>() {
    inner class RecyclerViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView)

    override fun onCreateViewHolder(parent: ViewGroup , viewType: Int): RecyclerViewHolder {
        val view =  LayoutInflater.from(parent.context).inflate(R.layout.clothing_item_view_pager, parent, false)
        return RecyclerViewHolder(view)
    }

    override fun onBindViewHolder(holder: RecyclerViewHolder , position: Int) {
        val currentImage = images[position]
        val imageView =holder.itemView.findViewById<ImageView>(R.id.ivImage)
        Picasso.get()
            .load(currentImage.previewImage.url)
            .into(imageView)
        //holder.itemView.
    }


    override fun getItemCount(): Int {
        return images.size
    }
}

class CustomLayoutManager(context: Context): LinearLayoutManager(context) {

    override fun measureChild(child: View , widthUsed: Int , heightUsed: Int) {
        var zoom =  (1+child.left/ 1080.0)
        super.measureChild(child , (widthUsed *zoom).roundToInt() , (heightUsed*zoom).roundToInt())
    }
}