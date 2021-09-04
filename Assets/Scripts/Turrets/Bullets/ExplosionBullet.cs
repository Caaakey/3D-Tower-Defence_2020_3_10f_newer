using UnityEngine;

public class ExplosionBullet : Bullet
{
    [SerializeField] private ParticleSystem m_HitParticle = null;
    [SerializeField] private float m_ExplosionRadius = 10f;

    protected override void OnHit()
    {
        ParticleSystem p = Instantiate(m_HitParticle, transform.position, transform.rotation);
        p.Play();

        Destroy(p, 1);

        //  해당 위치를 기준으로 Radius 만큼 원 안에 있는 콜라이더 객체를 찾는다
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            m_ExplosionRadius);

        for (int i = 0; i < colliders.Length; ++i)
        {
            if (colliders[i].CompareTag("Enemys"))
                colliders[i].GetComponent<Enemy>().OnHit(Damage);
        }
    }
}