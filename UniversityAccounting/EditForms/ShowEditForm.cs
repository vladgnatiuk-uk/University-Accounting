using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityAccounting.AddForms;
using UniversityAccounting.DatabaseUtility;

namespace UniversityAccounting.EditForms
{
    public partial class ShowEditForm : Form
    {
        Person Person { get; set; }
        DatabaseManager db { get; set; }

        public ShowEditForm(string connectionString, string name, Person person)
        {
            this.db = new DatabaseManager(connectionString);
            this.Text = name;
            InitializeComponent();

            this.Person = person;

            this.txtName.Text = Person.Name;
            this.txtSurname.Text = Person.Surname;
            this.txtPatronymic.Text = Person.Patronymic;
            this.dt.Value = Person.Date;
            this.txtAddress.Text = Person.Address;
            this.txtPN.Text = Person.PhoneNumber;
            this.txtMS.Text = Person.MaritialStatus;
            this.txtAmount.Text = Convert.ToString(Person.Amount);
            this.txtIndex.Text = Convert.ToString(Person.Index);
            
            if(Person.PersonType == PersonType.Employee)
            {
                this.lblPos.Visible = true;
                this.cbPosition.Visible = true;
                this.cbPosition.Items.AddRange(person.GetPositionsList());
                this.cbPosition.SelectedIndex = person.PositionId - 1;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            btnChange.Enabled = false;

            this.txtName.ReadOnly = false;
            this.txtSurname.ReadOnly = false;
            this.txtPatronymic.ReadOnly = false;
            this.dt.Enabled = true;
            this.txtAddress.ReadOnly = false;
            this.txtPN.ReadOnly = false;
            this.txtMS.ReadOnly = false;
            this.txtAmount.ReadOnly = false;
            this.txtIndex.ReadOnly = false;

            if (Person.PersonType == PersonType.Employee)
            {
                this.cbPosition.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Person.Name = txtName.Text;
            Person.Surname = txtSurname.Text;
            Person.Patronymic = txtPatronymic.Text;
            Person.Address = txtAddress.Text;
            Person.PhoneNumber = txtPN.Text;
            Person.MaritialStatus = txtMS.Text;
            Person.PositionId = cbPosition.SelectedIndex;
            Person.Date = dt.Value.Date;

            if (Person.PersonType == PersonType.Employee)
            {
                db.AlterEmployee(Person);
            }
            else
            {
                db.AlterStudent(Person);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
