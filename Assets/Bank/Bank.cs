using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Balance {
    public class Bank : MonoBehaviour
    {
        [SerializeField] int startingBalance = 125;
        int currentBalance;
        public int CurrentBalance { get { return currentBalance; } }
        void Awake() {
            currentBalance = startingBalance;
        }

        public void Deposit(int amount) {
            currentBalance += Mathf.Abs(amount);
        }

        public void Withdraw(int amount) {
            currentBalance -= Mathf.Abs(amount);
        }
    }

}
