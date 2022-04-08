package com.example.myspreadshirtapp.utils

import androidx.arch.core.util.Function
import androidx.databinding.Observable
import androidx.databinding.Observable.OnPropertyChangedCallback
import androidx.databinding.ObservableBoolean
import androidx.databinding.ObservableField
import androidx.lifecycle.ViewModel


class ValidatedEditTextViewModel(
    val value:ObservableField<String> = ObservableField(""),val validator: Function<String,String>
) : ViewModel() {
    // TODO: Implement the ViewModel
    val validationMessage: ObservableField<String> = ObservableField("")
    val isValid:ObservableBoolean = ObservableBoolean(true)
    init {
        value.addOnPropertyChangedCallback(object : OnPropertyChangedCallback() {
            override fun onPropertyChanged(sender: Observable , propertyId: Int) {
                val validationMsg =validator.apply(value.get())
                validationMessage.set(validationMsg)
                isValid.set(validationMsg.isEmpty())
            }
        })
    }
}