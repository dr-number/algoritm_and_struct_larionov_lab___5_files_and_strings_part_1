using System.Text.RegularExpressions;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_1_Task_16_1
    {
        private string deleteDoubleSpace(string str)
        {
            return Regex.Replace(str, @"\s+", " ");
        }

        private string correctingStr(string str, bool isSaveSpace)
        {
            if (isSaveSpace)
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
}
