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
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;
using PhoenixConsulting.Zipper.DotNetZip;

namespace eStoreAdminWeb.Web.UISample {
    // ZipExample.aspx
    // 
    // This .aspx page demonstrates how to use the DotNetZip library from within ASP.NET.
    // 
    // To run it,
    //  1. drop the Ionic.Zip.dll into the \bin directory of your ASP.NET app
    //  2. create a subdirectory called "fodder" in your web app directory.
    //  3. copy into that directory a variety of random files.
    //  4. insure your web.config is properly set up (See below)
    // 
    // 
    // notes:
    //  This requies the .NET Framework 3.5 - because it uses the ListView control that is
    //  new for ASP.NET in the .NET Framework v3.5.
    // 
    //  To use this control, you must add the new web controls.  Also, you must use the v3.5 compiler.
    //  IF you build your app in Visual Studio, this is all done for you. If you don't use VS2008,
    //  here's an example web.config that works with this aspx file:
    // 
    //    <configuration>
    //      <system.web>
    //        <trust level="Medium" />
    //        <compilation defaultLanguage="c#" />
    //        <pages>
    //          <controls>
    //            <add tagPrefix="asp" namespace="System.Web.UI.WebControls" assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    //          </controls>
    //        </pages>
    //      </system.web>
    //      <system.codedom>
    //        <compilers>
    //          <compiler language="c#;cs;csharp" extension=".cs" warningLevel="4" type="Microsoft.CSharp.CSharpCodeProvider, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
    //            <providerOption name="CompilerVersion" value="v3.5" />
    //            <providerOption name="WarnAsError" value="false" />
    //          </compiler>
    //        </compilers>
    //      </system.codedom>
    //    </configuration>
    // 
    // 
    // 
    public partial class DotNetZipExample : BasePage {
        public String width = "100%";

        public void Page_Load(Object sender, EventArgs e) {
            try {
                if(!Page.IsPostBack) {
                    // populate the dropdownlist
                    // must have a directory called "upload" in the web app
                    String homeDir = Server.MapPath(".");
                    String sMappedPath = Server.MapPath("~/Web/UISample/upload");

                    var fqFilenames = new List<String>(Directory.GetFiles(sMappedPath));
                    var filenames = fqFilenames.ConvertAll((s) => { return s.Replace(sMappedPath + "\\", ""); });

                    ErrorMessage.InnerHtml = "";

                    FileListView.DataSource = filenames;
                    FileListView.DataBind();
                }

            } catch(Exception) {
                // Ignored
            }
        }


        public void btnGo_Click(Object sender, EventArgs e) {
            ErrorMessage.InnerHtml = "";   // debugging only
            var filesToInclude = new System.Collections.Generic.List<String>();
            String sMappedPath = Server.MapPath("~/Web/UISample/upload");
            var source = FileListView.DataKeys as DataKeyArray;

            foreach(var item in FileListView.Items) {
                CheckBox chkbox = item.FindControl("include") as CheckBox;
                Label lbl = item.FindControl("label") as Label;

                if(chkbox != null && lbl != null) {
                    if(chkbox.Checked) {
                        ErrorMessage.InnerHtml += String.Format("adding file: {0}<br/>\n", lbl.Text);
                        filesToInclude.Add(System.IO.Path.Combine(sMappedPath, lbl.Text));
                    }
                }
            }

            if(filesToInclude.Count == 0) {
                ErrorMessage.InnerHtml += "You did not select any files?<br/>\n";

            } else {
                Response.Clear();

                System.Web.HttpContext c = System.Web.HttpContext.Current;
                String ReadmeText = String.Format("README.TXT\n\nHello!\n\n" +
                                                 "This is a zip file that was dynamically generated at {0}\n" +
                                                 "by an ASP.NET Page running on the machine named '{1}'.\n" +
                                                 "The server type is: {2}\n",
                                                 DateTime.Now.ToString("G"),
                                                 Environment.MachineName,
                                                 c.Request.ServerVariables["SERVER_SOFTWARE"]);
                string archiveName = String.Format("archive-{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "filename=" + archiveName);

                DotNetZipper zipper = new DotNetZipper(Server.MapPath("~/Web/ZippedFiles"));
                zipper.addFiles(filesToInclude);
                zipper.addEntry("Readme.txt", ReadmeText);
                //zipper.save(Response.OutputStream);
                zipper.save("MyZippedFile.zip");
                //Response.Flush();
                //Response.Close();
            }
        }
    }
}