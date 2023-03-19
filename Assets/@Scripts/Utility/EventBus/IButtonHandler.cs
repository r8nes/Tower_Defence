using Defender.Data;

namespace Defender.Utility.EventBus
{
    public interface IButtonHandler : IGlobalSubscriber
    {
        void HandleButtonData(PlayerAttackData data);
    }
}
