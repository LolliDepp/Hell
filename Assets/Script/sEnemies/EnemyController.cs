using UnityEngine;
using System.Collections;
using System;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Hit(HitData hitData)
	{
		GameObject.Destroy(gameObject, 0.1f);
	}
}
