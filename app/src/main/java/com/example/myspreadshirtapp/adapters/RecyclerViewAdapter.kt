package com.example.myspreadshirtapp.adapters

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import androidx.databinding.ObservableArrayList
import androidx.recyclerview.widget.RecyclerView
import com.example.myspreadshirtapp.R
import com.example.myspreadshirtapp.repository.ImageModel
import com.example.myspreadshirtapp.repository.Sellable
import com.squareup.picasso.Picasso

class ViewPagerAdapter(
    val images: ObservableArrayList<Sellable>
): RecyclerView.Adapter<ViewPagerAdapter.ViewPagerViewHolder>() {
    inner class ViewPagerViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView){

    }
    override fun onCreateViewHolder(parent: ViewGroup , viewType: Int): ViewPagerViewHolder {
        val view =  LayoutInflater.from(parent.context).inflate(R.layout.clothing_item_view_pager, parent, false)
        return ViewPagerViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewPagerViewHolder , position: Int) {
        val currentImage = images[position]
        val imageView =holder.itemView.findViewById<ImageView>(R.id.ivImage)
        Picasso.get()
            .load(currentImage.previewImage.url)
            .resize(256,256)
            .into(imageView)
        //holder.itemView.
    }

    override fun getItemCount(): Int {
        return images.size
    }
}