package com.example.myspreadshirtapp.user_area

import androidx.appcompat.app.AppCompatActivity
import android.content.Intent
import android.os.Bundle
import com.example.myspreadshirtapp.MainActivity
import com.example.myspreadshirtapp.R


const val LOGGED_USER = "com.example.myspreadshirtapp.User"

class LoginRegisterActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login_register)
    }

    fun goToMainActivity(userId: Int){
        val intent = Intent(this, MainActivity::class.java).apply {
            putExtra(LOGGED_USER, userId)
        }
        startActivity(intent)
    }
}