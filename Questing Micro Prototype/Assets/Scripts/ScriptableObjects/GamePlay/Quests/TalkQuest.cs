using MonoBehaviours.GamePlay;
using ScriptableObjects.Events;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.GamePlay.Quests
{
    [CreateAssetMenu(fileName = "New talk quest", menuName = "QST/TalkQuest", order = 0)]
    public class TalkQuest : Quest
    {
        public QuestEvent questComplete;
        public GameObjectVar talkTarget;
        private bool _talked;
        private TalkTarget _talkTarget;

        public override void Accept()
        {
            base.Accept();
            SpawnCompleteIcon(talkTarget.value.transform);
            
            _talkTarget = talkTarget.value.AddComponent<TalkTarget>();
            _talkTarget.onTalk += OnTalk;
        }

        public override bool IsQuestComplete()
        {
            return _talked;
        }

        public override void Complete()
        {
            questComplete.Broadcast(this);
            base.Complete();
            Destroy(talkTarget.value.GetComponent<TalkTarget>());
        }

        public override void Reset()
        {
            base.Reset();
            _talked = false;
            if (_talkTarget)
            {
                _talkTarget.onTalk -= OnTalk;
                Destroy(_talkTarget);
            }
        }

        private void OnTalk()
        {
            _talked = true;
            _talkTarget.onTalk -= OnTalk;
            Destroy(_talkTarget);
            Complete();
        }
    }
}