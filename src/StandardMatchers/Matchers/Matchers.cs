using System.Collections.Generic;
using JPopadak.CoreMatchers.Matchers;
using JPopadak.StandardMatchers.Matchers.Collections;
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
        public static IMatcher<IDictionary<TKey, TValue>> HasEntry<TKey, TValue>(IMatcher<TKey> keyMatcher, IMatcher<TValue> valueMatcher)
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
    }
}
