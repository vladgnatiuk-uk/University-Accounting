using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityAccounting.DatabaseUtility
{
    class DatabaseInitializer
    {
        string connectionString;

        public DatabaseInitializer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateDb()
        {
            Directory.CreateDirectory(@"D:\UniversityAccountingDBs");

            String str;
            SqlConnection myConn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated security=SSPI;database=master");

            str = "CREATE DATABASE UnAccounting ON PRIMARY " +
                "(NAME = UnAccounting_Data, " +
                "FILENAME = 'd:\\UniversityAccountingDBs\\UnAccountingData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = UnAccounting_Log, " +
                "FILENAME = 'd:\\UniversityAccountingDBs\\UnAccountingLog.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)" + 
                "COLLATE Cyrillic_General_CI_AS";

            SqlCommand myCommand = new SqlCommand(str, myConn);

            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                MessageBox.Show("БД успішно створена", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        public bool CheckConnection()
        {
            bool checkConnection = false;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                checkConnection = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("БД не існує, починаю створення!", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkConnection = false;
            }
            finally
            {
                connection.Close();
            }
            return checkConnection;
        }

        public void CreateTables()
        {
            Thread.Sleep(5000);
            SqlRequestForCreateTables();
            MessageBox.Show("Таблиці створені", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FillTablesByData();
            MessageBox.Show("Дата заповнені", "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SqlRequestForCreateTables()
        {
            #region Sql command
            string cmd = @"CREATE TABLE Positions
                            (
                                Id INT IDENTITY NOT NULL PRIMARY KEY,
                                Name nvarchar(40) NOT NULL
                            )
                            
                            CREATE TABLE EmployeePersonalInfo
                            (
                                Id int IDENTITY NOT NULL PRIMARY KEY,
                                BirthDate date NOT NULL,
                                Address nvarchar(50) NOT NULL,
                                Phone nvarchar(30) NOT NULL,
                                Maritial nvarchar(25) NULL,
                                PositionId int NOT NULL
                            )
                            
                            CREATE TABLE StudentPersonalInfo
                            (
                                Id int IDENTITY NOT NULL PRIMARY KEY,
                                BirthDate date NOT NULL,
                                Address nvarchar(50) NOT NULL,
                                Phone nvarchar(30) NOT NULL,
                                Maritial nvarchar(25) NULL
                            )
                            
                            CREATE TABLE Employees
                            (
                                Id int IDENTITY NOT NULL PRIMARY KEY,
                                Name nvarchar(30) NOT NULL,
                                Surname nvarchar(30) NOT NULL,
                                Patronymic nvarchar(30) NOT NULL,
                                EmpPersInfoId int NOT NULL
                            )
                            
                            CREATE TABLE Students
                            (
                                Id int IDENTITY NOT NULL PRIMARY KEY,
                                Name nvarchar(30) NOT NULL,
                                Surname nvarchar(30) NOT NULL,
                                Patronymic nvarchar(30) NOT NULL,
                                StudPersInfoId int NOT NULL
                            )
                            
                            CREATE TABLE [Payment]
                            (
                                Id int IDENTITY NOT NULL PRIMARY KEY,
                                EmployeeId int NULL,
                                StudentId int NULL,
                                [Amount] float(5) NOT NULL,
                                [Index] float(3) NULL
                            )
                            
                            ALTER TABLE EmployeePersonalInfo
                            ADD CONSTRAINT FK_PositionsId
                            FOREIGN KEY (PositionId) REFERENCES Positions(Id);
                                                                
                            ALTER TABLE Employees 
                            ADD CONSTRAINT FK_EmpPersInfoId
                            FOREIGN KEY (EmpPersInfoId) REFERENCES EmployeePersonalInfo(Id);
                            
                            ALTER TABLE Students
                            ADD CONSTRAINT FK_StudPersInfoId
                            FOREIGN KEY (StudPersInfoId) REFERENCES StudentPersonalInfo(Id);
                            
                            ALTER TABLE Payment
                            ADD CONSTRAINT FK_EmployeeId
                            FOREIGN KEY (EmployeeId) REFERENCES Employees(Id);
                            
                            ALTER TABLE Payment
                            ADD CONSTRAINT FK_StudentId
                            FOREIGN KEY (StudentId) REFERENCES Students(Id);";

            #endregion

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Бібліотека університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                connection.Close();
            }
        }

        private void FillTablesByData()
        {
            #region Sql command

            string cmd = @"
                           INSERT INTO Positions
                           VALUES 
                           ('Вчитель'),
                           ('Методист'),
                           ('Лаборант'),
                           ('Охоронець'),
                           ('Бібліотекар'),
                           ('Декан'),
                           ('Зав.Кафедри'),
                           ('Професор'),
                           ('Ректор'),
                           ('Секретар');
                           
                           INSERT INTO EmployeePersonalInfo
                           VALUES 
                           ('10/20/2009', 'м.Київ', '012-000-00-00', 'Неодружений' , 10),
                           ('09/20/2009', 'м.Київ', '012-111-11-11', 'Одружений'    ,  9),
                           ('08/20/2009', 'м.Київ', '012-222-22-22', 'Неодружений' ,  8),
                           ('07/20/2009', 'м.Київ', '012-333-33-33', 'Одружений'    ,  7),
                           ('06/20/2009', 'м.Київ', '012-444-44-44', 'Неодружений' ,  6),
                           ('05/20/2009', 'м.Київ', '012-555-55-55', 'Одружений'    ,  5),
                           ('04/20/2009', 'м.Київ', '012-666-66-66', 'Неодружений' ,  4),
                           ('03/20/2009', 'м.Київ', '012-777-77-77', 'Одружений'    ,  3),
                           ('02/20/2009', 'м.Київ', '012-888-88-88', 'Неодружений' ,  2),
                           ('01/20/2009', 'м.Київ', '012-999-99-99', 'Одружений'    ,  1);
                           
                           INSERT INTO Employees
                           VALUES
                           ('Іван'     ,'Іванов'    ,'Іванович'      , 10),
                           ('Сідор'    ,'Сідоров'   ,'Сідорович'     ,  9),
                           ('Петр'     ,'Петров'    ,'Петрович'      ,  8),
                           ('Максим'   ,'Максимов'  ,'Максименко'    ,  7),
                           ('Влад'     ,'Владов'    ,'Владиславович' ,  6),
                           ('Віталий'  ,'Вітальєв'  ,'Вітальєвич'    ,  5),
                           ('Жора'     ,'Жоров'     ,'Георгієвич'    ,  4),
                           ('Антон'    ,'Антонов'   ,'Антонович'     ,  3),
                           ('Семен'    ,'Семенов'   ,'Семенович'     ,  2),
                           ('Марьян'   ,'Марьянов'  ,'Марьяненко'    ,  1);
                           
                           INSERT INTO StudentPersonalInfo
                           VALUES 
                           ('10/20/2009', 'м.Київ', '012-000-00-00', 'Неодружений'),
                           ('09/20/2009', 'м.Київ', '012-111-11-11', 'Неодружений'),
                           ('08/20/2009', 'м.Київ', '012-222-22-22', 'Неодружений'),
                           ('07/20/2009', 'м.Київ', '012-333-33-33', 'Неодружений'),
                           ('06/20/2009', 'м.Київ', '012-444-44-44', 'Неодружений'),
                           ('05/20/2009', 'м.Київ', '012-555-55-55', 'Неодружений'),
                           ('04/20/2009', 'м.Київ', '012-666-66-66', 'Неодружений'),
                           ('03/20/2009', 'м.Київ', '012-777-77-77', 'Неодружений'),
                           ('02/20/2009', 'м.Київ', '012-888-88-88', 'Неодружений'),
                           ('01/20/2009', 'м.Київ', '012-999-99-99', 'Неодружений');
                           
                           INSERT INTO Students
                           VALUES
                           ('Іван'     ,'Петров'      ,'Іванович'      , 10),
                           ('Сідор'    ,'Іванов'      ,'Сідорович'     ,  9),
                           ('Петр'     ,'Максимов'    ,'Петрович'      ,  8),
                           ('Максим'   ,'Владов'      ,'Максименко'    ,  7),
                           ('Влад'     ,'Вітальєв'    ,'Владиславович' ,  6),
                           ('Віталий'  ,'Жоров'       ,'Витальєвич'    ,  5),
                           ('Жора'     ,'Антонов'     ,'Георгієвич'    ,  4),
                           ('Антон'    ,'Семенов'     ,'Антонович'     ,  3),
                           ('Семен'    ,'Марьянов'    ,'Семенович'     ,  2),
                           ('Марьян'   ,'Сідоров'     ,'Марьяненко'    ,  1);
                           
                           
                           INSERT INTO Payment
                           VALUES
                           (    1,         NULL,     5000.65,     2.5),
                           (    2,         NULL,     5000.65,     1.3),
                           (    3,         NULL,     2000.65,     1),
                           (    4,         NULL,     3000.65,     NULL),
                           (    5,         NULL,     400.65,      NULL),
                           (    6,         NULL,     10000.65,    3.1),
                           (    7,         NULL,     1100.65,     NULL),
                           (    8,         NULL,     3700.65,     NULL),
                           (    9,         NULL,     8900.65,     NULL),
                           (   10,         NULL,     2200.65,     NULL),
                           ( NULL,            1,     100.01,      NULL),
                           ( NULL,            2,     100.65,      NULL),
                           ( NULL,            3,     100.65,      1.3),
                           ( NULL,            4,     400.65,      NULL),
                           ( NULL,            5,     100.65,      3.5),
                           ( NULL,            6,     200.65,      1.1),
                           ( NULL,            7,     300.65,      NULL),
                           ( NULL,            8,     100.65,      NULL),
                           ( NULL,            9,     200.65,      NULL),
                           ( NULL,           10,     5000.65,     2);
                           ";

            #endregion

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(cmd, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Бухгалтерія університету", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
