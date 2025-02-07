﻿using Microsoft.CodeAnalysis.Text;

#pragma warning disable CA1716
namespace RoslynPad.Roslyn.Structure;

public readonly struct BlockSpan
{
    internal BlockSpan(Microsoft.CodeAnalysis.Structure.BlockSpan inner)
    {
        TextSpan = inner.TextSpan;
        BannerText = inner.BannerText;

    }

    public TextSpan TextSpan { get; }
    public string BannerText { get; }
}
