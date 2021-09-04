using UnityEngine;

public class ValcanTurret : TurretStatus
{
    [SerializeField] private ParticleSystem m_Particle;

    protected override void Shoot()
    {
        Vector3 norm = (EnemyTarget.transform.position - transform.position).normalized;
        ParticleSystem p = Instantiate(
            m_Particle,
            EnemyTarget.transform.position,
            Quaternion.Inverse(Quaternion.LookRotation(norm)));

        p.Play();

        EnemyTarget.OnHit(Damage);

    }
}