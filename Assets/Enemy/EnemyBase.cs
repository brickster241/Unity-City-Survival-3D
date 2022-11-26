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
        void Start()
        {
            bank = FindObjectOfType<Bank>();
        }

        public void RewardBalance() {
            if (bank != null) {
                bank.Deposit(balanceReward);
                Debug.Log(bank.CurrentBalance);
            }
        }

        public void RewardPenalty() {
            if (bank != null) {
                bank.Withdraw(balancePenalty);
                Debug.Log(bank.CurrentBalance);
            }
        }
    }

}
