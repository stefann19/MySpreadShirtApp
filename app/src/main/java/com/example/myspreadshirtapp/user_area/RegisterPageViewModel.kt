package com.example.myspreadshirtapp.user_area


import androidx.lifecycle.ViewModel
import com.example.myspreadshirtapp.utils.ValidatedEditTextViewModel
import com.example.myspreadshirtapp.utils.Validators
import com.example.myspreadshirtapp.utils.addOnPropertyChanged


class RegisterPageViewModel(): ViewModel() {
    // TODO: Implement the ViewModel
    val email: ValidatedEditTextViewModel = ValidatedEditTextViewModel(
        validator = {x-> Validators.emailValidator(x)}
    )
    val password: ValidatedEditTextViewModel = ValidatedEditTextViewModel(
        validator = {x-> Validators.passwordValidator(x)}
    )
    val confirmPassword: ValidatedEditTextViewModel = ValidatedEditTextViewModel(
        validator = {x-> Validators.confirmPasswordValidator(x, password.value.get())}
    )
    init {
        password.value.addOnPropertyChanged({
            confirmPassword.value.notifyChange()
        })

    }


}






