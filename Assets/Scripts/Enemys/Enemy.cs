using UnityEngine;

//  RequireComponent ?
//  이 컴포넌트를 AddComponent 할 경우 자동으로 typeof(EnemyMovement) 컴포넌트가 추가된다
[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    public float MaxHP;
    public int Prize;
    private float m_CurrentHp;

    private void Start()
    {
        m_CurrentHp = MaxHP;
    }

    public void OnHit(float damage)
    {
        m_CurrentHp -= damage;

        if (m_CurrentHp <= 0)
            SpawnManager.Get.DestoryEnemy(this);
    }

}
