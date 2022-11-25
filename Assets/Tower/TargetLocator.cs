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
        void Start() {
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
                float currDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (minDistance > currDistance) {
                    closestTarget = enemy.transform;
                    minDistance = currDistance;
                }
            }
            target = closestTarget;
        }

        void AimWeapon() {
            float targetDistance = Vector3.Distance(transform.position, target.position);
            if (targetDistance > range) {
                Attack(false);
            } else {
                Attack(true);
            }
            weapon.LookAt(target);
        }

        void Attack(bool isActive) {
            var emissionModule = ps.emission;
            emissionModule.enabled = isActive;
        }
    }

}
