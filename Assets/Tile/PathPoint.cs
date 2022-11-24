using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tile {
    public class PathPoint : MonoBehaviour
    {
        [SerializeField] GameObject TowerPrefab;
        [SerializeField] bool canPlaceTower = true;
        void OnMouseDown() {
            Debug.Log("You clicked at : " + transform.name + "...");
            if (canPlaceTower) {
                Instantiate(TowerPrefab, transform.position, Quaternion.identity);
                canPlaceTower = false;
            }
        }
    }

}
