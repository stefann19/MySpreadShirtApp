package com.example.myspreadshirtapp

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.findNavController
import com.example.myspreadshirtapp.databinding.LoginPageFragmentBinding
import com.example.myspreadshirtapp.repository.SpreadShirtApiRepo
import com.example.myspreadshirtapp.repository.User
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response


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
        var spreadShirtApiRepo = SpreadShirtApiRepo()
        binding.loginButton.setOnClickListener { v->
            val email :String= viewModel.email.value.get() ?: ""
            val password :String= viewModel.password.value.get() ?: ""
            if(email.isNotEmpty() && password.isNotEmpty()){
                val call: Call<String> = spreadShirtApiRepo.api.loginUser(email, password )
                call.enqueue(object : Callback<String?> {
                    override fun onResponse(call: Call<String?> , response: Response<String?>) {
                        val statusCode = response.code()
                        val resp = response.body()

                        val toast = Toast.makeText(v.context, resp, Toast.LENGTH_LONG)
                        toast.show()
                    }

                    override fun onFailure(call: Call<String?> , t: Throwable) {
                        // Log error here since request failed
                    }
                })
            }

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
