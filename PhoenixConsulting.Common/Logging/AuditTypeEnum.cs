#region Licence
/*
 * The MIT License
 *
 * Copyright (c) 2008-2013, Andrew Gray
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion
namespace phoenixconsulting.common.logging {
    public enum AuditEventType {
        //DIRECTIONS FOR USE:
        //DO NOT REMOVE THE COMMENT ON EACH LINE.
        //THIS IS THE CATEGORYID FROM THE AuditCategoryType TABLE USED BY THE ENUMTODB TOOL.
        //WHEN ADDING ROWS BE SURE TO ALSO INCLUDE THE RIGHT CATEGORY.
        LOGIN_SUCCESS = 1,                  //1
        DIAGNOSTICS_PAGE,                   //1
        DIAGNOSTICS_SENT,                   //1
        SUBMIT_CC_PAYMENT_FAILED,           //2
        SUBMIT_PAYPAL_PAYMENT_FAILED,       //2
        SUBMIT_CC_PAYMENT_SUCCESS,          //1
        SUBMIT_PAYPAL_PAYMENT_SUCCESS,      //1
        SUBMIT_CC_PAYMENT_REJECTED,         //2
        SUBMIT_PAYPAL_PAYMENT_REJECTED,     //2
        LOGIN_FAILED,                       //2
        SKU_SEARCH,                         //3
        KEYWORD_SEARCH,                     //3
        ACTIVATION_PAGE,                    //1
        USER_LOGIN_CREATED_SUCCESS,         //1
        USER_LOGIN_CREATED_FAILURE,         //2
        USER_PASSWORD_CHANGED_SUCCESS,      //1
        USER_PASSWORD_RECOVERED_SUCCESS,    //1
        USER_PASSWORD_RECOVERED_FAILURE,    //2
        USER_PASSWORD_CHANGED_FAILURE,      //2
        MAILSEND_FAILED,                    //2
        MAILSEND_SUCCESS,                   //1
        ORDER_REFUNDED,                     //1
        DEPARTMENT_ADDED,                   //1
        DEPARTMENT_UPDATED,                 //1
        DEPARTMENT_DELETED,                 //1
        CATEGORY_ADDED,                     //1
        CATEGORY_UPDATED,                   //1
        CATEGORY_DELETED,                   //1
        PRODUCT_ADDED,                      //1
        PRODUCT_UPDATED,                    //1
        PRODUCT_DELETED,                    //1
        PRODUCTSIZE_ADDED,                  //1
        PRODUCTSIZE_UPDATED,                //1
        PRODUCTSIZE_DELETED,                //1
        PRODUCTCOLOR_ADDED,                 //1
        PRODUCTCOLOR_UPDATED,               //1
        PRODUCTCOLOR_DELETED,               //1
        PRODUCTIMAGE_ADDED,                 //1
        PRODUCTIMAGE_UPDATED,               //1
        PRODUCTIMAGE_DELETED,               //1
        THEME_ADDED,                        //1
        THEME_UPDATED,                      //1
        THEME_DELETED,                      //1
        CURRENCY_ADDED,                     //1
        CURRENCY_UPDATED,                   //1
        CURRENCY_DELETED,                   //1
        ZONE_ADDED,                         //1
        ZONE_UPDATED,                       //1
        ZONE_DELETED,                       //1
        BRAND_ADDED,                        //1
        BRAND_UPDATED,                      //1
        BRAND_DELETED,                      //1
        MODE_ADDED,                         //1
        MODE_UPDATED,                       //1
        MODE_DELETED,                       //1
        COUNTRY_ADDED,                      //1
        COUNTRY_UPDATED,                    //1
        COUNTRY_DELETED,                    //1
        SUPPLIER_ADDED,                     //1
        SUPPLIER_UPDATED,                   //1
        SUPPLIER_DELETED,                   //1
        COST_ADDED,                         //1
        COST_UPDATED,                       //1
        COST_DELETED,                       //1
        CCYEAR_ADDED,                       //1
        CCYEAR_UPDATED,                     //1
        CCYEAR_DELETED,                     //1
        BADWORD_ADDED,                      //1
        BADWORD_UPDATED,                    //1
        BADWORD_DELETED,                    //1
        LINK_ADDED,                         //1
        LINK_UPDATED,                       //1
        LINK_DELETED,                       //1
        TESTIMONIAL_ADDED,                  //1
        TESTIMONIAL_UPDATED,                //1
        TESTIMONIAL_DELETED,                //1
        SNDEPT_UPDATED,                     //1
        SNCAT_UPDATED,                      //1
        SNPROD_UPDATED,                     //1
        SETTING_UPDATED,                    //1
        PRODUCTS_EXPORTED,                  //1
        PRODUCTINVENTORY_EXPORTED,          //1
        PRODUCTPRICING_EXPORTED,            //1
        SUPPLIERS_EXPORTED,                 //1
        TESTIMONIALS_EXPORTED,              //1
        DEPARTMENTS_EXPORTED,               //1
        CATEGORIES_EXPORTED,                //1
        DEPARTMENTS_IMPORTED,               //1
        CATEGORIES_IMPORTED,                //1
        LINKS_EXPORTED,                     //1
        PRODUCTS_IMPORTED,                  //1
        PRODUCTINVENTORY_IMPORTED,          //1
        PRODUCTPRICING_IMPORTED,            //1
        SUPPLIERS_IMPORTED,                 //1
        TESTIMONIALS_IMPORTED,              //1
        TRANSACTIONS_EXPORTED,              //1
        LINKS_IMPORTED,                     //1
        USER_LOGIN_UPDATED,                 //1
        USER_LOGIN_DELETED,                 //1
        USER_LOGIN_UNLOCKED,                //1
        CUSTOMER_LOGIN_UPDATED,             //1
        CUSTOMER_LOGIN_UNLOCKED,            //1
        USER_ROLE_ADDED,                    //1
        USER_ROLE_DELETED,                  //1
        USER_ADDED_TO_ROLE,                 //1
        USER_REMOVED_FROM_ROLE,             //1
        ACCESS_RULE_CREATED,                //1
        ACCESS_RULE_DELETED,                //1
        ACCESS_RULE_ADDED,                  //1
        PRODUCT_IMAGE_MAKE_DEFAULT,         //1
        CATEGORY_IMAGE_MAKE_DEFAULT,        //1
        DEPARTMENT_IMAGE_MAKE_DEFAULT       //1
    }
}