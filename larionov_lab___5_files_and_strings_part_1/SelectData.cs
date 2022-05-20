namespace larionov_lab___5_files_and_strings_part_1
{
    internal class SelectData
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

            MySettings mySettings = new MySettings();
            defaultReadFile = mySettings.getDirFile() + "\\" + defaultReadFile;

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

                fileName = myFiles.setReadFile(defaultReadFile, MyFiles.EXP);

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
}
