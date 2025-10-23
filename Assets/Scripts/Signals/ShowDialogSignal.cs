using UI;

namespace Signals
{
    public class ShowDialogSignal
    {
        public TextGroupBlock TextBlock { get; private set; }

        public ShowDialogSignal(TextGroupBlock textBlock)
        {
            TextBlock = textBlock;
        }
    }
}