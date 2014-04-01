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
using System;
using System.Web.UI.WebControls;

namespace eStoreAdminWeb.Controls {
    public partial class AlphaLinks : BaseUserControl {
        string[] letters = { "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
					"L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
					"W", "X", "Y", "Z"};

        private string selectedLetter;
        //private int selectedIndex;

        protected void Page_Load(object sender, EventArgs e) {
            /*
		     * Dan Clem, 3/7/2007: As currently written, the control's Letter property must be accessed from the
		     * PreRender method of the calling page, NOT the Page_Load method of the calling page.
		     * I tried changing this method in the control to Page_Init in an attempt to make the value accurate
		     * from the calling page's Page_Load method, but this resulted in a one-off error, where the control showed the
		     * correct selected value, but the page was filtering the user list based on the prior click.
		     * 
		     * So based on my current understanding, I want to use Page_Load in the control and Page_PreRender in the calling page
		     * 
		     * 
		     * 
		     * Dan Clem, 3/6/2007.
		     * This is my first user control / .ascx file.
		     * It took me a while to figure out how to get a handle on what letter the user clicked.
		     * I found the answer to this (using command arguments with that weird DataBind syntax) at
		     * http://www.codeproject.com/aspnet/letterbasedpaging.asp.
		     * 
		     * This DataBind syntax was somewhat LESS than intuitive. >:[]
		     * 
		     * Note that most samples I've found check for POSTBACK in the pageload event to set initial values.
		     * I've chosen to check for ViewState instead, because that's just how it played out.
		     * I have no idea whether this is considered standard usage.
		     * 
		     * On a related note, you may notice that I have a SETTER for the LETTER.
		     * Reason being: I want to make this page available through a querystring link with a letter in it.
		     * I haven't tested this yet, but I'm hoping that I can initialize to an original querystring value.
		     */
            if(ViewState["selectedLetter"] == null) {
                selectedLetter = "All";
                ViewState["selectedLetter"] = "All";
            }
        }

        public void Page_PreRender() {
            /*
             * I moved this out of the Page_Load so that I could disable the selected link.
             * Prior to moving it out of Page_Load, the deselected link lagged one behind, because
             * Page_Load fires prior to the command event handler.
             */
            __theAlphalink.DataSource = letters;
            __theAlphalink.DataBind();
        }

        public string Letter {
            get {
                return ViewState["selectedLetter"].ToString();
            }
            set {
                ViewState["selectedLetter"] = value;
            }
        }

        public void Select(object sender, CommandEventArgs e) {
            selectedLetter = e.CommandArgument.ToString();
            ViewState["selectedLetter"] = e.CommandArgument.ToString();
        }

        public void DisableSelectedLink(object sender, RepeaterItemEventArgs e) {
            LinkButton lb = (LinkButton)e.Item.Controls[1];
            if(lb.Text == Letter)
                lb.Enabled = false;
        }
    }
}