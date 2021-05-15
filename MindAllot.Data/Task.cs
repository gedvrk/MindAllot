using MindAllot.Data.Enums;
using System;

namespace MindAllot.Data
{
    public class Task
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public TaskType Type { get; set; }

        public TaskState State { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
