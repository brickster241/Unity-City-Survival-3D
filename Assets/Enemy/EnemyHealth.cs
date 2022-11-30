using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Balance;
namespace Enemy {
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] public int startingHitPoints = 2;
        int hitsRemaining;
        EnemyBase enemy;
        BoxCollider boxCollider;
        MeshRenderer mr;
        int currentHitPoints;
        Bank bank;
        // Start is called before the first frame update
        void Awake() {
            enemy = gameObject.GetComponentInParent<EnemyBase>();
            boxCollider = gameObject.GetComponent<BoxCollider>();
            mr = gameObject.GetComponentInChildren<MeshRenderer>();
            bank = FindObjectOfType<Bank>();
        }

        void Update() {
            currentHitPoints = startingHitPoints + bank.CurrentLevel;
        }

        void OnParticleCollision(GameObject other) {
            if (other.transform.name == "Particle System" && hitsRemaining > 0) {
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
            hitsRemaining = currentHitPoints;
            boxCollider.enabled = true;
            mr.enabled = true;
        }

        public bool isEnemyEnabled() {
            return boxCollider.enabled && mr.enabled;
        }
    }

}
