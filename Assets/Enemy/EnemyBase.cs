using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Balance;
namespace Enemy {
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] int balanceReward = 25;
        [SerializeField] int balancePenalty = 25;
        Bank bank;
        
        // Start is called before the first frame update
        void Awake()
        {
            bank = FindObjectOfType<Bank>();
        }

        public void RewardBalance() {
            if (bank != null) {
                bank.Deposit(balanceReward);
            }
        }

        public void RewardPenalty() {
            if (bank != null) {
                bank.Withdraw(balancePenalty);
            }
        }
    }

}
