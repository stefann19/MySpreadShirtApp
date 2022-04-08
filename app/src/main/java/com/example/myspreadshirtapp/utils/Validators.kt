package com.example.myspreadshirtapp.utils

import com.example.myspreadshirtapp.isValidEmail

class Validators {
    companion object{
        fun emailValidator(x:String): String{
            if(x.length<5) return "Email must be at least 5 characters long"
            if(!x.contains("@")) return "Email must contain @"
            if(!isValidEmail(x)) return "Email not valid"
            return ""
        }

        fun passwordValidator(x:String):String {
            if(x.length<5) return "Password must be at least 5 characters long"
            return ""
        }

    }
}