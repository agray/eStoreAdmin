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
using System.ComponentModel;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eStoreAdminWeb.Controls {
    [DefaultEvent("SelectedIndexChanged"), Designer("System.Web.UI.Design.WebControls.ListControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ParseChildren(true, "Items"), ControlValueProperty("SelectedValue"), DataBindingHandler("System.Web.UI.Design.WebControls.ListControlDataBindingHandler, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public partial class UserDDL : UserControl {
        private ListItemCollection m_Items;
        public event SelectedIndexChangedEventHandler SelectedIndexChanged;

        public delegate void SelectedIndexChangedEventHandler(object sender, SelectedIndexChangedEventArgs args);

        protected void Page_Load(object sender, EventArgs e) {}

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e) {
            if(SelectedIndexChanged != null) {
                SelectedIndexChanged(this, new SelectedIndexChangedEventArgs(UserDropDownList.SelectedItem));
            }
        }

        [DefaultValue((string)null), MergableProperty(false), PersistenceMode(PersistenceMode.InnerDefaultProperty), Editor("System.Web.UI.Design.WebControls.ListItemsCollectionEditor,System.Design, Version=2.0.0.0,Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public virtual ListItemCollection Items {
            get { return m_Items ?? (m_Items = new ListItemCollection()); }
        }

        protected override void CreateChildControls() {
            if(m_Items == null) {
                m_Items = new ListItemCollection();
            }

            if(m_Items.Count > 0) {
                foreach(ListItem item in m_Items) {
                    if(!UserDropDownList.Items.Contains(item)) {
                        UserDropDownList.Items.Add(item);
                    }
                }
            }
        }

        public override void DataBind() {
            ChildControlsCreated = true;
            base.DataBind();
        }

        public bool Enabled {
            get { return UserDropDownList.Enabled; }
            set { UserDropDownList.Enabled = value; }
        }

        public string[] DataSource {
            set { UserDropDownList.DataSource = value; }
        }

        public bool AutoPostBack {
            get { return UserDropDownList.AutoPostBack; }
            set { UserDropDownList.AutoPostBack = value; }
        }

        public bool AppendDataBoundItems {
            get { return UserDropDownList.AppendDataBoundItems; }
            set { UserDropDownList.AppendDataBoundItems = value; }
        }

        public string Text {
            get { return UserDropDownList.Text; }
            set { UserDropDownList.Text = value; }
        }

        public string SelectedValue {
            get { return UserDropDownList.SelectedValue; }
            set { UserDropDownList.SelectedValue = value; }
        }

        public int SelectedIndex {
            get { return UserDropDownList.SelectedIndex; }
            set { UserDropDownList.SelectedIndex = value; }
        }

        public ListItem SelectedItem {
            get { return UserDropDownList.SelectedItem; }
        }
    }
}