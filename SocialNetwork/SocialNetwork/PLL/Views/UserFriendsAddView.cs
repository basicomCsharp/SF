using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{/// <summary>
/// Класс добавления в друзья в социальной сети
/// ищем пользователя по адресу, если адрес есть, то user добавляем в друзья, если нет, то сообщение
/// </summary>
    public class UserFriendsAddView
    {
        FriendService friendService;
        public UserFriendsAddView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        public void Show(User user)
        {                        
            while(true)
            {
                try
                {
                    Console.WriteLine("Введите почтовый адрес того, кого хотите добавить в друзья или 0 для выхода:");                    

                    var email = Console.ReadLine();
                    if (String.IsNullOrEmpty(email))
                    {
                        Console.WriteLine("Введите Email или пункт из списка (0 - выход в главное меню, 1 - информация о профиле)");
                        continue;
                    }
                    if (email == "0") break;
                    switch (email)
                    {
                        case "1":
                            {
                                Program.userInfoView.Show(user);
                                break;
                            }                                                    
                        default:
                            {
                                int id = 0;
                                if (friendService.FindByEmail(email, out id))
                                {
                                    Console.WriteLine("регистрируем друга с id = {0}", id.ToString());
                                    //написать код по добавлению в друзья!
                                    if (friendService.FriendAddUser(user.Id, id) >= 0)
                                        Console.WriteLine("Пользователь с id = {0} теперь друг для пользователя с id = {1}", id.ToString(), user.Id.ToString());
                                    else
                                        Console.WriteLine("Не удалось добавить в друзья..");
                                }
                                else
                                    throw new UserNotFoundException();

                                break;
                            }
                    }
                }
                catch (UserNotFoundException)
                {
                    AlertMessage.Show("Пользователь с таким адресом не найден!");
                }
            }
        }
    }
}
