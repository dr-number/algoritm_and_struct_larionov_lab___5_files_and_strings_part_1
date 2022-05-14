namespace larionov_lab___5_files_and_strings_part1
{
    class TasksInfo
    {
        public const string PART_1_TASK_6_1 = "Дана строка, содержащая дату в формате \"дд.мм.гггг\".\n" +
            "Проверить корректность этой даты и сформировать строку,\n" +
            "содержащую следующую по порядку дату.\n\n\n";

        public const string PART_1_TASK_6_2 = "Дана строка символов до точки.\n" +
            "Записать новую строку из слов заданной, содержащих букву \"М\".\n\n\n";

        public const string PART_1_TASK_16_1 = "Дана символьная строка. Удалить из нее все символы, не являющиеся буквами.\n\n\n";

        public const string PART_1_TASK_16_2 = "Дана строка символов.\n" +
            "Выделить и вывести слова, ограниченные пробелом или знаками препинания:\n" +
            "запятой, точкой, двоеточием, точкой с запятой.\n\n\n";



        public const string PART_2_TASK_6_1 = "Дан файл, содержащий некоторый текст.\n" +
            "Отредактировать файл: после каждой фразы в скобках указать число слов в ней.\n\n\n";

        public const string PART_2_TASK_6_2 = "В текстовом файле хранится квадратная вещественная матрица.\n" +
            "Заменить в ней элементы, лежащие на главной диагонали, значением последнего элемента матрицы.\n\n\n";

        public const string PART_2_TASK_6_3 = "Компоненты бинарного файла – целые числа.\n" +
        "Удалить из этого файла максимальное и минимальное числа.\n\n\n";



        public const string PART_2_TASK_16_1 = "Дан файл, содержащий некоторый текст.\n" +
            "Переписать в новый текстовый файл фразы-палиндромы\n" +
            "(фразы, читающиеся одинаково слева направо и справа налево).\n\n\n";

        public const string PART_2_TASK_16_2 = "В текстовом файле хранится таблица\n" +
            "с результатами сдачи сессии студентами одной группы.\n" +
            "У таблицы есть шапка следующего вида: фамилия, № зачетки, математика, физика, химия, черчение.\n" +
            "Добавить в таблицу графу со средним баллом студента за сессию.\n\n\n";

        public const string PART_2_TASK_16_3 = "Компоненты бинарного файла – целые числа.\n" +
            "Поменять местами первый компонент с последним, второй – с предпоследним и т.д.\n\n\n";
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
    }

    class MyFiles
    {
        const string DEFAULT_READ_FILE = "data.txt";
        
        bool setReadFile()
        {
            bool isExist = false;

            while (!isExist)
            {
                Console.WriteLine("Введите имя файла с учетом регистра (расширение не обязательно): ");

                string fileName = Console.ReadLine();

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

            return isExist;
        }

        void printFileInfo(string fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length}");
            }
        }
    }


    public class Part_2_Task_6_1
    {

        public void init()
        {

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

                Console.WriteLine("\n1) " + TasksInfo.PART_1_TASK_6_1);

                Console.WriteLine("\nДля выхода введите \"0\": ");

                string selectStr = Console.ReadLine();

                switch (selectStr)
                {
                    case "1":
                        Part_2_Task_6_1 task = new Part_2_Task_6_1();
                        task.init() ;
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