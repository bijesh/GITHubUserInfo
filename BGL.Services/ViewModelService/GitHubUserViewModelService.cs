using BGL.Services.Interface.ViewModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGLMVC.ViewModel;
using BGL.Services.Interface;
using BGL.Services.Interface.ViewModelFactory;

namespace BGL.Services.ViewModelService
{
    public class GitHubUserViewModelService : IGitHubUserViewModelService
    {
        private readonly IGitHubUserInfoService gitHubUserInfoService;
        private readonly IGitHubRepoService gitHubRepoService;
        private readonly IGitHubUserViewModelFactory gitHubUserViewModelFactory;

        public GitHubUserViewModelService(IGitHubUserInfoService gitHubUserInfoService,IGitHubRepoService gitHubRepoService, IGitHubUserViewModelFactory gitHubUserViewModelFactory)
        {
            this.gitHubUserInfoService = gitHubUserInfoService;
            this.gitHubRepoService = gitHubRepoService;
            this.gitHubUserViewModelFactory = gitHubUserViewModelFactory;
        }

        public async Task<GitHubUserViewModel> GetGitHubUser(string gitUser)
        {
            var gitUserInfo = await this.gitHubUserInfoService.GetGitUserinfo(gitUser);
            var gitRepo = await this.gitHubRepoService.GetGitRepositoryInfo(gitUserInfo.repos_url);
            var topGitRepo = gitRepo.OrderByDescending(i => i.stargazers_count).Take(5);
            return gitHubUserViewModelFactory.ToGitHubUserViewModel(gitUserInfo, topGitRepo);
        }
    }
}
