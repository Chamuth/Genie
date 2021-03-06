﻿using System.Collections.Generic;
using Genie.Models.Abstract;

namespace Genie.Base.Abstract
{
    /// <summary>
    /// Schema of a database
    /// </summary>
    internal interface IDatabaseSchema
    {
        /// <summary>
        /// Base namespace of the DAL
        /// </summary>
        string BaseNamespace { get; set; }

        /// <summary>
        /// List of relations 
        /// </summary>
        List<IRelation> Relations { get; set; }

        /// <summary>
        /// List of view
        /// </summary>
        List<IView> Views { get; set; }

        /// <summary>
        /// List of stored procedures
        /// </summary>
        List<IStoredProcedure> Procedures { get; set; }
    }
}
