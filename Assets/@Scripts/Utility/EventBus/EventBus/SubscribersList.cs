using System.Collections.Generic;

namespace Defender.Utility.EventBus
{
    public class SubscribersList<TSubscriber> where TSubscriber : class
    {
        public bool Executing;
        public readonly List<TSubscriber> SubList = new List<TSubscriber>();

        private bool _isNeedsCleanUp = false;

        public void Add(TSubscriber subscriber)
        {
            SubList.Add(subscriber);
        }

        public void Remove(TSubscriber subscriber)
        {
            if (Executing)
            {
                var i = SubList.IndexOf(subscriber);
                if (i >= 0)
                {
                    _isNeedsCleanUp = true;
                    SubList[i] = null;
                }
            }
            else
            {
                SubList.Remove(subscriber);
            }
        }

        public void Cleanup()
        {
            if (!_isNeedsCleanUp)
            {
                return;
            }

            SubList.RemoveAll(s => s == null);
            _isNeedsCleanUp = false;
        }
    }
}