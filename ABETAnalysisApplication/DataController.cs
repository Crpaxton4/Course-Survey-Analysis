using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABETAnalysisApplication
{
    class DataController
    {

        private bool preFilesDropped = false;
        public bool PreFilesDropped
        {
            get
            {
                return preFilesDropped;
            }
            set
            {
                preFilesDropped = true;
            }
        }

        private List<String> preFilePaths = new List<string>();
        private List<String> postFilePaths = new List<string>();
        private List<PathPair> prePostPathPairs = new List<PathPair>();

        public bool addPreFilePath(string path)
        {
            // TODO Validate file path before adding it. 
            // If invalid return false and do nothing with the string. 
            // If valid add it to the list of pre file paths and 
            return true;
        }

        public bool addPostFilePath(string s)
        {
            // TODO Validate file path before adding it. 
            // If invalid return false and do nothing with the string. 
            // If valid add it to the list of post file paths and 
            return true;
        }

        public List<string> getFilePairs()
        {
            // TODO Make a copy of the pre and post file lists. For each pre file path find it in the post file list. 
            // Remove the files that are found to have a pair. Anything remaining in the pre and post lists will be added 
            // to the singleton file list and return the singleton file list 
            //return new List<string>();

            List<string> prePathsCopy = new List<string>(preFilePaths);
            List<string> postPathsCopy = new List<string>(postFilePaths);

            List<string> singletonFiles = new List<string>();
            List<PathPair> pathPairs = new List<PathPair>();

            for (int i = 0; i < prePathsCopy.Count; i++)
            {
                int preFileIndex = i;
                int postFileIndex = postPathsCopy.IndexOf(prePathsCopy.ElementAt(preFileIndex));

                // postFileIndex = -1 when not in postFilePaths list
                if (postFileIndex < 0)
                {
                    singletonFiles.Add(prePathsCopy.ElementAt(preFileIndex));
                    continue;
                }

                pathPairs.Add(new PathPair(prePathsCopy.ElementAt(preFileIndex), postFilePaths.ElementAt(postFileIndex)));

                postPathsCopy.RemoveAt(postFileIndex);

            }

            return singletonFiles;
        }

    }

}
}
