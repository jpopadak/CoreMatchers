using System;
using System.Reflection;

namespace JPopadak.CoreMatchers.Internal
{
    /// <summary>
    /// The TypeSafe classes, and their descendants, need a mechanism to find out what type has been used as a parameter
    /// for the concrete matcher. Unfortunately, this type is lost during type erasure so we need to use reflection
    /// to get it back, by picking out the type of a known parameter to a known method.
    /// The catch is that, with bridging methods, this type is only visible in the class that actually implements
    /// the expected method, so the ReflectiveTypeFinder needs to be applied to that class or a subtype.
    ///
    /// For example, the abstract TypeSafeDiagnosingMatcher&lt;T&gt; defines an abstract method
    /// <code>protected abstract boolean matchesSafely(T item, Description mismatchDescription);</code>
    /// By default it uses <code>new ReflectiveTypeFinder("MatchesSafely", 2, 0); </code> to find the
    /// parameterised type. If we create a TypeSafeDiagnosingMatcher&lt;String&gt;, the type
    /// finder will return String.class.
    ///
    /// A FeatureMatcher is an abstract subclass of TypeSafeDiagnosingMatcher.
    /// Although it has a templated implementation of <code>MatchesSafely(&lt;T&gt;, IDescription);</code>, the
    /// actual run-time signature of this is <code>MatchesSafely(Object, Description);</code>. Instead,
    /// we must find the type by reflecting on the concrete implementation of
    /// <code>protected abstract U featureValueOf(T actual);</code>
    /// a method which is declared in FeatureMatcher.
    ///
    /// In short, use this to extract a type from a method in the leaf class of a templated class hierarchy.
    /// </summary>
    public class ReflectiveTypeFinder
    {
        private readonly String _methodName;
        private readonly int _expectedNumberOfParameters;
        private readonly int _typedParameter;

        public ReflectiveTypeFinder(String methodName, int expectedNumberOfParameters, int typedParameter)
        {
            _methodName = methodName;
            _expectedNumberOfParameters = expectedNumberOfParameters;
            _typedParameter = typedParameter;
        }

        public Type FindExpectedType(Type fromType)
        {
            for (Type t = fromType; t != typeof(object); t = t.DeclaringType)
            {
                foreach (MethodInfo method in t.GetMethods())
                {
                    if (canObtainExpectedTypeFrom(method))
                    {
                        return expectedTypeFrom(method);
                    }
                }
            }
            throw new MissingMethodException($"Cannot determine correct type for {_methodName}() method.");
        }

        /// <param name="method">The method to examine.</param>
        /// <returns>true if this method references the relevant type.</returns>
        private bool canObtainExpectedTypeFrom(MethodInfo method)
        {
            return method.Name.Equals(_methodName)
                   && method.GetParameters().Length == _expectedNumberOfParameters
                   && !method.IsAbstract;
        }

        /// <param name="method">The method from which to extract</param>
        private Type expectedTypeFrom(MethodInfo method)
        {
            return method.GetParameters()[_typedParameter].ParameterType;
        }
    }
}