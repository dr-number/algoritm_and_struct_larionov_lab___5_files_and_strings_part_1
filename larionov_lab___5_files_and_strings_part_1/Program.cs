using larionov_lab___5_files_and_strings_part_1;

namespace larionov_lab___5_files_and_strings_part1
{
    class Class1
    {
        static void Main(string[] args)
        {
            MySettings mySettings = new MySettings();
            mySettings.initConfig();

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
                Console.WriteLine("\n10) " + TasksInfo.PART_2_TASK_16_3);


                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\ns) Настройка директории с исходными файлами\n");
                
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
                else if (selectStr == "10")
                {
                    Part_2_Task_16_3 task = new Part_2_Task_16_3();
                    task.init();
                }
                else if (selectStr == "s") {
                    mySettings.setDidectoryFile();
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