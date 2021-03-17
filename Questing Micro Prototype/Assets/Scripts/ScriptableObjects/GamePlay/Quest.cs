using ScriptableObjects.Refs;
using UnityEngine;

namespace ScriptableObjects.GamePlay
{
    [CreateAssetMenu(fileName = "New quest", menuName = "QST/Quest", order = 0)]
    public class Quest : ScriptableObject
    {
        public StringRef questName = new StringRef {var = "Generic quest name", useConstant = false};
        public StringRef instructions = new StringRef {var = "Generic quest instructions", useConstant = false};
    }
}