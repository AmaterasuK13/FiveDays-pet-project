using Commands;
using UnityEngine;
using UnityEngine.AI;

namespace Characters.PlayerCharacter
{
    public class MovementController : MonoBehaviour, IMovable
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void Move(Vector3 target)
        {
            _agent.SetDestination(target);
        }
    }
}