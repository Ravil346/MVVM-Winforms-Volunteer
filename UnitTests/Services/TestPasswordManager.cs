using BuisnessLogic.Models.Request;
using BuisnessLogic.Services;
using Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public class TestPasswordManager
    {
       
        [Fact]
        public void SaltTest()
        {
            //Arrange
            string password = "test";
            uint saltlenght = 8;
            ISafety passwordManager = new PasswordManager(new PasswordSaltOptions()
            {
                Password = password,
            });
            //Act
            var res1 = passwordManager.Salt(saltlenght);
            var res2 = passwordManager.Salt(saltlenght);

            //Assert
            Assert.True(((res2.Salt != res1.Salt) & (res2.Hash != res1.Hash)) ? true : false);
        }
        [Fact]
        public void CompareTest()
        {
            //Arrange
            string password = "test";
            uint saltlenght = 8;
            ISafety passwordManager = new PasswordManager(new PasswordSaltOptions()
            {
                Password = password,
            });
            //Act
            var res = passwordManager.Salt(saltlenght);
            passwordManager = new PasswordManager(new PasswordSaltOptions()
            {
                Password = password,
                Salt = res.Salt,
                Hash = res.Hash
            });
            var compRes = passwordManager.Compare();
            //Assert
            Assert.True(compRes);
        }
    }
}
