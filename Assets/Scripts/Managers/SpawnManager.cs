using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Get { get; private set; } = null;

    //  readonly ?
    //  이 객체는 수정되어지지 않는다. 읽기 전용
    [SerializeField] private Enemy[] Prefabs;           //  적 개체 프리팹
    [SerializeField] private float m_SpawnTime;         //  한 마리 뽑을 때 마다 대기할 시간
    [SerializeField] private float m_RoundWaitTime;     //  라운드 종료 시 대기 시간
    [SerializeField] private int m_SpawnLimitCount;     //  최대 몬스터 스폰 개수
    private readonly List<Enemy> m_Enemise = new List<Enemy>();

    public int RoundCount { get; private set; } = 0;

    private void Awake()
    {
        Get = this;

        StartCoroutine(UpdateSpawnTimer());
    }

    public void DestoryEnemy(Enemy enemy)
    {
        m_Enemise.Remove(enemy);

        Destroy(enemy.gameObject);
    }

    public Enemy GetEnemyInRange(Vector3 position, float range)
    {
        //return m_Enemise.Find(x => Vector3.Distance(x.transform.position, position) <= range);

        for (int i = 0; i < m_Enemise.Count; ++i)
        {
            float distance = Vector3.Distance(m_Enemise[i].transform.position, position);
            if (distance <= range)
                return m_Enemise[i];
        }

        return null;
    }

    private IEnumerator UpdateSpawnTimer()
    {
        int enemyIndex = Random.Range(0, Prefabs.Length);
        int count = 0;

        while (count++ != m_SpawnLimitCount)
        {
            SpawnEnemy(enemyIndex);
            yield return new WaitForSeconds(m_SpawnTime);
        }

        while (m_Enemise.Count != 0)
            yield return null;

        RoundCount++;
        yield return new WaitForSeconds(m_RoundWaitTime);

        StartCoroutine(UpdateSpawnTimer());
        yield break;
    }

    private void SpawnEnemy(int index)
    {
        Enemy e = Instantiate(Prefabs[index], null);

        m_Enemise.Add(e);
    }

}