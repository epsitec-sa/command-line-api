// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.CommandLine.Binding;
using System.CommandLine.Invocation;

namespace System.CommandLine.NamingConventionBinder
{
    /// <summary>
    /// <inheritdoc cref="AsynchronousCliAction"/>
    /// </summary>
    public abstract class BindingHandler : AsynchronousCliAction
    {
        private BindingContext? _bindingContext;

        /// <summary>
        /// The binding context for the current invocation.
        /// </summary>
        public virtual BindingContext GetBindingContext(ParseResult parseResult)
            => _bindingContext ??= new BindingContext(parseResult);
    }
}
