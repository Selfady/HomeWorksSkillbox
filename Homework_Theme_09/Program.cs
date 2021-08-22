using System;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace TODO_Bot
{
    class Program
    {
        static TelegramBotClient bot;

        static void Main(string[] args)
        {
            //token to access the bot
            string token = File.ReadAllText(@"D:\Source\My\Private\Token");

            bot = new TelegramBotClient(token);
            bot.OnMessage += MessageListener;
            bot.StartReceiving();
            Console.ReadKey();
        }

        private static void MessageListener(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {

            string text = $"{DateTime.Now.ToLongTimeString()}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            Console.WriteLine($"{text} TypeMessage: {e.Message.Type.ToString()}");

            string downloadPath = @".\Download\";

            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
            {
                Console.WriteLine(e.Message.Document.FileId);
                Console.WriteLine(e.Message.Document.FileName);
                Console.WriteLine(e.Message.Document.FileSize);

                DownLoad(e.Message.Document.FileId, e.Message.Document.FileName, downloadPath);
            }

            var messageText = e.Message.Text;

            if (e.Message.Text == null) return;


            #region ParseText

            if (!String.IsNullOrEmpty(e.Message.Text))
            {
                if (e.Message.Text == "/start")
                {
                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                        "Недобот забивает жесткий диск компьютера файлами, что втыкают в чатик и знает две команды:");
                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                        "/list - должен вернуть пронумерованный список всех файлов, что уже накидали.");
                    bot.SendTextMessageAsync(e.Message.Chat.Id,
                        "/gimme n - n это номер файла в списке");
                }

                if (e.Message.Text == "/list")
                {
                    string[] fileEntries = Directory.GetFiles(downloadPath);

                    foreach (var fileName in fileEntries)
                    {
                        bot.SendTextMessageAsync(e.Message.Chat.Id,
                        $"{fileName}");
                    }
                    
                }

                if (e.Message.Text.Contains("/gimme"))
                {
                    var whatToGive = e.Message.Text.Substring(7);
                    Upload(whatToGive, e.Message.Chat.Id);
                }
            }

            #endregion ParseText
        }

        static async void DownLoad(string fileId, string fileName, string path)
        {                        
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(path + fileName, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();
        }

        static async void Upload(string fileName, long id)
        {
            using(FileStream fs = System.IO.File.OpenRead(fileName))
            {
                InputOnlineFile inputOnlineFile = new InputOnlineFile(fs, fileName);
                await bot.SendDocumentAsync(id, inputOnlineFile);
            }
        }
    }
}
