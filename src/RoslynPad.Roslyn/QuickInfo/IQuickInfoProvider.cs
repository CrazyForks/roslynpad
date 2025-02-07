﻿using Microsoft.CodeAnalysis;

namespace RoslynPad.Roslyn.QuickInfo;

public interface IQuickInfoProvider
{
    Task<QuickInfoItem?> GetItemAsync(Document document, int position, CancellationToken cancellationToken = default);
}
