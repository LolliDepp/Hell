using System;
using UnityEngine;

public class HeroStatus
{
    private HeroController mHeroController;
    private int mDirection;
    private Vector2 mBottomLeft;
    private Vector2 mBottomRight;
    private GameObject myCamera;
    private int mWalkableLayer = LayerMask.GetMask("Walkable");
    public HeroStatus (HeroController heroController, GameObject camera)
    {
        mDirection = 1;
        mHeroController = heroController;
        myCamera = camera;
        SetGroundcheckPosition();
    }

    public Vector3 ActionStartPosition
    {
        get
        {
            Vector3 result = new Vector3(0, 0, 0);
            BoxCollider2D bodyCollider = mHeroController.gameObject.GetComponentInChildren<BoxCollider2D>();
            result.x += (bodyCollider.size.x / 2) + bodyCollider.offset.x;
            result.y += (bodyCollider.size.y / 2) + bodyCollider.offset.y;
            return result;
        }
    }

    public Quaternion ActionRotation
    {
        get
        {
            return mHeroController.transform.rotation;
        }
    }

    public Vector3 ActionScale
    {
        get
        {
            return mHeroController.transform.localScale;
        }
    }

    public bool IsGrounded
    {
        get
        {
            return Physics2D.OverlapArea(mBottomLeft, mBottomRight + new Vector2(0, -0.15f), mWalkableLayer);
        }
    }

    public float Jump()
    {
        if (!IsGrounded)
        {
            BoostJump();
        }
        else
        {
            Vector2 jumpForce = new Vector2(0, 6);
            mHeroController.GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
        }
        return 0;
    }

    public float Move(int newDirection)
    {
        if (mDirection != newDirection)
        {
            mDirection = newDirection;
            mHeroController.transform.Rotate(new Vector3(0, 180 * newDirection));
        }
        mHeroController.transform.Translate(new Vector3(2 * Time.deltaTime, 0));
        myCamera.transform.Translate(new Vector3(2 * mDirection * Time.deltaTime, 0));
        return 0;
    }

    private void BoostJump()
    {

    }

    private void SetGroundcheckPosition()
    {
        Vector2 bottomPosition = mHeroController.GetComponentInChildren<CircleCollider2D>().transform.position;
        float heroWidth = mHeroController.GetComponentInChildren<CircleCollider2D>().radius;
        mBottomRight = bottomPosition + new Vector2(heroWidth, 0);
        mBottomLeft = bottomPosition - new Vector2(heroWidth, 0);
    }
}
