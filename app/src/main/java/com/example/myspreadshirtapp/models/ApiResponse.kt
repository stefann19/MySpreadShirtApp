package com.example.myspreadshirtapp.models


class ApiResponse<T>(status: String , value: T? , message: String) {
    val status: String = status
    val value: T? = value
    val message: String = message

    constructor() : this("",null,"") {

    }
}