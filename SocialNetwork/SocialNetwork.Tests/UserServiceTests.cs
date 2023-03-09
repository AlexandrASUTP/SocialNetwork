using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void GetAuthenticationUserMustReturnNullableUser()
        {
            UserService userServiceTest = new UserService();
            Assert.IsNotNull(userServiceTest.FindById(0));
        }
    }
}
