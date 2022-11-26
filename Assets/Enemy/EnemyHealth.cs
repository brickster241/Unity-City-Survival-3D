using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy {
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] int maxHitPoints = 5;
        int hitsRemaining;
        EnemyBase enemy;
        // Start is called before the first frame update
        void Start() {
            enemy = GetComponentInParent<EnemyBase>();
        }

        void OnEnable()
        {
            hitsRemaining = maxHitPoints;
        }

        void OnParticleCollision(GameObject other) {
            Debug.Log("Successful Hit. Let's goo!!");
            if (other.transform.name == "Particle System" && hitsRemaining > 0) {
                hitsRemaining -= 1;
                if (hitsRemaining == 0) {
                    enemy.RewardBalance();
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
