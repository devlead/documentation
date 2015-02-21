namespace Docs.Compiler.Core
{
    public interface IContentGenerator
    {
        int SortOrder { get; }
        void Generate(CompilerConfiguration configuration, Content parent);
    }
}
