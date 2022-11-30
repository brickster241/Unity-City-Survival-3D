using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Tower {
    public class TargetLocator : MonoBehaviour
    {
        Transform weapon;
        [SerializeField] ParticleSystem ps;
        [SerializeField] float range = 25f;
        Transform target;
        // Start is called before the first frame update
        void Awake() {
            weapon = transform.Find("BallistaTopMesh");
        }

        // Update is called once per frame
        void Update() {
            FindClosestTarget();
            AimWeapon();
        }

        void FindClosestTarget() {
            EnemyBase[] enemies = FindObjectsOfType<EnemyBase>();
            float minDistance = Mathf.Infinity;
            Transform closestTarget = null;
            foreach (EnemyBase enemy in enemies) {
                EnemyHealth enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
                float currDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (minDistance > currDistance && enemyHealth.isEnemyEnabled()) {
                    closestTarget = enemy.transform;
                    minDistance = currDistance;
                }
            }
            target = closestTarget;
        }

        void AimWeapon() {
            if (target != null) {
                float targetDistance = Vector3.Distance(transform.position, target.position);
                if (targetDistance > range) {
                    Attack(false);
                } else {
                    Attack(true);
                }
                weapon.LookAt(target);
            } else {
                Attack(false);
            }        
        }

        void Attack(bool isActive) {
            var emissionModule = ps.emission;
            emissionModule.enabled = isActive;
        }
    }

}
