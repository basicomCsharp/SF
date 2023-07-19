namespace BlogSF
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (var db = new AppContext())
            {
                var user1 = new User { FirstName = "Admin", LastName ="admin", Email = "admin@mail.ru" };
                var user2 = new User { FirstName = "Петров", LastName = "Пётр", Email = "petr@mail.ru" };
                var user3 = new User { FirstName = "Иванов", LastName = "Иван", Email = "ivan@mail.ru" };
                db.Users.AddRange(user1, user2, user3);                
                db.SaveChanges();//сохраняем данные в таблицы
            }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}