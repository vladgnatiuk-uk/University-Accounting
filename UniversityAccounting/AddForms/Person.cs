using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityAccounting.AddForms
{
    public class Person
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string MaritialStatus { get; set; }
        public int PositionId { get; set; } = 0;
        public double Amount { get; set; } = 0;
        public double? Index { get; set; } = 0;
        public string Position { get; set; } = string.Empty;
        public PersonType PersonType { get; set; } = PersonType.Undefined;

        public bool CheckEmployeeFields()
        {
            bool isNames = !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Surname) && !string.IsNullOrEmpty(this.Patronymic);
            bool isAddress = !string.IsNullOrEmpty(this.Address);
            bool isPN = !string.IsNullOrEmpty(this.PhoneNumber);
            bool isMS = !string.IsNullOrEmpty(this.MaritialStatus);
            bool isPositionId = this.PositionId > 0 && this.PositionId < 11;
            bool isAmount = this.Amount > 0;

            return isNames && isAddress && isPN && isMS && isPositionId && isAmount;
        }

        public bool CheckStudentFields()
        {
            bool isNames = !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Surname) && !string.IsNullOrEmpty(this.Patronymic);
            bool isAddress = !string.IsNullOrEmpty(this.Address);
            bool isPN = !string.IsNullOrEmpty(this.PhoneNumber);
            bool isMS = !string.IsNullOrEmpty(this.MaritialStatus);
            bool isPositionId = this.PositionId == 0 ;
            bool isAmount = this.Amount > 0;

            return isNames && isAddress && isPN && isMS && isPositionId && isAmount;
        }

        public int GetPositionId(string position)
        {
            foreach (var pos in posId)
            {
                if(pos.Key == position)
                {
                    return pos.Value;
                }
            }

            return 0;
        }

        public object[] GetPositionsList()
        {
            string[] posNames = new string[posId.Keys.Count];
            int counter = 0;
            foreach (var pos in posId)
            {
                posNames[counter++] = pos.Key;
            }

            return posNames;
        }

        private Dictionary<string, int> posId = new Dictionary<string, int>()
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
