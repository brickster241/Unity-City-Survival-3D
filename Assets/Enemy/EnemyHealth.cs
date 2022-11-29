using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] int maxHitPoints = 3;
        int hitsRemaining;
        EnemyBase enemy;
        BoxCollider boxCollider;
        MeshRenderer mr;
        // Start is called before the first frame update
        void Awake() {
            enemy = gameObject.GetComponentInParent<EnemyBase>();
            boxCollider = gameObject.GetComponent<BoxCollider>();
            mr = gameObject.GetComponentInChildren<MeshRenderer>();
        }

        void OnParticleCollision(GameObject other) {
            if (other.transform.name == "Particle System" && hitsRemaining > 0) {
                Debug.Log("Successful Hit. Let's goo!!");
                hitsRemaining -= 1;
                if (hitsRemaining == 0) {
                    enemy.RewardBalance();
                    DisableEnemy();
                }
            }
        }

        public void DisableEnemy() {
            boxCollider.enabled = false;
            mr.enabled = false;
        }

        public void EnableEnemy() {
            hitsRemaining = maxHitPoints;
            boxCollider.enabled = true;
            mr.enabled = true;
        }

        public bool isEnemyEnabled() {
            return boxCollider.enabled && mr.enabled;
        }
    }

}
