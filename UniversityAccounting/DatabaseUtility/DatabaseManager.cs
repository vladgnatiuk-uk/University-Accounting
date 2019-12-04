using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityAccounting.AddForms;

namespace UniversityAccounting.DatabaseUtility
{
    class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool AddEmployee(Person employee)
        {
            bool isCorrect = false;

            if (employee.CheckEmployeeFields())
            {
                int rowNumber = 0;
                int numberOfCorrectSqlExpressions = 0;

                string[] parsedDate = employee.Date.ToString("MM/dd/yyyy").Split('.');
                string date = string.Empty;

                foreach (var item in parsedDate)
                {
                    date += item + "/";
                }
                date = date.TrimEnd('/');

                string sqlExpressionEmpPersInfo = $@"INSERT INTO EmployeePersonalInfo 
                                                     VALUES 
                                                     ('{date}', '{employee.Address}', '{employee.PhoneNumber}', '{employee.MaritialStatus}' , {employee.PositionId})";

                string sqlExpressionEmpPersInfoCount = @"SELECT COUNT(Id) FROM EmployeePersonalInfo";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(sqlExpressionEmpPersInfo, connection);
                    SqlCommand command2 = new SqlCommand(sqlExpressionEmpPersInfoCount, connection);

                    numberOfCorrectSqlExpressions += command1.ExecuteNonQuery();

                    SqlDataReader reader = command2.ExecuteReader();

                    while (reader.Read()) rowNumber = (int)reader.GetValue(0);

                    reader.Close();

                    if (rowNumber != 0)
                    {

                        string sqlExpressionEmployee = $@"INSERT INTO Employees 
                                                  VALUES 
                                                  ('{employee.Name}', '{employee.Surname}', '{employee.Patronymic}', {rowNumber})";
                        SqlCommand command3 = new SqlCommand(sqlExpressionEmployee, connection);

                        numberOfCorrectSqlExpressions += command3.ExecuteNonQuery();

                        rowNumber = 0;

                        string sqlExpressionEmployeesCount = @"SELECT COUNT(Id) FROM Employees";

                        SqlCommand command4 = new SqlCommand(sqlExpressionEmployeesCount, connection);

                        reader = command4.ExecuteReader();

                        while (reader.Read()) rowNumber = (int)reader.GetValue(0);

                        reader.Close();

                        if (rowNumber != 0)
                        {
                            double? index = employee.Index == 0 ? null : (double?)employee.Index;
                            string sqlExpressionPayment = string.Empty;

                            if (index == null)
                            {
                                sqlExpressionPayment = $@"INSERT INTO Payment 
                                                  VALUES 
                                                  ('{rowNumber}', NULL, '{employee.Amount}', NULL)";
                            }
                            else
                            {
                                sqlExpressionPayment = $@"INSERT INTO Payment 
                                                  VALUES 
                                                  ('{rowNumber}', NULL, '{employee.Amount}', {index})";
                            }

                            SqlCommand command5 = new SqlCommand(sqlExpressionPayment, connection);

                            numberOfCorrectSqlExpressions += command5.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Невірні дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невірні дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (numberOfCorrectSqlExpressions == 3) isCorrect = true;
            }

            return isCorrect;
        }

        public bool AddStudent(Person student)
        {
            bool isCorrect = false;

            if (student.CheckStudentFields())
            {
                int rowNumber = 0;
                int numberOfCorrectSqlExpressions = 0;

                string[] parsedDate = student.Date.ToString("MM/dd/yyyy").Split('.');
                string date = string.Empty;

                foreach (var item in parsedDate)
                {
                    date += item + "/";
                }
                date = date.TrimEnd('/');

                string sqlExpressionEmpPersInfo = $@"INSERT INTO StudentPersonalInfo 
                                                     VALUES 
                                                     ('{date}', '{student.Address}', '{student.PhoneNumber}', '{student.MaritialStatus}')";

                string sqlExpressionEmpPersInfoCount = @"SELECT COUNT(Id) FROM StudentPersonalInfo";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command1 = new SqlCommand(sqlExpressionEmpPersInfo, connection);
                    SqlCommand command2 = new SqlCommand(sqlExpressionEmpPersInfoCount, connection);

                    numberOfCorrectSqlExpressions += command1.ExecuteNonQuery();

                    SqlDataReader reader = command2.ExecuteReader();

                    while (reader.Read()) rowNumber = (int)reader.GetValue(0);

                    reader.Close();

                    if (rowNumber != 0)
                    {

                        string sqlExpressionStudent = $@"INSERT INTO Students 
                                                  VALUES 
                                                  ('{student.Name}', '{student.Surname}', '{student.Patronymic}', {rowNumber})";
                        SqlCommand command3 = new SqlCommand(sqlExpressionStudent, connection);

                        numberOfCorrectSqlExpressions += command3.ExecuteNonQuery();

                        rowNumber = 0;

                        string sqlExpressionStudentsCount = @"SELECT COUNT(Id) FROM Students";

                        SqlCommand command4 = new SqlCommand(sqlExpressionStudentsCount, connection);

                        reader = command4.ExecuteReader();

                        while (reader.Read()) rowNumber = (int)reader.GetValue(0);

                        reader.Close();

                        if (rowNumber != 0)
                        {
                            double? index = student.Index == 0 ? null : (double?)student.Index;
                            string sqlExpressionPayment = string.Empty;

                            if (index == null)
                            {
                                sqlExpressionPayment = $@"INSERT INTO Payment 
                                                  VALUES 
                                                  (NULL, {rowNumber}, '{student.Amount}', NULL)";
                            }
                            else
                            {
                                sqlExpressionPayment = $@"INSERT INTO Payment 
                                                  VALUES 
                                                  (NULL, {rowNumber}, '{student.Amount}', {index})";
                            }

                            SqlCommand command5 = new SqlCommand(sqlExpressionPayment, connection);

                            numberOfCorrectSqlExpressions += command5.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Невірні дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невірні дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (numberOfCorrectSqlExpressions == 3) isCorrect = true;
            }

            return isCorrect;
        }

        internal Person GetPersonForEdit()
        {
            throw new NotImplementedException();
        }

        public double CountAmount()
        {
            object amount = 0;

            string sqlExprCountAmount = @"SELECT Sum(Amount) FROM Payment";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    amount = reader.GetValue(0);

                reader.Close();
            }

            return Convert.ToDouble(amount);
        }

        public double CountAmountOfEmployees()
        {
            object amount = 0;

            string sqlExprCountAmount = @"SELECT Sum(Amount) FROM Payment AS pay
                                          INNER JOIN Employees AS emp
                                          ON emp.Id = pay.EmployeeId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    amount = reader.GetValue(0);

                reader.Close();
            }

            return Convert.ToDouble(amount);
        }

        public double CountAmountOfStudents()
        {
            object amount = 0;

            string sqlExprCountAmount = @"SELECT Sum(Amount) FROM Payment AS pay
                                          INNER JOIN Students AS st
                                          ON st.Id = pay.StudentId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    amount = reader.GetValue(0);

                reader.Close();
            }

            return Convert.ToDouble(amount);
        }

