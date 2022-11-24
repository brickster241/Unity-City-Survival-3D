using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Tile {
    [ExecuteAlways]
    public class TileDisplay : MonoBehaviour
    {
        TextMeshPro textLabel;
        Vector2Int coordinates = new Vector2Int();
        void Awake() {
            textLabel = GetComponent<TextMeshPro>();
            DisplayCoordinates();
        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying) {
                // execute code
                DisplayCoordinates();
                UpdateObjectName();
            }
        }

        void DisplayCoordinates()
        {
            coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
            coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
            textLabel.text = coordinates.x + ", " + coordinates.y;
        }

        void UpdateObjectName()
        {
            transform.parent.name = coordinates.ToString();
        }
    }

}
