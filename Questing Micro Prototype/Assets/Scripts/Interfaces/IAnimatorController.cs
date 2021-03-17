using UnityEngine;

namespace Interfaces
{
    public interface IAnimatorController
    {
        GameObject AnimatorSource { get; set; }

        void OverrideAnimatorController();
        void SetTrigger(string triggerName);
        void SetFloat(string floatKey, float floatValue);
    }
}