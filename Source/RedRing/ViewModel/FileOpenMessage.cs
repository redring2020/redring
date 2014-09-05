using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace Marimo.RedRing.ViewModel
{
    public class FileOpenMessage : MessageBase
    {
        public FileOpenMessage(Func<string, Task> callback)
        {
            CallBack = callback;
        }

        public Func<string, Task> CallBack { get; private set; }
    }
}
