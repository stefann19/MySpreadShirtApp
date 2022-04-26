package com.example.myspreadshirtapp

import androidx.lifecycle.ViewModelProvider
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.databinding.ObservableArrayList
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.myspreadshirtapp.adapters.CustomLayoutManager
import com.example.myspreadshirtapp.adapters.RecyclerViewAdapter
import com.example.myspreadshirtapp.repository.Sellable
import com.example.myspreadshirtapp.repository.SpreadShirtApiRepo
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

class Board : Fragment() {

    companion object {
        fun newInstance() = Board()
    }
    var sellables: ObservableArrayList<Sellable> =  ObservableArrayList()
    private lateinit var viewModel: BoardViewModel
    override fun onCreateView(
        inflater: LayoutInflater , container: ViewGroup? , savedInstanceState: Bundle?
    ): View? {
        val spreadShirtApiRepo = SpreadShirtApiRepo()
        val call: Call<List<Sellable>> = spreadShirtApiRepo.api.getSellables()
        val view =inflater.inflate(R.layout.board_fragment , container , false)

        call.enqueue(object : Callback<List<Sellable>> {
            override fun onResponse(call: Call<List<Sellable>> , response: Response<List<Sellable>>) {
                val resp = response.body() ?: return
                sellables.addAll(resp)
                val adapter = RecyclerViewAdapter(sellables)
                val recycler = view.findViewById<RecyclerView>(R.id.recyclerView)
                recycler.adapter = adapter
                var layoutManager = CustomLayoutManager(view.context)
                layoutManager.orientation = RecyclerView.HORIZONTAL
                recycler.layoutManager = layoutManager
            }
            override fun onFailure(call: Call<List<Sellable>> , t: Throwable) {
                // Log error here since request failed
                var z = t;
            }
        })

        return view
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)
        viewModel = ViewModelProvider(this).get(BoardViewModel::class.java)
        // TODO: Use the ViewModel
    }

}