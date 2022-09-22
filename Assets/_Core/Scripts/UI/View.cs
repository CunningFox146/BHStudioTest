using UnityEngine;

namespace BhTest.UI
{
    public abstract class View : MonoBehaviour
    {
        public ViewSystem ViewSystem { get; set; }

        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);

        public virtual bool GetIsActive() => gameObject.activeSelf;
    }
}