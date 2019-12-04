using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using UniversityAccounting.DatabaseUtility;
using UniversityAccounting.AddForms;
using UniversityAccounting.EditForms;

namespace UniversityAccounting
{
    public partial class Main : Form
    {
        private string connectionString;
        private DatabaseInitializer dbInitializer;
        private DatabaseManager dbManager;

        public Main()
        {
            InitializeComponent();

            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UnAccounting;Integrated Security=True";
            dbInitializer = new DatabaseInitializer(connectionString);
            dbManager = new DatabaseManager(connectionString);
            CreateOpenDatabaseOnAppStart();
            cbViewPage.SelectedIndex = 0;
            cbAdd.SelectedIndex = 0;
        }

        private async void CreateOpenDatabaseOnAppStart()
        {
            await Task.Run(() =>
            {
                if (!dbInitializer.CheckConnection())
                {
                    dbInitializer.CreateDb();
                    dbInitializer.CreateTables();
                }
                else
                    MessageBox.Show("База даних існує!", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);

            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tableName = "Employees";

            switch ((string)cbViewPage.SelectedItem)
            {
                case "Співробітники":
                    tableName = "Employees";
                    break;
                case "Персональна інформація співробітників":
                    tableName = "EmployeePersonalInfo";
                    break;
                case "Посади":
                    tableName = "Positions";
                    break;
                case "Студенти":
                    tableName = "Students";
                    break;
                case "Персональна інформація студентів":
                    tableName = "StudentPersonalInfo";
                    break;
                case "Оплати":
                    tableName = "Payment";
                    break;
            }

            string sql = $"SELECT * FROM {tableName}";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                dataGridView.DataSource = ds.Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gbEdit.Visible = false;
            switch ((string)cbCalcChoose.SelectedItem)
            {
                case "Затрати університету":
                    {
                        lblCalc.Text = "Затрати університету";
                        txtCalc1.Text = $"{dbManager.CountAmount():F2}";
                        break;
                    }
                case "Затрати на співробітників(Підрахунок)":
                    {
                        lblCalc.Text = "Затрати на співробітників(Підрахунок)";
                        txtCalc1.Text = $"{dbManager.CountAmountOfEmployees():F2}";
                        break;
                    }
                case "Затрати на студентів(Підрахунок)":
                    {
                        lblCalc.Text = "Затрати на студентів(Підрахунок)";
                        txtCalc1.Text = $"{dbManager.CountAmountOfStudents():F2}";
                        break;
                    }
                case "Кількість студентів":
                    {
                        lblCalc.Text = "Кількість студентів";
                        txtCalc1.Text = Convert.ToString(dbManager.CountStudents());
                        break;
                    }
                case "Кількість співробітників":
                    {
                        lblCalc.Text = "Кількість співробітників";
                        txtCalc1.Text = Convert.ToString(dbManager.CountEmployees());
                        break;
                    }
                case "Загальна кількість людей":
                    {
                        lblCalc.Text = "Загальна кількість людей";
                        txtCalc1.Text = Convert.ToString(dbManager.CountPersons());
                        break;
                    }
                case "Інформація про співробітника/студента":
                    {
                        lblCalc.Text = "Інформація про співробітника/студента";
                        txtCalc1.Text = "";
                        gbEdit.Visible = true;

                        break;
                    }
                case "Затрати на співробітників":
                    {
                        dgvTasks.Visible = true;

                        string sql = $@"SELECT emp.Name, emp.Surname, emp.Patronymic, pay.[Amount] as Fee, pay.[Index] as Indexing
                                        FROM [Payment] as pay
                                        INNER JOIN Employees as emp
                                        ON pay.EmployeeId = emp.Id";                                                                     

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                            //adapter.SelectCommand = new SqlCommand(sql, connection);

                            DataSet ds = new DataSet();

                            adapter.Fill(ds);

                            dgvTasks.DataSource = ds.Tables[0];
                        }
                        break;
                    }
                case "Затрати на студентів":
                    {
                        dgvTasks.Visible = true;
                        string sql = $@"SELECT st.Name, st.Surname, st.Patronymic, pay.[Amount] as Fee, pay.[Index] as Indexing
                                        FROM [Payment] as pay
                                        INNER JOIN Students as st
                                        ON pay.StudentId = st.Id
                                       ";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter();

                            adapter.SelectCommand = new SqlCommand(sql, connection);

                            DataSet ds = new DataSet();

                            adapter.Fill(ds);

                            dgvTasks.DataSource = ds.Tables[0];
                        }
                        break;
                    }
                case "Підрахунок оплат":
                    {
                        dgvTasks.Visible = true;
                        string sql = $@"SELECT st.Name, st.Surname, st.Patronymic, pay.[Amount] * ISNULL(pay.[Index], 1) as FullPay
                                        FROM [Payment] as pay
                                        INNER JOIN Students as st
                                        ON pay.StudentId = st.Id
                                        
                                        UNION ALL

                                        SELECT emp.Name, emp.Surname, emp.Patronymic, pay.[Amount] * ISNULL(pay.[Index], 1) as FullPay
                                        FROM [Payment] as pay
                                        INNER JOIN Employees as emp
                                        ON pay.EmployeeId = emp.Id";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter();

                            adapter.SelectCommand = new SqlCommand(sql, connection);

                            DataSet ds = new DataSet();

                            adapter.Fill(ds);

                            dgvTasks.DataSource = ds.Tables[0];
                        }
                        break;
                    }
                case "Показати людей с вказаної дати народження":
                    {
                        string[] parsedDate = dateTasks.Value.Date.ToString("MM/dd/yyyy").Split('.');
                        string date = string.Empty;

                        foreach (var item in parsedDate)
                        {
                            date += item + "/";
                        }
                        date = date.TrimEnd('/');

                        dateTasks.Visible = false;

                        dgvTasks.Visible = true;
                        string sql = $@"SELECT st.Name, st.Surname, st.Patronymic, pers.BirthDate
                                        FROM Students as st
                                        INNER JOIN StudentPersonalInfo as pers
                                        ON st.StudPersInfoId = pers.Id
                                        WHERE pers.BirthDate > @date
                                        
                                        UNION ALL

                                        SELECT emp.Name, emp.Surname, emp.Patronymic, pers.BirthDate
                                        FROM Employees as emp
                                        INNER JOIN EmployeePersonalInfo as pers
                                        ON emp.EmpPersInfoId = pers.Id
                                        WHERE pers.BirthDate > @date";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            SqlDataAdapter adapter = new SqlDataAdapter();

                            adapter.SelectCommand = new SqlCommand(sql, connection);
                            adapter.SelectCommand.Parameters.Add(new SqlParameter("@date", date));

                            DataSet ds = new DataSet();

                            adapter.Fill(ds);

                            dgvTasks.DataSource = ds.Tables[0];
                        }
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool notEmptyTextBoxes = !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text);
            string personStatus = (string)cbAdd.SelectedItem;

