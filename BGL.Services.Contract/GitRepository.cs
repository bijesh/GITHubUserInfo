using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Contract
{
    public class GitRepository
    {
        public string name { get; set; }
        public int stargazers_count { get; set; }
        // Todo: if needed add more property
    }
}
