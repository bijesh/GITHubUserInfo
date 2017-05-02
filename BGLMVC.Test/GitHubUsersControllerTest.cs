using BGL.Services.Interface;
using BGL.Services.Interface.ViewModelService;
using BGL.ViewModel;
using BGLMVC.Controllers;
using BGLMVC.ViewModel;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BGLMVC.Test
{
    [TestFixture]
    public class GitHubUsersControllerTest
    {

        private Mock<IGitHubUserViewModelService> mockIGitHubUserViewModelService;
        private string username;

        [OneTimeSetUp]
        public void TestSetup()
        {
            this.username = "robconery";
            this.mockIGitHubUserViewModelService = new Mock<IGitHubUserViewModelService>();
            this.mockIGitHubUserViewModelService.Setup(x => x.GetGitHubUser(username)).Returns(Task.FromResult(GetFakeGitHubUserViewModel()));
           
        }

        [TestCase]
        public void IndexViewTest()
        {
            //Arrange
             var controller = new GitHubUsersController(mockIGitHubUserViewModelService.Object);

            //Act
            var result =  controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestCase]
        public async Task GetUserViewTest()
        {
            //Arrange
            var controller = new GitHubUsersController(mockIGitHubUserViewModelService.Object);

            //Act
            var result = await controller.GetUser(username) as ViewResult;

            //Assert
            Assert.AreEqual("GetUser", result.ViewName);

        }

        [TestCase]
        public async Task GetUserViewObjectTest()
        {
            //Arrange
            var controller = new GitHubUsersController(mockIGitHubUserViewModelService.Object);

            //Act
            var result = await controller.GetUser(username);
            
            //Assert
            Assert.IsInstanceOf<ActionResult>(result);

        }

        [TestCase]
        public async Task GetUserModelObjectTest()
        {
            //Arrange
            var controller = new GitHubUsersController(mockIGitHubUserViewModelService.Object);

            //Act
            var result = await controller.GetUser(username) as ViewResult;
            var model = (GitHubUserViewModel) result.ViewData.Model;

            //Assert
            Assert.IsInstanceOf<GitHubUserViewModel>(model);

        }

        [TestCase]
        public async Task GetUserModelValueTest()
        {
            //Arrange
            var controller = new GitHubUsersController(mockIGitHubUserViewModelService.Object);

            //Act
            var result = await controller.GetUser(username) as ViewResult;
            var model = (GitHubUserViewModel) result.ViewData.Model;

            //Assert
            Assert.AreEqual(this.username, model.UserName);

        }
        private GitHubUserViewModel GetFakeGitHubUserViewModel()
        {
            return new GitHubUserViewModel
            {
                UserName = "robconery",
                AvatarUrl = "https://avatars3.githubusercontent.com/u/78586?v=3",
                Location = "Seattle, WA",
                RepositoryList= GetFakeGitHubRepositoryViewModel()
            };
        }
        private IEnumerable<GitHubRepositoryViewModel> GetFakeGitHubRepositoryViewModel()
        {
            return new List<GitHubRepositoryViewModel>()
            {
                new GitHubRepositoryViewModel{ RepositoryName="repo1", StargazerCount=500 },
                new GitHubRepositoryViewModel{ RepositoryName="repo2", StargazerCount=400 },
                new GitHubRepositoryViewModel{ RepositoryName="repo3", StargazerCount=300 },
                new GitHubRepositoryViewModel{ RepositoryName="repo4", StargazerCount=200 },
                new GitHubRepositoryViewModel{ RepositoryName="repo5", StargazerCount=100 },
            };
        }
    }
}
