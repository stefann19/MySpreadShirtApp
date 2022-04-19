package com.example.myspreadshirtapp.UserArea

import android.view.LayoutInflater
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.lifecycle.ViewModelProvider
import com.example.myspreadshirtapp.repository.SpreadShirtApiRepo
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

import android.os.Bundle
import android.view.View
import com.example.myspreadshirtapp.databinding.LoginPageFragmentBinding
import com.example.myspreadshirtapp.models.ApiResponse


class LoginPage : Fragment() {

    private lateinit var viewModel: LoginPageViewModel

    override fun onCreateView(
        inflater: LayoutInflater , container: ViewGroup? , savedInstanceState: Bundle?
    ): View? {
        val binding = LoginPageFragmentBinding.inflate(inflater , container , false)
        viewModel = ViewModelProvider(this)[LoginPageViewModel::class.java]
        binding.viewModel = viewModel

        /*binding.buttonTapHereToRegister.setOnClickListener { v->
            val action =LoginPageDirections.actionLoginPageToRegisterFragment(email = viewModel.email.value.get().toString(), password = viewModel.password.value.get().toString())
            v.findNavController().navigate(action)
        }*/
        val spreadShirtApiRepo = SpreadShirtApiRepo()
        binding.loginButton.setOnClickListener { v->
            val email :String= viewModel.email.value.get() ?: ""
            val password :String= viewModel.password.value.get() ?: ""
            if(email.isNotEmpty() && password.isNotEmpty()){
                val call: Call<ApiResponse<Int>> = spreadShirtApiRepo.api.loginUser(email, password )
                call.enqueue(object : Callback<ApiResponse<Int>> {
                    override fun onResponse(call: Call<ApiResponse<Int>> , response: Response<ApiResponse<Int>>) {
                        val resp = response.body() ?: return
                        if(resp.value==null) return

                        if(resp.status == "Success") {
                            (activity as LoginRegisterActivity).goToMainActivity(resp.value)
                        }else Toast.makeText(v.context, resp.message, Toast.LENGTH_LONG).show()

                    }

                    override fun onFailure(call: Call<ApiResponse<Int>> , t: Throwable) {
                        // Log error here since request failed
                        val toast = Toast.makeText(v.context, t.message, Toast.LENGTH_LONG)
                        toast.show()
                    }
                })
            }

        }
        return binding.root
    }

}
