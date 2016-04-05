using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(NotificationManager))]
[RequireComponent(typeof(DataManager))]
[RequireComponent(typeof(TimersManager))]

public class GameManager : MonoBehaviour
{
    private static GameManager mInstance = null;
    private static NotificationManager mNotifications = null;
    private static DataManager mData = null;
    private static TimersManager mTimers = null;

    public static GameManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = new GameObject("GameManager").AddComponent<GameManager>();
            return mInstance;
        }
    }

    public static NotificationManager Notifications
    {
        get
        {
            if (mNotifications == null)
                mNotifications = mInstance.GetComponent<NotificationManager>();
            return mNotifications;
        }
    }

    public static DataManager Data
    {
        get
        {
            if (mData == null)
                mData = mInstance.GetComponent<DataManager>();
            return mData;
        }
    }

    public static TimersManager Timers
    {
        get
        {
            if (mTimers == null)
                mTimers = mInstance.GetComponent<TimersManager>();
            return mTimers;
        }
    }

    void Awake()
    {
        if ((mInstance) && (mInstance.GetInstanceID() != GetInstanceID()))
            DestroyImmediate(gameObject);
        else
        {
            mInstance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
