package com.example.myspreadshirtapp

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.lifecycle.ViewModelProvider
import androidx.navigation.fragment.navArgs
import com.example.myspreadshirtapp.databinding.RegisterPageFragmentBinding
import com.example.myspreadshirtapp.repository.SpreadShirtApiRepo
import com.example.myspreadshirtapp.repository.User
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response

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
        var spreadShirtApiRepo = SpreadShirtApiRepo()

        binding.registerButton.setOnClickListener { v->
            val email :String= viewModel.email.value.get() ?: ""
            val password :String= viewModel.password.value.get() ?: ""
            if(email.isNotEmpty() && password.isNotEmpty()){
                val call: Call<String?> = spreadShirtApiRepo.api.registerUser(User(email,password))
                call.enqueue(object : Callback<String?> {
                    override fun onResponse(call: Call<String?> , response: Response<String?>) {
                        val statusCode = response.code()
                        val resp = response.body()

                        val toast = Toast.makeText(v.context, resp, Toast.LENGTH_LONG)
                        toast.show()
                    }

                    override fun onFailure(call: Call<String?> , t: Throwable) {
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