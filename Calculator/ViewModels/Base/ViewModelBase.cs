﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels.Base
{
    class ViewModelBase:BindableBase
    {
        protected ViewModelBase()
        {
            this.RegisterCommands();
        }

        protected virtual void RegisterCommands() { }   

    }
}
