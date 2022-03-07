using Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Rules.CoreRules;

namespace Mmu.WpfGraphApiTool.Infrastructure.Wpf.Validations.Rules
{
    public static class ValidationRuleFactory
    {
        public static StringNotNullOrEmptyRule StringNotNullOrEmpty()
        {
            return new StringNotNullOrEmptyRule();
        }
    }
}