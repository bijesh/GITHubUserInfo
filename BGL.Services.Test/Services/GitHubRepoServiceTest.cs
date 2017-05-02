using BGL.Services.Contract;
using BGL.Services.Interface;
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
    public class GitHubRepoServiceTest
    {
       private  IGitHubRepoService gitHubRepoService;
       private  Mock<IWebApiClient> client;
       private string repoUrl;

        [OneTimeSetUp]
        public void TestSetup()
        {
            this.client = new Mock<IWebApiClient>();
            this.repoUrl = "https://api.github.com/users/robconery/repos";
        }

        [TestCase]
        public void InstantiatingGitHubRepoServiceWithNullIWebApiClientThrowsNullRefException()
        {
            this.gitHubRepoService = new GitHubRepoService(null);
            Assert.That(() => this.gitHubRepoService.GetGitRepositoryInfo(repoUrl), Throws.TypeOf<NullReferenceException>());
        }

        [TestCase]
        public void GetGitRepositoryInfoPassEmptyStringAndThrowsArgumentNullException()
        {
            this.client.Setup(x => x.GetAsync<IEnumerable<GitRepository>>(It.IsAny<string>())).Returns(Task.FromResult(FakeGitRepository.gitRepositoryList.AsEnumerable()));

            this.gitHubRepoService = new GitHubRepoService(client.Object);
            Assert.That(() => this.gitHubRepoService.GetGitRepositoryInfo(string.Empty), Throws.TypeOf<ArgumentNullException>());

        }

        [TestCase]
        public async Task GetGitRepositoryInfoReturnTypeGitRepository()
        {
            this.client.Setup(x => x.GetAsync<IEnumerable<GitRepository>>(It.IsAny<string>())).Returns(Task.FromResult(FakeGitRepository.gitRepositoryList.AsEnumerable()));

            this.gitHubRepoService = new GitHubRepoService(client.Object);
           
            var result = await this.gitHubRepoService.GetGitRepositoryInfo(repoUrl);

            Assert.IsInstanceOf(typeof(GitRepository), result.First());
        }
    }
}
