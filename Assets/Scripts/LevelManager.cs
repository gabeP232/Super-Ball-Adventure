using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance;

    [Header("Level Goals")]
    public int coinsRequired = 0;
    public int buttonsRequired = 0; // 0 - Disabled, 1 - 1 button press needed


    [Header("HUD Elements")]
    public TextMeshProUGUI winText;
    public TextMeshProUGUI deathText;
    public TextMeshProUGUI coinText;

    private int coinsCollected = 0;
    private int buttonsPressed = 0;

    private bool levelComplete = false;

    private void Awake() {
        Instance = this;

        if (coinText != null) {
            updateCoinUI();
        }
    }

    public void addCoin(int add) {
        coinsCollected = coinsCollected + add;

        //Debug.Log("LevelManager -- Coin Picked Up");
        updateCoinUI();
        checkWin();
    }
    
    private void updateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinsCollected + " / " + coinsRequired;
        }
    }

    public void addButtonPress() {
        buttonsPressed++;
        checkWin();
    }

    public void removeButtonPress() {
        buttonsPressed--;
        checkWin();
    }

    private void checkWin() {
        if (levelComplete) {
            return;
        }

        bool coinsSatisfied = coinsCollected >= coinsRequired;
        bool buttonsSatisfied = buttonsRequired == 0 || buttonsPressed >= buttonsRequired;

        if (coinsSatisfied && buttonsSatisfied) {
            levelComplete = true;
            //Debug.Log("Level complete");
            //Debug.Log(winText);
            if (winText != null) {
                //Debug.Log("TEXT");
                winText.gameObject.SetActive(true);
                winText.enabled = true;
            }
        }
    }

    public void PlayerDied() {
        Debug.Log("Player died");

        if (deathText != null) {
            deathText.gameObject.SetActive(true);
            deathText.enabled = true;
        }
    }
}
