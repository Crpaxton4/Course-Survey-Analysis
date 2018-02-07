using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABETAnalysisApplication
{
    class PathPair
    {
        public string prePath { get; private set; }
        public string postPath { get; private set; }

        public PathPair(string prePath, string postPath)
        {
            this.prePath = prePath;
            this.postPath = postPath;
        }
    }
}
