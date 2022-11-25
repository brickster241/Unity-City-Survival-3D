using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] GameObject EnemyPrefab;
        [SerializeField] int poolSize = 5;
        [SerializeField] float spawnTimer = 2f;
        GameObject[] pool;

        void Awake() {
            pool = new GameObject[poolSize];
            for (int i = 0; i < poolSize; i++) {
                pool[i] = Instantiate(EnemyPrefab, transform);
                pool[i].SetActive(false);
            }
        }
        void Start() {
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
                if (!pool[i].activeInHierarchy) {
                    pool[i].SetActive(true);
                    break;
                }
            }
        }
    }

}
