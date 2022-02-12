using System;
using System.Threading.Tasks;

namespace RedRing.ViewModel
{
    public class FileOpenMessage
    {
        public FileOpenMessage(Func<string, Task> callback)
        {
            CallBack = callback;
        }

        public Func<string, Task> CallBack { get; private set; }
    }
}
