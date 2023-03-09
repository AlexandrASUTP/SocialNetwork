using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class FriendView
    {
        //обьекты
        UserService userService;             
        FriendService friendService;
        IUserRepository userRepository;
        public FriendView(FriendService friendService, UserService userService) // конструктор класса
        {
            this.friendService = friendService;
            this.userService = userService;
            userRepository = new UserRepository();
        }

        public void Show(User user)
        {
            //создаем обьект класса с наименованием почты для поиска друга
            var friendData = new FriendData();
            //вводим наименование почты друга
            Console.WriteLine("Введите почтовый адрес друга:");
            // записываем в обьект класса наименование почты
            friendData.Email = Console.ReadLine();

            try
            {
                //выполняем метод из класса friendService
                friendService.AddFriend(friendData,user);
                //если почта в наличии то добавляем друга, если нет исключение
                SuccessMessage.Show("Друг добавлен!");
                //присваиваем переменной обект класса данных о друге
                var friendUserEntity = this.userRepository.FindByEmail(friendData.Email);
                //выводим сообщение о том что друг с нужным именем
                SuccessMessage.Show("Имя Вашего друга  " + friendUserEntity.firstname);
            }
            catch (UserNotFoundException)
            {
                // сработка исключения
                AlertMessage.Show("Пользователь не найден!");
            }
            catch (ArgumentNullException)
            {
                // сработка исключения
                AlertMessage.Show("Введите корректное значение!");
            }
        }
    }
}
