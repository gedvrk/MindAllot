using MindAllot.Data.Enums;

namespace MindAllot.Data
{
    public class DailyTask : Task
    {
        public TaskState DailyState { get; set; }

        public int Completions { get; set; }
    }
}
