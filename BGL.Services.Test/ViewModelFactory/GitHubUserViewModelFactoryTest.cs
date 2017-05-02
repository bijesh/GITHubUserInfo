using BGL.Services.Interface.ViewModelFactory;
using BGL.Services.Test.TestObjects;
using BGL.Services.ViewModelFactory;
using BGLMVC.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.ViewModelFactory
{
    [TestFixture]
    public class GitHubUserViewModelFactoryTest
    {
        private IGitHubUserViewModelFactory gitHubUserViewModelFactory;

        [OneTimeSetUp]
        public void TestSetup()
        {
            this.gitHubUserViewModelFactory = new GitHubUserViewModelFactory();
        }

        [TestCase]
        public void ToGitHubUserViewModelFromGitUserAndRepositoryReturnsGitHubUserViewModel()
        {
            var gitUser = FakeGitUser.gitUser;
            var gitRepository = FakeGitRepository.gitRepositoryList;

            var result = this.gitHubUserViewModelFactory.ToGitHubUserViewModel(gitUser, gitRepository);

            Assert.IsInstanceOf(typeof(GitHubUserViewModel), result);
        }

        [TestCase]
        public void ToGitHubUserViewModelFromGitUserAndRepositoryConvertsCorrectly()
        {
            var gitUser = FakeGitUser.gitUser;
            var gitRepository = FakeGitRepository.gitRepositoryList;

            var result = this.gitHubUserViewModelFactory.ToGitHubUserViewModel(gitUser, gitRepository);

            Assert.AreEqual(gitUser.login, result.UserName);
            Assert.AreEqual(gitUser.location, result.Location);
            Assert.AreEqual(gitUser.avatar_url, result.AvatarUrl);
          //  Assert.That(result.RepositoryList, Has.Count.EqualTo(5));
        }

    }
}
