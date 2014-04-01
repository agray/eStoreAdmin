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

namespace Selenium2 {

    public class eStoreTestUtilities {
        //string htmlSource = selenium.PageSource;
        //System.Console.Out.WriteLine("*****START*****\n" + htmlSource + "\n" + "*****END*****");

        //public void AssertCRUDButtonsOnSelectOnly(IWebDriver driver, string formView) {
        //    string htmlSource = getPageSource();
        //    Assert.IsTrue(htmlSource.Contains("<input name=\"ctl00$ContentPlaceHolder1$" + formView + "$EditButton\" value=\"Edit\" id=\"ctl00_ContentPlaceHolder1_" + formView + "_EditButton\" type=\"submit\">"));
        //    Assert.IsTrue(htmlSource.Contains("name=\"ctl00$ContentPlaceHolder1$" + formView + "$DeleteButton\" value=\"Delete\""));
        //    Assert.IsTrue(htmlSource.Contains("<input name=\"ctl00$ContentPlaceHolder1$" + formView + "$NewButton\" value=\"New\" id=\"ctl00_ContentPlaceHolder1_" + formView + "_NewButton\" type=\"submit\">"));
        //}

        //public void AssertCRUDButtonsOnEdit(IWebDriver driver, string formView, string validationGroup) {
        //    string htmlSource = getPageSource();
        //    Assert.IsTrue(htmlSource.Contains("<input name=\"ctl00$ContentPlaceHolder1$" + formView + "$UpdateButton\" value=\"Update\" onclick='javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(\"ctl00$ContentPlaceHolder1$" + formView + "$UpdateButton\", \"\", true, \"" + validationGroup + "\", \"\", false, false))' id=\"ctl00_ContentPlaceHolder1_" + formView + "_UpdateButton\" type=\"submit\">&nbsp;"));
        //    Assert.IsTrue(htmlSource.Contains("<input name=\"ctl00$ContentPlaceHolder1$" + formView + "$UpdateCancelButton\" value=\"Cancel\" id=\"ctl00_ContentPlaceHolder1_" + formView + "_UpdateCancelButton\" type=\"submit\">"));
        //}

        public void getConfirmation(IWebDriver driver, string objectType) {
            Assert.That(driver.SwitchTo().Alert().Text, Is.StringMatching("^Are you sure you want to delete this " + objectType + "[\\s\\S]$"));
        }

        //public bool SelectValueEqual(IWebDriver driver, string selector, string value) {
        //    return driver.GetSelectedLabel(selector) == value;
        //}

        //public bool LabelValueEqual(IWebDriver driver, string selector, string value) {
        //    return driver.GetEval("document.getElementById(" + "'" + selector + "'" + ").innerText") == value;
        //}

        //public bool IsDisabled(IWebDriver driver, string field) {
        //    return driver.GetAttribute(field + "@disabled").Equals("disabled");
        //}

        //public bool IsEnabled(IWebDriver driver, string field) {
        //    return driver.IsEditable(field);
        //}
    }
}