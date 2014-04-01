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
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using SeleniumTests.Properties;

namespace Selenium2 {

    public class Selenium2TestBase : Base {
        public IWebDriver driver;
        public StringBuilder verificationErrors;
        public TestUtilities testUtil;

        [SetUp]
        public void SetupTest() {
            StartBrowser();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TearDownTest() {
            Common.WebBrowser = null;
            try {
                driver.Quit();
            } catch(Exception) {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public void StartBrowser() {
            Common.WebBrowser = Settings.Default.Selenium2Browser;

            switch(Common.WebBrowser) {
                case "firefox":
                    ICapabilities capability = DesiredCapabilities.Firefox();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
                    break;
                case "iexplore":
                    driver = new InternetExplorerDriver();
                    break;
                case "chrome":
                    ChromeOptions co = new ChromeOptions();
                    co.BinaryLocation = Settings.Default.ChromeEXELocation;
                    driver = new ChromeDriver(co);
                    break;
            }
        }

        public string getValue(IWebElement element) {
            return element.GetAttribute("value");
        }

        public string getPageSource() {
            return driver.PageSource;
        }
    }
}