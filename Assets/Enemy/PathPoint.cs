using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    [SerializeField] bool canPlaceTower = true;
    void OnMouseDown() {
        Debug.Log("You clicked at : " + transform.name + "...");
        if (canPlaceTower) {
            canPlaceTower = false;
        }
    }
}
