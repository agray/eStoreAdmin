﻿#region Licence
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
using System;
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;
using phoenixconsulting.common.logging;
using NLog;

namespace eStoreAdminWeb {
    public partial class ManageTestimonials : AuditBasePage {
        private string[] fieldNames = {"Name", "Country", "Testimonial"};

        protected void TestimonialFormView_ItemDeleted(object sender, FormViewDeletedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Testimonial"));
            TestimonialsGridView.DataBind();
            logInfo(AuditEventType.TESTIMONIAL_DELETED, null, e.Values[0].ToString(), null);
        }

        protected void TestimonialFormView_ItemInserted(object sender, FormViewInsertedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Testimonial"));
            TestimonialsGridView.DataBind();
            logInfo(AuditEventType.TESTIMONIAL_ADDED, e.Values[0].ToString(), null, null);
            TestimonialFormView.DefaultMode = FormViewMode.ReadOnly;
        }

        protected void TestimonialFormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e) {
            logger.Debug(LoggerUtil.getText(fieldNames, e, "Testimonial"));
            TestimonialsGridView.DataBind();
            logInfo(AuditEventType.TESTIMONIAL_UPDATED, e.OldValues[0].ToString(), e.NewValues[0].ToString(), null);

        }

        protected void TestimonialsGridView_DataBound(object sender, EventArgs e) {
            if(TestimonialsGridView.Rows.Count == 0) {
                TestimonialFormView.DefaultMode = FormViewMode.Insert;
            } else {
                TestimonialFormView.DefaultMode = FormViewMode.ReadOnly;
            }
        }
    }
}