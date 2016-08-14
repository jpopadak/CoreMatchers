﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;
using Xunit;

namespace JPopadak.CoreMatchers.Matchers
{
    public class MatcherFacts
    {
        private const string DESCRIPTION = "Some Description";

        class MatcherSubClass<T> : Matcher<T>
        {
            public override void Describe(IDescription description)
            {
                description.AppendText(DESCRIPTION);
            }

            public override bool Matches(object actual)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void TestMatcherSubClass_ToString_CallsDescribeAndReturnsSomeDescription()
        {
            // Given
            MatcherSubClass<string> subClass = new MatcherSubClass<string>();

            // When
            var stringValue = subClass.ToString();

            // Then
            Xunit.Assert.Equal(DESCRIPTION, stringValue);
        }
    }
}
