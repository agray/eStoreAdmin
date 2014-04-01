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
using SeleniumTests.Properties;

namespace Selenium2.StoreAdmin.PageObjects {

    internal class LoginPage : BasePage {
        private readonly string _inputFieldUserName = "ctl00_ContentPlaceHolder1_Login_UserName";
        private readonly string _inputFieldPassword = "ctl00_ContentPlaceHolder1_Login_Password";
        private readonly string _inputButtonLogin = "ctl00_ContentPlaceHolder1_Login_LoginButton";

        private readonly string _inputLoginStatus = "ctl00_MasterLoginView_MasterLoginStatus";
        private readonly string _inputLogoutLink = "ctl00_ContentPlaceHolder1_logoutHyperlink";

        private readonly string _inputUnlockUserAdvancedLink = "//input[@name='link=ADVANCED']";
        private readonly string _inputUnlockUserHyperlink10 = "//input[@name='ctl00_ContentPlaceHolder1_Hyperlink10']";
        private readonly string _inputUnlockUserButton1 = "//input[@name='ctl00_ContentPlaceHolder1_Button1']";

        public void performLoginProcess(IWebDriver driver, string username, string password) {
            sendKeysWithConsole(driver, _inputFieldUserName, username);
            sendKeysWithConsole(driver, _inputFieldPassword, password);
            driver.FindElement(By.Id(_inputButtonLogin)).Click();
            //WaitForPageToLoad(driver, "performLoginProcess");
            ImplicitlyWaitForPageToLoad(driver, "performLoginProcess", 300);
        }

        private bool isAnyoneLoggedIn(IWebDriver driver) {
            string htmlSource = driver.PageSource;
            return htmlSource.Contains("LOGOUT");
        }

        private void logOut(IWebDriver driver) {
            driver.Navigate().GoToUrl(BaseURL + "/Dashboards/ManagerDashboard.aspx");
            //WaitForPageToLoad(driver, "logOut1");
            ImplicitlyWaitForPageToLoad(driver, "logOut1", 300);
            driver.FindElement(By.Id(_inputLoginStatus)).Click();
            //WaitForPageToLoad(driver, "logOut2");
            ImplicitlyWaitForPageToLoad(driver, "logOut2", 300);
            driver.FindElement(By.Id(_inputLogoutLink)).Click();
            //WaitForPageToLoad(driver, "logOut3");
            ImplicitlyWaitForPageToLoad(driver, "logOut3", 300);
        }

        private void unlockUser(IWebDriver driver, string username) {
            System.Console.Out.WriteLine("Need to unlock user " + username);
            performLoginProcess(driver, Settings.Default.UnlockerUserName, Settings.Default.UnlockerPassword);

            driver.FindElement(By.XPath(_inputUnlockUserAdvancedLink)).Submit(); //Click instead?
            //WaitForPageToLoad(driver, "unlockUser1");
            ImplicitlyWaitForPageToLoad(driver, "unlockUser1", 300);
            driver.FindElement(By.XPath(_inputUnlockUserHyperlink10)).Submit(); //Click instead?
            //WaitForPageToLoad(driver, "unlockUser2");
            ImplicitlyWaitForPageToLoad(driver, "unlockUser2", 300);
            driver.FindElement(By.XPath("//input[@name='link=" + username + "']")).Submit(); //Click instead?
            //WaitForPageToLoad(driver, "unlockUser3");
            ImplicitlyWaitForPageToLoad(driver, "unlockUser3", 300);
            driver.FindElement(By.XPath(_inputUnlockUserButton1)).Submit(); //Click instead?
            //WaitForPageToLoad(driver, "unlockUser4");
            ImplicitlyWaitForPageToLoad(driver, "unlockUser4", 300);
            driver.SwitchTo().Alert().Accept();
        }

        private void login(IWebDriver driver, string username, string password) {
            performLoginProcess(driver, username, password);
            if(loginFailed(driver)) {
                unlockUser(driver, username);
                getToLoginPage(driver);
                performLoginProcess(driver, username, password);
            }
        }

        private bool loginFailed(IWebDriver driver) {
            string htmlSource = driver.PageSource;
            return htmlSource.Contains("Your login attempt was not successful. Please try again.");
        }

        private void getToLoginPage(IWebDriver driver) {
            if(isAnyoneLoggedIn(driver)) {
                logOut(driver);
            }
            driver.Navigate().GoToUrl(BaseURL + Settings.Default.ApplicationLoginPage);
            //WaitForPageToLoad(driver, "getToLoginPage");
            ImplicitlyWaitForPageToLoad(driver, "getToLoginPage", 300);
        }

        public void OpenHomePage(IWebDriver driver, string userType) {
            getToLoginPage(driver);
            switch(userType) {
                case _ManagerType:
                    login(driver, Settings.Default.ManagerUserName, Settings.Default.ManagerPassword);
                    break;
                case _AdminType:
                    login(driver, Settings.Default.AdministratorUserName, Settings.Default.AdministratorPassword);
                    break;
                case _StaffType:
                    login(driver, Settings.Default.StaffUserName, Settings.Default.StaffPassword);
                    break;
            }

            //WaitForPageToLoad(driver, "OpenHomePage");
            ImplicitlyWaitForPageToLoad(driver, "OpenHomePage", 10000);
        }
    }
}