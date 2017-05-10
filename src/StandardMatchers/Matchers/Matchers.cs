using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JPopadak.CoreMatchers.Matchers;
using JPopadak.StandardMatchers.Matchers.Collections;
using JPopadak.StandardMatchers.Matchers.Number;
using JPopadak.StandardMatchers.Matchers.Text;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers
{
    public static class Matchers
    {
        /// <summary>
        /// Creates a matcher that matches arrays whose elements are satisfied by the specified matchers. Matches
        /// positively only if the number of matchers specified is equal to the length of the examined array and
        /// each matcher[i] is satisfied by array[i].
        /// <p>
        /// Exmaple: Assert.That(new int[]{1,2,3}, Is(Array(EqualTo(1), EqualTo(2), EqualTo(3))))
        /// </p>
        /// </summary>
        /// <param name="matchers">The matchers that the elements of examined arrays should satisfy</param>
        public static IMatcher<T[]> Array<T>(params IMatcher<T>[] matchers)
        {
            return new IsArray<T>(matchers);
        }

        /// <summary>
        /// Creates a matcher for arrays that matches when the length of the array satisfies the specified matcher.
        /// </summary>
        /// <param name="sizeMatcher">A matcher for the length of an examined array</param>
        public static IMatcher<T[]> ArrayWithSize<T>(IMatcher<int> sizeMatcher)
        {
            return new IsArrayWithSize<T>(sizeMatcher);
        }

        /// <summary>
        /// Creates a matcher for arrays that matches when the length of the array satisfies the specified matcher.
        /// </summary>
        public static IMatcher<T[]> ArrayWithSize<T>(int size)
        {
            return new IsArrayWithSize<T>(new IsEqual<int>(size));
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string contains zero or
        /// more whitespace characters and nothing else.
        /// </summary>
        public static IMatcher<string> BlankString()
        {
            return new IsBlankString();
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string contains zero or
        /// more whitespace characters or is a null value.
        /// </summary>
        public static IMatcher<string> BlankOrNullString()
        {
            return new AnyOf<string>(new IsNull<string>(), new IsBlankString());
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that match when a single pass over the
        /// examined IEnumerable yields a single item that satisfies the specified matcher.
        /// For a positive match, the examined iterable must only yield one item.
        /// </summary>
        public static IMatcher<IEnumerable<T>> Contains<T>(IMatcher<T> matcher)
        {
            return new IsEnumerableContainingInOrder<T>(new List<IMatcher<T>> { matcher });
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that match when a single pass over the
        /// examined IEnumerable yields a series of items, each logically equal to the
        /// corresponding item in the specified items.  For a positive match, the examined iterable
        /// must be of the same length as the number of specified items.
        /// </summary>
        public static IMatcher<IEnumerable<T>> ContainsInOrder<T>(params T[] items)
        {
            return new IsEnumerableContainingInOrder<T>(EqualToArray(items));
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string contains (ordinally) all the
        /// specified substrings, considering the order of their appearance.
        /// </summary>
        public static IMatcher<string> ContainsStringsInOrder(params string[] substrings)
        {
            return new StringContainsInOrder(substrings);
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string contains (ordinally or using the
        /// current culture) all the specified substrings, considering the order of their appearance.
        /// </summary>
        /// <param name="useCurrentCulture">If true, use the current culture to compare each substring.</param>
        /// <param name="substrings">Strings to find in order</param>
        public static IMatcher<string> ContainsStringsInOrder(bool useCurrentCulture, params string[] substrings)
        {
            return new StringContainsInOrder(useCurrentCulture, substrings);
        }

        /// <summary>
        /// Creates a matcher that matches the dictionary's size against the given matcher.
        /// </summary>
        public static IMatcher<IDictionary<TKey, TValue>> DictionaryWithSize<TKey, TValue>(IMatcher<int> sizeMatcher)
        {
            return new IsDictionaryWithSize<TKey, TValue>(sizeMatcher);
        }

        /// <summary>
        /// Creates a matcher that matches the dictionary's size against the given size.
        /// </summary>
        public static IMatcher<IDictionary<TKey, TValue>> DictionaryWithSize<TKey, TValue>(int size)
        {
            return new IsDictionaryWithSize<TKey, TValue>(new IsEqual<int>(size));
        }

        /// <summary>
        /// Creates a matcher for Iterables matching examined
        /// iterables that yield no items.
        /// For example:
        /// <code>Assert.That(new List&lt;String&gt;(), Is(EmptyEnumerable()))</code>
        /// </summary>
        public static IMatcher<IEnumerable<T>> EmptyEnumerable<T>()
        {
            return new IsEmptyEnumerable<T>();
        }

        /// <summary>
        /// Creates a matcher for arrays that matches when the length of the array is zero.
        /// </summary>
        public static IMatcher<T[]> EmptyArray<T>()
        {
            return new DescribedAs<T[]>("an empty array", new IsArrayWithSize<T>(new IsEqual<int>(0)));
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string has zero length
        /// or the string is null.
        /// </summary>
        public static IMatcher<string> EmptyOrNullString()
        {
            return new AnyOf<string>(NullValue<string>(), EmptyString());
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string has zero length.
        /// </summary>
        public static IMatcher<string> EmptyString()
        {
            return new IsEmptyString();
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when a single pass over the examined Enumerable yields
        /// an item count that satisifes the specified matcher.
        /// For example:
        /// <code>Assert.That(new List&lt;string&gt; {"foo", "bar"}, EnumerableWithSize(EqualTo(2)))</code>
        /// </summary>
        /// <param name="sizeMatcher">A matcher for the number of items that should be yielded by an examined IEnumerable.</param>
        public static IMatcher<IEnumerable<T>> EnumerableWithSize<T>(IMatcher<int> sizeMatcher)
        {
            return new IsEnumerableWithSize<T>(sizeMatcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when a single pass over the examined Enumerable yields
        /// an item count that is equal to the specified size argument.
        /// For example:
        /// <code>Assert.That(new List&lt;string&gt; {"foo", "bar"}, EnumerableWithSize(2))</code>
        /// </summary>
        /// <param name="size">The number of items that should be yielded by an examined IEnumerable.</param>
        public static IMatcher<IEnumerable<T>> EnumerableWithSize<T>(int size)
        {
            return new IsEnumerableWithSize<T>(EqualTo(size));
        }

        /// <summary>
        /// Creates an array of EqualTo matchers for each item in items.
        /// </summary>
        public static IEnumerable<IMatcher<T>> EqualToArray<T>(params T[] items)
        {
            return items.Select(EqualTo);
        }

        /// <summary>
        /// Creates a string / IEnumerable&lt;char&gt; matcher that matches when the examined string is equal to
        /// the specified expectedString, when whitespace differences are (mostly) ignored.  To be
        /// exact, the following whitespace rules are applied:
        /// (1) all leading and trailing whitespace of both the expectedString and the examined string are ignored
        /// (2) any remaining whitespace, appearing within either string, is collapsed to a single space before comparison
        /// </summary>
        public static IMatcher<IEnumerable<char>> EqualToCompressingWhiteSpace(IEnumerable<char> value)
        {
            return new IsEqualCompressingWhiteSpace(value);
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string is equal ignoring case ordinally.
        /// </summary>
        /// <param name="expected">Expected string</param>
        public static IMatcher<string> EqualToIgnoringCase(string expected)
        {
            return new IsEqualIgnoringCase(expected);
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string is equal ignoring case either ordinally
        /// or using the current culture.
        /// </summary>
        /// <param name="expected">Expected string</param>
        /// <param name="includeCurrentCulture">If true, the string will be compared using the current culture (international languages).</param>
        public static IMatcher<string> EqualToIgnoringCase(bool includeCurrentCulture, string expected)
        {
            return new IsEqualIgnoringCase(expected, includeCurrentCulture);
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one entry
        /// whose key satisfies the specified keyMatcher <b>and</b> whose value satisfies the specified valueMatcher.
        /// For example:
        /// <code>Assert.That(myDictionary, HasEntry(EqualTo("bar"), EqualTo("foo")))</code>
        /// </summary>
        ///
        /// <param name="keyMatcher">
        ///     The key matcher that, in combination with the valueMatcher, must be satisfied by at least one entry.
        /// </param>
        /// <param name="valueMatcher">
        ///     The value matcher that, in combination with the keyMatcher, must be satisfied by at least one entry.
        /// </param>
        public static IMatcher<IDictionary<TKey, TValue>> HasEntry<TKey, TValue>(IMatcher<TKey> keyMatcher,
            IMatcher<TValue> valueMatcher)
        {
            return new IsDictionaryContaining<TKey, TValue>(keyMatcher, valueMatcher);
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one entry
        /// whose key equals the specified key <b>and</b> whose value equals the specified value.
        /// For example:
        /// <code>Assert.That(myDictionary, HasEntry(EqualTo("bar"), EqualTo("foo")))</code>
        /// </summary>
        ///
        /// <param name="key">The key that, in combination with the value, must describe at least one entry.</param>
        /// <param name="value">The value that, in combination with the key, must describe at least one entry.</param>
        public static IMatcher<IDictionary<TKey, TValue>> HasEntry<TKey, TValue>(TKey key, TValue value)
        {
            return new IsDictionaryContaining<TKey, TValue>(EqualTo(key), EqualTo(value));
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one key
        /// that satisfies the specified matcher.
        /// </summary>
        ///
        /// <param name="keyMatcher">The matcher that must be satisfied by at least one key.</param>
        public static IMatcher<IDictionary<TKey, TValue>> HasKey<TKey, TValue>(IMatcher<TKey> keyMatcher)
        {
            return new IsDictionaryContaining<TKey, TValue>(keyMatcher, Anything<TValue>());
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one key
        /// that equals the specified key.
        /// </summary>
        ///
        /// <param name="key">The key that satisfying IDictionarys must contain</param>
        public static IMatcher<IDictionary<TKey, TValue>> HasKey<TKey, TValue>(TKey key)
        {
            return new IsDictionaryContaining<TKey, TValue>(EqualTo(key), Anything<TValue>());
        }

        /// <summary>
        /// Creates a matcher that matches any examined object when passed to
        /// <see cref="Convert.ToString()">Convert.ToString()</see> returns a value that satisfies the
        /// specified matcher. If the value is <code>null</code>, the
        /// resulting match will be made against the string value "null".
        /// </summary>
        public static IMatcher<string> HasToString(IMatcher<string> matcher)
        {
            return new HasToString(matcher);
        }

        /// <summary>
        /// Creates an EqualTo matcher that matches any examined object when passed to
        /// <see cref="Convert.ToString()">Convert.ToString()</see> returns a value that satisfies the
        /// specified matcher. If the value is <code>null</code>, the
        /// resulting match will be made against the string value "null".
        /// </summary>
        public static IMatcher<string> HasToString(string value)
        {
            return new HasToString(EqualTo(value));
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one value
        /// that satisfies the specified matcher.
        /// </summary>
        ///
        /// <param name="valueMatcher">The matcher that must be satisfied by at least one value.</param>
        public static IMatcher<IDictionary<TKey, TValue>> HasValue<TKey, TValue>(IMatcher<TValue> valueMatcher)
        {
            return new IsDictionaryContaining<TKey, TValue>(Anything<TKey>(), valueMatcher);
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one value
        /// that equals the specified value.
        /// </summary>
        ///
        /// <param name="value">The key that satisfying IDictionarys must contain</param>
        public static IMatcher<IDictionary<TKey, TValue>> HasValue<TKey, TValue>(TValue value)
        {
            return new IsDictionaryContaining<TKey, TValue>(Anything<TKey>(), EqualTo(value));
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string has zero length
        /// or the string is null.
        /// </summary>
        public static IMatcher<string> IsEmptyOrNullString()
        {
            return new AnyOf<string>(NullValue<string>(), EmptyString());
        }

        /// <summary>
        /// Creates a string matcher that matches when the examined string has zero length.
        /// </summary>
        public static IMatcher<string> IsEmptyString()
        {
            return new IsEmptyString();
        }

        /// <summary>
        /// Creates a double matcher that matches when the examined double is not a number.
        /// </summary>
        public static IMatcher<double> NotANumber()
        {
            return new IsNaN();
        }
    }
}
