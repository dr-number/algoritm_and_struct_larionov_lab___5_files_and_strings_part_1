using System.Text;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MyFiles
    {
        public const string EXP_TMP = ".tmp";
        public const string EXP = ".txt";
        public const string EXP_BIN = ".lar_110z";

        public const string FILE_PART_1_TASK_6_1 = "Part_1_Task_6_1" + EXP;
        public const string FILE_PART_1_TASK_6_2 = "Part_1_Task_6_2" + EXP;

        public const string FILE_PART_1_TASK_16_1 = "Part_1_Task_16_1" + EXP;
        public const string FILE_PART_1_TASK_16_2 = "Part_1_Task_16_2" + EXP;


        public const string FILE_PART_2_TASK_6_1 = "Part_2_Task_6_1" + EXP;
        public const string FILE_PART_2_TASK_6_2 = "Part_2_Task_6_2" + EXP;
        public const string FILE_PART_2_TASK_6_3 = "Part_2_Task_6_3" + EXP_BIN;


        public const string FILE_PART_2_TASK_16_1 = "Part_2_Task_16_1" + EXP;
        public const string FILE_PART_2_TASK_16_2 = "Part_2_Task_16_2" + EXP;
        public const string FILE_PART_2_TASK_16_3 = "Part_2_Task_16_3" + EXP_BIN;


        public static string DIR_FILE = Environment.CurrentDirectory;

        public const string MESSAGE_ERROR_PROCESSING_FILE = "Ошибка обработки файла!";

        public void setDidectoryFile()
        {
            string result = DIR_FILE;
            bool isGo = true;

            Console.WriteLine("\nТекущие параметры папки:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(DIR_FILE);
            Console.ResetColor();

            Console.WriteLine("\nВведите директорию в которой лежат файлы с данными ");
            Console.Write("Для завершения настройки введите \"0\": ");

            while (isGo)
            {
                result = Console.ReadLine();

                if (result != "0")
                {
                    if (!Directory.Exists(result))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Папка: {result} - не существует!");
                    }
                    else
                    {
                        DIR_FILE = result;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Папка успешно изменена!");
                        isGo = false;
                    }

                    Console.ResetColor();
                }
                else
                    isGo = false;
            }
        }

        public string setReadFile(string defaultReadFile)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("* - если путь не будет указан программа будет искать файл в директории: \n" + DIR_FILE + "\\");
            Console.ResetColor();

            Console.Write("\nВведите (путь и) имя файла с учетом регистра (расширение не обязательно) [файл по умолчанию ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(defaultReadFile);
            Console.ResetColor();
            Console.Write("]: ");

            string fileName = Console.ReadLine();

            if (fileName == "")
                fileName = defaultReadFile;

            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файла: {fileName} - не существует!");
                Console.ResetColor();

                return "";
            }

            FileInfo fileInfo = new FileInfo(fileName);

            if (fileInfo.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файла: {fileName} - пуст!");
                Console.ResetColor();

                return "";
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nОбрабатываемый файл: ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(fileName + "\n");

            Console.ResetColor();
            printFileInfo(fileName);

            return fileName;
        }

        public void printFileInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);

            if (!fileInfo.Exists)
                return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Имя файла: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(fileInfo.Name + "\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Время создания: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(fileInfo.CreationTime + "\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Размер: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(fileInfo.Length + " байт\n\n");

            Console.ResetColor();
        }

        public void printError(string message = MESSAGE_ERROR_PROCESSING_FILE)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }

        public bool isReadDataFileUpSymbol(string symbol)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nПрочитать данные из файла до первого символа \"{symbol}\" [y/n]?: ");
            Console.ResetColor();
            return Console.ReadLine()?.ToLower() != "n";
        }

        public bool getText(string defaultReadFile, Delegate method, string param)
        {

            string path = setReadFile(DIR_FILE + "\\" + defaultReadFile);

            if (path == "")
                return false;

            bool isOk = true;
            string line = "", tmpFile = "";

            try
            {

                tmpFile = path + EXP_TMP;
                File.Move(path, tmpFile);

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {

                    using (StreamWriter fWriter = new StreamWriter(fs))
                    using (StreamReader fReader = new StreamReader(tmpFile))
                        while (!fReader.EndOfStream)
                        {
                            line = fReader.ReadLine();

                            if ((int)method.DynamicInvoke(fWriter, line, param) == -1)
                            {
                                isOk = false;
                                break;
                            }

                        }

                }

                if (isOk)
                {
                    File.Delete(tmpFile);
                    return true;
                }

            }
            catch (Exception e)
            {
                printError(e.Message);
                isOk = false;
            }

            if (!isOk)
                recoverOriginalFile(path, tmpFile);

            return isOk;

        }

        public void recoverOriginalFile(string pathOriginal, string pathTmp)
        {
            File.Move(pathTmp, pathTmp + EXP_TMP);
            File.Delete(pathOriginal);
            File.Move(pathTmp + EXP_TMP, pathOriginal);
        }

        public bool writeStrings(string pathOut, string strings)
        {
            string[] array = strings.Split("\n");
            int size = array.Length;

            if (size == 0)
                return false;

            try
            {
                using (StreamWriter fWrite = new StreamWriter(pathOut, false, Encoding.UTF8))
                    for (int i = 0; i < size; i++)
                        fWrite.Write(array[i] + "\n");

                return true;
            }
            catch (Exception e)
            {
                printError(e.Message);
                return false;
            }
        }

        public string createRandomBinFile(string defaultReadFile, int countNumbers, int min, int max)
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("* - если путь не будет указан программа создаст бинарный файл в директории: \n" + DIR_FILE + "\\");
            Console.ResetColor();

            Console.Write("\nВведите (путь и) имя файла с учетом регистра (расширение не обязательно) [файл по умолчанию ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(defaultReadFile);
            Console.ResetColor();
            Console.Write("]: ");

            string fileName = Console.ReadLine();

            if (fileName == "")
                fileName = defaultReadFile;

            fileName = DIR_FILE + "\\" + fileName;

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
                printError(e.Message + "\n");
                return "";
            }
        }


        public bool getBin(string path, Delegate method, int periodPrint, bool isReadFromEnd = false)
        {

            bool isOk = true;
            string tmpFile = "";

            try
            {
                tmpFile = path + EXP_TMP;
                File.Move(path, tmpFile);

                Stream read = File.OpenRead(tmpFile);

                if (read == null)
                    return false;

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter fWriter = new BinaryWriter(fs))
                    using (BinaryReader fReader = new BinaryReader(read))
                    {
                        long setSeek;
                        bool isPrintNewString;


                        int i = 0;
                        long size = fReader.BaseStream.Length;

                        while (true)
                        {
                            if (isReadFromEnd)
                            {
                                setSeek = size - (i + 1) * sizeof(int);

                                if (setSeek < 0)
                                    break;

                                fReader.BaseStream.Seek(setSeek, SeekOrigin.Begin);
                            }
                            else if (fReader.BaseStream.Position == size)
                                break;

                            isPrintNewString = i != 0 && i % periodPrint == 0;

                            if ((int)method.DynamicInvoke(fWriter, fReader.ReadInt32(), isPrintNewString) == -1)
                            {
                                isOk = false;
                                break;
                            }

                            ++i;

                        }
                    }

                }

                if (isOk)
                {
                    File.Delete(tmpFile); //ok
                    return true;
                }

            }
            catch (Exception e)
            {
                printError(e.Message);
                isOk = false;
            }

            if (!isOk)
                recoverOriginalFile(path, tmpFile);

            return isOk;

        }

    }
}
