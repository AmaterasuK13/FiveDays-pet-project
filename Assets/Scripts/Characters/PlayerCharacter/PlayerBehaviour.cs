using System;
using System.Collections.Generic;
using Commands;
using UnityEngine;

namespace Characters.PlayerCharacter
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private MovementController _movement;

        private List<AbstractCommand> _commands = new ();
        
        private void Awake()
        {
            _commands.Add(new MoveCommand(_movement));
        }

        public T GetCommand<T>() where T : AbstractCommand
        {
            foreach (var command in _commands)
            {
                if (command is T abstractCommand)
                    return abstractCommand;
            }

            throw new NullReferenceException($"Cannot find command of type {typeof(T)}");
        }
    }
}