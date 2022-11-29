using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject EnemyPrefab;
        [SerializeField] int poolSize = 8;
        [SerializeField] float spawnTimer = 1.25f;
        GameObject[] pool;

        void Start() {
            pool = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++) {
                pool[i] = Instantiate(EnemyPrefab, transform);
                EnemyHealth enemyHealth = pool[i].GetComponentInChildren<EnemyHealth>();
                enemyHealth.DisableEnemy();
            }
            StartCoroutine(SpawnEnemy());
        }
        IEnumerator SpawnEnemy() {
            while(true) {
                EnableEnemyInPool();
                yield return new WaitForSeconds(spawnTimer);
            }
        }

        void EnableEnemyInPool() {
            for (int i = 0; i < poolSize; i++) {
                EnemyHealth enemyHealth = pool[i].GetComponentInChildren<EnemyHealth>();
                EnemyMovement enemyMovement = pool[i].GetComponent<EnemyMovement>();
                if (!enemyHealth.isEnemyEnabled()) {
                    enemyHealth.EnableEnemy();
                    enemyMovement.OnEnableOperations();
                    break;
                }
            }
        }
    }

}
