
using System;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{

    private HeroController mHeroController;
    private List<Guid> mTimersIDs;
    public InputHandler(HeroController heroController)
    {
        mHeroController = heroController;
        mTimersIDs = new List<Guid>();
    }

    private bool CanCheck()
    {
        if (mTimersIDs.Count > 0)
        {
            UpdateTimersIDs();
            if (mTimersIDs.Count > 0)
                return false;
        }
        return true;
    }

    public void Check()
    {
        if (!CanCheck())
            return;
        float movHorizontal = Input.GetAxis("Horizontal");
        if (movHorizontal != 0)
        {
            int direction = 1;
            if (movHorizontal < 0)
                direction = -1;
            RegisterActionTimer(mHeroController.DoMovement(direction));
        }
        if (Input.GetButtonDown("MeleeAttack"))
        {
            RegisterActionTimer(mHeroController.DoMeleeAttack());
            return;
        }
        if (Input.GetButtonDown("MeleeSpecialAttack"))
        {
            RegisterActionTimer(mHeroController.DoMeleeAttack());
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            RegisterActionTimer(mHeroController.DoJump());
        }
    }

    private void RegisterActionTimer(float duration)
    {
        if (duration > 0)
            mTimersIDs.Add(GameManager.Timers.AddTimer(duration));
        return;
    }

    private void UpdateTimersIDs()
    {
        List<Guid> toRemove = new List<Guid>();
        foreach (Guid id in mTimersIDs)
        {
            if (GameManager.Timers.CheckTimer(id))
                toRemove.Add(id);
        }
        foreach (Guid id in toRemove)
            mTimersIDs.Remove(id);
    }
}