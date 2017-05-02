using BGL.ViewModel;
using BGLMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.TestObjects
{
    public class FakeGitHubUserViewModel
    {
        internal static GitHubUserViewModel GetFakeGitHubUserViewModel()
        {
            return new GitHubUserViewModel
            {
                UserName = "robconery",
                AvatarUrl = "https://avatars3.githubusercontent.com/u/78586?v=3",
                Location = "Seattle, WA",
                RepositoryList = GetFakeGitHubRepositoryViewModel()
            };
        }
        private static IEnumerable<GitHubRepositoryViewModel> GetFakeGitHubRepositoryViewModel()
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
