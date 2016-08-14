using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
    /// <summary>
    /// A static class of Matchers to use with Assert.That()
    /// </summary>
    public static class Matchers
    {
        /// <summary>
        /// Creates a matcher that matches if the examined object matches ALL of the specified matchers.
        /// </summary>
        public static Matcher<T> AllOf<T>(params Matcher<T>[] matchers)
        {
            return new AllOf<T>(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined object matches ALL of the specified matchers.
        /// </summary>
        public static Matcher<T> AllOf<T>(IEnumerable<Matcher<T>> matchers)
        {
            return new AllOf<T>(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined object matches ANY of the specified matchers.
        /// </summary>
        public static Matcher<T> AnyOf<T>(params Matcher<T>[] matchers)
        {
            return new AnyOf<T>(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined object matches ANY of the specified matchers.
        /// </summary>
        public static Matcher<T> AnyOf<T>(IEnumerable<Matcher<T>> matchers)
        {
            return new AnyOf<T>(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches when both of the specified matchers match the examined object.
        /// </summary>
        public static CombinationBothMatcher<T> Both<T>(Matcher<T> matcher)
        {
            return new CombinationBothMatcher<T>(matcher);
        }

        /// <summary>
        /// Creates a matcher that matches when either of the specified matchers match the examined object.
        /// </summary>
        public static CombinationEitherMatcher<T> Either<T>(Matcher<T> matcher)
        {
            return new CombinationEitherMatcher<T>(matcher);
        }

        /// <summary>
        /// Wraps an existing matcher, overriding its description with that specified.  All other functions are
        /// delegated to the decorated matcher, including its mismatch description.
        /// </summary>
        /// <param name="description">The new description for the wrapped matcher</param>
        /// <param name="matcher">Matcher to wrap</param>
        /// <param name="paramz">Optional values to insert into the tokenised description</param>
        public static Matcher<T> DescribeAs<T>(string description, Matcher<T> matcher, params object[] paramz)
        {
            return new DescribedAs<T>(description, matcher, paramz);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields items that are all matched by the specified itemMatcher.
        /// </summary>
        public static Matcher<IEnumerable<T>> Every<T>(Matcher<T> itemMatcher)
        {
            return new Every<T>(itemMatcher);
        }

        /// <summary>
        /// Decorates another Matcher, retaining its behaviour, but allowing tests
        /// to be slightly more expressive.
        /// </summary>
        public static Matcher<T> Is<T>(Matcher<T> matcher)
        {
            return new Is<T>(matcher);
        }

        /// <summary>
        /// A shortcut to the frequently used <code>is(equalTo(value))</code>.
        /// </summary>
        public static Matcher<T> Is<T>(T value)
        {
            return new Is<T>(new IsEqual<T>(value));
        }

        /// <summary>
        /// Creates a matcher that always matches, regardless of the examined object, even if null.
        /// </summary>
        public static Matcher<T> IsAnything<T>()
        {
            return new IsAnything<T>();
        }

        /// <summary>
        /// Creates a matcher that always matches, regardless of the examined object, but describes
        /// itself with the specified description.
        /// </summary>
        public static Matcher<T> IsAnything<T>(string description)
        {
            return new IsAnything<T>(description);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> IsEnumerableContaining<T>(Matcher<T> matcher)
        {
            return new IsEnumerableContaining<T>(matcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> IsEnumerableContaining<T>(T item)
        {
            return new IsEnumerableContaining<T>(new IsEqual<T>(item));
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> HasItem<T>(Matcher<T> matcher)
        {
            return new IsEnumerableContaining<T>(matcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> HasItem<T>(T item)
        {
            return new IsEnumerableContaining<T>(new IsEqual<T>(item));
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when consecutive passes over the
        /// examined IEnumerables yield at least one item that is matched by the corresponding
        /// matcher from the specified <code>itemMatchers</code>.  Whilst matching, each traversal of
        /// the examined IEnumerables will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> HasItems<T>(params Matcher<T>[] matchers)
        {
            List<Matcher<IEnumerable<T>>> all = new List<Matcher<IEnumerable<T>>>(matchers.Length);

            foreach (Matcher<T> elementMatcher in matchers)
            {
                all.Add(new IsEnumerableContaining<T>(elementMatcher));
            }

            return new AllOf<IEnumerable<T>>(all);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when consecutive passes over the
        /// examined IEnumerables yield at least one item that is matched by the corresponding
        /// matcher from the specified <code>itemMatchers</code>.  Whilst matching, each traversal of
        /// the examined IEnumerables will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> HasItems<T>(params T[] values)
        {
            List<Matcher<IEnumerable<T>>> all = new List<Matcher<IEnumerable<T>>>(values.Length);

            foreach (T element in values)
            {
                all.Add(new IsEnumerableContaining<T>(new IsEqual<T>(element)));
            }

            return new AllOf<IEnumerable<T>>(all);
        }

        /// <summary>
        /// Creates a matcher that matches when the examined object is logically equal to the specified
        /// <code>operand</code>, as determined by calling the Equals() method on the 'examined' object.
        /// 
        /// If the specified operand is <code>null</code> then the created matcher will only match if
        /// the examined object's <code>equals</code> method returns <code>true</code> when passed a
        /// <code>null</code> (which would be a violation of the <code>equals</code> contract), unless the
        /// examined object itself is <code>null</code>, in which case the matcher will return a positive
        /// match.
        /// 
        /// The created matcher provides a special behaviour when examining <code>Array</code>s, whereby
        /// it will match if both the operand and the examined object are arrays of the same length and
        /// contain items that are equal to each other (according to the above rules) 'in the same indexes'.
        /// </summary>
        public static Matcher<T> EqualTo<T>(T item)
        {
            return new IsEqual<T>(item);
        }

        /// <summary>
        /// Creates a IsEqual matcher that does not enforce the values being
        /// compared to be of the same static type.
        /// </summary>
        public static Matcher<object> EqualToObject(object value)
        {
            return new IsEqual<object>(value);
        }

        /// <summary>
        /// Creates a matcher that matches when the examined object is an instance of the specified <code>type</code>,
        /// as determined by calling 'is' operator on that type, passing the
        /// the examined object.
        /// </summary>
        public static Matcher<T> Any<T>(Type type)
        {
            return new IsA<T>(type);
        }

        /// <summary>
        /// Creates a matcher that matches when the examined object is an instance of the specified <code>type</code>,
        /// as determined by calling 'is' operator on that type, passing the
        /// the examined object.
        /// </summary>
        public static Matcher<T> IsA<T>(Type type)
        {
            return new IsA<T>(type);
        }

        /// <summary>
        /// Creates a matcher that wraps an existing matcher, but inverts the logic by which
        /// it will match.
        /// </summary>
        public static Matcher<T> Not<T>(Matcher<T> matcher)
        {
            return new IsNot<T>(matcher);
        }

        /// <summary>
        /// Creates a matcher that wraps an existing matcher, but inverts the logic by which
        /// it will match to EqualTo()
        /// </summary>
        public static Matcher<T> Not<T>(T item)
        {
            return new IsNot<T>(new IsEqual<T>(item));
        }

        /// <summary>
        /// A shortcut to the frequently used <code>not(nullValue())</code>.
        /// </summary>
        public static Matcher<object> NotNullValue()
        {
            return new IsNot<object>(new IsNull<object>());
        }

        /// <summary>
        /// Creates a matcher that matches if an object is not null.
        /// </summary>
        public static Matcher<T> IsNotNull<T>()
        {
            return new IsNot<T>(new IsNull<T>());
        }

        /// <summary>
        /// Creates a matcher that matches if examined object is <code>null</code>.
        /// </summary>
        public static Matcher<T> IsNull<T>()
        {
            return new IsNull<T>();
        }

        /// <summary>
        /// Creates a matcher that matches if examined object is <code>null</code>.
        /// </summary>
        public static Matcher<object> IsNull()
        {
            return new IsNull<object>();
        }

        /// <summary>
        /// Creates a matcher that matches if examined object is <code>null</code>.
        /// </summary>
        public static Matcher<object> NullValue()
        {
            return new IsNull<object>();
        }

        /// <summary>
        /// Creates a matcher that matches only when the examined object is the same instance as
        /// the specified target object.
        /// </summary>
        public static Matcher<T> IsSameInstance<T>(T value)
        {
            return new IsSame<T>(value);
        }

        /// <summary>
        /// Creates a matcher that matches only when the examined object is the same instance as
        /// the specified target object.
        /// </summary>
        public static Matcher<T> TheInstance<T>(T value)
        {
            return new IsSame<T>(value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String contains the specified
        /// string anywhere.
        /// </summary>
        public static Matcher<string> Contains(string value)
        {
            return new StringContains(false, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String contains the specified
        /// string anywhere, ignoring case (invariant).
        /// </summary>
        public static Matcher<string> ContainsIgnoringCase(string value)
        {
            return new StringContains(true, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String starts with the specified string.
        /// </summary>
        public static Matcher<string> StartsWith(string value)
        {
            return new StringStartsWith(false, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String starts with the specified string,
        /// ignoring case (invariant).
        /// </summary>
        public static Matcher<string> StartsWithIgnoringCase(string value)
        {
            return new StringStartsWith(true, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String ends with the specified string.
        /// </summary>
        public static Matcher<string> EndsWith(string value)
        {
            return new StringEndsWith(false, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String ends with the specified string,
        /// ignoring case (invariant).
        /// </summary>
        public static Matcher<string> EndsWithIgnoringCase(string value)
        {
            return new StringEndsWith(true, value);
        }
    }
}
