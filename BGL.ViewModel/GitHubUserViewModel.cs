using BGL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BGLMVC.ViewModel
{
    public class GitHubUserViewModel
    {
        public string UserName { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public IEnumerable<GitHubRepositoryViewModel> RepositoryList { get; set; }
    }
}