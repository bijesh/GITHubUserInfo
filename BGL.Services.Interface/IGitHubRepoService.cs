using BGL.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Interface
{
    public interface IGitHubRepoService
    {
        Task<IEnumerable<GitRepository>> GetGitRepositoryInfo(string repoUrl);
    }
}
