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
using OpenQA.Selenium;

namespace Selenium2.StoreAdmin.PageObjects {

    public class DepartmentPage : BasePage {
        private readonly string _departmentPage = "/Web/Merchandise/Department/ManageDepartment.aspx?DepID=1&DepName=Dogs";
        private readonly string _AddButton1 = "ctl00_ContentPlaceHolder1_AddButton";
        private readonly string _NameAddTextBox = "ctl00_ContentPlaceHolder1_AddDepartmentFormView_NameAddTextBox";
        private readonly string _SEOTitleAddTextBox = "ctl00_ContentPlaceHolder1_AddDepartmentFormView_SEOTitleAddTextBox";
        private readonly string _SEOKeywordsAddTextBox = "ctl00_ContentPlaceHolder1_AddDepartmentFormView_SEOKeywordsAddTextBox";
        private readonly string _SEODescAddTextBox = "ctl00_ContentPlaceHolder1_AddDepartmentFormView_SEODescAddTextBox";
        private readonly string _SEOFriendlyNameAddTextBox = "ctl00_ContentPlaceHolder1_AddDepartmentFormView_SEOFriendlyNameURLAddTextBox";
        private readonly string _AddButton2 = "ctl00_ContentPlaceHolder1_AddDepartmentFormView_btnAdd";
        private readonly string _CancelButton = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_btnCancel";
        private readonly string _EditButton = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_EditButton";
        private readonly string _DeleteButton = "ctl00_ContentPlaceHolder1_DepartmentsList_ctrl1_ctl02_DeleteButton";

        public void NavigateToPage(IWebDriver driver, string userType) {
            LoginPage loginPage = new LoginPage();
            loginPage.OpenHomePage(driver, userType);
            //WaitForPageToLoad(driver, "NavigateToPage1");
            ImplicitlyWaitForPageToLoad(driver, "NavigateToPage1", 300);

            driver.Navigate().GoToUrl(BaseURL + _departmentPage);

            //WaitForPageToLoad(driver, "NavigateToPage2");
            ImplicitlyWaitForPageToLoad(driver, "NavigateToPage2", 300);
        }

        public override void AddItem(IWebDriver driver) {
            driver.FindElement(By.Id(_AddButton1)).Click();
            //click(driver, _AddButton1);

            //WaitForPageToLoad(driver, "AddItem1");
            ImplicitlyWaitForPageToLoad(driver, "AddItem1", 300);

            driver.FindElement(By.Id(_NameAddTextBox)).Clear();
            driver.FindElement(By.Id(_NameAddTextBox)).SendKeys("SeleniumTest");
            driver.FindElement(By.Id(_SEOTitleAddTextBox)).Clear();
            driver.FindElement(By.Id(_SEOTitleAddTextBox)).SendKeys("SeleniumSEOTitle");
            driver.FindElement(By.Id(_SEOKeywordsAddTextBox)).Clear();
            driver.FindElement(By.Id(_SEOKeywordsAddTextBox)).SendKeys("SeleniumSEOKeywords");
            driver.FindElement(By.Id(_SEODescAddTextBox)).Clear();
            driver.FindElement(By.Id(_SEODescAddTextBox)).SendKeys("SeleniumSEODesc");
            driver.FindElement(By.Id(_SEOFriendlyNameAddTextBox)).Clear();
            driver.FindElement(By.Id(_SEOFriendlyNameAddTextBox)).SendKeys("SeleniumSEOFriendlyName");

            //driver.FindElement(By.Id(_AddButton2)).Click();
            click(driver, _AddButton2);

            //WaitForPageToLoad(driver, "AddItem2");
            ImplicitlyWaitForPageToLoad(driver, "AddItem2", 300);
        }

        public override void DeleteItem(IWebDriver driver) {
            //driver.FindElement(By.Id(_DeleteButton)).Click();
            click(driver, _DeleteButton);

            //WaitForPageToLoad(driver, "DeleteItem1");
            ImplicitlyWaitForPageToLoad(driver, "DeleteItem1", 300);
            IAlert prompt = driver.SwitchTo().Alert();
            prompt.Accept();
            //WaitForPageToLoad(driver, "DeleteItem2");
            ImplicitlyWaitForPageToLoad(driver, "DeleteItem2", 300);

            NavigateToPage(driver, "Manager");
        }

        public override void CancelDeleteOfItem(IWebDriver driver) {
            //driver.FindElement(By.Id(_DeleteButton)).Click();
            click(driver, _DeleteButton);
            //WaitForPageToLoad(driver, "CancelDeleteOfItem1");
            ImplicitlyWaitForPageToLoad(driver, "CancelDeleteOfItem1", 300);
            IAlert prompt = driver.SwitchTo().Alert();
            prompt.Dismiss();
            //WaitForPageToLoad(driver, "CancelDeleteOfItem2");
            ImplicitlyWaitForPageToLoad(driver, "CancelDeleteOfItem2", 300);
        }

        public override void EnterEditItem(IWebDriver driver) {
            //driver.FindElement(By.Id(_EditButton)).Click();
            click(driver, _EditButton);
            //WaitForPageToLoad(driver, "EnterEditItem");
            ImplicitlyWaitForPageToLoad(driver, "EnterEditItem", 300);
        }

        public override void EnterEditItemThenCancel(IWebDriver driver) {
            EnterEditItem(driver);
            driver.FindElement(By.Id(_CancelButton)).Click();
            //click(driver, _CancelButton);
            //WaitForPageToLoad(driver, "EnterEditItemThenCancel");
            ImplicitlyWaitForPageToLoad(driver, "EnterEditItemThenCancel", 300);
        }
    }
}