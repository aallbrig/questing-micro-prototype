using ScriptableObjects.GamePlay;
using UnityEngine;

namespace ScriptableObjects.RuntimeDictionaries
{
    [CreateAssetMenu(fileName = "New quest statuses dictionary", menuName = "QST/QuestStatusDictionary", order = 0)]
    public class QuestStatuses : RuntimeDictionary<Quest, bool> {}
}