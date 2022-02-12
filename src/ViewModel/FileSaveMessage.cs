using System;
using System.Threading.Tasks;

namespace RedRing.ViewModel
{
    public class FileSaveMessage
    {
        public FileSaveMessage(Func<string, int, Task> callback)
        {
            CallBack = callback;
        }

        public Func<string, int, Task> CallBack { get; private set; }
    }
}
