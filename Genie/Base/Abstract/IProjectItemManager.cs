﻿using System.Collections.Generic;

namespace Genie.Base.Abstract
{
    /// <summary>
    /// Manages items of an existing project file
    /// </summary>
    internal interface IProjectItemManager
    {
        /// <summary>
        /// Process the project file using given items
        /// </summary>
        /// <param name="projectFilePath">Path to the project file</param>
        /// <param name="files">Files to include</param>
        /// <param name="output">A process output</param>
        void Process(string projectFilePath, List<string> files, IProcessOutput output);
    }
}
