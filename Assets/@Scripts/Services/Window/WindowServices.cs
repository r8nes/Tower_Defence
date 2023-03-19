namespace Defender.Service
{
    public class WindowServices : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        public WindowServices(IUIFactory factory)
        {
            _uiFactory = factory;
        }

        public void Open(WindowId WindowId)
        {
            _uiFactory.CreateWindowById(WindowId);
        }
    }
}
