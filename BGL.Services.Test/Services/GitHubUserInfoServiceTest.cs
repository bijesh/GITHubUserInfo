using BGL.Services.Contract;
using BGL.Services.Interface;
using BGL.Services.Interface.Config;
using BGL.Services.Interface.Utilities;
using BGL.Services.Test.TestObjects;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.Services
{
    [TestFixture]
    public class GitHubUserInfoServiceTest
    {
        private IGitHubUserInfoService gitHubUserInfoService;
        private Mock<IWebApiClient> client;
        private Mock<IGitHubRepoConfig> config;
        private string username;
        private string GitUrl;

        [OneTimeSetUp]
        public void TestSetup()
        {
            this.client = new Mock<IWebApiClient>();
            this.config = new Mock<IGitHubRepoConfig>();
            this.username = "robconery";
            this.GitUrl = "https://api.github.com/users/robconery";
        }
               

        [TestCase]
        [Ignore("Not completed")]
        public void InstantiatingGitHubUserInfoServiceWithNullIWebApiClientThrowsNullRefException()
        {
            this.gitHubUserInfoService = new GitHubUserInfoService(null,config.Object);
            Assert.That(() => this.gitHubUserInfoService.GetGitUserinfo(username).ConfigureAwait(true), Throws.TypeOf<NullReferenceException>());
        }

        [TestCase]
        [Ignore("Not completed")]
        public void InstantiatingGitHubUserInfoServiceWithNullIGitHubRepoConfigThrowsNullRefException()
        {
            this.gitHubUserInfoService = new GitHubUserInfoService(client.Object,null);
            Assert.That(() => this.gitHubUserInfoService.GetGitUserinfo(username).ConfigureAwait(true), Throws.TypeOf<NullReferenceException>());
        }

        [TestCase]
        [Ignore("Not completed")]
        public void GetGitUserinfoPassEmptyStringAndThrowsArgumentNullException()
        {
            this.gitHubUserInfoService = new GitHubUserInfoService(client.Object, config.Object);
            Assert.That(() => this.gitHubUserInfoService.GetGitUserinfo(string.Empty).ConfigureAwait(true), Throws.TypeOf<ArgumentNullException>());

        }

        [TestCase]
        public async Task GetGitUserinfoReturnTypeGitUser()
        {

            this.client.Setup(x => x.GetAsync<GitUser>(It.IsAny<string>())).Returns(Task.FromResult(FakeGitUser.gitUser));
            this.config.Setup(x => x.GitHubUserApiUrl).Returns(this.GitUrl);


            this.gitHubUserInfoService = new GitHubUserInfoService(client.Object, config.Object);
            var result = await  this.gitHubUserInfoService.GetGitUserinfo(username);

            Assert.IsInstanceOf(typeof(GitUser), result);
        }



    }
}
