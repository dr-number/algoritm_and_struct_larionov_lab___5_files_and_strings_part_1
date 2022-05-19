namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MyInput
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
}
