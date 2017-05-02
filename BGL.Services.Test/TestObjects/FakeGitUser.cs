using BGL.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Test.TestObjects
{
   public static class FakeGitUser
    {
            internal static GitUser gitUser = new GitUser { login = "robconery",
                                                            avatar_url = "https://avatars3.githubusercontent.com/u/78586?v=3",
                                                            location = "Seattle, WA",
                                                            repos_url= "https://api.github.com/users/robconery/repos"
                                                            };
    }
}
