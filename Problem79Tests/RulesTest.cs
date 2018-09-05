using System;
using Problem79;
using Xunit;

namespace Problem79Tests
{
    public class RulesTest
    {
        [Theory]
        [InlineData("123","123")]
        [InlineData("123","0102030")]
        [InlineData("123","01023")]
        [InlineData("123","1013023")]
        public void PassingRule(string ruleDefinition,string input)
        {

            var rule = new Rule(ruleDefinition);
            Assert.True(rule.DoesRulePass(input));
        }

        [Theory]
        [InlineData("123", "0302010")]
        [InlineData("123","444")]
        [InlineData("123","201013")]
        public void FailingRule(string ruleDefinition,string input)
        {
            var rule = new Rule(ruleDefinition);
            Assert.False(rule.DoesRulePass(input));
        }
    }
}
