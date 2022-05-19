namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MyPrint
    {
        public const string INITIAL_DATA = "Исходные данные: ";
        public const string FINAL_RESULT = "Конечный результат: ";

        public const string WRITE_OK = "\nТребуемые данные успешно записаны в файл!";
        public const string WRITE_ERROR = "\nОшибка! Данные не записаны в файл!";
        public void printString(string title, string data, string subData = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title + " ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(data + " ");

            if (subData != "")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(subData);
            }

            Console.Write("\n");
            Console.ResetColor();
        }

        private void printStringArray(List<List<int>> array, int m)
        {

            if (array.Count == 0)
                return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[{0}]\t ", m);

            int countCol = array.Count;

            for (int j = 0; j < countCol; ++j)
            {
                if (j == m)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.Write("{0}\t", array[m][j]);
            }

            Console.Write("\n");
        }
        public void printArray(List<List<int>> array)
        {
            int countRow = array.Count;

            if (countRow == 0)
                return;

            int countCol = array.Count;

            printString("Строк:", countRow.ToString());
            printString("Столбцов:", countCol.ToString(), "\n");

            string header = " \t";

            for (int j = 0; j < countCol; j++)
                header += $"[{j}]\t";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(header);

            for (int i = 0; i < countRow; i++)
                printStringArray(array, i);
        }
        public void MyPause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadLine();

            Console.ResetColor();
        }

        public void printFinalInformation(bool isOk, string textOk = WRITE_OK, string textError = WRITE_ERROR)
        {
            if (isOk)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(textOk);
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(textError);
        }

        public void printInfoAboutWorkDir(String defaultReadFile)
        {
            Console.ResetColor();
            Console.Write("Текущая рабочая директория: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            MySettings mySettings = new MySettings();
            Console.Write(mySettings.getDirFile() + "\n");

            Console.ResetColor();
            Console.Write("\nВведите имя файла с учетом регистра\n[файл по умолчанию ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(defaultReadFile);
            Console.ResetColor();
            Console.Write("]: ");
        }
    }
}
