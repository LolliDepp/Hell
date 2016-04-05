using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HitTriggerHanlder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyController>().Hit(gameObject.GetComponentInParent<HeroController>().ThisHitData);
    }
}
