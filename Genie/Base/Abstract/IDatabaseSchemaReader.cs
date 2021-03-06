﻿namespace Genie.Base.Abstract
{

    /// <summary>
    /// Provides an interface to read database schema of a database
    /// </summary>
    internal interface IDatabaseSchemaReader
    {
        /// <summary>
        /// Reads the database and provides the schema of the database
        /// </summary>
        /// <returns></returns>
        IDatabaseSchema Read(IBasicConfiguration configuration, IProcessOutput output);
    }
}
