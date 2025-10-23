using Commands;
using Signals;
using UI;
using UnityEngine;

namespace Interactions
{
    public class FridgeInteraction : AbstractInteraction
    {
        [SerializeField] private Transform _interactPosition;
        [SerializeField] private TextGroupBlock _interactionText;
        
        public override void Interact()
        {
            Debug.Log("Fridge Interaction");
            _player.GetCommand<MoveCommand>().CommandMoveTo(_interactPosition.position);
            _signalBus.TryFire(new ShowDialogSignal(_interactionText));
        }

        public override bool CanInteract() => true;
    }
}