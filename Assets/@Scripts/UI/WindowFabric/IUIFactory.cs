namespace Defender.Service
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();

        void CreateWindowById(WindowId windowId);
    }
}
