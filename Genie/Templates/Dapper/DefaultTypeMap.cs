﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Genie.Templates.Dapper
{
    using Genie.Base;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "F:\Projects\Genie\Genie\Templates\Dapper\DefaultTypeMap.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DefaultTypeMap : DefaultTypeMapBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing Syste" +
                    "m.Reflection;\r\n\r\nnamespace ");
            
            #line 8 "F:\Projects\Genie\Genie\Templates\Dapper\DefaultTypeMap.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(GenerationContext.BaseNamespace));
            
            #line default
            #line hidden
            this.Write(".Dapper\r\n{\r\n    /// <summary>\r\n    /// Represents default type mapping strategy u" +
                    "sed by Dapper\r\n    /// </summary>\r\n    sealed class DefaultTypeMap : SqlMapper.I" +
                    "TypeMap\r\n    {\r\n        private readonly List<FieldInfo> _fields;\r\n        priva" +
                    "te readonly List<PropertyInfo> _properties;\r\n        private readonly Type _type" +
                    ";\r\n\r\n        /// <summary>\r\n        /// Creates default type map\r\n        /// </" +
                    "summary>\r\n        /// <param name=\"type\">Entity type</param>\r\n        public Def" +
                    "aultTypeMap(Type type)\r\n        {\r\n            if (type == null)\r\n              " +
                    "  throw new ArgumentNullException(\"type\");\r\n\r\n            _fields = GetSettableF" +
                    "ields(type);\r\n            _properties = GetSettableProps(type);\r\n            _ty" +
                    "pe = type;\r\n        }\r\n\r\n        internal static MethodInfo GetPropertySetter(Pr" +
                    "opertyInfo propertyInfo, Type type)\r\n        {\r\n            return propertyInfo." +
                    "DeclaringType == type ?\r\n                propertyInfo.GetSetMethod(true) :\r\n    " +
                    "            propertyInfo.DeclaringType.GetProperty(propertyInfo.Name, BindingFla" +
                    "gs.Public | BindingFlags.NonPublic | BindingFlags.Instance).GetSetMethod(true);\r" +
                    "\n        }\r\n\r\n        internal static List<PropertyInfo> GetSettableProps(Type t" +
                    ")\r\n        {\r\n            return t\r\n                    .GetProperties(BindingFl" +
                    "ags.Public | BindingFlags.NonPublic | BindingFlags.Instance)\r\n                  " +
                    "  .Where(p => GetPropertySetter(p, t) != null)\r\n                    .ToList();\r\n" +
                    "        }\r\n\r\n        internal static List<FieldInfo> GetSettableFields(Type t)\r\n" +
                    "        {\r\n            return t.GetFields(BindingFlags.Public | BindingFlags.Non" +
                    "Public | BindingFlags.Instance).ToList();\r\n        }\r\n\r\n        /// <summary>\r\n " +
                    "       /// Finds best constructor\r\n        /// </summary>\r\n        /// <param na" +
                    "me=\"names\">DataReader column names</param>\r\n        /// <param name=\"types\">Data" +
                    "Reader column types</param>\r\n        /// <returns>Matching constructor or defaul" +
                    "t one</returns>\r\n        public ConstructorInfo FindConstructor(string[] names, " +
                    "Type[] types)\r\n        {\r\n            var constructors = _type.GetConstructors(B" +
                    "indingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);\r\n         " +
                    "   foreach (ConstructorInfo ctor in constructors.OrderBy(c => c.IsPublic ? 0 : (" +
                    "c.IsPrivate ? 2 : 1)).ThenBy(c => c.GetParameters().Length))\r\n            {\r\n   " +
                    "             ParameterInfo[] ctorParameters = ctor.GetParameters();\r\n           " +
                    "     if (ctorParameters.Length == 0)\r\n                    return ctor;\r\n\r\n      " +
                    "          if (ctorParameters.Length != types.Length)\r\n                    contin" +
                    "ue;\r\n\r\n                int i = 0;\r\n                for (; i < ctorParameters.Len" +
                    "gth; i++)\r\n                {\r\n                    if (!String.Equals(ctorParamet" +
                    "ers[i].Name, names[i], StringComparison.OrdinalIgnoreCase))\r\n                   " +
                    "     break;\r\n                    if (types[i] == typeof(byte[]) && ctorParameter" +
                    "s[i].ParameterType.FullName == SqlMapper.LinqBinary)\r\n                        co" +
                    "ntinue;\r\n                    var unboxedType = Nullable.GetUnderlyingType(ctorPa" +
                    "rameters[i].ParameterType) ?? ctorParameters[i].ParameterType;\r\n                " +
                    "    if (unboxedType != types[i]\r\n                        && !(unboxedType.IsEnum" +
                    " && Enum.GetUnderlyingType(unboxedType) == types[i])\r\n                        &&" +
                    " !(unboxedType == typeof(char) && types[i] == typeof(string)))\r\n                " +
                    "        break;\r\n                }\r\n\r\n                if (i == ctorParameters.Len" +
                    "gth)\r\n                    return ctor;\r\n            }\r\n\r\n            return null" +
                    ";\r\n        }\r\n\r\n        /// <summary>\r\n        /// Gets mapping for constructor " +
                    "parameter\r\n        /// </summary>\r\n        /// <param name=\"constructor\">Constru" +
                    "ctor to resolve</param>\r\n        /// <param name=\"columnName\">DataReader column " +
                    "name</param>\r\n        /// <returns>Mapping implementation</returns>\r\n        pub" +
                    "lic SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, st" +
                    "ring columnName)\r\n        {\r\n            var parameters = constructor.GetParamet" +
                    "ers();\r\n\r\n            return new SimpleMemberMap(columnName, parameters.FirstOrD" +
                    "efault(p => string.Equals(p.Name, columnName, StringComparison.OrdinalIgnoreCase" +
                    ")));\r\n        }\r\n\r\n        /// <summary>\r\n        /// Gets member mapping for co" +
                    "lumn\r\n        /// </summary>\r\n        /// <param name=\"columnName\">DataReader co" +
                    "lumn name</param>\r\n        /// <returns>Mapping implementation</returns>\r\n      " +
                    "  public SqlMapper.IMemberMap GetMember(string columnName)\r\n        {\r\n         " +
                    "   var property = _properties.FirstOrDefault(p => string.Equals(p.Name, columnNa" +
                    "me, StringComparison.Ordinal))\r\n                ?? _properties.FirstOrDefault(p " +
                    "=> string.Equals(p.Name, columnName, StringComparison.OrdinalIgnoreCase));\r\n\r\n  " +
                    "          if (property != null)\r\n                return new SimpleMemberMap(colu" +
                    "mnName, property);\r\n\r\n            var field = _fields.FirstOrDefault(p => string" +
                    ".Equals(p.Name, columnName, StringComparison.Ordinal))\r\n                ?? _fiel" +
                    "ds.FirstOrDefault(p => string.Equals(p.Name, columnName, StringComparison.Ordina" +
                    "lIgnoreCase));\r\n\r\n            if (field != null)\r\n                return new Sim" +
                    "pleMemberMap(columnName, field);\r\n\r\n            return null;\r\n        }\r\n    }\r\n" +
                    "\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class DefaultTypeMapBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
