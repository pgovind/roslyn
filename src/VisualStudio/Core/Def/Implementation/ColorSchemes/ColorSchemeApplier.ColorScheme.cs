﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable enable

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.LanguageServices.ColorSchemes
{
    internal partial class ColorSchemeApplier
    {
        /// <summary>
        /// A ColorScheme contains classification colors for a set of VS themes.
        /// </summary>
        private class ColorScheme
        {
            public ImmutableArray<ColorTheme> Themes { get; }

            public ColorScheme(ImmutableArray<ColorTheme> themes)
            {
                Themes = themes;
            }
        }

        private class ColorTheme
        {
            public string Name { get; }
            public Guid Guid { get; }
            public ColorCategory Category { get; }

            public ColorTheme(string name, Guid guid, ColorCategory category)
            {
                Name = name;
                Guid = guid;
                Category = category;
            }
        }

        private class ColorCategory
        {
            public string Name { get; }
            public Guid Guid { get; }
            public ImmutableArray<ColorItem> Colors { get; }

            public ColorCategory(string name, Guid guid, ImmutableArray<ColorItem> colors)
            {
                Name = name;
                Guid = guid;
                Colors = colors;
            }
        }

        private class ColorItem
        {
            public string Name { get; }
            public int BackgroundType { get; }
            public uint? Background { get; }
            public int ForegroundType { get; }
            public uint? Foreground { get; }

            public ColorItem(string name, int backgroundType, uint? background, int foregroundType, uint? foreground)
            {
                Name = name;

                Debug.Assert(backgroundType == (int)__VSCOLORTYPE.CT_INVALID || background.HasValue);
                BackgroundType = backgroundType;
                Background = background;

                Debug.Assert(foregroundType == (int)__VSCOLORTYPE.CT_INVALID || foreground.HasValue);
                ForegroundType = foregroundType;
                Foreground = foreground;
            }
        }
    }
}
