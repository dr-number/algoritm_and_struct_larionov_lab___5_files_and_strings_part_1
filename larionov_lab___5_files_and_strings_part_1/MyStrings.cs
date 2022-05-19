namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MyStrings
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
                    if (myFiles.isReadDataUpSymbol(endSymbol))
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
}
