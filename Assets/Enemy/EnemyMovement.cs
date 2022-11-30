using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;
using Grid;

namespace Enemy {
    [RequireComponent(typeof(EnemyBase))]
    public class EnemyMovement : MonoBehaviour
    {
        List<Vector3> pathPositions = new List<Vector3>();
        [SerializeField] float speed = 1.5f;
        EnemyBase enemy;
        EnemyHealth enemyHealth;
        GridManager gridManager;
        // Start is called before the first frame update
        void Awake() {
            enemy = GetComponent<EnemyBase>();
            enemyHealth = GetComponentInChildren<EnemyHealth>();
            gridManager = GameObject.FindGameObjectWithTag("GridManager").GetComponent<GridManager>();
        }
        
        public void OnEnableOperations()
        {
            FindPath();
            StartCoroutine(TravelPathPoints());
        }

        void FindPath() {
            List<Vector2Int> pathPositions2d = gridManager.FindNewPath();
            pathPositions.Clear();
            foreach (Vector2Int pathPosition in pathPositions2d) {
                pathPositions.Add(new Vector3(pathPosition.x, 0, pathPosition.y));
            }
            transform.position = pathPositions[0];
        }

        IEnumerator TravelPathPoints() {
            foreach (Vector3 pathPosition in pathPositions) {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = pathPosition;
                transform.LookAt(endPosition);
                float travelPercent = 0f;
                while (travelPercent < 1f) {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }
            if (enemyHealth.isEnemyEnabled()) {
                enemy.RewardPenalty();
                enemyHealth.DisableEnemy();
            }
        }
    }

}
