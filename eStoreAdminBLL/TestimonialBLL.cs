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
using System.ComponentModel;
using eStoreAdminBLL.Base;
using eStoreAdminDAL;

namespace eStoreAdminBLL {
    [DataObject]
    public class TestimonialBLL : BaseBLL {
        private const int NUM_PRIMARY_KEYS = 1; //Primary Keys

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public DAL.TestimonialsDataTable GetTestimonials() {
            return BLLAdapter.Instance.TestimonialAdapter.GetTestimonials();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public DAL.TestimonialsDataTable GetTestimonialById(int ID) {
            return BLLAdapter.Instance.TestimonialAdapter.GetTestimonialByID(ID);
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
        public bool PrimaryKeyExists(int ID) {
            return (NUM_PRIMARY_KEYS == (int)BLLAdapter.Instance.TestimonialAdapter.TestimonialPrimaryKeyExists(ID));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public bool AddTestimonial(string customerName,
                                   string customerCountry,
                                   string testimonialText) {
            DAL.TestimonialsDataTable testimonials = new DAL.TestimonialsDataTable();
            //Create a new TestimonialsRow instance
            DAL.TestimonialsRow testimonial = testimonials.NewTestimonialsRow();

            testimonial.CustomerName = customerName;
            testimonial.CustomerCountry = customerCountry;
            testimonial.TestimonialText = testimonialText;

            //Add the new Supplier
            testimonials.AddTestimonialsRow(testimonial);
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.TestimonialAdapter.Update(testimonials));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public bool UpdateTestimonial(int original_ID,
                                   string customerName,
                                   string customerCountry,
                                   string testimonialText) {
            DAL.TestimonialsDataTable testimonials = BLLAdapter.Instance.TestimonialAdapter.GetTestimonialByID(original_ID);

            if(testimonials.Count == 0) {
                //No matching records found, return false
                return false;
            }

            testimonials.Rows[0]["CustomerName"] = customerName;
            testimonials.Rows[0]["CustomerCountry"] = customerCountry;
            testimonials.Rows[0]["TestimonialText"] = testimonialText;
            
            //Update the product records
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.TestimonialAdapter.Update(testimonials));
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public bool DeleteTestmonial(int original_ID) {
            //Delete the Testimonial record
            return WasOnlyOneRecordAffected(BLLAdapter.Instance.TestimonialAdapter.Delete(original_ID));
        }
    }
}