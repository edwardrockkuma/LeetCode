using LeetCode.SpecFlowXUnit.Drivers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace LeetCode.SpecFlowXUnit.Steps
{
    [Binding]
    public class LeetCodeTestSteps
    {
        private readonly Driver1 _driver;

        public LeetCodeTestSteps(Driver1 driver)
        {
            _driver = driver;
        }

        [Given(@"Number arrays: (.*)")]
        public void GivenNumberArrays(string nums)
        {
            _driver.CreateBackground(nums);
        }
        
        [Given(@"Taget is: (.*)")]
        public void GivenTagetIs(int p0)
        {
            _driver.SetTarget(p0);
        }
        
        [When(@"Run the test")]
        public void WhenRunTheTest()
        {
            _driver.ExecuteAction();
        }
        
        [Then(@"Result should be: (.*)")]
        public void ThenResultShouldBe(string results)
        {
            bool isOk = _driver.CheckCondition(results);
            Assert.True(isOk);
        }
    }
}
