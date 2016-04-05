using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HeroCombinationController
{
	protected string mCurrentCombination;
	protected string mSeparator = "_";
	public string CurrentCombination
	{
		get
		{
			UpdateCombination();
			return mCurrentCombination;
		}
	}
	private List<Guid> mTimersIDs;

	public void AddToCombination (string action)
	{
		mCurrentCombination += action + mSeparator;
		mTimersIDs.Add(GameManager.Timers.AddTimer(0.5f));
	}

	public void ClearCombination()
	{
		mCurrentCombination = "";
		GameManager.Timers.StopTimers(mTimersIDs);
		mTimersIDs.Clear();
	}

	public HeroCombinationController()
	{
		mTimersIDs = new List<Guid>();
		mCurrentCombination = "";
	}

	private void UpdateCombination()
	{
		List<Guid> toRemove = new List<Guid>();
		foreach (Guid id in mTimersIDs)
		{
			if (GameManager.Timers.CheckTimer(id))
			{
				toRemove.Add(id);
			}
		}
		foreach (Guid id in toRemove)
		{
			mTimersIDs.Remove(id);
		}
		if (mTimersIDs.Count == 0)
			mCurrentCombination = "";
	}
}
