using BGL.Services.Contract;
using BGL.Services.Interface;
using BGL.Services.Interface.ViewModelFactory;
using BGL.Services.Test.TestObjects;
using BGL.Services.ViewModelFactory;
using BGL.Services.ViewModelService;
using BGLMVC.ViewModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.ViewModelService
{
    [TestFixture]
    public class GitHubUserViewModelServiceTest
    {
        private GitHubUserViewModelService gitHubUserViewModelService;
        private Mock<IGitHubUserInfoService> gitHubUserInfoService;
        private Mock<IGitHubRepoService> gitHubRepoService;
        private Mock<IGitHubUserViewModelFactory> gitHubUserViewModelFactory;
        private string userName;

        [OneTimeSetUp]
        public void TestSetup()
        {
            this.userName = "robconery";
            //this.gitHubUserInfoService = new Mock<IGitHubUserInfoService>();
            //this.gitHubRepoService = new Mock<IGitHubRepoService>();
            //this.gitHubUserViewModelFactory = new GitHubUserViewModelFactory();


        }

        [TestCase]
        [Ignore("Not completed")]
        public void InstantiatingWithNullGitHubUserInfoServiceArgumentNullException()
        {
            this.gitHubUserInfoService = new Mock<IGitHubUserInfoService>();
            this.gitHubRepoService = new Mock<IGitHubRepoService>();
            this.gitHubUserViewModelFactory = new Mock<IGitHubUserViewModelFactory>();

            this.gitHubUserInfoService.Setup(x => x.GetGitUserinfo(It.IsAny<string>())).Throws(new ArgumentNullException());
            this.gitHubRepoService.Setup(x => x.GetGitRepositoryInfo(It.IsAny<string>())).Throws(new ArgumentNullException());

            this.gitHubUserViewModelService = new GitHubUserViewModelService(gitHubUserInfoService.Object, gitHubRepoService.Object, gitHubUserViewModelFactory.Object);
            Assert.That(() => this.gitHubUserViewModelService.GetGitHubUser(this.userName).ConfigureAwait(true), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase]
        public async Task GetGitHubUserViewModelReturnTypeGitHubUserViewModel()
        {
            this.gitHubUserInfoService = new Mock<IGitHubUserInfoService>();
            this.gitHubRepoService = new Mock<IGitHubRepoService>();
            this.gitHubUserViewModelFactory = new Mock<IGitHubUserViewModelFactory>();

            this.gitHubUserInfoService.Setup(x => x.GetGitUserinfo(userName)).Returns(Task.FromResult(FakeGitUser.gitUser));
            this.gitHubRepoService.Setup(x => x.GetGitRepositoryInfo(FakeGitUser.gitUser.repos_url)).Returns(Task.FromResult(FakeGitRepository.gitRepositoryList.AsEnumerable()));
            this.gitHubUserViewModelFactory.Setup(
               x => x.ToGitHubUserViewModel(It.IsAny<GitUser>(),It.IsAny<IEnumerable<GitRepository>>()))
               .Returns(FakeGitHubUserViewModel.GetFakeGitHubUserViewModel());

            this.gitHubUserViewModelService = new GitHubUserViewModelService(gitHubUserInfoService.Object, gitHubRepoService.Object, gitHubUserViewModelFactory.Object);
            var result = await this.gitHubUserViewModelService.GetGitHubUser(this.userName);

            Assert.IsInstanceOf(typeof(GitHubUserViewModel), result);
        }

       
    }
}
