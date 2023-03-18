using System;
using System.Collections.Generic;
using System.Linq;

namespace Defender.Utility.EventBus
{
    public static class EventBusHelper
    {
        private static Dictionary<Type, List<Type>> StaticCashedSubscriberTypes =
            new Dictionary<Type, List<Type>>();

        public static List<Type> GetSubscriberTypes(
            IGlobalSubscriber globalSubscriber)
        {
            Type type = globalSubscriber.GetType();
            if (StaticCashedSubscriberTypes.ContainsKey(type))
            {
                return StaticCashedSubscriberTypes[type];
            }

            List<Type> subscriberTypes = type
                .GetInterfaces()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IGlobalSubscriber)))
                .ToList();

            StaticCashedSubscriberTypes[type] = subscriberTypes;
            return subscriberTypes;
        }
    }
}