using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace RedRing.ViewModel
{
    public class FileSaveMessage : MessageBase
    {
        public FileSaveMessage(Func<string, int, Task> callback)
        {
            CallBack = callback;
        }

        public Func<string, int, Task> CallBack { get; private set; }
    }
}
