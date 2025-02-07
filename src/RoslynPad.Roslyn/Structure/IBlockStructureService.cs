﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;

namespace RoslynPad.Roslyn.Structure;

public interface IBlockStructureService : ILanguageService
{
    Task<BlockStructure> GetBlockStructureAsync(Document document, CancellationToken cancellationToken = default);
}
