using Input.Interfaces;
using Zenject;

namespace Input.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public MouseInputController MouseInputController;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IMouseInputController>()
                .FromInstance(MouseInputController)
                .NonLazy();
        }
    }
}