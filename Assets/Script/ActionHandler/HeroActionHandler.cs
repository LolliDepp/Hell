using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class HeroActionHandler
{
	protected HeroController mHeroController;
	public void InitializeActionTransform(Transform actionTransform)
	{
		mHeroController.SetupTransformForAction(actionTransform);
	}

	public HitData thisHitData
	{
		get
		{
			return new HitData();
		}
	}

	protected GameObject mActionGameObject;
}
