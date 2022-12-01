using CliWrap;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using static System.Net.WebRequestMethods;

namespace CommandPattern
{
    /// <summary>
    /// Базовый класс команды
    /// </summary>
    abstract class Command
    {
        public abstract void Run();
        public abstract void Cancel();
    }

    /// <summary>
    /// Конкретная реализация команды.
    /// </summary>
    class CommandDownload : Command
    {
        Receiver receiver;
        string videoUrl;

        public CommandDownload(Receiver receiver, string videoUrl)
        {
            this.receiver = receiver;
            this.videoUrl = videoUrl;
        }

        // Выполнить
        public override async void Run()
        {
            await receiver.DownloadVideo(videoUrl);
            Console.WriteLine("Команда Download отправлена");
            //receiver.Operation();
        }

        // Отменить
        public override void Cancel()
        { }
    }
    class CommandInfo : Command
    {
        Receiver receiver;
        string videoUrl;

        public CommandInfo(Receiver receiver, string videoUrl)
        {
            this.receiver = receiver;
            this.videoUrl = videoUrl;
        }

        // Выполнить
        public override async void Run()
        {
            await receiver.InfoForVideo(videoUrl);
            Console.WriteLine("Команда Info отправлена");
        }

        // Отменить
        public override void Cancel()
        { }
    }
    /// <summary>
    /// Адресат команды
    /// </summary>
    class Receiver
    {
        public async Task InfoForVideo(string videoUrl = "https://www.youtube.com/watch?v=1La4QzGeaaQ")
        {
            try
            {
                Console.WriteLine("Информация о видео:");
                YoutubeClient client = new YoutubeClient();
                var video = await client.Videos.GetAsync(videoUrl);
                Console.WriteLine($"Название: {video.Title}");
                Console.WriteLine($"Продолжительность: {video.Duration}");
                Console.WriteLine($"Автор: {video.Author}");               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
        }
        public async Task DownloadVideo(string videoUrl = "https://www.youtube.com/watch?v=2ElTIOJ6Qbs&t=20s", string outputFilePath = "G:\\video\\SF\\")
        {
            YoutubeClient client = new YoutubeClient();

            var streamManifest = await client.Videos.Streams.GetManifestAsync(videoUrl);
            // Get highest quality muxed stream
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            // ...or highest quality MP4 video-only stream
            //var streamInfo = streamManifest
            //    .GetVideoOnlyStreams()
            //    .Where(s => s.Container == Container.Mp4)
            //    .GetWithHighestVideoQuality();
            await client.Videos.Streams.DownloadAsync(streamInfo, outputFilePath);            
        }
        public void Operation()
        {
            Console.WriteLine("Процесс запущен");
        }
    }

    /// <summary>
    /// Отправитель команды
    /// </summary>
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        // Выполнить
        public void Run()
        {
            _command.Run();
        }

        // Отменить
        public void Cancel()
        {
            _command.Cancel();
        }
    }


    /// <summary>
    /// Клиентский код
    /// </summary>
    class Program
    {
        public static void InfoForVideo(string videoUrl = "https://www.youtube.com/watch?v=1La4QzGeaaQ")
        {
            try
            {
                Console.WriteLine("Информация о видео:");
                YoutubeClient client = new YoutubeClient();
                var video =  client.Videos.GetAsync(videoUrl);
                Console.WriteLine($"Название: {video.Result.Title}");
                Console.WriteLine($"Продолжительность: {video.Result.Duration}");
                Console.WriteLine($"Автор: {video.Result.Author}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void DownloadVideo(string videoUrl = "https://www.youtube.com/watch?v=2ElTIOJ6Qbs&t=20s", string outputFilePath = "G:\\video\\SF\\")
        {
            YoutubeClient client = new YoutubeClient();

            var streamManifest = client.Videos.Streams.GetManifestAsync(videoUrl);
            // Get highest quality muxed stream
            var streamInfo = streamManifest.Result.GetMuxedStreams().GetWithHighestVideoQuality();
            // ...or highest quality MP4 video-only stream
            //var streamInfo = streamManifest
            //    .GetVideoOnlyStreams()
            //    .Where(s => s.Container == Container.Mp4)
            //    .GetWithHighestVideoQuality();
            client.Videos.Streams.DownloadAsync(streamInfo, outputFilePath);
        }
        public static string videoUrl = String.Empty;
        public static void Main()
        {
            //Console.WriteLine("Информация о видео:");
            //YoutubeClient client = new YoutubeClient();
            //var video = client.Videos.GetAsync("https://www.youtube.com/watch?v=SV7NImkKd2Q");
            //Console.WriteLine($"Название: {video.Result.Title}");
            //Console.WriteLine($"Продолжительность: {video.Result.Duration}");
            //Console.WriteLine($"Автор: {video.Result.Author}");

            // создадим отправителя 
            
            var sender = new Sender();

            // создадим получателя 
            var receiver = new Receiver();
            Command command;

            Console.WriteLine("Введите ссылку на видео");
            videoUrl = Console.ReadLine()?? "https://www.youtube.com/watch?v=SV7NImkKd2Q";
            
            Console.WriteLine("Введите команду info для получения информации о видеофайле или save для скачивания и сохранения");
            var enterCommand = Console.ReadLine();
            
            if (enterCommand == "info")
            {
                command = new CommandInfo(receiver, videoUrl);
                // инициализация команды
                sender.SetCommand(command);
            }
            else if (enterCommand == "save")
            {
                command = new CommandDownload(receiver, videoUrl);
                // инициализация команды
                sender.SetCommand(command);
            }
            // инициализация команды
            //sender.SetCommand(command);
            //  выполнение
            sender.Run();
        }
    }
}