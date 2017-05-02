using BGL.Services.Interface.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.Config
{
    [TestFixture]
    public class GitHubRepoConfigTest
    {
        [TestCase]
        public void GitHubUserApiUrlReturnsExpected()
        {
            //Arrange
            IGitHubRepoConfig gitHubRepoConfig = new GitHubRepoConfig(string.Format("https://api.github.com/users/{0}", "robconery"));
            const string Expected = "https://api.github.com/users/robconery";

            //Act
            var result = gitHubRepoConfig.GitHubUserApiUrl;

            //Assert
            Assert.AreEqual(Expected, result);
        }

    }
}
