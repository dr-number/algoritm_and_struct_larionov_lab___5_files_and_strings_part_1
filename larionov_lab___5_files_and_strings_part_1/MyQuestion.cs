namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MyQuestion
    {
        public const string QUESTION_READ_FILE = "Прочитать данные из файла [y/n]? ";
        public const string QUESTION_SHOW_CALC = "Показывать ход вычислений [y/n]? ";

        public const string QUESTION_CREATE_RANDOM_NUMBER_BIN = "Создать бинарный файл со случайными числовыми данными [y/n]? ";
        public const string QUESTION_PRINT_FINAL_RESULT = "Вывести на экран конечный результат [y/n]? ";

        public bool isQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }

        public bool isReadDataUpSymbol(string symbol)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nПрочитать данные до первого символа \"{symbol}\" [y/n]?: ");
            Console.ResetColor();
            return Console.ReadLine()?.ToLower() != "n";
        }

        public bool isProbably(string option)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Возможно, имелось в виду: \"{option}\" [y/n]? ");
            return Console.ReadLine()?.ToLower() != "n";
        }

    }
}
