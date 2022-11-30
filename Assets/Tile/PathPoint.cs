using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tower;

namespace Tile {
    public class PathPoint : MonoBehaviour
    {
        [SerializeField] TowerBase TowerPrefab;
        [SerializeField] bool canPlaceTower = true;
        [SerializeField] bool isStartingRoadPoint = false;
        [SerializeField] bool isEndingRoadPoint = false;
        public bool CanPlaceTower { get { return canPlaceTower; } set { canPlaceTower = value; }}
        public bool IsStartingRoadPoint { get { return isStartingRoadPoint; } }
        public bool IsEndingRoadPoint { get { return isEndingRoadPoint; } }
        void OnMouseDown() {
            if (canPlaceTower) {
                bool isTowerPlaced = TowerPrefab.AddTower(TowerPrefab, transform.position);
                canPlaceTower = !isTowerPlaced;
            }
        }
    }

}
