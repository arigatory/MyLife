using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLife
{
    enum TypeOfSort
    {
        Priority,
        Urgency,
    }
    class MyTasks
    {
        private bool sorted = false;
        private int _current_i = 0;
        private int _current_j = 0;
        private int _max_index = 0;
        private TypeOfSort typeOfSort;
        
        public void SetTypeOfSort(TypeOfSort t)
        {
            typeOfSort = t;
        }
        public List<MyTask> all { get; set; }
        public MyTasks()
        {
            all = new List<MyTask>();
            all.Add(new MyTask("Test 1!"));
        }
      

        public (MyTask,MyTask) SortStepStart()
        {
            if (_current_j == _current_j)
            {
                SortStepEnd(true);
            }
            MyTask t1 = all[_max_index];
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
            if (_current_j == all.Count)
            {
                swap(_current_i, _max_index);
                _current_i++;
                if (_current_i == all.Count - 1)
                {
                    _current_i = 0;
                    _current_j = 0;
                    _max_index = 0;
                    sorted = true;
                    SetWeights();
                    
                    return true;
                }
                _current_j = _current_i;
                _max_index = _current_i;
            }
            return false;
        }

        private void SetWeights()
        {
            switch (typeOfSort)
            {
                case TypeOfSort.Priority:
                    for (int i = 0; i < all.Count; i++)
                    {
                        all[i].Priority = all.Count - i;
                    }
                    break;
                case TypeOfSort.Urgency:
                    for (int i = 0; i < all.Count; i++)
                    {
                        all[i].Urgency = all.Count - i;
                    }
                    break;
                default:
                    break;
            }
        }

        private void swap(int i, int j)
        {
            MyTask temp = all[i];
            all[i] = all[j];
            all[j] = temp;
        }
    }

    class MyTask
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Due { get; set; }

        public int Priority { get; set; }
        public int Urgency { get; set; }
        public MyTask(string s)
        {
            Name = s;
            Created = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Name} Priority: {Priority} Urgency: {Urgency}";
        }
        public static explicit operator MyTask(string s) => new MyTask(s);
    }
}
