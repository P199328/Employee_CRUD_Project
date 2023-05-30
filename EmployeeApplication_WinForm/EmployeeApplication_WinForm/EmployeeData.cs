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
        EmployeeModel employeeModel = new EmployeeModel();
        public EmployeeData()
        {
            InitializeComponent();
        }

     
        private async void BtnGetallEmp_Click(object sender, EventArgs e)
        {

            var response = await RestApicall.GetAll();
            if (txtEmpName.Text==""&txtId.Text==""&txtEmail.Text==""&txtGender.Text==""&txtStatus.Text=="")
            {
                txtView.Text = RestApicall.EmpJson(response);

            }
            else
            {
                MessageBox.Show("Please Don't Insert The Employee Details Feilds");
            }
            ClearData();
        }

       
        private async void btnView_Click(object sender, EventArgs e)
        {
            if(txtId.Text!=""& txtEmail.Text == "" & txtGender.Text == "" & txtStatus.Text == ""&txtEmpName.Text=="")
            {
                var response = await RestApicall.GetById(txtId.Text);
                txtView.Text = RestApicall.EmpJson(response);

            }
            else
            {
                txtView.Text = "";
                MessageBox.Show("Please Insert Employee Id Feild Only");
            }
            ClearData();
        }

        private async void btnAddEmp_Click(object sender, EventArgs e)
        {
            if ( txtEmail.Text != "" & txtGender.Text != "" & txtStatus.Text != "" & txtEmpName.Text != "")
            {
                if(txtId.Text == "")
                {
                    var response = await RestApicall.AddEmployee(txtEmpName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text);
                    txtView.Text = RestApicall.EmpJson(response);
                    MessageBox.Show("Employee Data Added Sucessfully");
                }
                else
                {
                    MessageBox.Show("Please Don't enter Employee Id Feild");
                }
            }
            else
            {
                txtView.Text = "";
                MessageBox.Show("Please Enter EmployeeName,Email,Gender,Status Feilds");

            }
            ClearData();
        }

        private async void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

            if (txtId.Text != "" &txtEmail.Text != "" & txtGender.Text != "" & txtStatus.Text != "" & txtEmpName.Text != "")
            {
               

                    var response = await RestApicall.UpdateEmployee(txtId.Text, txtEmpName.Text, txtEmail.Text, txtGender.Text, txtStatus.Text);
                    txtView.Text = RestApicall.EmpJson(response);
                    
                    MessageBox.Show("Employee Data Updated Sucessfully");
                
            }

            else
            {
                MessageBox.Show("Please Enter EmployeeId, EmployeeName,Email,Gender,Status Feilds");
            }

            ClearData();
        }

        private async void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" & txtEmail.Text == "" & txtGender.Text == "" & txtStatus.Text == "" & txtEmpName.Text == "")
            {

                var response = await RestApicall.DeleteEmployee(txtId.Text);
                txtView.Text = response;
            }
            else
            {
                MessageBox.Show("Please Enter only EmployeeId");
                txtView.Text = "";
            }
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
