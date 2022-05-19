namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_1_Task_16_2
    {

        private const string DEFAULT_DELIMITERS = ",.:; ";

        private string getDelimitersInfo(string delimiters)
        {
            string result = "";

            foreach (var item in delimiters)
            {
                if (item == ' ')
                    result += "(пробел) ";
                else
                    result = result + item + " ";
            }

            return result;
        }

        string deleteRepeat(string str)
        {
            return new string(str.ToCharArray().Distinct().ToArray());
        }
        private void PrintSplint(string str, string delimiterChars)
        {
            string[] array = str.Split(delimiterChars.ToCharArray());

            int count = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nДанные после обработки: \n");

            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var item in array)
                if (item != "")
                {
                    Console.WriteLine(item);
                    ++count;
                }

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\nКоличество слов:", count.ToString());
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_1_TASK_16_2);

            string delimiters = DEFAULT_DELIMITERS;

            MyStrings myStrings = new MyStrings();
            string str = myStrings.getFirstString("Введите строку: ", MyFiles.FILE_PART_1_TASK_16_2, "");

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\n" + MyPrint.INITIAL_DATA, str, "\n");

            myPrint.printString("\nРазделители:", getDelimitersInfo(delimiters), "\n");

            MyQuestion myQuestion = new MyQuestion();

            if (myQuestion.isQuestion("Добавить другие разделители? [y/n]: "))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Введите разделители (через пробел): ");
                Console.ResetColor();

                delimiters = deleteRepeat(delimiters + Console.ReadLine().Replace(" ", ""));

                myPrint.printString("\nОбновленные разделители:", getDelimitersInfo(delimiters), "\n");
            }

            PrintSplint(str, delimiters);
        }
    }
}
