using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountDownUI : MonoBehaviour {

    private const string NUMBER_POP = "NumberPopUp";

    [SerializeField] private TextMeshProUGUI countDownText;

    private Animator animator;

    private int previousCountDownNumber;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        GameManager.instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if(GameManager.instance.IsCountDownToStartActive()) {
            Show();
        } else {
            Hide();
        }
    }

    private void Update() {
        int countDownNumber = Mathf.CeilToInt(GameManager.instance.GetCountDownToStartTimer());
        countDownText.text = countDownNumber.ToString();

        if(previousCountDownNumber != countDownNumber) {
            previousCountDownNumber = countDownNumber;
            animator.SetTrigger(NUMBER_POP);
            SoundManager.instance.PlayCountDownSound();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }
}
