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
using System.Web;
using System.Web.SessionState;
using phoenixconsulting.common.handlers;

namespace phoenixconsulting.common.basepages {
    public class HTTPScopeHandlerBase : BasePage {
        #region HTTP Scopes

        protected HttpApplicationState ApplicationState {
            get { return getCurrentContext().Application; }
        }

        protected HttpSessionState SessionState {
            get { return getCurrentContext().Session; }
        }

        protected HttpRequest RequestObject {
            get { return getCurrentContext().Request; }
        }

        #endregion

        #region Setters
        protected void setInt(string variableName, HTTPScope scope, int val) {
            setVar(variableName, scope, val);
        }

        protected void setString(string variableName, HTTPScope scope, string val) {
            setVar(variableName, scope, val);
        }

        protected void setDouble(string variableName, HTTPScope scope, double val) {
            setVar(variableName, scope, val);
        }

        protected void setBool(string variableName, HTTPScope scope, bool val) {
            setVar(variableName, scope, val);
        }

        private void setVar(string variableName, HTTPScope scope, object objVal) {
            switch(scope) {
                case HTTPScope.APPLICATION:
                    ApplicationState[variableName] = objVal;
                    break;
                case HTTPScope.SESSION:
                    SessionState[variableName] = objVal;
                    break;
            }
        }

        #endregion

        #region Getters
        protected int getInt(string variableName, HTTPScope scope) {
            object check = getScopedValue(variableName, scope);
            //Check for null first
            if(check == null) {
                return 0;
            } 
            return int.Parse(returnVal(check, typeof(int)).ToString());
        }

        protected string getString(string variableName, HTTPScope scope) {
            object check = getScopedValue(variableName, scope);
            return (string)returnVal(check, typeof(string));
        }

        protected double getDouble(string variableName, HTTPScope scope) {
            object check = getScopedValue(variableName, scope);
            //Check for null first
            if(check == null) {
                return 0;
            } 
            return (double)check;
        }

        protected bool getBool(string variableName, HTTPScope scope) {
            object check = getScopedValue(variableName, scope);
            return (bool)returnVal(check, typeof(bool));
        }

        private object getScopedValue(string variableName, HTTPScope scope) {
            switch(scope) {
                case HTTPScope.APPLICATION:
                    return ApplicationState[variableName];
                case HTTPScope.SESSION:
                    return SessionState[variableName];
                case HTTPScope.REQUEST:
                    return RequestObject[variableName];
                default:
                    return null;
            }
        }

        private object returnVal(object val, Type t) {
            if(val != null) {
                return val;
            }
            if(t.Equals(typeof(double)) || t.Equals(typeof(int))) {
                return 0;
            }
            if(t.Equals(typeof(string))) {
                return string.Empty;
            }
            if(t.Equals(typeof(bool))) {
                return false;
            }
            return string.Empty;
        }
        #endregion
    }
}