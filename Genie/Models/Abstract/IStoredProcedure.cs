﻿using System.Collections.Generic;

namespace Genie.Models.Abstract
{
    public class ProcedureParameter
    {
        public string Name { get; set; }
        public string DataType { get; set; }
    }

    /// <summary>
    /// Represents a stored procedure with all the properties to just generate an accessible code
    /// </summary>
    interface IStoredProcedure
    {
        /// <summary>
        /// Name of the Stored Procedure
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// How the parameters are passed into the SQL query
        /// </summary>
        string PassString { get; set; }

        /// <summary>
        /// How the parameters of the function should look like
        /// </summary>
        string ParamString { get; set; }

        /// <summary>
        /// List of parameters
        /// </summary>
        List<ProcedureParameter> Parameters { get; set; }
    }
}
