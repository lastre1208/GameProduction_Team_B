using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletHit : MonoBehaviour
{
    [SerializeField] AttackOfBullet attackOfBullet;

    void OnTriggerEnter(Collider t)
    {
        attackOfBullet.HitTrigger(t);
    }
}
