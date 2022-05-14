namespace larionov_lab___5_files_and_strings_part1
{
    class TasksInfo
    {
        public const string PART_1_TASK_6_1 = "Дана строка, содержащая дату в формате \"дд.мм.гггг\".\n" +
            "Проверить корректность этой даты и сформировать строку,\n" +
            "содержащую следующую по порядку дату.\n";

        public const string PART_1_TASK_6_2 = "Дана строка символов до точки.\n" +
            "Записать новую строку из слов заданной, содержащих букву \"М\".\n";

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
        
        private
        const string DEFAULT_READ_FILE = "data.txt";
        string DIR_FILE = Environment.CurrentDirectory;

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
            Console.WriteLine("Для завершения настройки введите \"0\": ");

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

        public string setReadFile()
        {
            string fileName = "";
            bool isExist = false;

            while (!isExist)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("* - если путь не будет указан программа будет искать файл в директории: \n" + DIR_FILE);
                Console.ResetColor();

                Console.WriteLine("Введите (путь) имя файла с учетом регистра (расширение не обязательно): ");
                fileName = Console.ReadLine();

                if (fileName == "")
                    fileName = DEFAULT_READ_FILE;

                isExist = File.Exists(fileName);

                if (!isExist)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Файла: {fileName} - не существует!");
                    Console.ResetColor();
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    
                    if(fileInfo.Length == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Файла: {fileName} - пуст!");
                        Console.ResetColor();

                        isExist = false;
                    }
                }
            }

            return fileName;
        }

        public void printFileInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }
        }

        public void printError(string message = MESSAGE_ERROR_PROCESSING_FILE)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
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
        data selectInputData()
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

                fileName = myFiles.setReadFile();

                if (fileName != "")
                {
                    result.select = SELECT_FILE;
                    result.fileName = fileName;
                    return result;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка чтения файла!");
                Console.ResetColor();

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

            for(int i = 0; i < size; ++i)
                if (str[i] - '0' >= 0 && str[i] - '0' <= 9)
                    result += str[i];

            return result;
        }
        public string getFirstString(string text)
        {
            SelectData selectData = new SelectData();
            MyFiles myFiles = new MyFiles();

            string inputString = "";
            SelectData.data inputData;

            bool isGo = true;

            while (true)
            {
                inputData = selectData.selectInputData();

                if (inputData.select == SelectData.SELECT_KEYBOARD)
                {
                    Console.WriteLine(text);
                    inputString = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        StreamReader file = new StreamReader(inputData.fileName);
                        inputString = file.ReadLine();
                        file.Close();
                    }
                    catch (Exception e)
                    {
                        myFiles.printError();
                    }
                }

                if(trim(inputString) == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Найденная строка пуста или содержит одни пробелы!");
                    Console.ResetColor();
                }
                else
                    return inputString;

            }
        }
    }

    class MyPrint
    {
        public const string INITIAL_DATA = "Исходные данные: ";
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
    }

    public class Part_2_Task_6_1
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
            string str = myStrings.getFirstString($"Введите дату в формате \"{FORMAT_DATE_TEXT}\": ");

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

    class Class1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ларионов Никита Юрьевич. гр. 110з\n");

            bool isGo = true;


            while (isGo)
            {
                Console.WriteLine("\nВведите номер задачи: ");

                Console.WriteLine("\n1) " + TasksInfo.PART_1_TASK_6_1 + "\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\ns) Настройка директории с исходными файлами\n" +
                    "(значение сохраняется только на текущий сеанс работы программы)\n\n");
                
                Console.ResetColor();
                Console.WriteLine("\nДля выхода введите \"0\": ");

                string selectStr = Console.ReadLine().ToLower();

                switch (selectStr)
                {
                    case "1":
                        Part_2_Task_6_1 task = new Part_2_Task_6_1();
                        task.init() ;
                        break;

                    case "s":
                        MyFiles myFiles = new MyFiles();
                        myFiles.setDidectoryFile();
                        break;

                    case "0":
                        isGo = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекорректные данные!");
                        Console.ResetColor();
                        break;

                }
            }

        }

    }

}