            if (notEmptyTextBoxes)
            {
                Person person = new Person();

                switch (personStatus)
                {
                    case "Співробітник":
                        {
                            AddEmployee addEmployee = new AddEmployee();
                            addEmployee.Person.Name = textBox1.Text;
                            addEmployee.Person.Surname = textBox2.Text;
                            addEmployee.Person.Patronymic = textBox3.Text;

                            addEmployee.ShowDialog();

                            if (addEmployee.IsAdded)
                            {
                                person = addEmployee.Person;
                                if (dbManager.AddEmployee(person))
                                {
                                    MessageBox.Show("Дані успішно додані", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearTextBoxes(textBox1, textBox2, textBox3);
                                }
                                else
                                {
                                    MessageBox.Show("Дані не були додані, помилка на стороні серверу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Дані не були додані, заповнення відмінено чи виникла помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;
                        }
                    case "Студент":
                        {
                            AddStudent addStudent = new AddStudent();
                            addStudent.Person.Name = textBox1.Text;
                            addStudent.Person.Surname = textBox2.Text;
                            addStudent.Person.Patronymic = textBox3.Text;

                            addStudent.ShowDialog();

                            if (addStudent.IsAdded)
                            {
                                person = addStudent.Person;
                                if (dbManager.AddStudent(person))
                                {
                                    MessageBox.Show("Дані успішно додані", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearTextBoxes(textBox1, textBox2, textBox3);
                                }
                                else
                                {
                                    MessageBox.Show("Дані не були додані, помилка на стороні серверу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Дані не були додані, заповнення відмінено чи виникла помилка", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Всі текстові поля повинні бути заповнені!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region Helpers

        private void ClearTextBoxes(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }
        }

        #endregion

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cbChange.Items.Clear();
            var peoplesList = dbManager.GetPeople(PersonType.Employee);
            string[] personNames = new string[peoplesList.Count];
            int counter = 0;
            foreach (var people in peoplesList)
            {
                personNames[counter++] = people.Name;
            }
            cbChange.Items.AddRange(personNames);
            cbChange.SelectedIndex = 0;
            btnChange.Enabled = true;
        }

        private void rbStud_CheckedChanged(object sender, EventArgs e)
        {
            cbChange.Items.Clear();
            var peoplesList = dbManager.GetPeople(PersonType.Student);
            string[] personNames = new string[peoplesList.Count];
            int counter = 0;
            foreach (var people in peoplesList)
            {
                personNames[counter++] = people.Name;
            }
            cbChange.Items.AddRange(personNames);
            cbChange.SelectedIndex = 0;
            btnChange.Enabled = true;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int id = cbChange.SelectedIndex + 1;
            string name = (string)cbChange.SelectedItem;

            Person person = null;

            if (rbEmp.Checked)
            {
                person = dbManager.GetEmployee(id);
                person.PersonType = PersonType.Employee;

            }
            else if (rbStud.Checked)
            {
                person = dbManager.GetStudent(id);
                person.PersonType = PersonType.Student;
            }

            person.Id = id;
            ShowEditForm showEdit = new ShowEditForm(connectionString, name, person);
            showEdit.ShowDialog();


        }

        private void cbCalcChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvTasks.Visible = false;
            txtCalc1.Visible = true;
            button2.Enabled = true;
            dateTasks.Visible = false;
            txtCalc1.Text = string.Empty;
            lblCalc.Text = string.Empty;

            if ((string)cbCalcChoose.SelectedItem == "Показати людей с вказаної дати народження")
            {
                dateTasks.Visible = true;
                txtCalc1.Visible = false;
                button2.Enabled = false;
            }
        }

        private void dateTasks_ValueChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
