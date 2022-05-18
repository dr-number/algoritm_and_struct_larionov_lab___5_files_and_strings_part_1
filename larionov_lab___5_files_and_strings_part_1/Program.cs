using System.Text.RegularExpressions;
using System.Text;

namespace larionov_lab___5_files_and_strings_part1
{
    class TasksInfo
    {
        public const string PART_1_TASK_6_1 = "Дана строка, содержащая дату в формате \"дд.мм.гггг\".\n" +
            "Проверить корректность этой даты и сформировать строку,\n" +
            "содержащую следующую по порядку дату.\n";

        public const string PART_1_TASK_6_2 = "Дана строка символов до точки.\n" +
            "Записать новую строку из слов заданной, содержащих букву \"М\" (Кириллица).\n";

        public const string PART_1_TASK_16_1 = "Дана символьная строка. Удалить из нее все символы, не являющиеся буквами.\n";

        public const string PART_1_TASK_16_2 = "Дана строка символов.\n" +
            "Выделить и вывести слова, ограниченные пробелом или знаками препинания:\n" +
            "запятой, точкой, двоеточием, точкой с запятой.\n";



        public const string PART_2_TASK_6_1 = "Дан файл, содержащий некоторый текст.\n" +
            "Отредактировать файл: после каждой фразы в скобках указать число слов в ней.\n";

        public const string PART_2_TASK_6_2 = "В текстовом файле хранится квадратная вещественная матрица.\n" +
            "Заменить в ней элементы, лежащие на главной диагонали, значением последнего элемента матрицы.\n";

        public const string PART_2_TASK_6_3 = "Компоненты бинарного файла – целые числа.\n" +
        "Удалить из этого файла максимальное и минимальное числа.\n";



        public const string PART_2_TASK_16_1 = "Дан файл, содержащий некоторый текст.\n" +
            "Переписать в новый текстовый файл фразы-палиндромы\n" +
            "(фразы, читающиеся одинаково слева направо и справа налево).\n";

        public const string PART_2_TASK_16_2 = "В текстовом файле хранится таблица\n" +
            "с результатами сдачи сессии студентами одной группы.\n" +
            "У таблицы есть шапка следующего вида: фамилия, № зачетки, математика, физика, химия, черчение.\n" +
            "Добавить в таблицу графу со средним баллом студента за сессию.\n";

        public const string PART_2_TASK_16_3 = "Компоненты бинарного файла – целые числа.\n" +
            "Поменять местами первый компонент с последним, второй – с предпоследним и т.д.\n";
    }

    class MyQuestion
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

