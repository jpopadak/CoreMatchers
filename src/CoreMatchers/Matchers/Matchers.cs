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
        public static Matcher AllOf(params Matcher[] matchers)
        {
            return new AllOf(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined object matches ALL of the specified matchers.
        /// </summary>
        public static Matcher AllOf(IEnumerable<Matcher> matchers)
        {
            return new AllOf(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined object matches ANY of the specified matchers.
        /// </summary>
        public static Matcher AnyOf(params Matcher[] matchers)
        {
            return new AnyOf(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined object matches ANY of the specified matchers.
        /// </summary>
        public static Matcher AnyOf(IEnumerable<Matcher> matchers)
        {
            return new AnyOf(matchers);
        }

        /// <summary>
        /// Creates a matcher that matches when both of the specified matchers match the examined object.
        /// </summary>
        public static CombinationBothMatcher Both(Matcher matcher)
        {
            return new CombinationBothMatcher(matcher);
        }

        /// <summary>
        /// Creates a matcher that matches when either of the specified matchers match the examined object.
        /// </summary>
        public static CombinationEitherMatcher Either(Matcher matcher)
        {
            return new CombinationEitherMatcher(matcher);
        }

        /// <summary>
        /// Wraps an existing matcher, overriding its description with that specified.  All other functions are
        /// delegated to the decorated matcher, including its mismatch description.
        /// </summary>
        /// <param name="description">The new description for the wrapped matcher</param>
        /// <param name="matcher">Matcher to wrap</param>
        /// <param name="paramz">Optional values to insert into the tokenised description</param>
        public static Matcher DescribeAs(string description, Matcher matcher, params object[] paramz)
        {
            return new DescribedAs(description, matcher, paramz);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields items that are all matched by the specified itemMatcher.
        /// </summary>
        public static Matcher Every<T>(Matcher itemMatcher)
        {
            return new Every<T>(itemMatcher);
        }

        /// <summary>
        /// Decorates another Matcher, retaining its behaviour, but allowing tests
        /// to be slightly more expressive.
        /// </summary>
        public static Matcher Is(Matcher matcher)
        {
            return new Is(matcher);
        }

        /// <summary>
        /// A shortcut to the frequently used <code>is(equalTo(value))</code>.
        /// </summary>
        public static Matcher Is(object value)
        {
            return new Is(new IsEqual(value));
        }

        /// <summary>
        /// Creates a matcher that always matches, regardless of the examined object, even if null.
        /// </summary>
        public static Matcher Anything()
        {
            return new IsAnything();
        }

        /// <summary>
        /// Creates a matcher that always matches, regardless of the examined object, but describes
        /// itself with the specified description.
        /// </summary>
        public static Matcher Anything(string description)
        {
            return new IsAnything(description);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher IsEnumerableContaining<T>(Matcher matcher)
        {
            return new IsEnumerableContaining<T>(matcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher IsEnumerableContaining<T>(T item)
        {
            return new IsEnumerableContaining<T>(new IsEqual(item));
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher HasItem<T>(Matcher matcher)
        {
            return new IsEnumerableContaining<T>(matcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher HasItem<T>(T item)
        {
            return new IsEnumerableContaining<T>(new IsEqual(item));
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when consecutive passes over the
        /// examined IEnumerables yield at least one item that is matched by the corresponding
        /// matcher from the specified <code>itemMatchers</code>.  Whilst matching, each traversal of
        /// the examined IEnumerables will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher HasItems<T>(params Matcher[] matchers)
        {
            List<Matcher> all = new List<Matcher>(matchers.Length);

            foreach (Matcher elementMatcher in matchers)
            {
                all.Add(new IsEnumerableContaining<T>(elementMatcher));
            }

            return new AllOf(all);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when consecutive passes over the
        /// examined IEnumerables yield at least one item that is matched by the corresponding
        /// matcher from the specified <code>itemMatchers</code>.  Whilst matching, each traversal of
        /// the examined IEnumerables will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher HasItems<T>(params T[] values)
        {
            List<Matcher> all = new List<Matcher>(values.Length);

            foreach (T element in values)
            {
                all.Add(new IsEnumerableContaining<T>(new IsEqual(element)));
            }

            return new AllOf(all);
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
        public static Matcher EqualTo<T>(T item)
        {
            return new IsEqual(item);
        }

        /// <summary>
        /// Creates a IsEqual matcher that does not enforce the values being
        /// compared to be of the same static type.
        /// </summary>
        public static Matcher EqualToObject(object value)
        {
            return new IsEqual(value);
        }

        /// <summary>
        /// Creates a matcher that matches when the examined object is an instance of the specified <code>type</code>,
        /// as determined by calling 'is' operator on that type, passing the
        /// the examined object.
        /// </summary>
        public static Matcher Any(Type type)
        {
            return new IsA(type);
        }

        /// <summary>
        /// Creates a matcher that matches when the examined object is an instance of the specified <code>type</code>,
        /// as determined by calling 'is' operator on that type, passing the
        /// the examined object.
        /// </summary>
        public static Matcher IsA(Type type)
        {
            return new IsA(type);
        }

        /// <summary>
        /// Creates a matcher that matches when the examined object is an instance of the specified <code>type</code>,
        /// as determined by calling 'is' operator on that type, passing the
        /// the examined object.
        /// </summary>
        public static Matcher InstanceOf(Type type)
        {
            return new IsA(type);
        }

        /// <summary>
        /// Creates a matcher that wraps an existing matcher, but inverts the logic by which
        /// it will match.
        /// </summary>
        public static Matcher Not(Matcher matcher)
        {
            return new IsNot(matcher);
        }

        /// <summary>
        /// Creates a matcher that wraps an existing matcher, but inverts the logic by which
        /// it will match to EqualTo()
        /// </summary>
        public static Matcher Not<T>(T item)
        {
            return new IsNot(new IsEqual(item));
        }

        /// <summary>
        /// A shortcut to the frequently used <code>not(nullValue())</code>.
        /// </summary>
        public static Matcher NotNullValue()
        {
            return new IsNot(new IsNull());
        }

        /// <summary>
        /// Creates a matcher that matches if an object is not null.
        /// </summary>
        public static Matcher IsNotNull()
        {
            return new IsNot(new IsNull());
        }

        /// <summary>
        /// Creates a matcher that matches if examined object is <code>null</code>.
        /// </summary>
        public static Matcher IsNull()
        {
            return new IsNull();
        }
       
        /// <summary>
        /// Creates a matcher that matches if examined object is <code>null</code>.
        /// </summary>
        public static Matcher NullValue()
        {
            return new IsNull();
        }

        /// <summary>
        /// Creates a matcher that matches only when the examined object is the same instance as
        /// the specified target object.
        /// </summary>
        public static Matcher IsSameInstance<T>(T value)
        {
            return new IsSame(value);
        }

        /// <summary>
        /// Creates a matcher that matches only when the examined object is the same instance as
        /// the specified target object.
        /// </summary>
        public static Matcher TheInstance<T>(T value)
        {
            return new IsSame(value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String contains the specified
        /// string anywhere.
        /// </summary>
        public static Matcher Contains(string value)
        {
            return new StringContains(false, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String contains the specified
        /// string anywhere, ignoring case (invariant).
        /// </summary>
        public static Matcher ContainsIgnoringCase(string value)
        {
            return new StringContains(true, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String starts with the specified string.
        /// </summary>
        public static Matcher StartsWith(string value)
        {
            return new StringStartsWith(false, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String starts with the specified string,
        /// ignoring case (invariant).
        /// </summary>
        public static Matcher StartsWithIgnoringCase(string value)
        {
            return new StringStartsWith(true, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String ends with the specified string.
        /// </summary>
        public static Matcher EndsWith(string value)
        {
            return new StringEndsWith(false, value);
        }

        /// <summary>
        /// Creates a matcher that matches if the examined String ends with the specified string,
        /// ignoring case (invariant).
        /// </summary>
        public static Matcher EndsWithIgnoringCase(string value)
        {
            return new StringEndsWith(true, value);
        }

        /// <summary>
        /// Creates a matcher that matches the text against the given regular expression.
        /// </summary>
        public static Matcher MatchesRegex(string value)
        {
            return new StringRegularExpression(value);
        }
    }
}
