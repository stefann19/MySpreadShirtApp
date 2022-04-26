package com.example.myspreadshirtapp.utils

import com.example.myspreadshirtapp.user_area.isValidEmail

class Validators {
    companion object{
        fun emailValidator(x:String): String{
            if(x.isEmpty())return " "
            if(x.length<5) return "Email must be at least 5 characters long"
            if(!x.contains("@")) return "Email must contain @"
            if(!isValidEmail(x)) return "Email not valid"
            return ""
        }
        fun passwordValidator(x:String):String {
            if(x.isEmpty())return " "
            if(x.length<5) return "Password must be at least 5 characters long"
            return ""
        }
        fun confirmPasswordValidator(x:String , password: String?):String {
            if(x.isEmpty())return " "
            if(x != password)return "Passwords don't match"
            return ""
        }
    }
}