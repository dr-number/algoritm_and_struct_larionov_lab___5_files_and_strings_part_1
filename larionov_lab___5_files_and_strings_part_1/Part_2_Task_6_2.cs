namespace larionov_lab___5_files_and_strings_part_1
{
    internal class Part_2_Task_6_2
    {

        private const string DEFAULT_SEPARATOR = " ";
        private string separator = DEFAULT_SEPARATOR;

        private MyMatrixData matrix;

        public struct MyMatrixData
        {
            public List<List<int>> data;
            public int size;
            public bool isCorrect;
        };

        private int readMatrix(StreamWriter file, string str, string endSymbols)
        {
            string[] array = str.Split(separator);
            int countCol = array.Length;

            if (matrix.data == null)
            {
                matrix.data = new List<List<int>>();
                matrix.size = countCol;
            }
            else if (matrix.size != countCol)
            {
                matrix.isCorrect = false;
                return -1;
            }

            List<int> row = new List<int>();

            int num;
            for (int j = 0; j < countCol; ++j)
            {

                try
                {
                    int.TryParse(array[j], out num);
                    row.Add(num);
                }
                catch
                {
                    matrix.isCorrect = false;
                    return -1;
                }
            }

            matrix.data.Add(row);

            matrix.isCorrect = true;
            return 1;
        }

        private void changeMainDiagonal(int size, int lastElement)
        {
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    if (i == j)
                    {
                        matrix.data[i][j] = lastElement;
                        break;
                    }
        }

        private string matrixToStr(int size)
        {
            String result = "";

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    result += matrix.data[i][j];

                    if (j != size - 1)
                        result += separator;
                }

                if (i != size - 1)
                    result += "\n";
            }


            return result;
        }


        public void init()
        {
            Console.WriteLine(TasksInfo.PART_2_TASK_6_2);

            const string ORIGINAL_FILE = MyFiles.FILE_PART_2_TASK_6_2;
            const string TMP_FILE = ORIGINAL_FILE + MyFiles.EXP_TMP;

            MyFiles myFiles = new MyFiles();
            bool isResult = myFiles.getText(ORIGINAL_FILE, new Func<StreamWriter, string, string, int>(readMatrix), "");

            if (!isResult)
            {
                myFiles.printError("Ошибка чтения матрицы либо матрица не корректна!");
                return;
            }

            if (matrix.data == null)
            {
                myFiles.printError("Матрица не корректна!");
                return;
            }

            if (matrix.isCorrect == null || !matrix.isCorrect)
            {
                myFiles.printError("Матрица не корректна!");
                return;
            }

            int size = matrix.data.Count;

            if (size == 0)
            {
                myFiles.printError("Матрица пуста!");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nИсходная матрица:");

            MyPrint myPrint = new MyPrint();
            myPrint.printArray(matrix.data);

            int lastElement = matrix.data[size - 1][size - 1];

            myPrint.printString("\nПоследний элемент матрицы:", lastElement.ToString());

            changeMainDiagonal(size, lastElement);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nизмененная матрица:");

            myPrint.printArray(matrix.data);

            string write = matrixToStr(size);

            bool isOk = myFiles.writeStrings(MyFiles.FILE_PART_2_TASK_6_2, matrixToStr(size));
            myPrint.printFinalInformation(isOk);

            if (!isOk)
                myFiles.recoverOriginalFile(ORIGINAL_FILE, TMP_FILE);
        }
    }
}
