using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
    }
    public class EmployeeData
    {
        public int ENo { get; set; }
        public string EName { get; set; }
    }

    class Program
    {
        enum Gender
        {
            Male = 1,
            Female = 0,
            Unknown = -1
        }
        enum UserType
        {
            enduser = 100,
            Admin = 101,
            SuperAdmin = 102,
            GlobalAdmin = 103
        }
             

        static void Main(string[] args)
        {
            //Console.WriteLine(Addition(10, 20));
            //Console.WriteLine(Addition(10.56, 20.78));
            //Console.WriteLine(Addition("m", "urali"));

            //Console.WriteLine(Add<int>(10, 20, 56));
            //Console.WriteLine(Add<double>(10.45, 20.56, 56));
            //Console.WriteLine(Add<string>("Murali", "Krishna", 676));

            //Console.WriteLine(Concatenate<double, int>(10.56, 20));
            //Console.WriteLine(Concatenate<int, double>(10, 20.56));
            ////Console.WriteLine(Concatenate<string, int>("Murali", 100));


            Console.WriteLine(ConcatenateV2<double, int, double>(10.56, 20));
            Console.WriteLine(ConcatenateV2<int, double, double>(10, 20.56));
            //Console.WriteLine(ConcatenateV2<string, int, string>("Murali", 100));


            //Console.WriteLine(Compare<int>(10, 10));
            //Console.WriteLine(Compare<double>(10.45, 20.56));
            //Console.WriteLine(Compare<string>("Murali", "Murali"));
            //Console.WriteLine(Compare<string>("Murali", "murali"));
            //Console.WriteLine(Compare<string>("Murali", "  murali"));
            //Console.WriteLine(Compare<string>("Murali", "  murali   "));
            //Console.WriteLine(Compare<string>("Murali", "Krishna"));

            //var gender = GetEnumValue<Gender>(-1);
            //var ut = GetEnumValue<UserType>(102);

            //var employeeData =  "<Employee><EmpNo>1</EmpNo><EmpName>Murali</EmpName></Employee>";
            //var employeeData1 = "<EmployeeData><ENo>2</ENo><EName>Murali Krishna</EName></EmployeeData>";

            //var emp  = DeserializeObject<Employee>(employeeData);
            //var emp1 = DeserializeObject<EmployeeData>(employeeData1);

            //Console.WriteLine(ConvertDate<string>("12-FEB-2020", "YYYY-MM-DD"));
            //Console.WriteLine(ConvertDate<DateTime>(new DateTime(2022, 7, 21), "DD-MM-YYYY"));

            Console.WriteLine("Press any key to continue .......");
        }


        private static T3 ConcatenateV2<T1, T2, T3>(T1 first, T2 second)
        {
            dynamic a = first;
            dynamic b = second;

            // returnValue = ((T)result);
            return (T3)(a + b);
        }

        // dataTable -> class object
        // datatable -> excel document
        // class A = Class B
        // 


        private static string ConvertDate<T>(T strInput, string eType)
        {
            DateTime strData = DateTime.MinValue;

            if (typeof(T).Equals(typeof(string)))
            {
                string strDataConv = Convert.ToString(strInput);
                if (!string.IsNullOrWhiteSpace(strDataConv))
                    strData = Convert.ToDateTime(strDataConv);
            }
            else if (typeof(T).Equals(typeof(DateTime)) || typeof(T).Equals(typeof(DateTime?)))
            {
                strData = Convert.ToDateTime(strInput);
            }

            if (eType == "YYYY-MM-DD")
            {
                return strData.Year.ToString() + "-" + IntMonth(strData.Month.ToString()) + "-" + IntDay(strData.Day.ToString());
            }
            else if (eType == "DD-MM-YYYY")
            {
                return IntDay(strData.Day.ToString()) + "-" + IntMonth(strData.Month.ToString()) + "-" + strData.Year.ToString();
            }
            else if (eType == "DD/MM/YYYY")
            {
                return IntDay(strData.Day.ToString()) + "/" + IntMonth(strData.Month.ToString()) + "/" + strData.Year.ToString();
            }
            return strData.ToString();
        }

        private static string IntMonth(string mon)
        {
            mon = mon.ToUpper();
            switch (mon)
            {
                case "JAN": case "01": case "1": return "01";
                case "FEB": case "02": case "2": return "02";
                case "MAR": case "03": case "3": return "03";
                case "APR": case "04": case "4": return "04";
                case "MAY": case "05": case "5": return "05";
                case "JUN": case "06": case "6": return "06";

                case "JUL": case "07": case "7": return "07";
                case "AUG": case "08": case "8": return "08";
                case "SEP": case "09": case "9": return "09";
                case "OCT": case "10": return "10";
                case "NOV": case "11": return "11";
                case "DEC": case "12": return "12";
            }
            return string.Empty;
        }

        private static string IntDay(string dd)
        {
            switch (dd)
            {
                case "01": case "1": return "01";
                case "02": case "2": return "02";
                case "03": case "3": return "03";
                case "04": case "4": return "04";
                case "05": case "5": return "05";
                case "06": case "6": return "06";

                case "07": case "7": return "07";
                case "08": case "8": return "08";
                case "09": case "9": return "09";
                default: return dd;
            }
            //return string.Empty;
        }


        //public static T DeserializeObject<T>(string strInput)
        //{
        //    try
        //    {
        //        T returnValue = default(T);
        //        XmlSerializer serial = new XmlSerializer(typeof(T));
        //        StringReader reader = new StringReader(strInput);
        //        object result = serial.Deserialize(reader);

        //        if (result != null && result is T)
        //        {
        //            returnValue = ((T)result);
        //        }
        //        reader.Close();

        //        return returnValue;
        //    }
        //    catch (Exception ex)
        //    {
        //        string str = ex.Message;
        //        throw ex;
        //    }
        //}

        //private static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        //{
        //    if (!typeof(T).IsEnum)
        //    {
        //        throw new Exception("T must be an Enumeration type.");
        //    }
        //    T val = ((T[])Enum.GetValues(typeof(T)))[0];

        //    foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
        //    {
        //        if (Convert.ToInt32(enumValue).Equals(intValue))
        //        {
        //            val = enumValue;
        //            break;
        //        }
        //    }
        //    return val;
        //}


        //private static bool Compare<T>(T first, T second)
        //{
        //    if (typeof(T).Equals(typeof(string)))
        //    {
        //        return string.Compare(first.ToString().Trim(), second.ToString().Trim(), StringComparison.OrdinalIgnoreCase) == 0 ? true : false;
        //    }
        //    else
        //        return first.Equals(second);
        //}

        //private static T1 Concatenate<T1, T2>(T1 first, T2 second)
        //{
        //    dynamic a = first;
        //    dynamic b = second;
        //    return a + b;
        //}

        //private static T Add<T>(T first, T second, int third)
        //{
        //    dynamic a = first;
        //    dynamic b = second;
        //    return a + b;
        //}

        //private static int Addition(int first, int second)
        //{
        //    return first + second;
        //}
        //private static double Addition(double first, double second)
        //{
        //    return first + second;
        //}
        //private static string Addition(string first, string second)
        //{
        //    return first + second;
        //}


    }
}
