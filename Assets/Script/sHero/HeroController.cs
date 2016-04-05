using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

	private InputHandler mInputHandler;
	private HeroStatus mHeroStatus;
	public GameObject mCamera;
	private WeaponHandler mWeapon;
	//private MagicHandler mMagic;
	
	private HeroCombinationController mCombinationController = null;
	public HeroCombinationController CombinationController
	{
		get
		{
			if (mCombinationController == null)
				return new HeroCombinationController();
			return mCombinationController;
		}
	}

	public HitData ThisHitData
	{
		get
		{
			return mWeapon.thisHitData;
		}
	}


	public void SetupTransformForAction(Transform itemTransform)
	{
		itemTransform.transform.parent = transform;
		itemTransform.transform.localPosition += mHeroStatus.ActionStartPosition;
	}

	public float DoMovement(int direction)
	{
		return mHeroStatus.Move(direction);
	}

	public float DoJump()
	{
		return mHeroStatus.Jump();
	}

	public float DoMeleeAttack()
	{
		return mWeapon.DoMeleeAttack();
	}

	public float DoMeleeSpecialAttack()
	{
		return mWeapon.DoMeleeSpecialAttack();
	}

	void Start () {
		mHeroStatus = new HeroStatus(this, mCamera);
		mInputHandler = new InputHandler(this);
		mWeapon = new WeaponHandler(new System.Collections.Generic.List<SpecialEffect>(), this);

	}
	
	void FixedUpdate ()
	{
		mInputHandler.Check();
	}
	
	void Update () {

	}
}
