package com.example.myspreadshirtapp

import androidx.lifecycle.ViewModelProvider
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup

class Board : Fragment() {

    companion object {
        fun newInstance() = Board()
    }

    private lateinit var viewModel: BoardViewModel

    override fun onCreateView(
        inflater: LayoutInflater , container: ViewGroup? , savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.board_fragment , container , false)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)
        viewModel = ViewModelProvider(this).get(BoardViewModel::class.java)
        // TODO: Use the ViewModel
    }

}