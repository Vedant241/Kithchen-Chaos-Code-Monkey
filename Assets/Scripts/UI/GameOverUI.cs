using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour {

    [SerializeField] TextMeshProUGUI recipesDeliveredText;

    private void Start() {
        GameManager.instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (GameManager.instance.IsGameOver()) {
            Show();

            recipesDeliveredText.text = DeliveryManager.instance.GetSuccesFullRecipesAmount().ToString();
        } else {
            Hide();
        }
    }

    private void Update() {

    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}