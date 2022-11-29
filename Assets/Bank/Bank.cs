using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

namespace Balance {
    public class Bank : MonoBehaviour
    {
        [SerializeField] int startingBalance = 250;
        [SerializeField] int levelUpBalance = 500;
        int levelUpDeficit = 50;
        [SerializeField] TextMeshProUGUI balanceLabel;
        [SerializeField] TextMeshProUGUI levelLabel;
        int currentBalance;
        int currentLevel = 1;
        public int CurrentBalance { get { return currentBalance; } }
        public int CurrentLevel { get { return currentLevel; } }
        AudioSource audioSource;
        void Awake() {
            currentBalance = startingBalance;
            audioSource = GetComponent<AudioSource>();
        }

        void Update() {
            UpdateLabels();
        }

        void UpdateLabels() {
            balanceLabel.text = "BANK : " + currentBalance + " / " + levelUpBalance;
            levelLabel.text = "LEVEL : " + currentLevel;
        }

        public void Deposit(int amount) {
            currentBalance += Mathf.Abs(amount);
            // Level Up Condition
            if (currentBalance >= levelUpBalance) {
                UpdateLabels();
                currentBalance = Mathf.Max(startingBalance - levelUpDeficit * currentLevel, 0);
                currentLevel += 1;
                audioSource.Play();
            }
        }

        public void Withdraw(int amount) {
            currentBalance -= Mathf.Abs(amount);
            // Losing Condition
            if (currentBalance < 0) {
                currentBalance = startingBalance;
                currentLevel = 1;
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
