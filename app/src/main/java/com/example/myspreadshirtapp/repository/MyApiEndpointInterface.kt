package com.example.myspreadshirtapp.repository

import com.example.myspreadshirtapp.models.ApiResponse
import retrofit2.Call
import retrofit2.http.*

class User(var email:String,var password:String){
    var id:Int = 0
    var accountStatus:String = ""
    var verificationCode:String =""
}

class Sellable(){
    lateinit var sellableId:String
    lateinit var ideaId:String
    lateinit var mainDesignId:String
    lateinit var productTypeId:String
    var defaultAppearanceId:Int = 0
    lateinit var tags:List<Tag>
    lateinit var previewImage:ImageModel
    lateinit var appearanceIds:List<Appearance>
}
class Tag{
    var value:String=""
}
class CurrencyPrice{
    var amount:Double=0.0

}
class Currency{
    lateinit var plain:String
    lateinit var IsoCode:String
    lateinit var symbol:String
    var decimalCount:Double = 0.0
    lateinit var pattern:String
    lateinit var href:String
}
class ImageModel(var url:String,var type:String){
}
class Appearance {
    lateinit var value:String
}
interface MyApiEndpointInterface {
    @GET("users/LoginUser")
    fun loginUser(@Query("email")email:String , @Query("password")password: String) : Call<ApiResponse<Int>>
    @Headers("Content-Type: application/json")
    @GET("users/VerifyUser")
    fun verifyUserCode(@Query("email")email:String,@Query("code")code: String) : Call<String>
    @Headers("Content-Type: application/json")
    @POST("users")
    fun registerUser(@Body user:User?): Call<String?>
    @GET("sellables")
    fun getSellables() : Call<List<Sellable>>
    /*@GET("users/{username}")
    fun getUser(@Path("username") username: String?): Call<User?>?

    @GET("group/{id}/users")
    fun groupList(@Path("id") groupId: Int , @Query("sort") sort: String?): Call<List<User?>?>?

    @POST("users/new")
    fun createUser(@Body user: User?): Call<User?>?*/
}