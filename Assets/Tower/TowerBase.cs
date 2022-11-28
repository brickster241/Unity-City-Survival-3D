using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Balance;
namespace Tower {
    public class TowerBase : MonoBehaviour
    {
        [SerializeField] int cost = 50;
        public bool AddTower(TowerBase towerPrefab, Vector3 position) {
            Bank bank = FindObjectOfType<Bank>();
            if (bank == null) {
                return false;
            } else if (bank.CurrentBalance >= cost) {
                Instantiate(towerPrefab, position, Quaternion.identity);
                bank.Withdraw(cost);
                return true;
            } else {
                return false;
            }
        }
    }

}
