﻿using SLS.Core;
using System;

namespace SLS.Infrastucture.Commands
{
    internal class LambdaCommand : RelayCommand
    {
        private Action<object> _Execute;

        private Func<object, bool> _CanExecute;

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object? parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;

            _Execute(parameter); 
        }
    }
}
