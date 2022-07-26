﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using TeleBotMeloman;
using Telegram.Bot;
using TeleBot.Controllers;
using TeleBot.Services;
using TeleBot.Configuration;

//Cчитаем, что Main где то спрятался от нас, вернее его спрятали индусские программисты,
// чтобы мы не писали всякие аргументы ;)
    Console.OutputEncoding = Encoding.Unicode;

    // Объект, отвечающий за постоянный жизненный цикл приложения
    var host = new HostBuilder()
        .ConfigureServices((hostContext, services) => ConfigureServices(services)) // Задаем конфигурацию
        .UseConsoleLifetime() // Позволяет поддерживать приложение активным в консоли
        .Build(); // Собираем

    Console.WriteLine("Сервис запущен");
    // Запускаем сервис
    await host.RunAsync();
    Console.WriteLine("Сервис остановлен");

static AppSettings BuildAppSettings()
{
    return new AppSettings()
    {
        BotToken = "5705080055:AAFhAZlIuBTWU8f2rzE1KEtEu098fNEYLn0"
    };
}
static void ConfigureServices(IServiceCollection services)
{
    AppSettings appSettings = BuildAppSettings();
    services.AddSingleton(BuildAppSettings());

    services.AddSingleton<IStorage, MemoryStorage>();

    // Подключаем контроллеры сообщений и кнопок
    services.AddTransient<DefaultMessageController>();    
    services.AddTransient<TextMessageController>();
    services.AddTransient<InlineKeyboardController>();

    services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
    services.AddHostedService<Bot>();
    //// Подключаем контроллеры сообщений и кнопок
    //services.AddTransient<DefaultMessageController>();  
    //services.AddTransient<TextMessageController>();
    //services.AddTransient<InlineKeyboardController>();
    //services.AddSingleton<IStorage, MemoryStorage>();
    //// Регистрируем объект TelegramBotClient c токеном подключения MelomanTeleBot:
    //services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5705080055:AAFhAZlIuBTWU8f2rzE1KEtEu098fNEYLn0"));
    //// Регистрируем постоянно активный сервис бота
    //services.AddHostedService<Bot>();
}