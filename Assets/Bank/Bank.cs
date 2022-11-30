using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

namespace Balance {
    public class Bank : MonoBehaviour
    {
        int levelUpDeficit = 50;
        int currentBalance;
        int currentLevel = 1;
        [SerializeField] int maxTowerCount = 5;
        [SerializeField] int startingBalance = 250;
        [SerializeField] int levelUpBalance = 500;
        [SerializeField] TextMeshProUGUI balanceLabel;
        [SerializeField] TextMeshProUGUI levelLabel;
        [SerializeField] TextMeshProUGUI hitPointsLabel;
        public int currentTowerCount = 0;
        public int CurrentBalance { get { return currentBalance; } }
        public int CurrentLevel { get { return currentLevel; } }
        public int MaxTowerCount { get { return maxTowerCount; } }
        AudioSource audioSource;
        int startingHits = 2;
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
            int hits = startingHits + currentLevel;
            hitPointsLabel.text = "HITS / KILL : " + hits;
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
