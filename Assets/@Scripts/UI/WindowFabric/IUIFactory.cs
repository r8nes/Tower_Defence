namespace Defender.Service
{
    public interface IUIFactory : IService
    {
        void CreateDefeatWindow();
        void CreateUIRoot();
        void CreateHackWindow();
    }
}
