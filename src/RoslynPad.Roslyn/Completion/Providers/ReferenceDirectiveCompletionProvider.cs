using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynPad.Roslyn.Completion.Providers;

[ExportCompletionProvider("ReferenceDirectiveCompletionProvider", LanguageNames.CSharp)]
internal class ReferenceDirectiveCompletionProvider : AbstractReferenceDirectiveCompletionProvider
{
    private static readonly CompletionItemRules s_rules = CompletionItemRules.Create(
        filterCharacterRules: [],
        commitCharacterRules: [],
        enterKeyRule: EnterKeyRule.Never,
        selectionBehavior: CompletionItemSelectionBehavior.SoftSelection);

    private CompletionItem CreateNuGetRoot()
        => CommonCompletionItem.Create(
            displayText: ReferenceDirectiveHelper.NuGetPrefix,
            displayTextSuffix: "",
            rules: s_rules,
            glyph: Microsoft.CodeAnalysis.Glyph.NuGet,
            sortText: "");

    protected override Task ProvideCompletionsAsync(CompletionContext context, string pathThroughLastSlash)
    {
        if (string.IsNullOrEmpty(pathThroughLastSlash))
        {
            context.AddItem(CreateNuGetRoot());
        }

        return base.ProvideCompletionsAsync(context, pathThroughLastSlash);
    }

    protected override bool TryGetStringLiteralToken(SyntaxTree tree, int position, out SyntaxToken stringLiteral, CancellationToken cancellationToken) =>
        tree.TryGetStringLiteralToken(position, SyntaxKind.ReferenceDirectiveTrivia, out stringLiteral, cancellationToken);
}
