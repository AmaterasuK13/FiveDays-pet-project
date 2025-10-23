using Characters.PlayerCharacter;
using UnityEngine;
using Zenject;

namespace Interactions
{
    public abstract class AbstractInteraction : MonoBehaviour, IInteractable
    {
        protected SignalBus _signalBus;
        protected PlayerBehaviour _player; 
        
        [Inject]
        public void Construct(SignalBus signalBus, PlayerBehaviour playerBehaviour)
        {
            _signalBus = signalBus;
            _player = playerBehaviour;
        }
        
        public abstract void Interact();

        public abstract bool CanInteract();
    }
}