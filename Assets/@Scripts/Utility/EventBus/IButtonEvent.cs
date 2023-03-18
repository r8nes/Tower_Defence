using Defender.Data;

namespace Defender.Utility.EventBus
{
    public interface IButtonEvent : IGlobalSubscriber
    {
        void HandleButtonData(PlayerAttackData data);
    }
}
