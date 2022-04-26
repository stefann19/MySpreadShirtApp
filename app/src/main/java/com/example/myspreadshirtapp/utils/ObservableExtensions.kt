package com.example.myspreadshirtapp.utils

import androidx.databinding.Observable
import androidx.databinding.ObservableBoolean
import androidx.databinding.ObservableField

fun <T> ObservableField<T>.addOnPropertyChanged(callback: (ObservableField<T>) -> Unit) =
    object: Observable.OnPropertyChangedCallback() {
        override fun onPropertyChanged(observable: Observable?, i: Int) =
            callback(observable as ObservableField<T>)
    }.also { addOnPropertyChangedCallback(it) }

fun ObservableBoolean.addOnPropertyChanged(callback: (ObservableBoolean) -> Unit) =
    object: Observable.OnPropertyChangedCallback() {
        override fun onPropertyChanged(observable: Observable?, i: Int) =
            callback(observable as ObservableBoolean)
    }.also { addOnPropertyChangedCallback(it) }
