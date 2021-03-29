/*
    Source: life

    Solution Author: Anderson Urbano

    Problem:
        Create a data structure with 2 basic operation, first is to add an integer range
        and a value object. Second operation is given an index retrieve the objects for
        all ranges that have the index. The structure must make an internal separation
        of intersecting ranges.
*/

using System;
using System.Collections.Generic;

namespace Challenges.Solutions.RangeDictionary
{
    public class RangeDictionary<T>
    {
        #region Public Interface
        public RangeDictionary()
        {
            _ranges = new List<Range<T>>();
        }

        public ISet<T> GetValues(int index)
        {
            ISet<T> values = new HashSet<T>();

            lock (_ranges)
            {
                foreach (var range in _ranges)
                {
                    if (index >= range.StartIndex && index <= range.EndIndex)
                    {
                        values = range.Values;
                        break;
                    }
                }
            }

            return values;
        }

        public void AddRange(int singleIndex, T value)
        {
            this.AddRange(singleIndex, singleIndex, value);
        }

        public void AddRange(int startIndex, int endIndex, T value)
        {
            Range<T> input = new Range<T>()
            {
                StartIndex = startIndex,
                EndIndex = endIndex,
                Values = new HashSet<T>() { value }
            };

            lock (_ranges)
            {
                this.AddRange(input);
            }
        }
        #endregion

        #region Private Implementation
        private class Range<TValue>
        {
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public ISet<TValue> Values { get; set; }

            public bool Intersects(Range<TValue> range)
            {
                return !(EndIndex < range.StartIndex || StartIndex > range.EndIndex);
            }

            public void AddValues(ICollection<TValue> values)
            {
                foreach (var v in values)
                    Values.Add(v);
            }
        }

        private List<Range<T>> _ranges;

        private void AddRange(Range<T> input)
        {
            Stack<Range<T>> rangesToBeAdded = new Stack<Range<T>>();
            rangesToBeAdded.Push(input);

            while (rangesToBeAdded.Count > 0)
            {
                Range<T> top = rangesToBeAdded.Pop();

                Range<T> intersectedRange = null;
                foreach (var r in _ranges)
                {
                    if (top.Intersects(r))
                    {
                        intersectedRange = r;
                        break;
                    }
                }

                if (intersectedRange != null)
                {
                    SplitIntersection(top, intersectedRange, out List<Range<T>> leftovers, out List<Range<T>> newRanges);

                    _ranges.Remove(intersectedRange);
                    _ranges.AddRange(newRanges);
                    foreach (var r in leftovers)
                        rangesToBeAdded.Push(r);
                }
                else
                    _ranges.Add(top);
            }
        }

        private void SplitIntersection(Range<T> top, Range<T> intersected, out List<Range<T>> leftovers, out List<Range<T>> newRanges)
        {
            leftovers = new List<Range<T>>();
            newRanges = new List<Range<T>>();

            Range<T> left = new Range<T>()
            {
                StartIndex = Math.Min(top.StartIndex, intersected.StartIndex),
                EndIndex = Math.Max(top.StartIndex, intersected.StartIndex) - 1,
                Values = new HashSet<T>()
            };

            Range<T> right = new Range<T>()
            {
                StartIndex = Math.Min(top.EndIndex, intersected.EndIndex) + 1,
                EndIndex = Math.Max(top.EndIndex, intersected.EndIndex),
                Values = new HashSet<T>()
            };

            Range<T> intersection = new Range<T>()
            {
                StartIndex = Math.Max(top.StartIndex, intersected.StartIndex),
                EndIndex = Math.Min(top.EndIndex, intersected.EndIndex),
                Values = new HashSet<T>()
            };

            //create intersection
            intersection.AddValues(top.Values);
            intersection.AddValues(intersected.Values);
            newRanges.Add(intersection);

            //top starts before
            if (top.StartIndex < intersected.StartIndex)
            {
                left.AddValues(top.Values);
                leftovers.Add(left);
            }
            //intersected starts before
            else if (intersected.StartIndex < top.StartIndex)
            {
                left.AddValues(intersected.Values);
                newRanges.Add(left);
            }

            //top ends after
            if (top.EndIndex > intersected.EndIndex)
            {
                right.AddValues(top.Values);
                leftovers.Add(right);
            }
            //intersected ends after
            else if (intersected.EndIndex > top.EndIndex)
            {
                right.AddValues(intersected.Values);
                newRanges.Add(right);
            }
        }
        #endregion
    }
}
