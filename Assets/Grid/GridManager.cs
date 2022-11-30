using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Tile;

namespace Grid {
    public class GridManager : MonoBehaviour
    {
        [SerializeField] public Vector2Int gridSize = new Vector2Int(11, 9);
        Dictionary<Vector2Int, GridNode> grid = new Dictionary<Vector2Int, GridNode>();
        List<Vector2Int> startingRoadPoints = new List<Vector2Int>();
        List<Vector2Int> endingRoadPoints = new List<Vector2Int>(); 


        void Awake() {
            // fill out the grid
            for (int x = 0; x < gridSize.x; x++) {
                for (int y = 0; y < gridSize.y; y++) {
                    Vector2Int coordinates = new Vector2Int(x * 10, y * 10);
                    grid.Add(coordinates, new GridNode(coordinates));
                }
            }

            // fill out the Roads
            GameObject[] roadTiles = GameObject.FindGameObjectsWithTag("Road");
            foreach (GameObject roadTile in roadTiles) {
                PathPoint pathPoint = roadTile.GetComponent<PathPoint>();
                Vector3 position = roadTile.transform.position;
                Vector2Int coordinates = new Vector2Int((int)position.x, (int)position.z);
                GridNode node = grid[coordinates];
                node.isRoad = true;
                node.isStartingRoadPoint = pathPoint.IsStartingRoadPoint;
                node.isEndingRoadPoint = pathPoint.IsEndingRoadPoint;
                if (node.isStartingRoadPoint) {
                    startingRoadPoints.Add(node.coordinates);
                } else if (node.isEndingRoadPoint) {
                    endingRoadPoints.Add(node.coordinates);
                }
            }
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                // Quit Application
                Application.Quit();
            }
        }

        public List<Vector2Int> FindNewPath() {
            List<Vector2Int> path = new List<Vector2Int>();
            int startingIndex = Random.Range(0, startingRoadPoints.Count);
            Vector2Int startingPoint = startingRoadPoints[startingIndex];
            path.Add(startingPoint);
            Vector2 direction = Vector2.left;
            while (!endingRoadPoints.Contains(path[path.Count - 1])) {
                List<Vector2Int> neighbours = new List<Vector2Int>();
                Vector2Int currentNode = path[path.Count - 1];
                // search in all three directions
                if (grid[currentNode + Vector2Int.right * 10].isRoad) {
                    neighbours.Add(currentNode + Vector2Int.right * 10);
                }
                if (grid[currentNode + Vector2Int.up * 10].isRoad && direction != Vector2.down) {
                    neighbours.Add(currentNode + Vector2Int.up * 10);
                }
                if (grid[currentNode + Vector2Int.down * 10].isRoad && direction != Vector2.up) {
                    neighbours.Add(currentNode + Vector2Int.down * 10);
                }
                // To remove the IndexOutOfBoundsError
                neighbours.Add(currentNode + Vector2Int.left * 10);
                int neighbourIndex = Random.Range(0, neighbours.Count - 1);
                Vector2Int nextInPath = neighbours[neighbourIndex];
                direction = (nextInPath - currentNode) / 10;
                path.Add(nextInPath);
            }
            return path;
        }
    }

}
