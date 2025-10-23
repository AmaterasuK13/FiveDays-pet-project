using Commands;
using Signals;
using UnityEngine;

namespace Interactions
{
    public class DoorInteraction : AbstractInteraction, IInteractable
    {
        [SerializeField] private Transform _interactPosition;
        
        public override void Interact()
        {
            Debug.Log("Door Interaction");
            _player.GetCommand<MoveCommand>().CommandMoveTo(_interactPosition.position);
            _signalBus.TryFire(new PlayerMoveSignal(_interactPosition.position));
        }

        public override bool CanInteract() => true;
    }
}