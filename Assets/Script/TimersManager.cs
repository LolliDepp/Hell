using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TimersManager : MonoBehaviour
{
    protected class Timer
    {
        private float mDuration;
        private float mElapsed;
        public Timer (float duration)
        {
            mDuration = duration;
            mElapsed = 0;
        }
        public bool Trigger ()
        {
            mElapsed += Time.deltaTime;
            if (mElapsed >= mDuration)
                return true;
            else
                return false;
        }
        
    }

    private Dictionary<Guid, Timer> mTimers = new Dictionary<Guid, Timer>();

    void FixedUpdate()
    {
        List<Guid> toRemove = new List<Guid>();
        foreach (KeyValuePair<Guid, Timer> timerReferenceItem in mTimers)
        {
            if (timerReferenceItem.Value.Trigger())
            {
                toRemove.Add(timerReferenceItem.Key);
            }
        }
        foreach (Guid id in toRemove)
        {
            mTimers.Remove(id);
        }
    }

    public Guid AddTimer(float duration)
    {
        Guid result = Guid.NewGuid();
        mTimers.Add(result, new Timer(duration));
        return result;
    }

    public bool CheckTimer(Guid id)
    {
        return !mTimers.ContainsKey(id);
    }

    public void StopTimers(List<Guid> keyList)
    {
        foreach (Guid key in keyList)
        {
            if (mTimers.ContainsKey(key))
                mTimers.Remove(key);
        }
    }
}

