using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;

namespace SocialNetwork.BLL.Services
{
 /// <summary>
 /// класс по поиску всех друзей и добавлению в друзья
 /// </summary>
    public class FriendService
    {
        IFriendRepository friendRepository;        
        IUserRepository userRepository;
        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();            
        }
 
        public bool FindByEmail(string email, out int user_id)
        {
            user_id = -1;
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null)                            
                return false;
            
            user_id = findUserEntity.id;
            return true;
        }
        public IEnumerable<FriendEntity> FindAllByUserId(int user_id)
        {
            var findUserEntity = friendRepository.FindAllByUserId(user_id);           
            if (findUserEntity is null) throw new UserNotFoundException();
            return findUserEntity;
        }
        public int FriendAddUser(int userID, int friendID)
        {
            try
            {
                var friends = friendRepository.FindAllByUserId(userID);
                FriendEntity friendEntity = new FriendEntity();

                friendEntity.user_id = userID;
                friendEntity.friend_id = friendID;

                return friendRepository.Create(friendEntity);
            }
            catch
            {
                return -1;
            }
        }
        private Friend ConstructFriendModel(FriendEntity friendEntity)
        {
            return new Friend(friendEntity.id,
                              friendEntity.user_id,
                              friendEntity.friend_id                              
                             );
        }
    }
}
