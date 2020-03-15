using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace RedRing.ViewModel
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
