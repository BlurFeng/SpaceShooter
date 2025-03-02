using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class GameMode : MonoBehaviourSingleton<GameMode>
{
    [SerializeField]
    private Boundary enemiesSpawnBoundary;
    
    [SerializeField]
    private GameObject[] spawnEnemyPrefabs;
    
    [SerializeField]
    private FloatRandom spawnEnemiesInterval = new FloatRandom(1.2f, 0.8f);
    
    [SerializeField]
    private float spawnEnemiesWaveStartWait = 4f;
    
    [SerializeField]
    private FloatRandom spawnEnemiesWaveInterval = new FloatRandom(12f, 2f);
    
    [SerializeField]
    private IntRandom spawnEnemiesWaveCount = new IntRandom(6, 2);

    public int Score => score;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnWaves()
    {
        // Wait at the start. // 开始时等待。 // 開始時に待機する。
        yield return new WaitForSeconds(spawnEnemiesWaveStartWait);

        while (true)
        {
            // Get the number of randomly generated enemies. // 获取随机生成的敌人数量。 // ランダムに生成された敵の数を取得する。
            int spawnEnemyNumCur = spawnEnemiesWaveCount.GetValue();
            
            for (int i = 0; i < spawnEnemyNumCur; i++)
            {
                // Get the type of randomly generated enemies. // 获取随机生成的敌人类型。 //ランダムに生成された敵の種類を取得する。
                int index = Random.Range(0, spawnEnemyPrefabs.Length);
                GameObject enemyPrefab = spawnEnemyPrefabs[index];
                
                // Generate enemies within a random position range. // 在随机的位置范围内生成敌人。 // ランダムな位置範囲内で敵を生成する。
                Vector3 spawnPos = new Vector3(
                    Random.Range(enemiesSpawnBoundary.xMin, enemiesSpawnBoundary.xMax), 
                    Random.Range(enemiesSpawnBoundary.yMin, enemiesSpawnBoundary.yMax), 
                    GameSettings.PlayItemPosZ);
                
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                
                yield return new WaitForSeconds(spawnEnemiesInterval.GetValue());
            }
            
            yield return new WaitForSeconds(spawnEnemiesWaveInterval.GetValue());
        }
    }

    public void AddScore(int scoreValue)
    {
        this.score += scoreValue;
        
        UIEvent.OnScoreChange?.Invoke(this.score);
    }
}
