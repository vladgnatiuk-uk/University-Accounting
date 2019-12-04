using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityAccounting.AddForms;

namespace UniversityAccounting
{
    public static class Extensions
    {
        public static List<string> GetStringList(this ComboBox.ObjectCollection collection)
        {
            List<string> stringList = new List<string>();
            foreach (var item in collection)
            {
                stringList.Add((string)item);
            }
            return stringList;
        }

        public static int GetPositionNumber(this Dictionary<string, int> dictionary, string value)
        {
            int returnItem = 0;

            foreach (var item in dictionary)
            {
                if (item.Key.Contains(value))
                {
                    returnItem = item.Value;
                    break;
                }
            }

            return returnItem;
        }

        public static bool IsDigitOnly(this string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;

        }

        public static PersonType GetPersonType(this PersonType personType, string status)
        {
            PersonType type = PersonType.Undefined;

            if (status == "Співробітник")
                type = PersonType.Employee;
            else if (status == "Студент")
                type = PersonType.Student;
            else
                type = PersonType.Undefined;

                return type;
        }
    }
}
