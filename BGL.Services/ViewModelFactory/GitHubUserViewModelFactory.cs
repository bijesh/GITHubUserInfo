using BGL.Services.Interface.ViewModelFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGL.Services.Contract;
using BGLMVC.ViewModel;
using BGL.ViewModel;

namespace BGL.Services.ViewModelFactory
{
    public class GitHubUserViewModelFactory : IGitHubUserViewModelFactory
    {
        public GitHubUserViewModel ToGitHubUserViewModel(GitUser gitUser, IEnumerable<GitRepository> gitRepository)
        {

            var gitHubUserViewModel = new GitHubUserViewModel
            {
                UserName = gitUser.login,
                AvatarUrl = gitUser.avatar_url,
                Location = gitUser.location,
                RepositoryList = gitRepository.Select(i => GetGitHubRepositoryViewModel(i))
            };
           
            return gitHubUserViewModel;
        }

        private ViewModel.GitHubRepositoryViewModel GetGitHubRepositoryViewModel(GitRepository gitRepository)
        {
            return new GitHubRepositoryViewModel
            {
                RepositoryName = gitRepository.name,
                StargazerCount = gitRepository.stargazers_count
            };
        }
    }
}
