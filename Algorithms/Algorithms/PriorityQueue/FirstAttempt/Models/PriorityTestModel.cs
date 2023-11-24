namespace Algorithms.PriorityQueue.FirstAttempt.Models
{
    public class PriorityTestModel : IComparable<PriorityTestModel>
    {
        public PriorityEnum Priority { get; init; }
        public PriorityTestModel(PriorityEnum priority)
        {
            Priority = priority;
        }

        public int CompareTo(PriorityTestModel? other)
        {
            // If other is null, then this object has higher priority.
            if (other == null)
            {
                return 1;
            }

            // If the other priority minus our priority is more than 0, we have priority.
            // If the other priority minus our priority is equal to 0, we have the same priority.
            // If the other priority minus our priority is less than 0, the other has priority.
            return other.Priority - Priority;
        }
    }
}
