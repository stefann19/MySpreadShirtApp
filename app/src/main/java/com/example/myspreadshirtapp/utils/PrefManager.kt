package com.example.myspreadshirtapp.utils

import android.content.Context
import android.content.SharedPreferences
import com.example.myspreadshirtapp.repository.User


class PrefManager(context: Context) {
    private val pref: SharedPreferences
    private val editor: SharedPreferences.Editor


    init {
        pref = context.getSharedPreferences("MySpreadShirtApp" , Context.MODE_PRIVATE)
        editor = pref.edit()
    }

    var rememberMe = pref.getBoolean("rememberMe", false)
    fun saveRememberMe(value:Boolean) {
        editor.putBoolean("rememberMe",value)
        editor.apply()
    }
    var logInAutomatically = pref.getBoolean("logInAuto", false)
    fun saveLogInAutomatically(value:Boolean) {
        editor.putBoolean("logInAuto",value)
        editor.apply()
    }


    fun saveUser(user:User){
        editor.putString("email",user.email)
        editor.putString("password",user.password)
        editor.apply()
    }

    var savedUser = User(email = pref.getString("email", null) ?: "", password= pref.getString("password", null)  ?: "")
}