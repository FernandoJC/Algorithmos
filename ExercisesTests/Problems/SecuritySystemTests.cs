using Exercises;
using System;
using Xunit;

namespace ExercisesTests
{
    public class SecuritySystemTests
    {
        [Fact]
        public void Test1()
        {
            var securitySystem = new SecuritySystem();
            securitySystem.CheckEntrance();
        }
    }
}
