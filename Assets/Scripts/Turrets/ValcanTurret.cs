using UnityEngine;

public class ValcanTurret : TurretStatus
{
    [SerializeField] private ParticleSystem m_Particle;

    protected override void Shoot()
    {
        Ray ray = new Ray(NeckTransform.position, Vector3.forward);
        if (Physics.Raycast(ray, out var hitInfo, Range))
        {
            ParticleSystem p = Instantiate(m_Particle, hitInfo.point, Quaternion.identity, null);
            p.Play();

            Destroy(p.gameObject, 0.5f);
        }

        EnemyTarget.OnHit(Damage);

    }
}