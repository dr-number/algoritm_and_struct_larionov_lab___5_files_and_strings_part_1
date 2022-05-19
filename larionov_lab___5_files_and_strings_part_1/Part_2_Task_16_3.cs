namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_16_3
    {
        private void printBin(string pathFile, int periodPrint)
        {

            try
            {
                int i = 0;

                using (BinaryReader bin = new BinaryReader(File.Open(pathFile, FileMode.Open)))
                {

                    while (bin.BaseStream.Position != bin.BaseStream.Length)
                    {
                        Console.Write(bin.ReadInt32() + " ");

                        if (i != 0 && i % periodPrint == 0)
                            Console.Write("\n");

                        ++i;
                    }

                }
            }
            catch (Exception e)
            {
                MyFiles myFiles = new MyFiles();
                myFiles.printError(e.Message);
            }
        }

        private int reverseBin(BinaryWriter fWriter, int read, bool isNewStr)
        {
            fWriter.Write(read);
            Console.Write(read + " ");

            if (isNewStr)
                Console.Write("\n");

            return 1;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_16_3);

            const string DEFAULT_FILE = MyFiles.FILE_PART_2_TASK_16_3;

            GenerationBin generationBin = new GenerationBin();
            string originalFile = generationBin.createBin(DEFAULT_FILE);

            if (originalFile == "")
                return;

            Console.WriteLine(MyPrint.INITIAL_DATA);
            printBin(originalFile, GenerationBin.PERIOD_PRINT);

            Console.WriteLine("\n");

            MyFiles myFiles = new MyFiles();
            bool isOk = myFiles.getBin(originalFile, new Func<BinaryWriter, int, bool, int>(reverseBin), GenerationBin.PERIOD_PRINT, true);

            Console.WriteLine("\n");
            myFiles.printFileInfo(originalFile);

            MyPrint myPrint = new MyPrint();
            myPrint.printFinalInformation(isOk);
        }
    }
}
