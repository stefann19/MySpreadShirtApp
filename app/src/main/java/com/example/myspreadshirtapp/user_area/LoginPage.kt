package com.example.myspreadshirtapp.user_area

import android.content.Context
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
import androidx.navigation.findNavController
import com.example.myspreadshirtapp.databinding.LoginPageFragmentBinding
import com.example.myspreadshirtapp.models.ApiResponse
import com.example.myspreadshirtapp.repository.User
import com.example.myspreadshirtapp.utils.PrefManager


class LoginPage : Fragment() {

    private lateinit var viewModel: LoginPageViewModel
    lateinit var prefManager:PrefManager
    lateinit var spreadShirtApiRepo: SpreadShirtApiRepo
    lateinit var binding: LoginPageFragmentBinding
    override fun onCreateView(
        inflater: LayoutInflater , container: ViewGroup? , savedInstanceState: Bundle?
    ): View? {
        binding = InflateView(inflater , container)
        spreadShirtApiRepo = SpreadShirtApiRepo()
        prefManager = PrefManager(binding.root.context)

        AddLoginButtonHandler()
        AddRegisterButtonHandler()

        GetSavedEmailAndPassword()
        return binding.root
    }

    private fun GetSavedEmailAndPassword() {
        viewModel.rememberMe.set(prefManager.rememberMe)
        viewModel.logInAutomatically.set(prefManager.logInAutomatically)
        if(prefManager.rememberMe){
            var user = prefManager.savedUser
            viewModel.email.value.set(user.email)
            viewModel.password.value.set(user.password)
        }

        if(prefManager.logInAutomatically){
            LogIn(binding.root.context)
        }

    }

    private fun InflateView(
        inflater: LayoutInflater , container: ViewGroup?
    ): LoginPageFragmentBinding {
        val binding = LoginPageFragmentBinding.inflate(inflater , container , false)
        viewModel = ViewModelProvider(this)[LoginPageViewModel::class.java]
        binding.viewModel = viewModel
        return binding
    }

    private fun AddRegisterButtonHandler() {
        binding.buttonTapHereToRegister.setOnClickListener { v ->
            val action = LoginPageDirections.actionLoginPageToRegisterFragment(
                email = viewModel.email.value.get().toString() ,
                password = viewModel.password.value.get().toString()
            )
            v.findNavController().navigate(action)
        }
    }

    private fun AddLoginButtonHandler() {
        binding.loginButton.setOnClickListener { v ->
            LogIn(v.context)
        }
    }

    private fun LogIn(context: Context
    ) {
        viewModel.logginIn.set(true)
        val email: String = viewModel.email.value.get() ?: ""
        val password: String = viewModel.password.value.get() ?: ""

        prefManager.saveUser(User(email,password))
        prefManager.saveRememberMe(binding.rememberMeSwitch.isChecked)
        prefManager.saveLogInAutomatically(binding.logInAutomaticallySwitch.isChecked)

        if (email.isNotEmpty() && password.isNotEmpty()) {
            val call: Call<ApiResponse<Int>> = spreadShirtApiRepo.api.loginUser(email , password)
            call.enqueue(object : Callback<ApiResponse<Int>> {
                override fun onResponse(
                    call: Call<ApiResponse<Int>> , response: Response<ApiResponse<Int>>
                ) {
                    val resp = response.body() ?: return
                    if (resp.value == null) return
                    viewModel.logginIn.set(false)

                    if (resp.status == "Success") {
                        (activity as LoginRegisterActivity).goToMainActivity(resp.value)
                    } else Toast.makeText(context , resp.message , Toast.LENGTH_LONG).show()

                }

                override fun onFailure(call: Call<ApiResponse<Int>> , t: Throwable) {
                    // Log error here since request failed
                    val toast = Toast.makeText(context , t.message , Toast.LENGTH_LONG)
                    toast.show()
                    viewModel.logginIn.set(false)
                }
            })
        }
    }

}
