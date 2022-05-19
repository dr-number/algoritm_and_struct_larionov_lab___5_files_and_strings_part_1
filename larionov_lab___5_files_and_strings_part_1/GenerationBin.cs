namespace larionov_lab___5_files_and_strings_part_1
{
    internal class GenerationBin
    {
        public const int MIN = -1000;
        public const int DEFAULT_MIN = -100;

        public const int MAX = 1000;
        public const int DEFAULT_MAX = 100;

        public const int PERIOD_PRINT = 25;

        public const int DEFAULT_COUNT_NUMBERS = 256;
        public const int MIN_COUNT_NUMBERS = 10;
        public const int MAX_COUNT_NUMBERS = 1024 * 6;

        private string createRandomBinFile(string defaultReadFile, int countNumbers, int min, int max)
        {

            MySettings mySettings = new MySettings();
            defaultReadFile = mySettings.getDirFile() + "\\" + defaultReadFile;

            MyPrint myPrint = new MyPrint();
            myPrint.printInfoAboutWorkDir(defaultReadFile);

            string fileName = Console.ReadLine();

            if (fileName == "")
                fileName = defaultReadFile;

            try
            {
                using (BinaryWriter bin = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    Random random = new Random();

                    for (int i = 0; i < countNumbers; i++)
                        bin.Write(random.Next(min, max));
                }

                return fileName;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message + "\n");
                Console.ResetColor();

                return "";
            }
        }

        public string createBin(string defaultReadFile)
        {

            MyFiles myFiles = new MyFiles();
            MyQuestion myQuestion = new MyQuestion();

            if (!myQuestion.isQuestion(MyQuestion.QUESTION_CREATE_RANDOM_NUMBER_BIN))
                return myFiles.setReadFile(defaultReadFile, MyFiles.EXP_BIN);

            Random random = new Random();
            MyInput myInput = new MyInput();

            int count = myInput.inputNumber($"Введите колличество элементов в файле [по умолчанию {DEFAULT_COUNT_NUMBERS}]: ", MIN_COUNT_NUMBERS, MAX_COUNT_NUMBERS, DEFAULT_COUNT_NUMBERS);
            int min = myInput.inputNumber($"Минимальный элемент (для случайной генерации) [по умолчанию случайная генерация]: ", 0, MIN, random.Next(MIN, 0));
            int max = myInput.inputNumber($"Максимальный элемент (для случайной генерации) [по умолчанию случайная генерация]: ", 0, MAX, random.Next(0, MAX));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nИсходные данные:");

            MyPrint myPrint = new MyPrint();
            myPrint.printString("Количество элементов:", count.ToString());
            myPrint.printString("Минимальный элемент:", min.ToString());
            myPrint.printString("Максимальный элемент:", max.ToString(), "\n");

            return createRandomBinFile(defaultReadFile, count, min, max);
        }
    }
}
