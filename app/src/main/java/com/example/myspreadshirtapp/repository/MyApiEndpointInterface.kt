package com.example.myspreadshirtapp.repository

import retrofit2.Call
import retrofit2.http.*

class User(var id:Int,var email:String,var password:String,var accountStatus:String,var verificationCode:String)

interface MyApiEndpointInterface {
    @Headers("Content-Type: application/json")
    @GET("users/LoginUser")
    fun loginUser(@Query("email")email:String , @Query("password")password: String) : Call<String>
    @Headers("Content-Type: application/json")
    @GET("users/VerifyUser")
    fun verifyUserCode(@Query("email")email:String,@Query("code")code: String) : Call<String>
    @Headers("Content-Type: application/json")
    @POST("users")
    fun registerUser(@Body user:User?): Call<User?>

    /*@GET("users/{username}")
    fun getUser(@Path("username") username: String?): Call<User?>?

    @GET("group/{id}/users")
    fun groupList(@Path("id") groupId: Int , @Query("sort") sort: String?): Call<List<User?>?>?

    @POST("users/new")
    fun createUser(@Body user: User?): Call<User?>?*/
}