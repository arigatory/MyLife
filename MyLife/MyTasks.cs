using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLife
{
    class MyTasks
    {
        private bool sorted = false;
        private int _current_i = 0;
        private int _current_j = 1;
        private int _max_index = 0;

        public List<MyTask> all { get; set; }
        public MyTasks()
        {
            all = new List<MyTask>();
            all.Add(new MyTask("Test 1!"));
        }
        public (MyTask,MyTask) SortStepStart()
        {
            MyTask t1 = all[_current_i];
            MyTask t2 = all[_current_j];
            return (t1, t2);
        }
        public bool SortStepEnd(bool first)
        {
            if (first)
            {
                
            } else
            {
                _max_index = _current_j;
            }
            _current_j++;
            if (_current_j >= all.Count-1)
            {
                MyTask temp = all[_current_i];
                all[_current_i] = all[_max_index];
                all[_max_index] = temp;
                _current_i++;
                _current_j = _current_i + 1;
                _max_index = _current_i;
                if (_current_i == all.Count - 1)
                {
                    _current_i = 0;
                    _current_j = 1;
                    _max_index = 0;
                    sorted = true;
                    return true;
                }
            }
            return false;
        }
    }

    class MyTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Due { get; set; }
        public MyTask(string s)
        {
            Name = s;
            Created = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Name} created {Created.ToShortDateString()}";
        }
        public static explicit operator MyTask(string s) => new MyTask(s);
    }
}
