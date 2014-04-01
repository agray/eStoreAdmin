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
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Properties;

namespace Selenium2 {
    public class Base {
        public void printPageToConsole(string id, string html) {
            writeLine(id + " PAGE START");
            writeLine(html);
            writeLine(id + " PAGE END");
        }

        public void writeLine(string line) {
            Console.Out.WriteLine(line);
        }

        public void writeFileToUsersDesktop(string filename, string text) {
            writeFileToUsersDesktop(filename, text, true);
        }

        public void writeFileToUsersDesktop(string filename, string text, Boolean overwrite) {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = desktopPath + Path.DirectorySeparatorChar + filename;
            if(File.Exists(fullPath)) {
                if(overwrite) {
                    writeFile(fullPath, text);
                }
            } else {
                writeFile(fullPath, text);
            }
        }

        private void writeFile(string fullPath, string text) {
            TextWriter tw = new StreamWriter(fullPath);
            tw.WriteLine(text);
            tw.Close();
        }

        public void clearWithConsole(IWebDriver driver, string fieldName) {
            IWebElement element;
            element = driver.FindElement(By.Id(fieldName));
            if(element != null) {
                element.Click();
                element.Clear();
                element.Clear();
                writeLine("Inner Text of element " + fieldName + " after Clear is: " + driver.FindElement(By.Id(fieldName)).Text);
            } else {
                writeLine("Element " + fieldName + " not found");
            }
        }

        public void sendKeysWithConsole(IWebDriver driver, string fieldName, string textSent) {
            IWebElement element;
            element = driver.FindElement(By.Id(fieldName));
            if(element != null) {
                element.Click();
                element.Clear();
                element.SendKeys(textSent);
                ImplicitlyWaitForPageToLoad(driver, "sent keys to stick to " + fieldName, 300);
                IWebElement populated = driver.FindElement(By.Id(fieldName));
                writeLine("Inner Text of element " + fieldName + " after SendKeys is: " + populated.Text);
            } else {
                writeLine("Element " + fieldName + " not found");
            }
            ImplicitlyWaitForPageToLoad(driver, fieldName, 300);
        }

        public void ImplicitlyWaitForPageToLoad(IWebDriver driver, string source, int timespan) {
            writeLine("Implicitly Waiting for " + timespan + " sec (" + source + ")...");
            driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, timespan));
        }

        public void WaitForPageToLoad(IWebDriver driver, string source) {
            TimeSpan timeout = new TimeSpan(0, 0, 0, 45);
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            int i = 0;
            IJavaScriptExecutor javascript = driver as IJavaScriptExecutor;
            if(javascript == null) {
                throw new ArgumentException("driver", "Driver must support javascript execution");
            }
            wait.Until((d) => {
                i++;
                try {
                    string readyState = javascript.ExecuteScript("if (document.readyState) return document.readyState;").ToString();
                    Console.Out.WriteLine("readyState " + i + " (" + source + "): " + readyState);
                    return readyState.ToLower() == "complete";
                } catch(InvalidOperationException e) {
                    //Window is no longer available
                    return e.Message.ToLower().Contains("unable to get browser");
                } catch(WebDriverException e) {
                    //Browser is no longer available
                    return e.Message.ToLower().Contains("unable to connect");
                } catch(Exception) {
                    return false;
                }
            });
        }


        /**
         * This is identical to the selenium.isAlertPresent() method for
         * WebDriverBackedSelenium, in that it checks to see if an alert message
         * is present, except this one works.  It uses WebDriver methods to check to
         * see if a JavaScript alert() message is on the screen.
         * @return This will return true is an alert message is on the screen.
         */

        public Boolean isAlertPresent(IWebDriver driver) {
            try {
                driver.SwitchTo().Alert();
                return true;
            } catch(NoAlertPresentException) {
                return false;
            }
        }

        /**
         * This is identical to the selenium.getAlert() method for
         * WebDriverBackedSelenium, in that it gets the text of the alert message
         * and it clicks the OK button to make it go away, except this one works.
         * @return String with the text of the alert message in it.
         */

        public String getAlertWithAccept(IWebDriver driver) {
            IAlert alert = driver.SwitchTo().Alert();
            String str = alert.Text;

            alert.Accept();
            return str;
        }

        /**
         * This is identical to the selenium.getAlert() method for
         * WebDriverBackedSelenium, in that it gets the text of the alert message
         * and it clicks the Cancel button to make it go away, except this one works.
         * @return String with the text of the alert message in it.
         */

        public String getAlertWithDismiss(IWebDriver driver) {
            IAlert alert = driver.SwitchTo().Alert();
            String str = alert.Text;

            alert.Dismiss();
            return str;
        }

        public static string BaseURL {
            get { return Settings.Default.ApplicationTestEnvironment; }
        }
    }
}