using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Grid {
    [System.Serializable]
    public class GridNode
    {
        public bool isStartingRoadPoint = false;
        public bool isEndingRoadPoint = false;
        public bool isRoad = false;
        public Vector2Int coordinates;

        public GridNode(Vector2Int coordinates, bool isRoad = false, bool isStartingRoadPoint = false, bool isEndingRoadPoint = false) {
            this.coordinates = coordinates;
            this.isRoad = isRoad;
            this.isStartingRoadPoint = isStartingRoadPoint;
            this.isEndingRoadPoint = isEndingRoadPoint;
        }
    }

}
