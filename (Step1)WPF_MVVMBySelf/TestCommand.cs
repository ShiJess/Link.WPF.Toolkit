using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPF_MVVM
{
    class TestCommand : ICommand
    {
        //public Action<object> ExecuteCommand { get; set; }
        //public Func<object, bool> CanExecuteCommand { get; set; }
        public TestCommand(TestViewModel viemo)
        {
            viewmodel = viemo;
        }

        TestViewModel viewmodel{get;set;}

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        int i = 0;

        /// <summary>
        /// 命令是否可用
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 命令执行的操作
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            i++;
            viewmodel.TestStr = i.ToString();
        }

    }
}
