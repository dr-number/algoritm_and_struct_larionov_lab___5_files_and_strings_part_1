using System.Text.RegularExpressions;

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
        public const string EXP = ".txt";

        public const string FILE_PART_1_TASK_6_1 = "Part_1_Task_6_1" + EXP;
        public const string FILE_PART_1_TASK_6_2 = "Part_1_Task_6_2" + EXP;

        public const string FILE_PART_1_TASK_16_1 = "Part_1_Task_16_1" + EXP;
        public const string FILE_PART_1_TASK_16_2 = "Part_1_Task_16_2" + EXP;


        public const string FILE_PART_2_TASK_6_1 = "Part_2_Task_6_1" + EXP;

        private
        static string DIR_FILE = Environment.CurrentDirectory;

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
            Console.Write(fileInfo.Length + " байт\n");

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
        
    }

    class MyInput
    {
        public
        string inputText(string title)
        {
            Console.WriteLine(title);
            return Console.ReadLine();
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

        public bool correctingFile(string defaultFile, Delegate methodForStr, string endSymbol)
        {
            MyFiles myFiles = new MyFiles();
            string path = myFiles.setReadFile(defaultFile);

            if(path == "")
                return false;

            bool result = false;
            StreamReader? file = null;

            try
            {
                file = new StreamReader(path);

                while (file.EndOfStream != true)
                    methodForStr.DynamicInvoke(file, file.ReadLine(), endSymbol);

                result = true;
            }
            catch (Exception e)
            {
                myFiles.printError();
                result = false;
            }
            finally
            {
                file?.Close();
            }

            return result;

        }
    }

    class MyPrint
    {
        public const string INITIAL_DATA = "Исходные данные: ";
        public const string FINAL_RESULT = "Конечный результат: ";
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

        public void MyPause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadLine();

            Console.ResetColor();
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

        private void printStringWithCount(string str, bool isNewLine)
        {
            string tmp = deleteFromStr(str, DEFAULT_DELIMITERS);
            tmp = Regex.Replace(tmp, @"\s+", " ").Trim(); // удаляем лишние пробелы (двойные, в начале и в конце)

            string[] array = tmp.Split(" ");

            if (array.Length == 1)
                return;

            int size = array.Length;
            Console.Write(str + ".");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($" ({size})");

            if (isNewLine)
                Console.Write("\n");

            Console.ResetColor();
        }
        private bool fun(StreamReader file, string str, string endSymbols)
        {
            char[] ends = endSymbols.ToCharArray();
            string[] partStr = str.Split(ends);

            bool isEndLine = partStr.Length < 1;

            foreach (var item in partStr)
                printStringWithCount(item, isEndLine);

            Console.Write("\n");

            return false;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_6_1);

            MyStrings myStrings = new MyStrings();
            myStrings.correctingFile(MyFiles.FILE_PART_2_TASK_6_1, new Func<StreamReader, string, string, bool>(fun), ".");
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