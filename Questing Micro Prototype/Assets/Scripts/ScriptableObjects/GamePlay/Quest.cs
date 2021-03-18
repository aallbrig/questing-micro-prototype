using Interfaces;
using ScriptableObjects.Refs;
using ScriptableObjects.Vars;
using UnityEngine;

namespace ScriptableObjects.GamePlay
{
    public abstract class Quest : ScriptableObject, IQuest
    {
        public StringRef questName = new StringRef {var = "Generic quest name", useConstant = false};
        public StringRef instructions = new StringRef {var = "Generic quest instructions", useConstant = false};
        public GameObjectVar questPendingIcon;
        public GameObjectVar questCompleteIcon;
        public bool ready;
        protected GameObject questGiver;
        protected GameObject pendingIconInstance;
        protected GameObject completeIconInstance;

        public virtual void Accept()
        {
            DeSpawnPendingIcon();
            ready = false;
        }
        public abstract bool IsQuestComplete();

        public virtual void Complete()
        {
            DeSpawnCompleteIcon();
        }

        public void Setup(GameObject questGiver)
        {
            ready = true;
            this.questGiver = questGiver;
            SpawnPendingIcon(this.questGiver.transform);
        }

        public virtual void Reset()
        {
            ready = false;
            DeSpawnPendingIcon();
            DeSpawnCompleteIcon();
        }

        public void SpawnPendingIcon(Transform parent)
        {
            DeSpawnPendingIcon();

            pendingIconInstance = Instantiate(questPendingIcon.value, parent);
        }

        public void DeSpawnPendingIcon()
        {
            if (pendingIconInstance != null) Destroy(pendingIconInstance);
        }

        public void SpawnCompleteIcon(Transform parent)
        {
            DeSpawnCompleteIcon();

            completeIconInstance = Instantiate(questCompleteIcon.value, parent);
        }

        public void DeSpawnCompleteIcon()
        {
            if (completeIconInstance != null) Destroy(completeIconInstance);
        }
    }
}