using BGL.Services.Contract;
using BGLMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Interface.ViewModelFactory
{
    public interface IGitHubUserViewModelFactory
    {
        GitHubUserViewModel ToGitHubUserViewModel(GitUser gitUser,IEnumerable<GitRepository> gitRepository);
    }
}
