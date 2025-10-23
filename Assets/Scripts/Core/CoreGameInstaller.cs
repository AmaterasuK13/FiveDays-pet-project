using Characters.PlayerCharacter;
using Signals;
using UI;
using UnityEngine;
using Zenject;

namespace Core
{
    public class CoreGameInstaller : MonoInstaller<CoreGameInstaller>
    {
        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private TextPanel _textPanel;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<ShowDialogSignal>();
            Container.BindInstance(_player).AsSingle().NonLazy();
            Container.BindInstance(_textPanel).AsSingle().NonLazy();
            
            
            Container.BindSignal<ShowDialogSignal>()
                .ToMethod(s=> _textPanel.ShowDialog(s.TextBlock));
        }
    }
}