﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Knapcode.MiniZip {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Knapcode.MiniZip.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find central directory..
        /// </summary>
        internal static string CannotFindCentralDirectory {
            get {
                return ResourceManager.GetString("CannotFindCentralDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot find Zip64 locator..
        /// </summary>
        internal static string CannotFindZip64Locator {
            get {
                return ResourceManager.GetString("CannotFindZip64Locator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Content-Range header was expected but not found..
        /// </summary>
        internal static string ContentRangeHeaderNotFound {
            get {
                return ResourceManager.GetString("ContentRangeHeaderNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Zip64 metadata is not consistent with the non-Zip64 metadata..
        /// </summary>
        internal static string InconsistentZip64Metadata {
            get {
                return ResourceManager.GetString("InconsistentZip64Metadata", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid central directory signature found..
        /// </summary>
        internal static string InvalidCentralDirectorySignature {
            get {
                return ResourceManager.GetString("InvalidCentralDirectorySignature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Content-Range header has an unexpected value..
        /// </summary>
        internal static string InvalidContentRangeHeader {
            get {
                return ResourceManager.GetString("InvalidContentRangeHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Zip64 central directory signature found..
        /// </summary>
        internal static string InvalidZip64CentralDirectorySignature {
            get {
                return ResourceManager.GetString("InvalidZip64CentralDirectorySignature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid length for Zip64 extended information extra field..
        /// </summary>
        internal static string InvalidZip64ExtendedInformationLength {
            get {
                return ResourceManager.GetString("InvalidZip64ExtendedInformationLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The HTTP response did not have the expected status code HTTP 206 Partial Content..
        /// </summary>
        internal static string NonPartialContentHttpResponse {
            get {
                return ResourceManager.GetString("NonPartialContentHttpResponse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not all of the Zip64 extended information extra field was read..
        /// </summary>
        internal static string NotAllZip64ExtendedInformationWasRead {
            get {
                return ResourceManager.GetString("NotAllZip64ExtendedInformationWasRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The position must be a non-negative number..
        /// </summary>
        internal static string PositionMustBeNonNegative {
            get {
                return ResourceManager.GetString("PositionMustBeNonNegative", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream must support reading..
        /// </summary>
        internal static string StreamMustSupportRead {
            get {
                return ResourceManager.GetString("StreamMustSupportRead", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The stream must support seeking..
        /// </summary>
        internal static string StreamMustSupportSeek {
            get {
                return ResourceManager.GetString("StreamMustSupportSeek", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The UTF-8 flag is set on the ZIP entry but the encoding provided was not UTF-8..
        /// </summary>
        internal static string UTF8Mismatch {
            get {
                return ResourceManager.GetString("UTF8Mismatch", resourceCulture);
            }
        }
    }
}
