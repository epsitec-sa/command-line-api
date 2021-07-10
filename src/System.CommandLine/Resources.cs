﻿// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;

namespace System.CommandLine
{
    /// <summary>
    /// Provides localizable strings for help and error messages.
    /// </summary>
    public class Resources
    {
        /// <summary>
        /// Gets a global instance of the <see cref="Resources"/> class.
        /// </summary>
        public static Resources Instance { get; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Resources"/> class.
        /// </summary>
        protected Resources()
        {
        }

        /// <summary>
        ///   Interpolates values into a localized string similar to Command &apos;{0}&apos; expects a single argument but {1} were provided.
        /// </summary>
        public virtual string ExpectsOneArgument(SymbolResult symbolResult) => 
            symbolResult is CommandResult
                    ? GetResourceString(Properties.Resources.CommandExpectsOneArgument, symbolResult.Token().Value, symbolResult.Tokens.Count)
                    : GetResourceString(Properties.Resources.OptionExpectsOneArgument, symbolResult.Token().Value, symbolResult.Tokens.Count);

        /// <summary>
        ///   Interpolates values into a localized string similar to No argument was provided for Command &apos;{0}&apos;..
        /// </summary>
        public virtual string NoArgumentProvided(SymbolResult symbolResult) =>
            symbolResult is CommandResult
                ? GetResourceString(Properties.Resources.CommandNoArgumentProvided, symbolResult.Token().Value)
                : GetResourceString(Properties.Resources.OptionNoArgumentProvided, symbolResult.Token().Value);

        /// <summary>
        ///   Interpolates values into a localized string similar to Command &apos;{0}&apos; expects no more than {1} arguments, but {2} were provided.
        /// </summary>
        public virtual string ExpectsFewerArguments(
            Token token,
            int providedNumberOfValues,
            int maximumNumberOfValues) =>
            token.Type == TokenType.Command
                ? GetResourceString(Properties.Resources.CommandExpectsFewerArguments, token, maximumNumberOfValues, providedNumberOfValues)
                : GetResourceString(Properties.Resources.OptionExpectsFewerArguments, token, maximumNumberOfValues, providedNumberOfValues);

        /// <summary>
        ///   Interpolates values into a localized string similar to Directory does not exist: {0}.
        /// </summary>
        public virtual string DirectoryDoesNotExist(string path) =>
            GetResourceString(Properties.Resources.DirectoryDoesNotExist, path);

        /// <summary>
        ///   Interpolates values into a localized string similar to File does not exist: {0}.
        /// </summary>
        public virtual string FileDoesNotExist(string filePath) =>
            GetResourceString(Properties.Resources.FileDoesNotExist, filePath);

        /// <summary>
        ///   Interpolates values into a localized string similar to File or directory does not exist: {0}.
        /// </summary>
        public virtual string FileOrDirectoryDoesNotExist(string path) =>
            GetResourceString(Properties.Resources.FileOrDirectoryDoesNotExist, path);

        /// <summary>
        ///   Interpolates values into a localized string similar to Character not allowed in a path: {0}.
        /// </summary>
        public virtual string InvalidCharactersInPath(char invalidChar) =>
            GetResourceString(Properties.Resources.InvalidCharactersInPath, invalidChar);
        
        /// <summary>
        ///   Interpolates values into a localized string similar to Character not allowed in a file name: {0}.
        /// </summary>
        public virtual string InvalidCharactersInFileName(char invalidChar) =>
            GetResourceString(Properties.Resources.InvalidCharactersInFileName, invalidChar);

        /// <summary>
        ///   Interpolates values into a localized string similar to Required argument missing for command: {0}.
        /// </summary>
        public virtual string RequiredArgumentMissing(SymbolResult symbolResult) =>
            symbolResult is CommandResult
                ? GetResourceString(Properties.Resources.CommandRequiredArgumentMissing, symbolResult.Token().Value)
                : GetResourceString(Properties.Resources.OptionRequiredArgumentMissing, symbolResult.Token().Value);

        /// <summary>
        ///   Interpolates values into a localized string similar to Required command was not provided.
        /// </summary>
        public virtual string RequiredCommandWasNotProvided() =>
            GetResourceString(Properties.Resources.RequiredCommandWasNotProvided);

        /// <summary>
        ///   Interpolates values into a localized string similar to Argument &apos;{0}&apos; not recognized. Must be one of:{1}.
        /// </summary>
        public virtual string UnrecognizedArgument(string unrecognizedArg, IReadOnlyCollection<string> allowedValues) =>
            GetResourceString(Properties.Resources.UnrecognizedArgument, unrecognizedArg,$"\n\t{string.Join("\n\t", allowedValues.Select(v => $"'{v}'"))}");

        /// <summary>
        ///   Interpolates values into a localized string similar to Unrecognized command or argument &apos;{0}&apos;.
        /// </summary>
        public virtual string UnrecognizedCommandOrArgument(string arg) =>
            GetResourceString(Properties.Resources.UnrecognizedCommandOrArgument, arg);

        /// <summary>
        ///   Interpolates values into a localized string similar to Response file not found &apos;{0}&apos;.
        /// </summary>
        public virtual string ResponseFileNotFound(string filePath) =>
            GetResourceString(Properties.Resources.ResponseFileNotFound, filePath);

        /// <summary>
        ///   Interpolates values into a localized string similar to Error reading response file &apos;{0}&apos;: {1}.
        /// </summary>
        public virtual string ErrorReadingResponseFile(string filePath, IOException e) =>
            GetResourceString(Properties.Resources.ErrorReadingResponseFile, filePath, e.Message);

        /// <summary>
        ///   Interpolates values into a localized string similar to Show help and usage information.
        /// </summary>
        public virtual string HelpOptionDescription() =>
            GetResourceString(Properties.Resources.HelpOptionDescription);

        /// <summary>
        ///   Interpolates values into a localized string similar to Usage:.
        /// </summary>
        public virtual string HelpUsageTitle() =>
            GetResourceString(Properties.Resources.HelpUsageTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to [options].
        /// </summary>
        public virtual string HelpUsageOptionsTitle() =>
            GetResourceString(Properties.Resources.HelpUsageOptionsTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to [command].
        /// </summary>
        public virtual string HelpUsageCommandTitle() =>
            GetResourceString(Properties.Resources.HelpUsageCommandTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to [[--] &lt;additional arguments&gt;...]].
        /// </summary>
        public virtual string HelpUsageAdditionalArguments() =>
            GetResourceString(Properties.Resources.HelpUsageAdditionalArguments);

        /// <summary>
        ///   Interpolates values into a localized string similar to Arguments:.
        /// </summary>
        public virtual string HelpArgumentsTitle() =>
            GetResourceString(Properties.Resources.HelpArgumentsTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to Options:.
        /// </summary>
        public virtual string HelpOptionsTitle() =>
            GetResourceString(Properties.Resources.HelpOptionsTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to (REQUIRED).
        /// </summary>
        public virtual string HelpOptionsRequired() =>
            GetResourceString(Properties.Resources.HelpOptionsRequired);

        /// <summary>
        ///   Interpolates values into a localized string similar to default.
        /// </summary>
        public virtual string HelpArgumentDefaultValueTitle() =>
            GetResourceString(Properties.Resources.HelpArgumentDefaultValueTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to Commands:.
        /// </summary>
        public virtual string HelpCommandsTitle() =>
            GetResourceString(Properties.Resources.HelpCommandsTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to Additional Arguments:.
        /// </summary>
        public virtual string HelpAdditionalArgumentsTitle() =>
            GetResourceString(Properties.Resources.HelpAdditionalArgumentsTitle);

        /// <summary>
        ///   Interpolates values into a localized string similar to Arguments passed to the application that is being run..
        /// </summary>
        public virtual string HelpAdditionalArgumentsDescription() =>
            GetResourceString(Properties.Resources.HelpAdditionalArgumentsDescription);

        /// <summary>
        ///   Interpolates values into a localized string similar to &apos;{0}&apos; was not matched. Did you mean one of the following?.
        /// </summary>
        public virtual string SuggestionsTokenNotMatched(string token)
            => GetResourceString(Properties.Resources.SuggestionsTokenNotMatched, token);

        /// <summary>
        ///   Interpolates values into a localized string similar to Show version information.
        /// </summary>
        public virtual string VersionOptionDescription()
            => GetResourceString(Properties.Resources.VersionOptionDescription);

        /// <summary>
        ///   Interpolates values into a localized string similar to {0} option cannot be combined with other arguments..
        /// </summary>
        public virtual string VersionOptionCannotBeCombinedWithOtherArguments(string optionAlias)
            => GetResourceString(Properties.Resources.VersionOptionCannotBeCombinedWithOtherArguments, optionAlias);

        /// <summary>
        ///   Interpolates values into a localized string similar to Unhandled exception: .
        /// </summary>
        public virtual string ExceptionHandlerHeader()
            => GetResourceString(Properties.Resources.ExceptionHandlerHeader);

        /// <summary>
        ///   Interpolates values into a localized string similar to Debug directive specified, but no process names are listed as allowed for debug.
        ///Add your process name to the &apos;{0}&apos; environment variable.
        ///The value of the variable should be the name of the processes, separated by a semi-colon &apos;;&apos;, for example &apos;{0}={1}&apos;.
        /// </summary>
        public virtual string DebugDirectiveExecutableNotSpecified(string environmentVariableName, string processName)
            => GetResourceString(Properties.Resources.DebugDirectiveExecutableNotSpecified, environmentVariableName, processName);

        /// <summary>
        ///   Interpolates values into a localized string similar to Attach your debugger to process {0} ({1})..
        /// </summary>
        public virtual string DebugDirectiveAttachToProcess(int processId, string processName)
            => GetResourceString(Properties.Resources.DebugDirectiveAttachToProcess, processId, processName);

        /// <summary>
        ///   Interpolates values into a localized string similar to Process name &apos;{0}&apos; is not included in the list of debuggable process names in the {1} environment variable (&apos;{2}&apos;).
        /// </summary>
        public virtual string DebugDirectiveProcessNotIncludedInEnvironmentVariable(string processName, string environmentVariableName, string processNames)
            => GetResourceString(Properties.Resources.DebugDirectiveProcessNotIncludedInEnvironmentVariable, processName, environmentVariableName, processNames);

        /// <summary>
        ///   Interpolates values into a localized string similar to Cannot parse argument &apos;{0}&apos; as expected type {1}..
        /// </summary>
        public virtual string ArgumentConversionCannotParse(string value, Type expectedType)
            => GetResourceString(Properties.Resources.ArgumentConversionCannotParse, value, expectedType);

        /// <summary>
        ///   Interpolates values into a localized string similar to Cannot parse argument &apos;{0}&apos; for command &apos;{1}&apos; as expected type {2}..
        /// </summary>
        public virtual string ArgumentConversionCannotParseForCommand(string value, string commandAlias, Type expectedType)
            => GetResourceString(Properties.Resources.ArgumentConversionCannotParseForCommand, value, commandAlias, expectedType);

        /// <summary>
        ///   Interpolates values into a localized string similar to Cannot parse argument &apos;{0}&apos; for option &apos;{1}&apos; as expected type {2}..
        /// </summary>
        public virtual string ArgumentConversionCannotParseForOption(string value, string optionAlias, Type expectedType)
            => GetResourceString(Properties.Resources.ArgumentConversionCannotParseForOption, value, optionAlias, expectedType);

        /// <inheritdoc/>
        protected virtual string GetResourceString(string resourceString, params object[] formatArguments)
        {
            if (resourceString is null)
            {
                return string.Empty;
            }
            if (formatArguments.Length > 0)
            {
                return string.Format(resourceString, formatArguments);
            }
            return resourceString;
        }
    }
}