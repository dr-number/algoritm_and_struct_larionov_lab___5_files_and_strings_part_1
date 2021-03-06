using System.Text.RegularExpressions;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_16_1
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

            for (int i = 0; i < half; ++i)
                if (str[i] != str[size - 1 - i])
                    return false;

            return true;
        }

        private int scanPalindrom(string str, string endSymbols)
        {

            string[] array = str.Split(endSymbols);
            string word;

            foreach (string item in array)
            {
                if (item == "")
                    continue;

                ++countAllPhrases;
                word = item.Trim() + endSymbols;

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
            int size = result.Count;

            for (int i = 0; i < size; ++i)
            {
                if(result[i] != "")
                    writeStr += result[i];

                if (i != size)
                    writeStr += "\n";

            }

            return writeStr;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_16_1);

            MyFiles myFiles = new MyFiles();
            MyFiles.PathsForTask paths = myFiles.getPathsForTask(MyFiles.FILE_PART_2_TASK_16_1);

            string fileOut = myFiles.setFileForOut(paths.outFile);

            if (fileOut == "")
            {
                myFiles.printError(MyFiles.MESSAGE_ERROR_CREATE_FILE);
                return;
            }

            string path = myFiles.getTextReadOnly(paths.originalFile, new Func<string, string, int>(scanPalindrom), ".");
            paths.originalFile = path;

            bool isResult = path != "";

            if (!isResult)
            {
                myFiles.printError("Ошибка чтения текстового файла!");
                return;
            }

            int count = result.Count;

            if (count == 0)
            {
                myFiles.printError("Фраз-палиндромов не обнаружено!");
                return;
            }

            MyPrint myPrint = new MyPrint();
            myPrint.printString("\nОбщее количество фраз:", countAllPhrases.ToString());
            myPrint.printString("Общее количество простых фраз:", (countAllPhrases - count).ToString());

            myPrint.printString("\nКоличество фраз-полинтропов:", count.ToString(), "\n");


            bool isOk = myFiles.writeStrings(paths.originalFile, arrayToWrite(), fileOut);

            if (isOk)
                myFiles.printFileInfo(fileOut);
            

            myPrint.printFinalInformation(isOk);

        }
    }
}
