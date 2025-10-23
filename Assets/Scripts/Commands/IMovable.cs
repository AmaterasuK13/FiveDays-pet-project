using UnityEngine;

namespace Commands
{
    public interface IMovable
    {
        public void Move(Vector3 target);
    }
}