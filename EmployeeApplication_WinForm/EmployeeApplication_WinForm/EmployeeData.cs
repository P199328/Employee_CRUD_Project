using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace EmployeeApplication_WinForm
{
    public partial class EmployeeData : Form
    {
        public EmployeeData()
        {
            InitializeComponent();
        }

     
        private async void BtnGetallEmp_Click(object sender, EventArgs e)
        {

            var response = await RestApicall.GetAll();
         
            txtView.Text =RestApicall.EmpJson(response);
            ClearData();
        }

       
        private async void btnView_Click(object sender, EventArgs e)
        {
            var response = await RestApicall.GetById(txtId.Text);
            txtView.Text = RestApicall.EmpJson(response);
            ClearData();
        }

        private async void btnAddEmp_Click(object sender, EventArgs e)
        {
            var response = await RestApicall.AddEmployee(txtEmpName.Text,txtEmail.Text,txtGender.Text,txtStatus.Text);
            txtView.Text = RestApicall.EmpJson(response);
            MessageBox.Show("Employee Data Added Sucessfully");
            ClearData();
        }

        private async void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            var response = await RestApicall.UpdateEmployee(txtId.Text,txtEmpName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text);
            txtView.Text = RestApicall.EmpJson(response);
            MessageBox.Show("Employee Data Updated Sucessfully");

            ClearData();
        }

        private async void btnDeleteEmp_Click(object sender, EventArgs e)
        {

            var response = await RestApicall.DeleteEmployee(txtId.Text);
            txtView.Text = response;
            ClearData();
        }

       public void ClearData()
        {
            txtId.Text = "";
            txtEmail.Text = "";
            txtEmpName.Text = "";
            txtGender.Text = "";
            txtStatus.Text = "";
        }

        
    }
}
