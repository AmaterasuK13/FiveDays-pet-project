using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private GameObject _view;
        [SerializeField] private float _secondsBetweenSymbols;
        
        private float _currentSecondsBetweenSymbols;
        private bool _isSpeedUp = false;

        public bool IsRunning { get; private set; } = false;
        
        public void ShowDialog(TextGroupBlock block)
        {
            SetText(block).Forget();
        }

        private void Update()
        {
            if (!_isSpeedUp && IsRunning)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _currentSecondsBetweenSymbols = 0.001f;
                    _isSpeedUp = true;
                }
            }
        }

        private async UniTaskVoid SetText(TextGroupBlock block)
        {
            _currentSecondsBetweenSymbols = _secondsBetweenSymbols;
            IsRunning = true;
            _view.SetActive(true);

            foreach (var message in block.Messages)
            {
                _text.text = "";
                foreach (var symbol in message.Text)
                {
                    _text.text += symbol;
                    await UniTask.WaitForSeconds(_currentSecondsBetweenSymbols);
                }

                _currentSecondsBetweenSymbols = _secondsBetweenSymbols;
                await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
                await UniTask.WaitForEndOfFrame();
                _currentSecondsBetweenSymbols = _secondsBetweenSymbols;
                _isSpeedUp = false;
            }

            IsRunning = false;
            _view.SetActive(false);
            await UniTask.CompletedTask;
        }
        
    }
}