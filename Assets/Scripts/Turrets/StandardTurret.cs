using UnityEngine;

public class StandardTurret : TurretStatus
{
    protected override void Shoot()
    {
        var bullet = Instantiate(
            Prefab,
            FireTransform.position,
            Quaternion.identity,
            null);

        bullet.Initialize(EnemyTarget, BulletSpeed, Damage);
    }

}