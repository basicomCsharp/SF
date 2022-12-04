using SocialNetwork.BLL.Services;

namespace SocialNetwork.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void FriendAddUserTest()
        {
            int id = 0 ;
            FriendService FriendServiceTest = new FriendService();            
            var b = FriendServiceTest.FindByEmail("mail@mail.ru", out id);
            Assert.True(id >= 0);
        }
        [Test]
        public void Test1()
        {
            Assert.True(0 == 0);
        }
    }
}