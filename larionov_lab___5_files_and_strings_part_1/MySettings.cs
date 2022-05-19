using System.Text.Json;
using System.Text;

namespace larionov_lab___5_files_and_strings_part_1
{
    internal class MySettings
    {
        private const string FILE_CONFIG = "config.ini";

        private const string KEY_DIR_FILE = "DIR_FILE";

        private Dictionary<string, string> settings = new Dictionary<string, string>()
        {
            { KEY_DIR_FILE, Environment.CurrentDirectory }
        };

        public string getDirFile()
        {
            return settings[KEY_DIR_FILE];
        }


        private bool updateJson(string fileName, string jsonData)
        {
            try
            {
                JsonDocument jdoc = JsonDocument.Parse(jsonData);
                using FileStream fs = File.OpenWrite(fileName);

                using var writer = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true });
                jdoc.WriteTo(writer);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool initConfig()
        {
            if (!File.Exists(settings[KEY_DIR_FILE])) 
                setKey(KEY_DIR_FILE, Environment.CurrentDirectory);

            if (File.Exists(FILE_CONFIG))
                return false;

            return setKeys(settings);
        }


        private bool setKeys(Dictionary<string, string> data)
        {
            try
            {
                using var ms = new MemoryStream();
                using var writer = new Utf8JsonWriter(ms);

                writer.WriteStartObject();

                foreach (var item in data)
                    writer.WriteString(item.Key, item.Value);

                writer.WriteEndObject();
                writer.Flush();

                return updateJson(FILE_CONFIG, Encoding.UTF8.GetString(ms.ToArray()));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool setKey(string key, string value)
        {
            try
            {
                using var ms = new MemoryStream();
                using var writer = new Utf8JsonWriter(ms);

                writer.WriteStartObject();
                writer.WriteString(key, value);

                writer.WriteEndObject();
                writer.Flush();

                return updateJson(FILE_CONFIG, Encoding.UTF8.GetString(ms.ToArray()));
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public void setDidectoryFile()
        {
            bool isGo = true;

            Console.WriteLine("\nТекущие параметры папки:");
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(getDirFile());
            Console.ResetColor();

            Console.WriteLine("\nВведите директорию в которой лежат файлы с данными ");
            Console.Write("Для выхода из настройки введите \"0\": ");

            string result;

            while (isGo)
            {
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
                        settings[KEY_DIR_FILE] = result;
                        isGo = !setKey(KEY_DIR_FILE, result);

                        if (!isGo)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Папка успешно изменена!");
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
