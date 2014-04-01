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
using OpenQA.Selenium;

namespace Selenium2.StoreAdmin.PageObjects {

    public class BasePage : Base {
        public const string _ManagerType = "Manager";
        public const string _AdminType = "Administrator";
        public const string _StaffType = "Staff";

        public virtual void NavigateToPage() {
            Console.WriteLine("Performing base class NavigateToPage");
        }

        public virtual void AddItem(IWebDriver driver) {
            Console.WriteLine("Performing base class AddItem");
        }

        public virtual void DeleteItem(IWebDriver driver) {
            Console.WriteLine("Performing base class DeleteItem");
        }

        public virtual void CancelDeleteOfItem(IWebDriver driver) {
            Console.WriteLine("Performing base class AddItem");
        }

        public virtual void EnterEditItem(IWebDriver driver) {
            Console.WriteLine("Performing base class EnterEditItem");
        }

        public virtual void EnterEditItemThenCancel(IWebDriver driver) {
            Console.WriteLine("Performing base class EnterEditItemThenCancel");
        }

        public void click(IWebDriver driver, string button) {
            //http://stackoverflow.com/questions/5574802/selenium-2-0b3-ie-webdriver-click-not-firing
            //Have to click parent...for some reason
            driver.FindElement(By.Id(button)).FindElement(By.XPath("..")).Click();
            driver.FindElement(By.Id(button)).Click();
        }
    }
}