        public bool isProbably(string option)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Возможно, имелось в виду: \"{option}\" [y/n]? ");
            return Console.ReadLine()?.ToLower() != "n";
        }

    }

    class MyFiles
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
            string fileName = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("* - если путь не будет указан программа будет искать файл в директории: \n" + DIR_FILE + "\\");
            Console.ResetColor();

            Console.Write("\nВведите (путь и) имя файла с учетом регистра (расширение не обязательно) [файл по умолчанию ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(defaultReadFile);
            Console.ResetColor();
            Console.Write("]: ");

            fileName = Console.ReadLine();

            if (fileName == "")
                fileName = defaultReadFile;

            fileName = DIR_FILE + "\\" + fileName;

            if (!File.Exists(fileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файла: {fileName} - не существует!");
                Console.ResetColor();

                return "";
            }
            
            FileInfo fileInfo = new FileInfo(fileName);
                    
            if(fileInfo.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файла: {fileName} - пуст!");
                Console.ResetColor();

                return "";
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nОбрабатываемый файл: ");

            Console.ForegroundColor = ConsoleColor.Green;

            string file = DIR_FILE + "\\" + fileName;
            Console.WriteLine(file + "\n");

            Console.ResetColor();
            printFileInfo(file);

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
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public bool isReadDataFileUpSymbol(string symbol)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nПрочитать данные из файла до первого символа \"{symbol}\" [y/n]?: ");
            Console.ResetColor();
            return Console.ReadLine()?.ToLower() != "n";
        }

        public bool getText(string defaultReadFile, Delegate method, string param) //params object[] parameters)
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

            if(size == 0)
                return false;

            try
            {
                using (StreamWriter fWrite = new StreamWriter(pathOut, false, Encoding.UTF8))
                    for(int i = 0; i < size; i++)
                        fWrite.Write(array[i] + "\n");

                return true;
            } 
            catch (Exception e)
            {
                printError(e.Message);
                return false;
            }
        }

        public string createRandomBinFile(string defaultReadFile, int countNumbers, int min, int max, int periodPrint)
        {
            string fileName = "";

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("* - если путь не будет указан программа создаст бинарный файл в директории: \n" + DIR_FILE + "\\");
            Console.ResetColor();

            Console.Write("\nВведите (путь и) имя файла с учетом регистра (расширение не обязательно) [файл по умолчанию ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(defaultReadFile);
            Console.ResetColor();
            Console.Write("]: ");

            fileName = Console.ReadLine();

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


        public bool getBin(string path, Delegate method, int periodPrint)
        {

            bool isOk = true;
            string tmpFile = "";

            try
            {

                tmpFile = path + EXP_TMP;
                File.Move(path, tmpFile);

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    int i = 0;
                    bool isPrintNewString;

                    using (BinaryWriter fWriter = new BinaryWriter(fs))
                        using (BinaryReader fReader = new BinaryReader(fs))
                            while (fReader.BaseStream.Position != fReader.BaseStream.Length)
                            {

                            isPrintNewString = i % periodPrint == 0;

                                if ((int)method.DynamicInvoke(fWriter, fReader.ReadInt32(), isPrintNewString) == -1)
                                {
                                    isOk = false;
                                    break;
                                }

                                ++i;

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

    }

    class MyInput
    {
        public
        string inputText(string title)
        {
            Console.WriteLine(title);
            return Console.ReadLine();
        }

        public int inputNumber(string text, int min, int max, int defaultValue)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.Write(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (xStr == "")
                    return defaultValue;

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else if (x < min || x > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число в промежутке от {min} до {max} включительно!\n");
                }
                else
                    break;
            }

            return x;
        }
    }

    class SelectData
    {
        public const bool SELECT_FILE = false;
        public const bool SELECT_KEYBOARD = true;
        public struct data
        {
            public bool select;
            public string fileName;
        }

        public
        data selectInputData(string defaultReadFile)
        {
            string fileName;
            data result;

            MyQuestion myQuestion = new MyQuestion();
            MyFiles myFiles = new MyFiles();

            while (true)
            {
                if (!myQuestion.isQuestion(MyQuestion.QUESTION_READ_FILE))
                {
                    result.select = SELECT_KEYBOARD;
                    result.fileName = "";
                    return result;
                }

                fileName = myFiles.setReadFile(defaultReadFile);

                if (fileName != "")
                {
                    result.select = SELECT_FILE;
                    result.fileName = fileName;
                    return result;
                }

            }

            return result;
        }
    }

    class MyStrings
    {
        public string trim(string str)
        {
            return str.Replace(" ", "");
        }

        public string getOnlyDigit(string str)
        {
            int size = str.Length;
            string result = "";

            for (int i = 0; i < size; ++i)
                if (str[i] - '0' >= 0 && str[i] - '0' <= 9)
                    result += str[i];

            return result;
        }
        public string getFirstString(string text, string defaultReadFile, string endSymbol)
        {
            SelectData selectData = new SelectData();
            MyFiles myFiles = new MyFiles();

            string inputString = "";
            SelectData.data inputData;

            bool isGo = true;

            while (true)
            {
                inputData = selectData.selectInputData(defaultReadFile);

                if (inputData.select == SelectData.SELECT_KEYBOARD)
                {
                    Console.WriteLine(text);
                    inputString = Console.ReadLine();
                }
                else
                {
                    StreamReader? file = null;

                    try
                    {
                        file = new StreamReader(inputData.fileName);
                        inputString = file.ReadLine();
                    }
                    catch (Exception e)
                    {
                        myFiles.printError();
                    }
                    finally
                    {
                        file?.Close();
                    }
                }

                if (endSymbol != "")
                {
                    if (myFiles.isReadDataFileUpSymbol(endSymbol))
                    {
                        int index = inputString.IndexOf(endSymbol);

                        if (index != -1)
                            inputString = inputString.Substring(0, index);
                    }
                }

                if (trim(inputString) == "")
                    myFiles.printError("Найденная строка пуста или содержит одни пробелы!");
                else
                    return inputString;

            }
        }
    }

    class MyPrint
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

            if(subData != "")
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
                if(j == m)
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
    }

    class Generation
    {
        public const int MIN = -1000;
        public const int DEFAULT_MIN = -100;

        public const int MAX = 1000;
        public const int DEFAULT_MAX = 100;

        public const int PERIOD_PRINT = 25;

        public const int DEFAULT_COUNT_NUMBERS = 1024;
        public const int MIN_COUNT_NUMBERS = 512;
        public const int MAX_COUNT_NUMBERS = 1024 * 6;

        public string createBin(string defaultReadFile)
        {
            string resultPath = "";

            MyFiles myFiles = new MyFiles();
            MyQuestion myQuestion = new MyQuestion();

            if (!myQuestion.isQuestion(MyQuestion.QUESTION_CREATE_RANDOM_NUMBER_BIN))
                return myFiles.setReadFile(defaultReadFile);
            
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

            return myFiles.createRandomBinFile(defaultReadFile, count, min, max, PERIOD_PRINT);
        }
    }



    public class Part_1_Task_6_1
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

    public class Part_1_Task_6_2
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

            if(isReg)
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

    public class Part_1_Task_16_1
    {
        private string deleteDoubleSpace(string str)
        {
            return Regex.Replace(str, @"\s+", " ");
        }

        private string correctingStr(string str, bool isSaveSpace)
        {
            if(isSaveSpace)
                return deleteDoubleSpace(new String(str.Where(c => Char.IsLetter(c) || Char.IsWhiteSpace(c)).ToArray()));

            return new String(str.Where(Char.IsLetter).ToArray());
        }
        public void init()
        {
            Console.WriteLine(TasksInfo.PART_1_TASK_16_1);

            MyStrings myStrings = new MyStrings();
            string str = myStrings.getFirstString("Введите строку: ", MyFiles.FILE_PART_1_TASK_16_1, ".");

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\n" + MyPrint.INITIAL_DATA, str, "\n");

            MyQuestion myQuestion = new MyQuestion();
            bool isSaveSpace = myQuestion.isQuestion("Оставить пробелы в строке? [y/n]: ");


            myPrint.printString("\n" + MyPrint.FINAL_RESULT, correctingStr(str, isSaveSpace), "\n");
        }
    }

    public class Part_1_Task_16_2 {

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
            
            if(myQuestion.isQuestion("Добавить другие разделители? [y/n]: "))
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


    public class Part_2_Task_6_1
    {
        private const string DEFAULT_ENDS = ".!?";
        private const string DEFAULT_DELIMITERS = ",-:;";

        private string deleteFromStr(string str, string deleteSymbols)
        {
            return String.Join("", str.Split(deleteSymbols.ToCharArray()));
        }

        private void writeStringWithCount(StreamWriter file, string str, bool isNewLine)
        {

            string tmp = deleteFromStr(str, DEFAULT_DELIMITERS);
            tmp = Regex.Replace(tmp, @"\s+", " ").Trim(); // удаляем лишние пробелы (двойные, в начале и в конце)

            string[] array = tmp.Split(" ");

            if (array.Length == 1)
            {
                file.Write("\r\n");
                return;
            }

            int size = array.Length;
            string sizeStr = " (" + size + ")";

            Console.Write(str + ".");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(sizeStr);

            if (isNewLine)
                Console.Write("\n");

            Console.ResetColor();

            file.Write(str + "." + sizeStr);
        }

        private int getCountWords(StreamWriter file, string str, string endSymbols)
        {
            char[] ends = endSymbols.ToCharArray();
            string[] partStr = str.Split(ends);

            int size = partStr.Length;

            bool isEndLine = size < 1;

            foreach (var item in partStr)
                writeStringWithCount(file, item, isEndLine);

            Console.Write("\n");

            return size;
        }

        public void init()
        {
            const string DEFAULT_END_SYMBOL = ".";

            Console.WriteLine(TasksInfo.PART_2_TASK_6_1);
            
            MyFiles myFiles = new MyFiles();
            myFiles.getText(MyFiles.FILE_PART_2_TASK_6_1, new Func<StreamWriter, string, string, int>(getCountWords), DEFAULT_END_SYMBOL);
        }
    }

    public class Part_2_Task_6_2
    {

        private const string DEFAULT_SEPARATOR = " ";
        private string separator = DEFAULT_SEPARATOR;

        private MyMatrixData matrix;

        public struct MyMatrixData
        {
            public List<List<int>> data;
            public int size;
            public bool isCorrect;
        };

        private int readMatrix(StreamWriter file, string str, string endSymbols)
        {
            string[] array = str.Split(separator);
            int countCol = array.Length;

            if (matrix.data == null)
            {
                matrix.data = new List<List<int>>();
                matrix.size = countCol;
            }
            else if (matrix.size != countCol)
            {
                matrix.isCorrect = false;
                return -1;
            }

            List<int> row = new List<int>();

            int num;
            for (int j = 0; j < countCol; ++j) {

                try
                {
                    int.TryParse(array[j], out num);
                    row.Add(num);
                }
                catch {
                    matrix.isCorrect = false;
                    return -1;
                }
            }

            matrix.data.Add(row);

            matrix.isCorrect = true;
            return 1;
        }

        private void changeMainDiagonal(int size, int lastElement)
        {
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    if (i == j)
                    {
                        matrix.data[i][j] = lastElement;
                        break;
                    }
        }

        private string matrixToStr(int size)
        {
            String result = "";

            for(int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    result += matrix.data[i][j];

                    if(j != size - 1)
                        result += separator;
                }

                if (i != size - 1)
                    result += "\n";
            }


            return result;
        }
    

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_6_2);

            const string ORIGINAL_FILE = MyFiles.FILE_PART_2_TASK_6_2;
            const string TMP_FILE = ORIGINAL_FILE + MyFiles.EXP_TMP;

            MyFiles myFiles = new MyFiles();
            bool isResult = myFiles.getText(ORIGINAL_FILE, new Func<StreamWriter, string, string, int>(readMatrix), "");

            if (!isResult)
            {
                myFiles.printError("Ошибка чтения матрицы либо матрица не корректна!");
                return;
            }

            if (matrix.data == null)
            {
                myFiles.printError("Матрица не корректна!");
                return;
            }

            if (matrix.isCorrect == null || !matrix.isCorrect)
            {
                myFiles.printError("Матрица не корректна!");
                return;
            }

            int size = matrix.data.Count;

            if (size == 0)
            {
                myFiles.printError("Матрица пуста!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nИсходная матрица:");

            MyPrint myPrint = new MyPrint();
            myPrint.printArray(matrix.data);

            int lastElement = matrix.data[size - 1][size - 1];

            myPrint.printString("\nПоследний элемент матрицы:", lastElement.ToString());

            changeMainDiagonal(size, lastElement);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nизмененная матрица:");

            myPrint.printArray(matrix.data);

            string write = matrixToStr(size);

            bool isOk = myFiles.writeStrings(MyFiles.FILE_PART_2_TASK_6_2, matrixToStr(size));
            myPrint.printFinalInformation(isOk);

            if(!isOk)
                myFiles.recoverOriginalFile(ORIGINAL_FILE, TMP_FILE);
        }
    }

    public class Part_2_Task_6_3
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

                        if(item < min)
                            min = item;

                        if(item > max)
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

                        if(i % periodPrint == 0)
                            Console.Write("\n");
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

        private void printInfoBin(string file, int min, int countMin, int max, int countMax)
        {
            Console.WriteLine("\n");

            MyFiles myFiles = new MyFiles();
            myFiles.printFileInfo(file);

            MyPrint myPrint = new MyPrint();
            myPrint.printFinalInformation(true);

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
            const string TMP_FILE = DEFAULT_FILE + MyFiles.EXP_TMP;

            Generation generation = new Generation();
            string originalFile = generation.createBin(DEFAULT_FILE);

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
            bool isOk = myFiles.getBin(originalFile, new Func<BinaryWriter, int, bool, int>(deleteMinMaxFormBin), Generation.PERIOD_PRINT);

            if (!countMinMax.isCorrect)
            {
                myFiles.printError("Ошибка сканирования бинарного файла!");
                return;
            }

            if (!isOk) {
                myFiles.printError("Ошибка изменения бинарного файла!");
                return;
            }

            printInfoBin(originalFile, interval.min, countMinMax.countMin, interval.max, countMinMax.countMax);

           
            MyQuestion myQuestion = new MyQuestion();
            if (!myQuestion.isQuestion(MyQuestion.QUESTION_PRINT_FINAL_RESULT))
                return;

            interval = scanBin(originalFile);

            if (!interval.isCorrect)
            {
                myFiles.printError("Ошибка повторного сканирования бинарного файла!");
                return;
            }

            CountMinMax finalCount = printBin(originalFile, interval, Generation.PERIOD_PRINT);

            if (!finalCount.isCorrect)
            {
                myFiles.printError("Ошибка чтения измененного бинарного файла!");
                return;
            }

            printInfoBin(originalFile, interval.min, finalCount.countMin, interval.max, finalCount.countMax);
        }
    }



    public class Part_2_Task_16_1
    {
        List<string> result = new List<string>();
        int countAllPhrases = 0;

        public string Filter(string str)
        {
            Regex reg = new Regex("[^a-яА-яa-zA-Z1-9]");
            return reg.Replace(str, "");
        }

        private bool isPalindrom(string str)
        {
            str = Filter(str).ToLower();

            if (str == "")
                return false;

            int size = str.Length;
            int half = size / 2;

            for(int i = 0; i < half; ++i)
                if(str[i] != str[size - 1 - i])
                    return false;

            return true;
        }

        private int scanPalindrom(StreamWriter file, string str, string endSymbols)
        {
       
            string[] array = str.Split(".");
            string word;

            foreach (string item in array)
            {
                if (item == "")
                    continue;

                ++countAllPhrases;
                word = item.Trim() + ".";

                if (isPalindrom(item))
                {
                    result.Add(word);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(word);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(word);
                }
            }

            return 1;
        }

        string arrayToWrite()
        {
            string writeStr = "";

            foreach (string item in result)
                writeStr += item + "\n";
            
            return writeStr;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_16_1);

            const string ORIGINAL_FILE = MyFiles.FILE_PART_2_TASK_16_1;
            const string TMP_FILE = ORIGINAL_FILE + MyFiles.EXP_TMP;

            MyFiles myFiles = new MyFiles();
            bool isResult = myFiles.getText(ORIGINAL_FILE, new Func<StreamWriter, string, string, int>(scanPalindrom), "");

            if (!isResult)
            {
                myFiles.printError("Ошибка чтения текстового файла!");
                return;
            }

            int count = result.Count;

            if(count == 0)
            {
                myFiles.printError("Фраз-палиндромов не обнаружено!");
                return;
            }

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\nОбщее количество фраз:", countAllPhrases.ToString());
            myPrint.printString("Общее количество простых фраз:", (countAllPhrases - count).ToString());

            myPrint.printString("\nКоличество фраз-полинтропов:", count.ToString(), "\n");


            bool isOk = myFiles.writeStrings(ORIGINAL_FILE, arrayToWrite());
            myPrint.printFinalInformation(isOk);

            if (!isOk)
                myFiles.recoverOriginalFile(ORIGINAL_FILE, TMP_FILE);

        }
    }

    public class Part_2_Task_16_2
    {
        private int count = 0;
        const string TITLE_GPA = "Cредний балл";

        public string Filter(string str)
        {
            Regex reg = new Regex("[^1-9|]");
            str = reg.Replace(str, "");

            if(str != "")
                str.Remove(str.Length - 1);

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

            if(divider == 0)
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

    class Class1
    {
        static void Main(string[] args)
        {
            MyPrint myPrint = new MyPrint();

            Console.WriteLine("Ларионов Никита Юрьевич. гр. 110з\n");

            bool isGo = true;

            while (isGo)
            {
                Console.WriteLine("\nВведите номер задачи: ");

                Console.WriteLine("\n1) " + TasksInfo.PART_1_TASK_6_1);
                Console.WriteLine("\n2) " + TasksInfo.PART_1_TASK_6_2);

                Console.WriteLine("\n3) " + TasksInfo.PART_1_TASK_16_1);
                Console.WriteLine("\n4) " + TasksInfo.PART_1_TASK_16_2);

                Console.WriteLine("\n5) " + TasksInfo.PART_2_TASK_6_1);
                Console.WriteLine("\n6) " + TasksInfo.PART_2_TASK_6_2);
                Console.WriteLine("\n7) " + TasksInfo.PART_2_TASK_6_3);


                Console.WriteLine("\n8) " + TasksInfo.PART_2_TASK_16_1);
                Console.WriteLine("\n9) " + TasksInfo.PART_2_TASK_16_2);


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\ns) Настройка директории с исходными файлами\n" +
                    "(значение сохраняется только на текущий сеанс работы программы)\n");
                
                Console.ResetColor();
                Console.Write("\nДля выхода введите \"0\": ");

                string selectStr = Console.ReadLine().ToLower();

                if (selectStr == "1") {
                    Part_1_Task_6_1 task = new Part_1_Task_6_1();
                    task.init();
                }
                else if (selectStr == "2")
                {
                    Part_1_Task_6_2 task = new Part_1_Task_6_2();
                    task.init();
                }
                else if (selectStr == "3") {
                    Part_1_Task_16_1 task = new Part_1_Task_16_1();
                    task.init();
                }
                else if (selectStr == "4")
                {
                    Part_1_Task_16_2 task = new Part_1_Task_16_2();
                    task.init();
                }
                else if (selectStr == "5")
                {
                    Part_2_Task_6_1 task = new Part_2_Task_6_1();
                    task.init();
                }
                else if (selectStr == "6")
                {
                    Part_2_Task_6_2 task = new Part_2_Task_6_2();
                    task.init();
                }
                else if (selectStr == "7")
                {
                    Part_2_Task_6_3 task = new Part_2_Task_6_3();
                    task.init();
                }
                else if (selectStr == "8")
                {
                    Part_2_Task_16_1 task = new Part_2_Task_16_1();
                    task.init();
                }
                else if (selectStr == "9")
                {
                    Part_2_Task_16_2 task = new Part_2_Task_16_2();
                    task.init();
                }
                else if (selectStr == "s") {
                    MyFiles myFiles = new MyFiles();
                    myFiles.setDidectoryFile();
                }
                else if (selectStr == "0")
                {
                    isGo = false;
                }
                else { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nНекорректные данные!");
                    Console.ResetColor();
                }

                myPrint.MyPause();
            }

        }

    }

}