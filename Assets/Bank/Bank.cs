using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Balance {
    public class Bank : MonoBehaviour
    {
        [SerializeField] int startingBalance = 200;
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
            if (currentBalance < 0) {
                currentBalance = startingBalance;
                // Reload the Game
                ReloadScene();
            }
        }

        void ReloadScene() {
            Scene currScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currScene.buildIndex);
        }
    }

}
