using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPopadak.CoreMatchers.Matchers
{
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
            return new AllOf<T>(matchers.ToArray<Matcher<T>>());
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
            return new AnyOf<T>(matchers.ToArray<Matcher<T>>());
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
            return Is(EqualTo(value));
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
            return IsEnumerableContaining(EqualTo(item));
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> HasItem<T>(Matcher<T> matcher)
        {
            return IsEnumerableContaining(matcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that only matches when a single pass over the
        /// examined IEnumerable yields at least one item that is matched by the specified
        /// <code>itemMatcher</code>. Whilst matching, the traversal of the examined IEnumerable
        /// will stop as soon as a matching item is found.
        /// </summary>
        public static Matcher<IEnumerable<T>> HasItem<T>(T item)
        {
            return HasItem(EqualTo(item));
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

            return AllOf(all);
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
                all.Add(HasItem<T>(element));
            }

            return AllOf(all);
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
        /// Creates an {@link org.hamcrest.core.IsEqual} matcher that does not enforce the values being
        /// compared to be of the same static type.
        /// </summary>
        public static Matcher<object> EqualToObject(object value)
        {
            return new IsEqual<object>(value);
        }
    }
}
