using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ValueTuplePerformance>(
                ManualConfig.Create(DefaultConfig.Instance)
                    .With(Job.RyuJitX64)
                    .With(Job.LegacyJitX64)
                    .With(Job.LegacyJitX86));
        }
    }

    public class ValueTuplePerformance
    {
        private ValueTuple<int, float, bool, decimal> a = ValueTuple.Create(10, 1, true, 0.1m);
        private ValueTuple<int, float, bool, decimal> b = ValueTuple.Create(11, 2, false, 0.2m);

        private ValueTupleCached<int, float, bool, decimal> a1 = new ValueTupleCached<int, float, bool, decimal>(10, 1, true, 0.1m);
        private ValueTupleCached<int, float, bool, decimal> b1 = new ValueTupleCached<int, float, bool, decimal>(11, 2, false, 0.2m);

        public ValueTuplePerformance()
        {
        }

        [Benchmark]
        public void Equals()
        {
            a.Equals(b);
        }

        [Benchmark]
        public void GetHashCode()
        {
            b.GetHashCode();
        }

        [Benchmark]
        public void EqualsCached()
        {
            a1.Equals(b1);
        }

        [Benchmark]
        public void GetHashCodeCached()
        {
            b1.GetHashCode();
        }
    }

    /// <summary>
    /// Represents a 4-tuple, or quadruple, as a value type.
    /// </summary>
    /// <typeparam name="T1">The type of the tuple's first component.</typeparam>
    /// <typeparam name="T2">The type of the tuple's second component.</typeparam>
    /// <typeparam name="T3">The type of the tuple's third component.</typeparam>
    /// <typeparam name="T4">The type of the tuple's fourth component.</typeparam>
    [StructLayout(LayoutKind.Auto)]
    public struct ValueTupleCached<T1, T2, T3, T4>
        : IEquatable<ValueTupleCached<T1, T2, T3, T4>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTupleCached<T1, T2, T3, T4>>
    {
        internal static readonly EqualityComparer<T1> T1Comparer = EqualityComparer<T1>.Default;
        internal static readonly EqualityComparer<T2> T2Comparer = EqualityComparer<T2>.Default;
        internal static readonly EqualityComparer<T3> T3Comparer = EqualityComparer<T3>.Default;
        internal static readonly EqualityComparer<T4> T4Comparer = EqualityComparer<T4>.Default;

        /// <summary>
        /// The current <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance's first component.
        /// </summary>
        public T1 Item1;
        /// <summary>
        /// The current <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance's second component.
        /// </summary>
        public T2 Item2;
        /// <summary>
        /// The current <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance's third component.
        /// </summary>
        public T3 Item3;
        /// <summary>
        /// The current <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance's fourth component.
        /// </summary>
        public T4 Item4;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueTupleCached{T1, T2, T3, T4}"/> value type.
        /// </summary>
        /// <param name="item1">The value of the tuple's first component.</param>
        /// <param name="item2">The value of the tuple's second component.</param>
        /// <param name="item3">The value of the tuple's third component.</param>
        /// <param name="item4">The value of the tuple's fourth component.</param>
        public ValueTupleCached(T1 item1, T2 item2, T3 item3, T4 item4)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
            Item4 = item4;
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance is equal to a specified object.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the specified object; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The <paramref name="obj"/> parameter is considered to be equal to the current instance under the following conditions:
        /// <list type="bullet">
        ///     <item><description>It is a <see cref="ValueTupleCached{T1, T2, T3, T4}"/> value type.</description></item>
        ///     <item><description>Its components are of the same types as those of the current instance.</description></item>
        ///     <item><description>Its components are equal to those of the current instance. Equality is determined by the default object equality comparer for each component.</description></item>
        /// </list>
        /// </remarks>
        public override bool Equals(object obj)
        {
            return obj is ValueTupleCached<T1, T2, T3, T4> && Equals((ValueTupleCached<T1, T2, T3, T4>)obj);
        }

        /// <summary>
        /// Returns a value that indicates whether the current <see cref="ValueTupleCached{T1, T2, T3, T4}"/>
        /// instance is equal to a specified <see cref="ValueTupleCached{T1, T2, T3, T4}"/>.
        /// </summary>
        /// <param name="other">The tuple to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the specified tuple; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// The <paramref name="other"/> parameter is considered to be equal to the current instance if each of its fields
        /// are equal to that of the current instance, using the default comparer for that field's type.
        /// </remarks>
        public bool Equals(ValueTupleCached<T1, T2, T3, T4> other)
        {
            return T1Comparer.Equals(Item1, other.Item1)
                && T2Comparer.Equals(Item2, other.Item2)
                && T3Comparer.Equals(Item3, other.Item3)
                && T4Comparer.Equals(Item4, other.Item4);
        }

        bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
        {
            if (other == null || !(other is ValueTupleCached<T1, T2, T3, T4>)) return false;

            var objTuple = (ValueTupleCached<T1, T2, T3, T4>)other;

            return comparer.Equals(Item1, objTuple.Item1)
                && comparer.Equals(Item2, objTuple.Item2)
                && comparer.Equals(Item3, objTuple.Item3)
                && comparer.Equals(Item4, objTuple.Item4);
        }

        int IComparable.CompareTo(object other)
        {
            if (other == null) return 1;

            if (!(other is ValueTupleCached<T1, T2, T3, T4>))
            {
                throw new ArgumentException("", nameof(other));
            }

            return CompareTo((ValueTupleCached<T1, T2, T3, T4>)other);
        }

        /// <summary>Compares this instance to a specified instance and returns an indication of their relative values.</summary>
        /// <param name="other">An instance to compare.</param>
        /// <returns>
        /// A signed number indicating the relative values of this instance and <paramref name="other"/>.
        /// Returns less than zero if this instance is less than <paramref name="other"/>, zero if this
        /// instance is equal to <paramref name="other"/>, and greater than zero if this instance is greater 
        /// than <paramref name="other"/>.
        /// </returns>
        public int CompareTo(ValueTupleCached<T1, T2, T3, T4> other)
        {
            int c = Comparer<T1>.Default.Compare(Item1, other.Item1);
            if (c != 0) return c;

            c = Comparer<T2>.Default.Compare(Item2, other.Item2);
            if (c != 0) return c;

            c = Comparer<T3>.Default.Compare(Item3, other.Item3);
            if (c != 0) return c;

            return Comparer<T4>.Default.Compare(Item4, other.Item4);
        }

        int IStructuralComparable.CompareTo(object other, IComparer comparer)
        {
            if (other == null) return 1;

            if (!(other is ValueTupleCached<T1, T2, T3, T4>))
            {
                throw new ArgumentException("");
            }

            var objTuple = (ValueTupleCached<T1, T2, T3, T4>)other;

            int c = comparer.Compare(Item1, objTuple.Item1);
            if (c != 0) return c;

            c = comparer.Compare(Item2, objTuple.Item2);
            if (c != 0) return c;

            c = comparer.Compare(Item3, objTuple.Item3);
            if (c != 0) return c;

            return comparer.Compare(Item4, objTuple.Item4);
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return CombineHashCodes(T1Comparer.GetHashCode(Item1), T2Comparer.GetHashCode(Item2), T3Comparer.GetHashCode(Item3), T4Comparer.GetHashCode(Item4));
        }

        int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
        {
            return GetHashCodeCore(comparer);
        }

        private int GetHashCodeCore(IEqualityComparer comparer)
        {
            return CombineHashCodes(comparer.GetHashCode(Item1),
                                               comparer.GetHashCode(Item2),
                                               comparer.GetHashCode(Item3),
                                               comparer.GetHashCode(Item4));
        }

        /// <summary>
        /// Returns a string that represents the value of this <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance.
        /// </summary>
        /// <returns>The string representation of this <see cref="ValueTupleCached{T1, T2, T3, T4}"/> instance.</returns>
        /// <remarks>
        /// The string returned by this method takes the form <c>(Item1, Item2, Item3, Item4)</c>.
        /// If any field value is <see langword="null"/>, it is represented as <see cref="String.Empty"/>.
        /// </remarks>
        public override string ToString()
        {
            return "(" + Item1?.ToString() + ", " + Item2?.ToString() + ", " + Item3?.ToString() + ", " + Item4?.ToString() + ")";
        }

        internal static int CombineHashCodes(int h1, int h2)
        {
            return HashHelpers.Combine(h1, h2);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2), h3);
        }

        internal static int CombineHashCodes(int h1, int h2, int h3, int h4)
        {
            return CombineHashCodes(CombineHashCodes(h1, h2, h3), h4);
        }
    }

    internal static class HashHelpers
    {
        public static int Combine(int h1, int h2)
        {
            uint num = (uint)(h1 << 5 | (int)((uint)h1 >> 27));
            return (int)(num + (uint)h1 ^ (uint)h2);
        }
    }
}
