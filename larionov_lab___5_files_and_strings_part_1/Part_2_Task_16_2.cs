using System.Text.RegularExpressions;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_16_2
    {
        private int count = 0;
        const string TITLE_GPA = "Cредний балл";

        public string Filter(string str)
        {
            Regex reg = new Regex("[^1-9|]");
            str = reg.Replace(str, "");

            if (str != "")
                str = str.Remove(str.Length - 1);

            return str;
        }

        private double getGPA(string str)
        {
            int n5 = 0, n4 = 0, n3 = 0, n2 = 0, n1 = 0;

            string[] marks = Filter(str).Split("|");

            foreach (string item in marks)
                switch (item)
                {
                    case "5": ++n5; break;
                    case "4": ++n4; break;
                    case "3": ++n3; break;
                    case "2": ++n2; break;
                    case "1": ++n1; break;
                }

            int divider = n5 + n4 + n3 + n2 + n1;

            if (divider == 0)
                return 0.00;

            double sum = n5 * 5 + n4 * 4 + n3 * 3 + n2 * 2 + n1;
            return Math.Round(sum / divider, 2);
        }

        private int scanTable(StreamWriter file, string str, string endSymbols)
        {

            if (count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                str += "  " + TITLE_GPA + " |";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                str += " \t\t" + getGPA(str).ToString("#.00") + " |";
            }

            Console.Write(str + "\n");

            file.WriteLine(str);
            ++count;

            return 1;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_16_2);

            const string ORIGINAL_FILE = MyFiles.FILE_PART_2_TASK_16_2;
            const string TMP_FILE = ORIGINAL_FILE + MyFiles.EXP_TMP;

            MyFiles myFiles = new MyFiles();
            bool isResult = myFiles.getText(ORIGINAL_FILE, new Func<StreamWriter, string, string, int>(scanTable), "");

            MyPrint myPrint = new MyPrint();
            myPrint.printFinalInformation(isResult);
        }
    }
}
