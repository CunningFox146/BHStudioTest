using System;
using System.Collections;
using UnityEngine;

namespace BhTest.Utils
{
    public static class MonoBehaviourExtentions
    {
        public static Coroutine DelayTask(this MonoBehaviour monoBehaviour, float waitTime, Action action)
        {
            return monoBehaviour.StartCoroutine(DelayCoroutine(waitTime, action));
        }

        private static IEnumerator DelayCoroutine(float waitTime, Action action)
        {
            yield return new WaitForSeconds(waitTime);
            action();
        }
    }
}
