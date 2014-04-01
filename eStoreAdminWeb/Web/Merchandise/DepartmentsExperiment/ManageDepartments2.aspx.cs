using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using phoenixconsulting.common.basepages;
using eStoreAdminBLL;

namespace eStoreAdminWeb.Web.Merchandise.Departments {
    public partial class ManageDepartments2 : BasePage {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e) {

        }

        protected void btnClear_Click(object sender, ImageClickEventArgs e) {
            DepartmentTextbox.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e) {
            LinkButton DepartmentIdButton = (LinkButton)sender;
            int depID = Convert.ToInt32(DepartmentIdButton.CommandArgument);
            DepartmentsBLL departmentBLL = new DepartmentsBLL();
            departmentBLL.DeleteDepartment(depID);

            Response.Redirect("ManageDepartments2.aspx");
        }
    }
}
