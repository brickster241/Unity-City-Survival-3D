using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Tower {
    public class TargetLocator : MonoBehaviour
    {
        Transform weapon;
        Transform target;
        // Start is called before the first frame update
        void Start()
        {
            target = FindObjectOfType<EnemyMovement>().transform;
            weapon = transform.Find("BallistaTopMesh");
        }

        // Update is called once per frame
        void Update()
        {
            AimWeapon();
        }

        void AimWeapon() {
            weapon.LookAt(target);
        }
    }

}
