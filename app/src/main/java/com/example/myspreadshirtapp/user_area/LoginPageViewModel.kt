package com.example.myspreadshirtapp.user_area

import android.text.TextUtils
import android.util.Patterns
import androidx.databinding.ObservableBoolean
import androidx.databinding.ObservableField
import androidx.lifecycle.ViewModel
import com.example.myspreadshirtapp.utils.ValidatedEditTextViewModel
import com.example.myspreadshirtapp.utils.Validators
import com.example.myspreadshirtapp.utils.addOnPropertyChanged


class LoginPageViewModel : ViewModel() {
    // TODO: Implement the ViewModel
    var rememberMe: ObservableBoolean = ObservableBoolean(false)
    val logInAutomatically: ObservableBoolean = ObservableBoolean(false)

    val email : ValidatedEditTextViewModel =
        ValidatedEditTextViewModel(
            validator = {x-> Validators.emailValidator(x)}
        )

    val password : ValidatedEditTextViewModel =
        ValidatedEditTextViewModel(
            validator = {x-> Validators.passwordValidator(x)}
        )
    val logginIn : ObservableBoolean = ObservableBoolean(false)

    init{
        rememberMe.addOnPropertyChanged {
            if (!it.get()) {
                logInAutomatically.set(false)
            }
        }
    }
}


fun isValidEmail(target: CharSequence?): Boolean {
    return !TextUtils.isEmpty(target) && Patterns.EMAIL_ADDRESS.matcher(target.toString()).matches()
}