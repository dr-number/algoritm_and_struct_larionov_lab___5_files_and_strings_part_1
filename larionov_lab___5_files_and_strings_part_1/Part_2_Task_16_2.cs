using System.Text.RegularExpressions;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_16_2
    {
        
        const int COUNT_COL = 6;

        const string TITLE_GPA = "Cредний балл";
        const string MESSAGE_ERROR = "Ошибка обработки данных\nВозможно структура таблицы не соответствует условию задачи!";

        private int count = 0;

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

        bool isCorrectTable(string str)
        {
            return Filter(str).Split("|").Length == COUNT_COL;
        }

        private int scanTable(StreamWriter file, string str, string ignore)
        {

            if (count == 0)
            {
                if (isCorrectTable(str))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    str += "  " + TITLE_GPA + " |";
                }
                else
                    return -1;
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

            MyFiles myFiles = new MyFiles();
            MyFiles.PathsForTask paths = myFiles.getPathsForTask(MyFiles.FILE_PART_2_TASK_16_2);

            string path = myFiles.getText(paths.originalFile, new Func<StreamWriter, string, string, int>(scanTable), "");
            paths.originalFile = path;

            bool isOk = path != "";

            MyPrint myPrint = new MyPrint();
            myPrint.printFinalInformation(isOk, MyPrint.WRITE_OK, MESSAGE_ERROR);

            if (!isOk)
                myFiles.recoverOriginalFile(paths.originalFile, paths.tmpFile);
        }
    }
}
