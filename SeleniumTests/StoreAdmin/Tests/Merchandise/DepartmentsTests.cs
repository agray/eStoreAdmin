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
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium2.StoreAdmin.PageObjects;

namespace Selenium2.StoreAdmin.Tests {

    [TestFixture]
    public class DepartmentsTests : Selenium2TestBase {
        private string NameEditBox = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_NameEditTextBox";
        private string TitleEditBox = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_SEOTitleEditTextBox";
        private string KeywordsEditBox = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_SEOKeywordsEditTextBox";
        private string DescEditBox = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_SEODescEditTextBox";
        private string FriendlyNameEditBox = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_SEOFriendlyNameURLEditTextBox";
        private string EditButton = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_EditButton";
        private string DeleteButton = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_DeleteButton";
        private string DepartmentName = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_DepartmentName";

        [Test]
        public void AddTestItem() {
            DepartmentsPage departmentspage = new DepartmentsPage();

            departmentspage.NavigateToPage(driver, "Manager");
            departmentspage.AddItem(driver);
            driver.Navigate().GoToUrl(departmentspage.getPageURL());

            string htmlSource = getPageSource();
            writeFileToUsersDesktop("TestItemAdded.html", htmlSource, true);

            Assert.IsTrue(htmlSource.Contains("class=DepartmentName>SeleniumTest</SPAN></A>"));
            //Assert.IsTrue(htmlSource.Contains("<a href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$EditButton','')\" id=\"" + EditButton + "\">Edit</a>"));
            Assert.IsTrue(htmlSource.Contains("<A id=" + EditButton + " href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$EditButton','')\">Edit</A>"));
            //Assert.IsTrue(htmlSource.Contains("<a href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$DeleteButton','')\" id=\"" + DeleteButton + "\" onclick=\"return confirm('Are you sure you want to delete this department?');\">Delete</a>"));
            Assert.IsTrue(htmlSource.Contains("<A id=" + DeleteButton + " onclick=\"return confirm('Are you sure you want to delete this department?');\" href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$DeleteButton','')\">Delete</A>"));

        }

        [Test]
        public void CancelDeleteProcess() {
            DepartmentsPage departmentspage = new DepartmentsPage();

            departmentspage.NavigateToPage(driver, "Manager");
            departmentspage.CancelDeleteOfItem(driver);

            string htmlSource = getPageSource();
            writeFileToUsersDesktop("CancelledDeleteOfItem.html", htmlSource, true);
            Assert.IsTrue(htmlSource.Contains("<span class=\"DepartmentName\" id=\"" + DepartmentName + "\">SeleniumTest</span></a>"));
            Assert.IsTrue(htmlSource.Contains("<a href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$EditButton','')\" id=\"" + EditButton + "\">Edit</a>"));
            Assert.IsTrue(htmlSource.Contains("<a href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$DeleteButton','')\" id=\"" + DeleteButton + "\" onclick=\"return confirm('Are you sure you want to delete this department?');\">Delete</a>"));
        }

        [Test]
        public void EnterEditItem() {
            DepartmentsPage departmentspage = new DepartmentsPage();

            departmentspage.NavigateToPage(driver, "Manager");
            departmentspage.EnterEditItem(driver);
            writeFileToUsersDesktop("EnteredEditItem.html", driver.PageSource, true);

            string DepName = getValue(driver.FindElement(By.Id(NameEditBox)));
            string SEOTitle = getValue(driver.FindElement(By.Id(TitleEditBox)));
            string SEOKeywords = getValue(driver.FindElement(By.Id(KeywordsEditBox)));
            string SEODesc = getValue(driver.FindElement(By.Id(DescEditBox)));
            string SEOFriendly = getValue(driver.FindElement(By.Id(FriendlyNameEditBox)));

            Assert.IsTrue(DepName.Equals("SeleniumTest"));
            Assert.IsTrue(SEOTitle.Equals("SeleniumSEOTitle"));
            Assert.IsTrue(SEOKeywords.Equals("SeleniumSEOKeywords"));
            Assert.IsTrue(SEODesc.Equals("SeleniumSEODesc"));
            Assert.IsTrue(SEOFriendly.Equals("SeleniumSEOFriendlyName"));
        }

        [Test]
        public void EnterEditItemThenCancel() {
            DepartmentsPage departmentspage = new DepartmentsPage();

            departmentspage.NavigateToPage(driver, "Manager");
            departmentspage.EnterEditItemThenCancel(driver);

            string htmlSource = getPageSource();
            writeFileToUsersDesktop("AfterEnterEditItemThenCancel.html", htmlSource, true);
            Assert.IsTrue(htmlSource.Contains("<SPAN id=" + DepartmentName + " class=DepartmentName>SeleniumTest</SPAN>"));
        }

        [Test]
        public void FinalDeleteTestOfItem() {
            DepartmentsPage departmentspage = new DepartmentsPage();

            departmentspage.NavigateToPage(driver, "Manager");
            departmentspage.DeleteItem(driver);

            string htmlSource = getPageSource();
            writeFileToUsersDesktop("FinalDeleteOfItem.html", htmlSource, true);
            Assert.IsFalse(htmlSource.Contains("<span id=\"" + DepartmentName + "\" class=\"DepartmentName\">SeleniumTest</span></a>"));
            Assert.IsFalse(htmlSource.Contains("<a href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$EditButton','')\" id=\"" + EditButton + "\">Edit</a>"));
            Assert.IsFalse(htmlSource.Contains("<a href=\"javascript:__doPostBack('ctl00$ContentPlaceHolder1$DepartmentsList$ctrl1$ctl02$DeleteButton','')\" id=\"" + DeleteButton + "\" onclick=\"return confirm('Are you sure you want to delete this department?');\">Delete</a>"));
        }
    }
}