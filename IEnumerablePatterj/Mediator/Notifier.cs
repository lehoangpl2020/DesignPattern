using System.Diagnostics;

namespace IEnumerablePattern.Mediator
{
    public interface INotifier
    {
        void Notify();
        bool CanRun();
    }

    public class Notifier1 : INotifier
    {
        public bool CanRun()
        {
            return true;
        }

        public void Notify()
        {
            Debug.WriteLine("Debugging from Notifier 1");
        }
    }

    public class Notifier2 : INotifier
    {
        public bool CanRun() => false
        public void Notify()
        {
            Debug.WriteLine("Debugging from Notifier 2");
        }
    }


}
