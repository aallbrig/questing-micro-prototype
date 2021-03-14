using System.Collections.Generic;
using ScriptableObjects.Refs;
using UnityEngine;

namespace ScriptableObjects.GamePlay
{
    [CreateAssetMenu(fileName = "New quest", menuName = "QST/Quest", order = 0)]
    public class Quest : ScriptableObject
    {
        public List<StringRef> introText = new List<StringRef>();
        public List<StringRef> pendingText = new List<StringRef>();
        public List<StringRef> completionText = new List<StringRef>();
    }
}