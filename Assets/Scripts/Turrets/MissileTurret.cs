using UnityEngine;

public class MissileTurret : TurretStatus
{
    protected override void Shoot()
    {
        if (EnemyTarget == null) return;

        Bullet b = Instantiate(
            Prefab,
            FireTransform.position,
            Quaternion.identity,
            null);

        b.Initialize(EnemyTarget, BulletSpeed, Damage);
    }
}