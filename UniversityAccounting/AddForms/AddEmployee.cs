﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UniversityAccounting.AddForms
{
    public partial class AddEmployee : Form
    {
        private string phoneNumberRegex;
        private Dictionary<string, int> positionsNameId;

        public bool IsAdded { get; private set; }
        public Person Person { get; set; }

        public AddEmployee()
        {
            InitializeComponent();

            phoneNumberRegex = @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)";
            positionsNameId = InitializePositionDict();

            cbMaritialStatus.SelectedIndex = 0;
            cbPosition.SelectedIndex = 0;

            IsAdded = false;
            Person = new Person();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isPersonNotEmpty = Person.Name != string.Empty && Person.Surname != string.Empty && Person.Patronymic != string.Empty;

            if (isPersonNotEmpty)
            {
                bool isTextsBoxNotEmpty = !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox3.Text) && textBox3.Text.IsDigitOnly();

                if (isTextsBoxNotEmpty)
                {
                    Person.Date = date.Value.Date;
                    
                    if(textBox1.Text.Length <= 30)
                    {
                        Person.Address = textBox1.Text;
                    }
                    else
                    {
                        MessageBox.Show("Занадто довга адреса, спробуйте знову!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(textBox2.Text.Length <= 20 && Regex.IsMatch(textBox2.Text, phoneNumberRegex))
                    {
                        Person.PhoneNumber = textBox2.Text;
                    }
                    else
                    {
                        MessageBox.Show("Невірно ведений номер телефону, спробуйте знову!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }                

                    Person.MaritialStatus = (string)cbMaritialStatus.SelectedItem;

                    Person.PositionId = positionsNameId.GetPositionNumber((string)cbPosition.SelectedItem);

                    Person.Amount = Convert.ToDouble(textBox3.Text);

                    if (!string.IsNullOrEmpty(textBox4.Text))
                        Person.Index = textBox4.Text.IsDigitOnly() ? Convert.ToDouble(textBox4.Text) : 0;

                    IsAdded = true;
                }
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Dictionary<string, int> InitializePositionDict()
        {
            return new Dictionary<string, int>
            {
                {"Вчитель", 1},
                {"Методист", 2},
                {"Лаборант", 3},
                {"Охоронець", 4},
                {"Бібліотекар", 5},
                {"Декан", 6},
                {"Зав.Кафедри", 7},
                {"Професор", 8},
                {"Ректор", 9},
                {"Секретар", 10}
            };
        }
    }

}
