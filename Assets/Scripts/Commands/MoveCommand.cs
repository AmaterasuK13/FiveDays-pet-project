using UnityEngine;

namespace Commands
{
    public class MoveCommand : AbstractCommand
    {
        private IMovable _movable;

        public MoveCommand(IMovable movable)
        {
            _movable = movable;
        }

        public void CommandMoveTo(Vector3 targetPos)
        {
            Debug.Log($"Command {_movable} move to {targetPos}");
            _movable.Move(targetPos);
        }
    }
}