package com.example.myspreadshirtapp

import android.R
import android.graphics.Color
import androidx.lifecycle.ViewModelProvider
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.databinding.DataBindingUtil
import androidx.navigation.findNavController
import androidx.navigation.navOptions
import com.example.myspreadshirtapp.databinding.LoginPageFragmentBinding

class LoginPage : Fragment() {

    companion object {
        fun newInstance() = LoginPage()
    }

    private lateinit var viewModel: LoginPageViewModel

    override fun onCreateView(
        inflater: LayoutInflater , container: ViewGroup? , savedInstanceState: Bundle?
    ): View? {
        var binding = LoginPageFragmentBinding.inflate(inflater , container , false)
        viewModel = ViewModelProvider(this).get(LoginPageViewModel::class.java)
        binding.viewModel = viewModel

        binding.buttonTapHereToRegister.setOnClickListener { v->
            val action =LoginPageDirections.actionLoginPageToRegisterFragment(email = viewModel.email.value.get().toString(), password = viewModel.password.value.get().toString())
            v.findNavController().navigate(action)
        }
        return binding.root
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)
        // TODO: Use the ViewModel
    }

    override fun onResume() {
        super.onResume()
    }
}