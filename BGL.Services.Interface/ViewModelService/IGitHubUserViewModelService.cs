using BGLMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Interface.ViewModelService
{
    public interface IGitHubUserViewModelService
    {
        Task<GitHubUserViewModel> GetGitHubUser(string gitUser);
    }
}
