using System;
using System.Collections.Generic;
using UnityEngine;

namespace Defender.Utility.EventBus
{
    public static class EventBus
    {
        private static Dictionary<Type, SubscribersList<IGlobalSubscriber>> SubscribersDictionary
            = new Dictionary<Type, SubscribersList<IGlobalSubscriber>>();

        public static void Subscribe(IGlobalSubscriber subscriber)
        {
            List<Type> subscriberTypes = EventBusHelper.GetSubscriberTypes(subscriber);
            foreach (Type sub in subscriberTypes)
            {
                if (!SubscribersDictionary.ContainsKey(sub))
                {
                    SubscribersDictionary[sub] = new SubscribersList<IGlobalSubscriber>();
                }
                SubscribersDictionary[sub].Add(subscriber);
            }
        }

        public static void Unsubscribe(IGlobalSubscriber subscriber)
        {
            List<Type> subscriberTypes = EventBusHelper.GetSubscriberTypes(subscriber);
          
            foreach (Type sub in subscriberTypes)
            {
                if (SubscribersDictionary.ContainsKey(sub))
                    SubscribersDictionary[sub].Remove(subscriber);
            }
        }

        public static void RaiseEvent<TSubscriber>(Action<TSubscriber> action)
            where TSubscriber : class, IGlobalSubscriber
        {
            SubscribersList<IGlobalSubscriber> subscribers = SubscribersDictionary[typeof(TSubscriber)];

            subscribers.Executing = true;
            foreach (IGlobalSubscriber subscriber in subscribers.SubList)
            {
                try
                {
                    action.Invoke(subscriber as TSubscriber);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
            subscribers.Executing = false;
            subscribers.Cleanup();
        }
    }
}