        public int CountPersons()
        {
            object count = 0;

            string sqlExprCountAmount = @"SELECT ((SELECT Count(Id) FROM Students) + Count(Id)) AS SUMRESULT FROM Employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    count = reader.GetValue(0);

                reader.Close();
            }

            return Convert.ToInt32(count);
        }

        public int CountEmployees()
        {
            object count = 0;

            string sqlExprCountAmount = @"SELECT Count(Id) FROM Employees";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    count = reader.GetValue(0);

                reader.Close();
            }

            return Convert.ToInt32(count);
        }

        public int CountStudents()
        {
            object count = 0;

            string sqlExprCountAmount = @"SELECT Count(Id) FROM Students";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    count = reader.GetValue(0);

                reader.Close();
            }

            return Convert.ToInt32(count);
        }

        public List<Person> GetPeople(PersonType person)
        {
            List<Person> peoplesList = new List<Person>();

            string sqlExpression = string.Empty;

            switch (person)
            {
                case PersonType.Employee:
                    sqlExpression = @"SELECT Id, Name + ' ' + Surname + ' ' + Patronymic FROM Employees";
                    break;
                case PersonType.Student:
                    sqlExpression = @"SELECT Id, Name + ' ' + Surname + ' ' + Patronymic FROM Students";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    object[] objArr = new object[2];
                    reader.GetValues(objArr);

                    peoplesList.Add(new Person()
                    {
                        Id = Convert.ToInt32(objArr[0]),
                        Name = (string)objArr[1],
                    });
                }

                reader.Close();
            }

            return peoplesList;
        }
    
        public Person GetEmployee(int id)
        {
            Person retPerson = null;

            string sqlExprCountAmount;

            sqlExprCountAmount = $@"SELECT emp.Name, emp.Surname ,emp.Patronymic, empInf.BirthDate,  empInf.Address, empInf.Phone, pay.Amount, pay.[Index], pos.Name, empInf.Maritial, empInf.PositionId
                                    FROM Employees as emp
	                                     INNER JOIN EmployeePersonalInfo as empInf
	                                     ON emp.EmpPersInfoId = empInf.Id
	                                     INNER JOIN Positions as pos
	                                     ON pos.Id = empInf.PositionId
	                                     INNER JOIN Payment as pay
	                                     ON pay.EmployeeId = emp.Id
                                         WHERE emp.Id = @id";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlParameter param = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);
                command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();              

                while (reader.Read())
                {
                    object[] objArr = new object[11];
                    reader.GetSqlValues(objArr);

                    retPerson = new Person()
                    {
                        Name = Convert.ToString(objArr[0]),
                        Surname = Convert.ToString(objArr[1]),
                        Patronymic = Convert.ToString(objArr[2]),
                        Date = Convert.ToDateTime(objArr[3]),
                        Address = Convert.ToString(objArr[4]),
                        PhoneNumber = Convert.ToString(objArr[5]),
                        Amount = (double)(SqlSingle)objArr[6],
                        Index = objArr[7] as double? ?? default(double),
                        Position = Convert.ToString(objArr[8]),
                        MaritialStatus = Convert.ToString(objArr[9]),
                        PositionId = (int)(SqlInt32)objArr[10]
                    };
                }

                reader.Close();
            }

            retPerson.PersonType = PersonType.Employee;

            return retPerson;
        }

        public void AlterEmployee(Person person)
        {
            string sqlUpdateEmpInfo;
            string sqlUpdateEmp;

            string[] parsedDate = person.Date.ToString("MM/dd/yyyy").Split('.');
            string date = string.Empty;

            foreach (var item in parsedDate)
            {
                date += item + "/";
            }
            date = date.TrimEnd('/');

            sqlUpdateEmpInfo = $@"UPDATE EmployeePersonalInfo
                                  SET BirthDate = @birthdate, Address = @address, Phone = @phone, Maritial = @maritial, PositionId = @posId
                                  WHERE Id = @id";


            sqlUpdateEmp = $@"UPDATE Employees
                              SET Name = @name, Surname = @surname, Patronymic = @patronymic
                              WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlUpdateEmpInfo, connection);

                SqlParameter bdPar = new SqlParameter("@birthdate", date);
                SqlParameter addressPar = new SqlParameter("@address", person.Address);
                SqlParameter phonePar = new SqlParameter("@phone", person.PhoneNumber);
                SqlParameter maritialPar = new SqlParameter("@maritial", person.MaritialStatus);
                SqlParameter posIdPar = new SqlParameter("@posId", person.PositionId);
                SqlParameter idPar = new SqlParameter("@id", person.Id);

                SqlParameter namePar = new SqlParameter("@name", person.Name);
                SqlParameter surnamePar = new SqlParameter("@surname", person.Surname);
                SqlParameter patronymicPar = new SqlParameter("@patronymic", person.Patronymic);
                SqlParameter id2Par = new SqlParameter("@id", person.Id);

                command.Parameters.Add(bdPar);
                command.Parameters.Add(addressPar);
                command.Parameters.Add(phonePar);
                command.Parameters.Add(maritialPar);
                command.Parameters.Add(posIdPar);
                command.Parameters.Add(idPar);

                var execute = command.ExecuteNonQuery();

                command = new SqlCommand(sqlUpdateEmp, connection);

                command.Parameters.Add(namePar);
                command.Parameters.Add(surnamePar);
                command.Parameters.Add(patronymicPar);
                command.Parameters.Add(id2Par);

                execute = command.ExecuteNonQuery();
            }
        }

        public Person GetStudent(int id)
        {
            Person retPerson = null;

            string sqlExprCountAmount;

            sqlExprCountAmount = $@"SELECT stud.Name, stud.Surname ,stud.Patronymic, studInf.BirthDate,  studInf.Address, studInf.Phone, pay.Amount, pay.[Index], studInf.Maritial
                                    FROM Students as stud
	                                     INNER JOIN StudentPersonalInfo as studInf
	                                     ON stud.StudPersInfoId = studInf.Id
	                                     INNER JOIN Payment as pay
	                                     ON pay.StudentId = stud.Id
                                         WHERE stud.Id = @id";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlParameter param = new SqlParameter("@id", id);

                SqlCommand command = new SqlCommand(sqlExprCountAmount, connection);
                command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    object[] objArr = new object[9];
                    reader.GetSqlValues(objArr);

                    retPerson = new Person()
                    {
                        Name = Convert.ToString(objArr[0]),
                        Surname = Convert.ToString(objArr[1]),
                        Patronymic = Convert.ToString(objArr[2]),
                        Date = Convert.ToDateTime(objArr[3]),
                        Address = Convert.ToString(objArr[4]),
                        PhoneNumber = Convert.ToString(objArr[5]),
                        Amount = (double)(SqlSingle)objArr[6],
                        Index = objArr[7] as double? ?? default(double),
                        MaritialStatus = Convert.ToString(objArr[8]),
                    };
                }
                
                reader.Close();
            }

            retPerson.PersonType = PersonType.Employee;

            return retPerson;
        }

        public void AlterStudent(Person person)
        {
            string sqlUpdateStudInfo;
            string sqlUpdateStud;

            string[] parsedDate = person.Date.ToString("MM/dd/yyyy").Split('.');
            string date = string.Empty;

            foreach (var item in parsedDate)
            {
                date += item + "/";
            }
            date = date.TrimEnd('/');

            sqlUpdateStudInfo = $@"UPDATE StudentPersonalInfo
                                  SET BirthDate = @birthdate, Address = @address, Phone = @phone, Maritial = @maritial
                                  WHERE Id = @id";


            sqlUpdateStud = $@"UPDATE Students
                              SET Name = @name, Surname = @surname, Patronymic = @patronymic
                              WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlUpdateStudInfo, connection);

                SqlParameter bdPar = new SqlParameter("@birthdate", date);
                SqlParameter addressPar = new SqlParameter("@address", person.Address);
                SqlParameter phonePar = new SqlParameter("@phone", person.PhoneNumber);
                SqlParameter maritialPar = new SqlParameter("@maritial", person.MaritialStatus);
                SqlParameter idPar = new SqlParameter("@id", person.Id);

                SqlParameter namePar = new SqlParameter("@name", person.Name);
                SqlParameter surnamePar = new SqlParameter("@surname", person.Surname);
                SqlParameter patronymicPar = new SqlParameter("@patronymic", person.Patronymic);
                SqlParameter id2Par = new SqlParameter("@id", person.Id);

                command.Parameters.Add(bdPar);
                command.Parameters.Add(addressPar);
                command.Parameters.Add(phonePar);
                command.Parameters.Add(maritialPar);
                command.Parameters.Add(idPar);

                var execute = command.ExecuteNonQuery();

                command = new SqlCommand(sqlUpdateStud, connection);

                command.Parameters.Add(namePar);
                command.Parameters.Add(surnamePar);
                command.Parameters.Add(patronymicPar);
                command.Parameters.Add(id2Par);

                execute = command.ExecuteNonQuery();
            }
        }
    }
}
