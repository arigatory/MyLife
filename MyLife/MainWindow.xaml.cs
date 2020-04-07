using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyTasks tasks = new MyTasks();
        bool b1 = false;
        bool b2 = false;
        public MainWindow()
        {
            InitializeComponent();
            tasks.all.Add((MyTask)"Test 2!");
            tasks.all.Add((MyTask)"Test 3!");
            DataContext = tasks.all;
            grdSort.Visibility = Visibility.Collapsed;
            
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            tasks.all.Add((MyTask)txtBox.Text);
            txtBox.SelectAll();
            lstOfTasks.Items.Refresh();
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAdd_Click(sender, e);
            }
        }


        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            if (lstOfTasks.SelectedIndex<0 || lstOfTasks.SelectedIndex >= tasks.all.Count)
            {
                return;
            }
            tasks.all.RemoveAt(lstOfTasks.SelectedIndex);
            lstOfTasks.Items.Refresh();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            grdSort.Visibility = Visibility.Visible;
            btn1.Content = tasks.SortStepStart().Item1.Name;
            btn2.Content = tasks.SortStepStart().Item2.Name;

            //MyTask mostTask;
            //int mostIndex;
            //for (int i = 0; i < tasks.all.Count; i++)
            //{
            //    mostTask = tasks.all[i];
            //    mostIndex = i;
                
            //    for (int j = 0; j < tasks.all.Count; j++)
            //    {
            //        if (b2)
            //        {
            //            mostTask = tasks.all[j];
            //            mostIndex = j;
            //            b2 = false;
            //        } else
            //        {
            //            b1 = false;
            //        }
            //        MyTask temp = tasks.all[i];
            //        tasks.all[i] = mostTask;
            //        tasks.all[mostIndex] = temp;
            //    }
            //}
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (tasks.SortStepEnd(true))
            {
                grdSort.Visibility = Visibility.Collapsed;
            } else
            {
                lstOfTasks.Items.Refresh();
                btn1.Content = tasks.SortStepStart().Item1.Name;
                btn2.Content = tasks.SortStepStart().Item2.Name;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (tasks.SortStepEnd(false))
            {
                grdSort.Visibility = Visibility.Collapsed;
            }
            else
            {
                lstOfTasks.Items.Refresh();
                btn1.Content = tasks.SortStepStart().Item1.Name;
                btn2.Content = tasks.SortStepStart().Item2.Name;
            }
        }
    }
}
