using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Balance;
using Tile;
namespace Tower {
    public class TowerBase : MonoBehaviour
    {
        [SerializeField] int costBuild = 50;
        [SerializeField] int costDestroy = 25;
        AudioSource audioSource;
        public bool AddTower(TowerBase towerPrefab, Vector3 position) {
            Bank bank = FindObjectOfType<Bank>();
            if (bank == null) {
                return false;
            } else if (bank.CurrentBalance >= costBuild && bank.currentTowerCount < bank.MaxTowerCount) {
                Instantiate(towerPrefab, position, Quaternion.identity);
                bank.currentTowerCount += 1;
                bank.Withdraw(costBuild);
                return true;
            } else {
                return false;
            }
        }

        void OnMouseDown() {
            Bank bank = FindObjectOfType<Bank>();
            bank.currentTowerCount -= 1;
            Vector2Int position = new Vector2Int((int)(transform.position.x / 10), (int)(transform.position.z / 10));
            GameObject tile = GameObject.Find(position.ToString());
            PathPoint pathPoint = tile.GetComponent<PathPoint>();
            pathPoint.CanPlaceTower = true;
            bank.Deposit(costDestroy);
            // Destroy the Tower
            Destroy(gameObject);
        }
    }

}
