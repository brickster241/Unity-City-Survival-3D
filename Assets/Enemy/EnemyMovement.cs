using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tile;

namespace Enemy {
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] List<PathPoint> path = new List<PathPoint>();
        [SerializeField] float speed = 1f;
        // Start is called before the first frame update
        void OnEnable()
        {
            FindPath();
            StartCoroutine(TravelPathPoints());
        }

        void FindPath() {
            path.Clear();
            GameObject[] pathPoints = GameObject.FindGameObjectsWithTag("Path");
            foreach (GameObject pathPoint in pathPoints) {
                path.Add(pathPoint.GetComponent<PathPoint>());
            }
            transform.position = path[0].transform.position;
        }

        IEnumerator TravelPathPoints() {
            foreach (PathPoint pathPoint in path) {
                Debug.Log("Travelling to " + pathPoint.name + "...");
                Vector3 startPosition = transform.position;
                Vector3 endPosition = pathPoint.transform.position;
                transform.LookAt(endPosition);
                float travelPercent = 0f;
                while (travelPercent < 1f) {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }
            gameObject.SetActive(false);
        }
    }

}
