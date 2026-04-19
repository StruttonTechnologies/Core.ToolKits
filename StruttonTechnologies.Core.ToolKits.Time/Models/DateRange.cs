namespace StruttonTechnologies.Core.ToolKit.Time.Models
{
    /// <summary>
    /// Represents an inclusive start / exclusive end date range.
    /// </summary>
    public readonly record struct DateRange
    {
        public DateRange(DateTime start, DateTime end)
        {
            if (end < start)
            {
                throw new ArgumentOutOfRangeException(nameof(end), "End must be greater than or equal to Start.");
            }

            Start = start;
            End = end;
        }

        public DateTime Start { get; init; }
        public DateTime End { get; init; }

        public TimeSpan Duration => End - Start;

        public bool Contains(DateTime value)
        {
            return value >= Start && value < End;
        }

        public bool Overlaps(DateRange other)
        {
            return Start < other.End && End > other.Start;
        }

        public DateRange? Intersect(DateRange other)
        {
            DateTime start = Start > other.Start ? Start : other.Start;
            DateTime end = End < other.End ? End : other.End;

            return end <= start ? null : new DateRange(start, end);
        }

        public static IReadOnlyList<DateRange> MergeOverlaps(IEnumerable<DateRange> ranges)
        {
            ArgumentNullException.ThrowIfNull(ranges);

            List<DateRange> ordered = ranges.OrderBy(static r => r.Start).ToList();
            if (ordered.Count == 0)
            {
                return Array.Empty<DateRange>();
            }

            List<DateRange> merged = [ordered[0]];

            for (var index = 1; index < ordered.Count; index++)
            {
                DateRange current = ordered[index];
                DateRange previous = merged[^1];

                if (current.Start <= previous.End)
                {
                    merged[^1] = new DateRange(previous.Start, current.End > previous.End ? current.End : previous.End);
                    continue;
                }

                merged.Add(current);
            }

            return merged;
        }
    }
}
