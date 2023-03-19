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
            switch (WindowId)
            {
                case WindowId.UNKNOWN:
                    _uiFactory.CreateHackWindow();
                    break;
                case WindowId.DEFEAT:
                    _uiFactory.CreateDefeatWindow();
                    break;
            }
        }
    }
}
