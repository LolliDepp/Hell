using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponHandler : HeroActionHandler
{
	protected List<SpecialEffect> mSpecialEffects;
	protected float mWidth = 4;
	protected float mHeight = 4;
	protected float mOffsetX = 2;
	protected float mOffsetY = 0;
	protected float mDuration = 0.5f;
	

	public float DoMeleeAttack()
	{
		mHeroController.CombinationController.AddToCombination("basic-attack");
		mActionGameObject = new GameObject("ActionObject");
		mActionGameObject.layer = LayerMask.NameToLayer("PlayerHitzone");
		InitializeActionTransform(mActionGameObject.transform);
		BoxCollider2D weaponCollider = mActionGameObject.AddComponent<BoxCollider2D>();
		weaponCollider.isTrigger = true;
		weaponCollider.size = new Vector2(mWidth, mHeight);
		weaponCollider.offset = new Vector2(mOffsetX, mOffsetY);
		mActionGameObject.AddComponent<HitTriggerHanlder>();
		GameObject.Destroy(mActionGameObject, 0.3f);
		return mDuration;
	}
	public float DoMeleeSpecialAttack()
	{
		return mDuration;
	}

	public WeaponHandler (List<SpecialEffect> specialEffects, HeroController heroController)
	{
		mSpecialEffects = specialEffects;
		mHeroController = heroController;
	}
	
}
