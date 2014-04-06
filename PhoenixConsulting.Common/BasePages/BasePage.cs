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
using NLog;
using phoenixconsulting.common.handlers;
using phoenixconsulting.common.navigation;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace phoenixconsulting.common.basepages {
    public class BasePage : Page {
        protected Logger logger = LogManager.GetLogger("TraceFileAndEventLogger");
        public const string ROOT_DIR = "~/";
        public const string SYSTEM_IMAGE_DIR = ROOT_DIR + "Images/System/";
        public string mappedRootPath = mapPath(ROOT_DIR);
        
        protected virtual void Page_PreInit(object sender, EventArgs e) {
            MasterPageFile = Pages.ADMIN_MASTER;
        }

        public static string GetSiteBasePath(string path, string target) {
            StringBuilder b = new StringBuilder(path);

            switch(target) {
                case "CSStore":
                    //remove all instances of "admin" and "Admin"
                    return b.Replace("Admin", "").Replace("admin", "").ToString();
                default:
                    return "";
            }
        }

        public static string getHomePage(string username) {
            if(Roles.IsUserInRole(username, "Manager")) {
                return ROOT_DIR + ApplicationHandler.Instance.ManagerRoleHomePage;
            } 
            if(Roles.IsUserInRole(username, "Administrator")) {
                return ROOT_DIR + ApplicationHandler.Instance.AdminRoleHomePage;
            }
            if(Roles.IsUserInRole(username, "Staff")) {
                return ROOT_DIR + ApplicationHandler.Instance.StaffRoleHomePage;
            } 
            //return "Error.aspx";
            return Pages.NO_ROLES;
        }

        public void setNavigateURL(HyperLink link, string page) {
            link.NavigateUrl = page;
        }

        public void setNavigateURL(HyperLink link, string page, string querystring){
            link.NavigateUrl = page + querystring;
        }

        public bool IsApproved(FormView formView) {
            Label CCApprovalStatusLabel = (Label)formView.FindControl("CCApprovalStatusLabel");
            return CCApprovalStatusLabel.Text.Equals("0");
        }

        //*****************************************
        //  Custom Validator Methods
        //*****************************************
        public static bool isValidInt(string s) {
            int throwaway;
            return int.TryParse(s, out throwaway);
        }

        public static bool isValidString(string s) {
            return true;
        }

        public static bool isValidDouble(string s) {
            double throwaway;
            return double.TryParse(s, out throwaway);
        }

        public static bool isValidURL(string s) {
            Regex objPattern = new Regex("((https?|ftp|gopher|http|telnet|file|notes|ms-help):((//)|(\\\\))+[\\w\\d:#@%/;$()~_?\\+-=\\\\.&]*)");
            return objPattern.IsMatch(s);
        }

        public static bool isValidEmail(string s) {
            Regex objPattern = new Regex("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
            return objPattern.IsMatch(s);
        }
        
        public static bool isValidLength(string s, int length) {
            return s.Length <= length;
        }

        //*****************************************
        //  Conversion Methods
        //*****************************************
        public static int toInt(string s) {
            return int.Parse(s);
        }

        public static double toDouble(string s) {
            return double.Parse(s);
        }

        public static int toInt(object o) {
            return int.Parse(o.ToString());
        }

        public static double toDouble(object o) {
            return double.Parse(o.ToString());
        }

        //*****************************************
        //  Core HTTP Methods
        //*****************************************
        public static string mapPath(string path) {
            return getCurrentContext().Server.MapPath(path);
        }

        protected static HttpContext getCurrentContext() {
            return HttpContext.Current;
        }

        protected static HttpRequest getRequest() {
            return getCurrentContext().Request;
        }

        public static string GetCurrentPath() {
            return getRequest().Url.AbsolutePath;
        }

        public static string GetURL() {
            return getRequest().Url.GetLeftPart(UriPartial.Authority);
        }

        public static string GetCurrentPageName() {
            FileInfo oInfo = new FileInfo(GetCurrentPath());
            return oInfo.Name;
        }

        public static string CurrentUserName() {
            return getCurrentContext().User.Identity.Name;
        }
    }
}