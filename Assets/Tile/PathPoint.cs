using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tower;

namespace Tile {
    public class PathPoint : MonoBehaviour
    {
        [SerializeField] TowerBase TowerPrefab;
        [SerializeField] bool canPlaceTower = true;
        public bool CanPlaceTower { get { return canPlaceTower; } }
        void OnMouseDown() {
            // Debug.Log("You clicked at : " + transform.name + "...");
            if (canPlaceTower) {
                bool isTowerPlaced = TowerPrefab.AddTower(TowerPrefab, transform.position);
                canPlaceTower = !isTowerPlaced;
            }
        }
    }

}
