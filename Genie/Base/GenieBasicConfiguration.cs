﻿using System;
using Genie.Base.Abstract;

namespace Genie.Base
{
    /// <summary>
    /// Contains configurations that are need to do the data access layer generation
    /// </summary>
    public class GenieBasicConfiguration : IBasicConfiguration
    {
        public string ConnectionString { get; set; }
        
        public string ProjectPath { get; set; }

        public string BaseNamespace { get; set; }

        public void Validate()
        {
            string error = null;
            if (string.IsNullOrWhiteSpace(ConnectionString))
                error = "ConnectionString (connectionString in JSON) not found in the configuration";
            else if (string.IsNullOrWhiteSpace(ProjectPath))
                error = "ProjectPath (projectPath in JSON) not found in the configuration";
            else if (string.IsNullOrWhiteSpace(BaseNamespace))
                error = "BaseNamespace (baseNamespace in JSON) not found in the configuration file";

            if(error != null)
                throw new Exception(error);
        }

        public string ProjectFile { get; set; }
    }
}
