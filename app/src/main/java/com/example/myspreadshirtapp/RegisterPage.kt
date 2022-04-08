package com.example.myspreadshirtapp

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.fragment.navArgs
import com.example.myspreadshirtapp.databinding.RegisterPageFragmentBinding

class RegisterPage : Fragment() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }
    private lateinit var viewModel: RegisterPageViewModel
    val args: RegisterPageArgs by navArgs()

    override fun onCreateView(
        inflater: LayoutInflater , container: ViewGroup? , savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        var binding = RegisterPageFragmentBinding.inflate(inflater,container,false)
        viewModel = ViewModelProvider(this).get(RegisterPageViewModel::class.java)
        binding.viewModel = viewModel

        args.email.let {viewModel.email.value.set(it)}
        args.password.let { viewModel.password.value.set(it) }

        return binding.root
    }
}