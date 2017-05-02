using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Contract
{
    public class GitUser
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string location { get; set; }
        public string repos_url { get; set; }
        
        // Todo: if needed add more property
    }
}
