﻿using System.Composition;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Host;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Structure;

namespace RoslynPad.Roslyn.Structure;

[ExportLanguageServiceFactory(typeof(IBlockStructureService), LanguageNames.CSharp), Shared]
internal class BlockStructureServiceFactory : ILanguageServiceFactory
{
    public ILanguageService CreateLanguageService(HostLanguageServices languageServices) => new BlockStructureServiceWrapper(languageServices.LanguageServices.GetRequiredService<BlockStructureService>());

    private class BlockStructureServiceWrapper(BlockStructureService service) : ILanguageService, IBlockStructureService
    {
        public async Task<BlockStructure> GetBlockStructureAsync(Document document, CancellationToken cancellationToken)
        {
            return new(await service.GetBlockStructureAsync(document, BlockStructureOptions.Default, cancellationToken).ConfigureAwait(false));
        }
    }
}
