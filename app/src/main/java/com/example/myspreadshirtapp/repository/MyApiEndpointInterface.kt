package com.example.myspreadshirtapp.repository

import retrofit2.Call
import retrofit2.http.*

class User(var id:Int,var email:String,var password:String,var accountStatus:String,var verificationCode:String)

interface MyApiEndpointInterface {

    @GET("users/LoginUser")
    fun loginUser(@Path("email")email:String,@Path("password")password: String) : Call<String>
    @GET("users/VerifyUser")
    fun verifyUserCode(@Path("email")email:String,@Path("code")code: String) : Call<String>
    @POST("users")
    fun registerUser(@Body user:User?): Call<User?>

    /*@GET("users/{username}")
    fun getUser(@Path("username") username: String?): Call<User?>?

    @GET("group/{id}/users")
    fun groupList(@Path("id") groupId: Int , @Query("sort") sort: String?): Call<List<User?>?>?

    @POST("users/new")
    fun createUser(@Body user: User?): Call<User?>?*/
}