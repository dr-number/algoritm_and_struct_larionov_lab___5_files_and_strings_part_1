using System.Text.RegularExpressions;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_6_1
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
}
