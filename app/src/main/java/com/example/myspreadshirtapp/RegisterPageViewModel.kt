package com.example.myspreadshirtapp

import androidx.databinding.ObservableBoolean
import androidx.databinding.ObservableField
import androidx.lifecycle.ViewModel
import com.example.myspreadshirtapp.utils.ValidatedEditTextViewModel
import com.example.myspreadshirtapp.utils.Validators

class RegisterPageViewModel(): ViewModel() {
    // TODO: Implement the ViewModel
    val email: ValidatedEditTextViewModel = ValidatedEditTextViewModel(
        validator = {x-> Validators.emailValidator(x)}
    )
    val password: ValidatedEditTextViewModel = ValidatedEditTextViewModel(
        validator = {x-> Validators.passwordValidator(x)}
    )
    val confirmPassword: ValidatedEditTextViewModel = ValidatedEditTextViewModel(
        validator = {x->
            var validPass=Validators.passwordValidator(x)
            if(validPass.isEmpty()){
                if(password.value.get() == x){
                    return@ValidatedEditTextViewModel ""
                }else{
                    return@ValidatedEditTextViewModel "Passwords not matching!"
                }
            }else return@ValidatedEditTextViewModel validPass
        }
    )
}