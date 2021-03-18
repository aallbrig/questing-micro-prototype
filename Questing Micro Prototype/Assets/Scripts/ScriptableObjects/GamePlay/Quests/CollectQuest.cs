using MonoBehaviours.GamePlay;
using ScriptableObjects.RuntimeSets;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.GamePlay.Quests
{
    [CreateAssetMenu(fileName = "New collect quest", menuName = "QST/CollectQuest", order = 0)]
    public class CollectQuest : Quest
    {
        public GameObjectVar playerVar;
        public GameObjectRuntimeSet collection;
        private Collector<GameObject> _collector;

        public override void Accept()
        {
            base.Accept();
            _collector = playerVar.value.AddComponent<Collector<GameObject>>();
        }

        public override bool IsQuestComplete()
        {
            return _collector != null && _collector.collection.Count >= collection.list.Count;
        }

        public override void Reset()
        {
            base.Reset();
            Destroy(_collector);
        }
    }
}