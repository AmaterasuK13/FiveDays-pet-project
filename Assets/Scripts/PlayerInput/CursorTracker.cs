using Characters.PlayerCharacter;
using Commands;
using Interactions;
using UI;
using UnityEngine;
using Zenject;

namespace PlayerInput
{
    public class CursorTracker : MonoBehaviour
    {
        private Camera _mainCamera;
        private TextPanel _textPanel;
        private PlayerBehaviour _player;

        [Inject]
        public void Construct(TextPanel textPanel, PlayerBehaviour playerBehaviour)
        {
            _textPanel = textPanel;
            _player = playerBehaviour;
        } 
        
        private void Awake()
        {
            _mainCamera = Camera.main;
            Cursor.lockState = CursorLockMode.Confined;
        }

        private void Update()
        {
            if (_textPanel.IsRunning)
                return;
            
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            var target = Physics.Raycast(ray, out RaycastHit hit);

            if (target)
            {
                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
#if UNITY_EDITOR
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.cyan);
#endif
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (interactable.CanInteract())
                            interactable.Interact();
                    }
                }
                else
                {
                    
                    if (Input.GetMouseButtonDown(1))
                    {
                        _player.GetCommand<MoveCommand>().CommandMoveTo(hit.point);
                    }
                }
            }
        }
    }
}