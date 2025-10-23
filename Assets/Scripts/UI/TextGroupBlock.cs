using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    [CreateAssetMenu(menuName = "SO/Text/TextGroup", fileName = "TextGroup")]
    public class TextGroupBlock : ScriptableObject
    {
        public List<TextUnit> Messages;
    }
}