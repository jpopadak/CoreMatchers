using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class CombinableFacts
    {
        private static readonly CombinationMatcher<int> EITHER_3_OR_4 = Either(EqualTo(3)).Or<int>(EqualTo(4));
        private static readonly CombinationMatcher<int> NOT_3_AND_NOT_4 = Both(Not(EqualTo(3))).And<int>(Not(EqualTo(4)));
        
        [Fact]
        public void NullValue_Either_IsNullSafe()
        {
            // When
            TestHelper.AssertNullSafe(EITHER_3_OR_4);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_Either_IsUnknownTypeSafe()
        {
            // When
            TestHelper.AssertUnknownTypeSafe(EITHER_3_OR_4);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_Both_IsNullSafe()
        {
            // When
            TestHelper.AssertNullSafe(NOT_3_AND_NOT_4);

            // Then - No Exception
        }

        [Fact]
        public void UnknownType_Both_IsUnknownTypeSafe()
        {
            // When
            TestHelper.AssertUnknownTypeSafe(NOT_3_AND_NOT_4);

            // Then - No Exception
        }

        [Fact]
        public void Not3AndNot4With2_Both_ReturnsTrue()
        {
            // Given
            int actual = 2;

            // When
            TestHelper.AssertMatches(NOT_3_AND_NOT_4, actual);

            // Then - No Exception
        }

        [Fact]
        public void Not3AndNot4With3_Both_ReturnsFalse()
        {
            // Given
            int actual = 3;

            // When
            TestHelper.AssertDoesNotMatch(NOT_3_AND_NOT_4, actual);

            // Then - No Exception
        }

        [Fact]
        public void Not3AndNot4And2With2_Both_ReturnsTrue()
        {
            // Given
            Matcher matcher = NOT_3_AND_NOT_4.And(EqualTo(2));
            int actual = 2;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Not3AndNot4And2With3_Both_ReturnsFalse()
        {
            // Given
            Matcher matcher = NOT_3_AND_NOT_4.And(EqualTo(2));
            int actual = 3;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Not3AndNot4_Both_DescribesItself()
        {
            // Given
            Matcher matcher = NOT_3_AND_NOT_4;

            // When
            TestHelper.AssertDescription("(not <3> and not <4>)", matcher);

            // Then - No Exception
        }

        [Fact]
        public void Not3AnNot4With3_Both_DescribesMismatch()
        {
            // Given
            Matcher matcher = NOT_3_AND_NOT_4;
            int actual = 3;

            // When
            TestHelper.AssertMismatchDescription("not <3> was <3>", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Num3Or4With3_Either_ReturnsTrue()
        {
            // Given
            Matcher matcher = EITHER_3_OR_4;
            int actual = 3;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Num3Or4With6_Either_ReturnsFalse()
        {
            // Given
            Matcher matcher = EITHER_3_OR_4;
            int actual = 6;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Num3Or4Or11With11_Either_ReturnsTrue()
        {
            // Given
            Matcher matcher = EITHER_3_OR_4.Or(EqualTo(11));
            int actual = 11;

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Num3Or4Or11With9_Either_ReturnsFalse()
        {
            // Given
            Matcher matcher = EITHER_3_OR_4.Or(EqualTo(11));
            int actual = 9;

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void Num3Or4_Either_DescribesItself()
        {
            // Given
            Matcher matcher = EITHER_3_OR_4;

            // When
            TestHelper.AssertDescription("(<3> or <4>)", matcher);

            // Then - No Exception
        }

        [Fact]
        public void Num3Or4_Either_DescribesMismatch()
        {
            // Given
            Matcher matcher = EITHER_3_OR_4;
            int actual = 6;

            // When
            TestHelper.AssertMismatchDescription("was <6>", matcher, actual);

            // Then - No Exception
        }
    }
}
