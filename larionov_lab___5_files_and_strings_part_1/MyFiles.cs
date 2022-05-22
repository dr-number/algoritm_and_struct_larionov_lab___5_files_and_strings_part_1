using System.Text;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MyFiles
    {
        public const string EXP_TMP = ".tmp";
        public const string EXP = ".txt";
        public const string EXP_OUT = "_out" + EXP;
        public const string EXP_BIN = ".lar_110z";

        public const string FILE_PART_1_TASK_6_1 = "Part_1_Task_6_1" + EXP;
        public const string FILE_PART_1_TASK_6_2 = "Part_1_Task_6_2" + EXP;

        public const string FILE_PART_1_TASK_16_1 = "Part_1_Task_16_1" + EXP;
        public const string FILE_PART_1_TASK_16_2 = "Part_1_Task_16_2" + EXP;


        public const string FILE_PART_2_TASK_6_1 = "Part_2_Task_6_1" + EXP;
        public const string FILE_PART_2_TASK_6_2 = "Part_2_Task_6_2" + EXP;
        public const string FILE_PART_2_TASK_6_3 = "Part_2_Task_6_3" + EXP_BIN;


        public const string FILE_PART_2_TASK_16_1 = "Part_2_Task_16_1" + EXP;
        public const string FILE_PART_2_TASK_16_2 = "Part_2_Task_16_2" + EXP;
        public const string FILE_PART_2_TASK_16_3 = "Part_2_Task_16_3" + EXP_BIN;

        public const string MESSAGE_ERROR_PROCESSING_FILE = "Ошибка обработки файла!";
        public const string MESSAGE_ERROR_CREATE_FILE = "Ошибка создания файла для записи конечных результатов!";

        public struct PathsForTask
        {
            public string originalFile;
            public string tmpFile;
            public string outFile;
        }
        public PathsForTask getPathsForTask(string nameFilePartTask)
        {
            MySettings settings = new MySettings();
            string dirFile = settings.getDirFile();

            PathsForTask result;
            result.originalFile = dirFile + "\\" + nameFilePartTask;
            result.tmpFile = Path.GetTempPath() + nameFilePartTask + EXP_TMP;

            result.outFile = dirFile + "\\" + Path.GetFileNameWithoutExtension(nameFilePartTask) + EXP_OUT;

            return result;
        }

        string existFile(string fileName, string exp)
        {
            if(File.Exists(fileName))
                return fileName;

            fileName += exp;

            if (File.Exists(fileName))
                return fileName;

            return "";
        }

        public string setReadFile(string defaultReadFile, string exp)
        {

            MyPrint myPrint = new MyPrint();
            myPrint.printInfoAboutWorkDir(defaultReadFile);

            string fileName = Console.ReadLine();

            if (fileName == "")
                fileName = defaultReadFile;
            
            //
            MySettings mySettings = new MySettings();
            fileName = mySettings.getDirFile() + "\\" + fileName;
      
            
            string tmpFileName = existFile(fileName, exp);

            if (tmpFileName == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файла: {fileName} - не существует!");
                Console.ResetColor();

                return "";
            }

            fileName = tmpFileName;

            FileInfo fileInfo = new FileInfo(fileName);

            if (fileInfo.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файла: {fileName} - пуст!");
                Console.ResetColor();

                return "";
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nОбрабатываемый файл: ");

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(fileName + "\n");

            Console.ResetColor();
            printFileInfo(fileName);

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
            Console.Write(fileInfo.Length + " байт\n\n");

            Console.ResetColor();
        }

        public void printError(string message = MESSAGE_ERROR_PROCESSING_FILE)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + message);
            Console.ResetColor();
        }

        public string getTextReadOnly(string defaultReadFile, Delegate method, string param)
        {
            string path = setReadFile(defaultReadFile, EXP);

            if (path == "")
                return "";

            bool isOk = true;

            try
            {
                using (StreamReader fReader = new StreamReader(path))
                    while (!fReader.EndOfStream)
                        if ((int)method.DynamicInvoke(fReader.ReadLine(), param) == -1)
                        {
                            isOk = false;
                            break;
                        }
                
                if (isOk)
                    return path;

                return "";

            }
            catch (Exception e)
            {
                printError(e.Message);
                path = "";
            }

            return path;

        }

        public string getText(string defaultReadFile, Delegate method, string param)
        {
            string path = setReadFile(defaultReadFile, EXP);

            if (path == "")
                return "";

            bool isOk = true;
            string tmpFile = "";

            try
            {
                tmpFile = Path.GetTempPath() + Path.GetFileName(path) + EXP_TMP;

                if(File.Exists(tmpFile))
                    File.Delete(tmpFile);

                File.Move(path, tmpFile);

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {

                    using (StreamWriter fWriter = new StreamWriter(fs))
                    using (StreamReader fReader = new StreamReader(tmpFile))
                        while (!fReader.EndOfStream)
                        {
                            if ((int) method.DynamicInvoke(fWriter, fReader.ReadLine(), param) == -1)
                            {
                                isOk = false;
                                break;
                            }
                        }
                }

                if (isOk)
                {
                    File.Delete(tmpFile);
                    return path;
                }
                else
                    path = "";


            }
            catch (Exception e)
            {
                printError(e.Message);
                path = "";
            }

            if (path != "")
                recoverOriginalFile(path, tmpFile);

            return path;

        }

        public void recoverOriginalFile(string pathOriginal, string pathTmp)
        {

            if(pathTmp != "" && File.Exists(pathTmp))
                File.Move(pathTmp, pathTmp + EXP_TMP);

            if(pathOriginal != "" && File.Exists(pathOriginal))
                File.Delete(pathOriginal);

            if (pathOriginal != "" && pathTmp != "" && File.Exists(pathTmp + EXP_TMP))
                File.Move(pathTmp + EXP_TMP, pathOriginal);
        }

        public string setFileForOut(string defaultFile)
        {
            string pathOut = "";
            bool isGo = true;

            while (isGo)
            {
                Console.ResetColor();
                Console.Write("Введите имя файла для сохранения результатов [по умолчанию ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(defaultFile);

                Console.ResetColor();
                Console.Write("]: ");

                pathOut = Console.ReadLine();

                if(pathOut == "")
                    pathOut = defaultFile;

                if (File.Exists(pathOut))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Файл с таким именем уже существует. Заменить его? [y/n]?: ");

                    if (Console.ReadLine()?.ToLower() != "n")
                        return pathOut;
                }
                else
                    isGo = false;
            }

            return pathOut;
        }

        public bool writeStrings(string pathOriginal, string strings, string fileOut = "")
        {
            string[] array = strings.Split("\n");
            int size = array.Length;

            if (size == 0)
                return false;

            string pathOut = pathOriginal;

            try
            {
                if (fileOut != "")
                {
                    pathOut = fileOut;
                    using (File.Create(pathOut));
                }

                using (StreamWriter fWrite = new StreamWriter(pathOut, false, Encoding.UTF8))
                    for (int i = 0; i < size; i++)
                        fWrite.Write(array[i] + "\n");

                return true;
            }
            catch (Exception e)
            {
                printError(e.Message);

                if (fileOut != "")
                    File.Delete(pathOut);

                return false;
            }
        }

        public bool getBin(string path, Delegate method, int periodPrint, bool isReadFromEnd = false)
        {

            bool isOk = true;
            string tmpFile = "";

            try
            {
                tmpFile = Path.GetTempPath() + Path.GetFileName(path) + EXP_TMP;

                if (File.Exists(tmpFile))
                    File.Delete(tmpFile);

                File.Move(path, tmpFile);

                Stream read = File.OpenRead(tmpFile);

                if (read == null)
                    return false;

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    using (BinaryWriter fWriter = new BinaryWriter(fs))
                    using (BinaryReader fReader = new BinaryReader(read))
                    {
                        long setSeek;
                        bool isPrintNewString;


                        int i = 0;
                        long size = fReader.BaseStream.Length;

                        while (true)
                        {
                            if (isReadFromEnd)
                            {
                                setSeek = size - (i + 1) * sizeof(int);

                                if (setSeek < 0)
                                    break;

                                fReader.BaseStream.Seek(setSeek, SeekOrigin.Begin);
                            }
                            else if (fReader.BaseStream.Position == size)
                                break;

                            isPrintNewString = i != 0 && i % periodPrint == 0;

                            if ((int)method.DynamicInvoke(fWriter, fReader.ReadInt32(), isPrintNewString) == -1)
                            {
                                isOk = false;
                                break;
                            }

                            ++i;

                        }
                    }

                }

                if (isOk)
                {
                    File.Delete(tmpFile); //ok
                    return true;
                }

            }
            catch (Exception e)
            {
                printError(e.Message);
                isOk = false;
            }

            if (!isOk)
                recoverOriginalFile(path, tmpFile);

            return isOk;

        }

    }
}
