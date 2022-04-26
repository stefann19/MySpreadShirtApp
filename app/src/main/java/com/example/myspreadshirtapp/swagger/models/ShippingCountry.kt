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

import org.openapitools.client.models.ShippingState

import com.squareup.moshi.Json

/**
 * 
 *
 * @param id 
 * @param name 
 * @param isoCode 
 * @param shippingSupported 
 * @param externamFullfillmentSupported 
 * @param customs 
 * @param shippingStates 
 */

data class ShippingCountry (

    @Json(name = "id")
    val id: kotlin.Int? = null,

    @Json(name = "name")
    val name: kotlin.String? = null,

    @Json(name = "isoCode")
    val isoCode: kotlin.String? = null,

    @Json(name = "shippingSupported")
    val shippingSupported: kotlin.Boolean? = null,

    @Json(name = "externamFullfillmentSupported")
    val externamFullfillmentSupported: kotlin.Boolean? = null,

    @Json(name = "customs")
    val customs: kotlin.Boolean? = null,

    @Json(name = "shippingStates")
    val shippingStates: kotlin.collections.List<ShippingState>? = null

)

