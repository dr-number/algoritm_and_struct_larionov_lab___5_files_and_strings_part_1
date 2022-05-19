namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_1_Task_6_2
    {
        const string DEFAULT_SYMBOL = "М";
        private void PrintSplint(string str, string symbol, bool isReg)
        {
            string[] array = str.Split(" ");

            int count = 0;
            string result = "";

            bool isRegistr, isNoRegistr;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nДанные после обработки: ");

            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var item in array)
            {
                isNoRegistr = !isReg && item.ToLower().Contains(symbol.ToLower());
                isRegistr = isReg && item.Contains(symbol);

                if (isRegistr || isNoRegistr)
                {
                    result += item + " ";
                    ++count;
                }
            }

            MyPrint myPrint = new MyPrint();
            Console.WriteLine(result);

            myPrint.printString("Количество слов:", count.ToString());
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_1_TASK_6_2);

            MyQuestion myQuestion = new MyQuestion();
            bool isReg = myQuestion.isQuestion("Учитывать регистр? [y/n]: ");

            MyStrings myStrings = new MyStrings();
            string str = myStrings.getFirstString("Введите строку: ", MyFiles.FILE_PART_1_TASK_6_2, ".");

            string findSymbol = DEFAULT_SYMBOL;

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\n" + MyPrint.INITIAL_DATA, str);
            myPrint.printString("Общее колличество слов:", str.Split(" ").Length.ToString());

            myPrint.printString("\nНайти слова содержашие букву", $"\"{findSymbol}\"");

            if (isReg)
                myPrint.printString("Выполнить поиск", "с учетом регистра", "\n");
            else
                myPrint.printString("Выполнить поиск", "без учета регистра", "\n");

            if (myQuestion.isQuestion("Выпонить поиск ориентируясь на другие символ(ы)? [y/n]: "))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Введите символ(ы): ");
                Console.ResetColor();

                string tmp = Console.ReadLine();

                if (tmp != "" && tmp != " ")
                    findSymbol = tmp;

                myPrint.printString("Найти слова содержашие букву", $"\"{findSymbol}\"", "\n");
            }

            PrintSplint(str, findSymbol, isReg);
        }
    }
}
