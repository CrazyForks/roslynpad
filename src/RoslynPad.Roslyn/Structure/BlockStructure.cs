﻿using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace RoslynPad.Roslyn.Structure;

public sealed class BlockStructure
{
    internal BlockStructure(Microsoft.CodeAnalysis.Structure.BlockStructure inner)
    {
        Spans = inner.Spans.SelectAsArray(span => new BlockSpan(span));
    }

    public ImmutableArray<BlockSpan> Spans { get; }
}
