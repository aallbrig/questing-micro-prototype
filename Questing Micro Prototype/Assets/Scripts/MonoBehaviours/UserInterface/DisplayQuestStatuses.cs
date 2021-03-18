using System.Linq;
using ScriptableObjects.RuntimeDictionaries;
using TMPro;
using UnityEngine;

namespace MonoBehaviours.UserInterface
{
    public class DisplayQuestStatuses : MonoBehaviour
    {
        public QuestStatuses questStatuses;
        public Transform parent;

        public void RenderUserInterface()
        {
            foreach (Transform child in parent)
                Destroy(child.gameObject);

            questStatuses.dictionary.Keys.ToList().ForEach(quest =>
            {
                var go = new GameObject();
                var tmp = go.AddComponent<TextMeshProUGUI>();
                tmp.text = quest.questName.Value + "<br>" + quest.instructions.Value + "<br>Complete: " +
                          quest.IsQuestComplete() + "<br>";
                tmp.fontSize = 18;
                Instantiate(go, parent);
            });
        }
    }
}