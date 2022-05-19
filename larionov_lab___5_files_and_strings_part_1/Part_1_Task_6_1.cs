namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_1_Task_6_1
    {
        private string FORMAT_DATE = "dd.MM.yyyy";
        private string FORMAT_DATE_TEXT = "дд.мм.гггг";

        private string DateToStr(DateTime dDate)
        {
            return dDate.ToString(FORMAT_DATE);
        }

        private string getOptionDigit(string s)
        {
            int size = s.Length;
            string result = "";

            if (size == 6) // 1.1.2000
                result = "0" + s[0] + ".0" + s[1] + "." + s[2] + s[3] + s[4] + s[5];
            else if (size == 7) // 1.11.2000
                result = "0" + s[0] + "." + s[1] + s[2] + "." + s[3] + s[4] + s[5] + s[6];
            else if (size >= 8) // 11.11.2000
                result = "" + s[0] + s[1] + "." + s[2] + s[3] + "." + s[4] + s[5] + s[6] + s[7];

            return result;
        }

        private bool isDatePlasOne(string sDate)
        {
            DateTime dDate;
            bool isCorrectPoint = sDate.Where(x => x == '.').Count() == 2;

            if (sDate.IndexOf("..") != -1)
                isCorrectPoint = false;

            if (isCorrectPoint && DateTime.TryParse(sDate, out dDate))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Дата корректна!");

                String.Format($"{FORMAT_DATE}", dDate);
                dDate = dDate.AddDays(1);

                MyPrint myPrint = new MyPrint();
                myPrint.printString("Cледующая по порядку дата:", DateToStr(dDate));
                Console.ResetColor();
                return true;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Дата не корректна!");
            Console.ResetColor();

            return false;
        }

        public void init()
        {

            Console.WriteLine(TasksInfo.PART_1_TASK_6_1);

            MyStrings myStrings = new MyStrings();
            string str = myStrings.getFirstString($"Введите дату в формате \"{FORMAT_DATE_TEXT}\": ", MyFiles.FILE_PART_1_TASK_6_1, "");

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\n" + MyPrint.INITIAL_DATA, str, "\n");

            if (isDatePlasOne(str))
                return;


            string correctingData = myStrings.getOnlyDigit(str);
            string optionDigit = getOptionDigit(correctingData);

            if (optionDigit == "")
                return;

            MyQuestion question = new MyQuestion();

            if (question.isProbably(optionDigit))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Некорректная дата: ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(str + " ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("заменена на: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(optionDigit + "\n\n");

                isDatePlasOne(optionDigit);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Дата не корректна!");
                Console.ResetColor();
            }

        }
    }
}
