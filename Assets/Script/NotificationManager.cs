using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    private Dictionary<string, List<Component>> mListeners = new Dictionary<string, List<Component>>();

    public void AddListener(Component listener, string notificationName)
    {
        if (!mListeners.ContainsKey(notificationName))
            mListeners.Add(notificationName, new List<Component>());
        mListeners[notificationName].Add(listener);
    }

    public void PostNotification(string notificationName)
    {
        if (!mListeners.ContainsKey(notificationName))
            return;
        foreach (Component listener in mListeners[notificationName])
            listener.SendMessage(notificationName, listener, SendMessageOptions.DontRequireReceiver);
    }

    public void RemoveListener(Component listener, string notificationName)
    {
        if (!mListeners.ContainsKey(notificationName))
            return;
        for (int i = mListeners[notificationName].Count - 1; i >= 0; i--)
        {
            if (mListeners[notificationName][i].GetInstanceID() == listener.GetInstanceID())
                mListeners[notificationName].RemoveAt(i);
        }
    }

    public void ClearListeners()
    {
        mListeners.Clear();
    }

    public void RemoveRedundancies()
    {
        Dictionary<string, List<Component>> cleanListeners = new Dictionary<string, List<Component>>();
        foreach(KeyValuePair<string, List<Component>> item in mListeners)
        {
            item.Value.RemoveAll(x => x == null);
            if (item.Value.Count > 0)
                cleanListeners.Add(item.Key, item.Value);
        }
        mListeners = cleanListeners;
    }

    void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }
}