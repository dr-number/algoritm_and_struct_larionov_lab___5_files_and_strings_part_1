using System;
using System.Configuration;


namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MySettings
    {
        private const string FILE_CONFIG = "config.ini";

        private const string KEY_DIR_FILE = "DIR_FILE";

        private void setDefaultSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            settings.Add(KEY_DIR_FILE, "");

            File.WriteAllLines(FILE_CONFIG, settings.Select(x => $"{x.Key},{x.Value}"));
        }

        private string ReadSetting(string key)
        {
            try
            {
                string[] arr;
                var lines = File.ReadLines(FILE_CONFIG);

                foreach (var line in lines)
                {
                    arr = line.Split(',');

                    if(arr[0] == key)
                        return String.Join(",", arr.Skip(1));
                }

                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }

        bool UpdateSettings(string key, string value)
        {
            try
            {
                var lines = File.ReadLines(FILE_CONFIG);

                Dictionary<string, string> settings = new Dictionary<string, string>();
                string[] arr;

                foreach (var line in lines)
                {
                    arr = line.Split(',');
                    names.Add(arr[0], String.Join(",", arr.Skip(1)));
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string getDirFile()
        {
            return ReadSetting("Setting1");
        }

        public bool initConfig()
        {
            if (!Directory.Exists(settings[KEY_DIR_FILE]))
            {
                settings[KEY_DIR_FILE] = Environment.CurrentDirectory;
                setKeys();
            }

            if (File.Exists(FILE_CONFIG))
                return false;

            return setKeys();
        }


        public void setDidectoryFile()
        {
            bool isGo = true;

            Console.WriteLine("\nТекущие параметры папки:");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(getDirFile());
            Console.ResetColor();

            string result;

            while (isGo)
            {
                Console.WriteLine("\nВведите директорию в которой лежат файлы с данными ");
                Console.Write("Для выхода из настройки введите \"0\": ");

                result = Console.ReadLine();

                if (result != "0")
                {
                    if (!Directory.Exists(result))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Папка: {result} - не существует!");
                    }
                    else
                    {

                        if (UpdateSettings(KEY_DIR_FILE, result))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Папка успешно изменена!");
                            isGo = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка сохранения настроек!");
                        }
                    }

                    Console.ResetColor();
                }
                else
                    isGo = false;
            }
        }
    }
}
