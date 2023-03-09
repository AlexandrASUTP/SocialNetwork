using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()                                                           // конструктор класса
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
       
        public void AddFriend(FriendData friendData, User user)                         // метод по добавлению друга
        {
            var friendUserEntity = this.userRepository.FindByEmail(friendData.Email);   // ищем email друга, если есть записываем в переменную
            if (friendUserEntity is null) throw new UserNotFoundException();            // если нет - исключение

            if (String.IsNullOrEmpty(friendData.Email))                                 // проверяем что записали email
                throw new ArgumentNullException();                                      // если нет - исключение

            var friendEntity = new FriendEntity()                                       // записываем параметры в обьект класса
            {
                friend_id = friendUserEntity.id,
                user_id = user.Id
            };

            if (this.friendRepository.Create(friendEntity) == 0)                        // создаем запись в бд 
                throw new Exception();                                                  // если не создалась - исключение

        }
    }
}
