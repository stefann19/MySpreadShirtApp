/**
 * SpreadShirtShop
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 *
 * Please note:
 * This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * Do not edit this file manually.
 */

@file:Suppress(
    "ArrayInDataClass",
    "EnumEntryName",
    "RemoveRedundantQualifierName",
    "UnusedImport"
)

package org.openapitools.client.models

import org.openapitools.client.models.Appearance

import com.squareup.moshi.Json

/**
 * 
 *
 * @param href 
 * @param id 
 * @param appearances 
 */

data class PrintType (

    @Json(name = "href")
    val href: kotlin.String? = null,

    @Json(name = "id")
    val id: kotlin.String? = null,

    @Json(name = "appearances")
    val appearances: kotlin.collections.List<Appearance>? = null

)

