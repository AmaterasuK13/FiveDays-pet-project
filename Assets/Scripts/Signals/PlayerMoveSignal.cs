using UnityEngine;

namespace Signals
{
    public class PlayerMoveSignal
    {
        public Vector3 TargetPosition { get; private set; }

        public PlayerMoveSignal(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
    }
}