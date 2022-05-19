namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_6_3
    {
        private CountMinMax countMinMax;
        private MinMax interval;
        private struct MinMax
        {
            public int min;
            public int max;
            public bool isCorrect;
        }

        private struct CountMinMax
        {
            public int countMin;
            public int countMax;
            public bool isCorrect;
        }

        private MinMax scanBin(string pathFile)
        {
            MinMax result;

            try
            {
                using (BinaryReader bin = new BinaryReader(File.Open(pathFile, FileMode.Open)))
                {
                    int item;
                    int min = int.MaxValue;
                    int max = int.MinValue;

                    while (bin.BaseStream.Position != bin.BaseStream.Length)
                    {
                        item = bin.ReadInt32();

                        if (item < min)
                            min = item;

                        if (item > max)
                            max = item;
                    }

                    result.min = min;
                    result.max = max;
                    result.isCorrect = true;
                }
            }
            catch (Exception e)
            {
                MyFiles myFiles = new MyFiles();
                myFiles.printError(e.Message);

                result.isCorrect = false;
                result.min = 0;
                result.max = 0;
            }

            return result;
        }

        private int deleteMinMaxFormBin(BinaryWriter fWriter, int read, bool isPrintNewString)
        {
            if (!interval.isCorrect)
                return -1;

            try
            {

                if (read == interval.min)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    ++countMinMax.countMin;
                }
                else if (read == interval.max)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    ++countMinMax.countMax;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    fWriter.Write(read);
                }

                Console.Write(read + " ");

                if (isPrintNewString)
                    Console.Write("\n");

                countMinMax.isCorrect = true;

                return 1;
            }
            catch (Exception e)
            {
                MyFiles myFiles = new MyFiles();
                myFiles.printError(e.Message);
            }

            countMinMax.isCorrect = false;
            return -1;
        }

        private CountMinMax printBin(string pathFile, MinMax interval, int periodPrint)
        {
            CountMinMax result;
            result.countMin = 0;
            result.countMax = 0;
            result.isCorrect = false;

            if (!interval.isCorrect)
                return result;

            try
            {

                using (BinaryReader bin = new BinaryReader(File.Open(pathFile, FileMode.Open)))
                {
                    int i = 0, item;
                    int min = interval.min;
                    int max = interval.max;

                    while (bin.BaseStream.Position != bin.BaseStream.Length)
                    {
                        item = bin.ReadInt32();

                        if (item == min)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            ++result.countMin;
                        }
                        else if (item == max)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            ++result.countMax;
                        }
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(item + " ");

                        if (i != 0 && i % periodPrint == 0)
                            Console.Write("\n");

                        ++i;
                    }
                }

                result.isCorrect = true;
                return result;
            }
            catch (Exception e)
            {
                MyFiles myFiles = new MyFiles();
                myFiles.printError(e.Message);
            }

            result.isCorrect = false;
            return result;
        }

        private void printInfoBin(int min, int countMin, int max, int countMax)
        {
            Console.ResetColor();

            Console.Write("\n\nМинимальный элемент бинарного файла: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(min + " [" + countMin + " элемент(ов)]");

            Console.ResetColor();

            Console.Write("Максимальный элемент бинарного файла: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(max + " [" + countMax + " элемент(ов)]");
        }
        public void init()
        {
            countMinMax.countMin = 0;
            countMinMax.countMax = 0;
            countMinMax.isCorrect = false;

            Console.WriteLine(TasksInfo.PART_2_TASK_6_3);

            const string DEFAULT_FILE = MyFiles.FILE_PART_2_TASK_6_3;

            GenerationBin generationBin = new GenerationBin();
            string originalFile = generationBin.createBin(DEFAULT_FILE);

            if (originalFile == "")
                return;

            interval = scanBin(originalFile);

            MyFiles myFiles = new MyFiles();

            if (!interval.isCorrect)
            {
                myFiles.printError("Ошибка сканирования бинарного файла!");
                return;
            }

            Console.WriteLine("\n");
            myFiles.printFileInfo(originalFile);

            bool isOk = myFiles.getBin(originalFile, new Func<BinaryWriter, int, bool, int>(deleteMinMaxFormBin), GenerationBin.PERIOD_PRINT);

            if (!isOk || !countMinMax.isCorrect)
            {
                myFiles.printError("Ошибка изменения бинарного файла!");
                return;
            }

            MyPrint myPrint = new MyPrint();
            myPrint.printFinalInformation(true);

            printInfoBin(interval.min, countMinMax.countMin, interval.max, countMinMax.countMax);


            MyQuestion myQuestion = new MyQuestion();

            Console.ResetColor();
            if (!myQuestion.isQuestion(MyQuestion.QUESTION_PRINT_FINAL_RESULT))
                return;

            interval = scanBin(originalFile);

            if (!interval.isCorrect)
            {
                myFiles.printError("Ошибка повторного сканирования бинарного файла!");
                return;
            }

            CountMinMax finalCount = printBin(originalFile, interval, GenerationBin.PERIOD_PRINT);

            if (!finalCount.isCorrect)
            {
                myFiles.printError("Ошибка чтения измененного бинарного файла!");
                return;
            }

            Console.WriteLine("\n\n");
            myFiles.printFileInfo(originalFile);
            printInfoBin(interval.min, finalCount.countMin, interval.max, finalCount.countMax);
        }
    }
}
