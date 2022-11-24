using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Tile {
    [ExecuteAlways]
    public class TileDisplay : MonoBehaviour
    {
        [SerializeField] Color defaultColor = Color.green;
        [SerializeField] Color blockedColor = Color.black;
        TextMeshPro textLabel;
        Vector2Int coordinates = new Vector2Int();
        PathPoint pathPoint;
        void Awake() {
            textLabel = GetComponent<TextMeshPro>();
            pathPoint = GetComponentInParent<PathPoint>();
            DisplayCoordinates();
            textLabel.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying) {
                // execute code
                DisplayCoordinates();
                UpdateObjectName();
            }
            ColorCoordinates();
            ToggleLabel();
        }

        void ColorCoordinates()
        {
            textLabel.color = pathPoint.CanPlaceTower ? defaultColor : blockedColor;
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

        void ToggleLabel() {
            if (Input.GetKeyDown(KeyCode.C)) {
                textLabel.enabled = !textLabel.enabled;
            }
        }
    }

}
