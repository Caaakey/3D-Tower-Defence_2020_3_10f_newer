using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Enemy Target = null;
    protected float Speed;
    protected float Damage;

    public void Initialize(Enemy target, float speed, float damage)
    {
        Target = target;
        Speed = speed;
        Damage = damage;

        Vector3 norm = (target.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(norm);
    }

    private void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 norm = (Target.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(norm);

        float step = Speed * Time.deltaTime;
        transform.Translate(Vector3.forward * step);

        if (Vector3.Distance(transform.position, Target.transform.position) <= step)
        {
            OnHit();
            Destroy(gameObject);
        }
    }

    protected virtual void OnHit()
    {
        Target.OnHit(Damage);
    }

}