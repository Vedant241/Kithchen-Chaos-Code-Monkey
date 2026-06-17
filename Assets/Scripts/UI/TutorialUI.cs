using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI gamepadInteractText;
    [SerializeField] private TextMeshProUGUI gamepadAlternateText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;

    private void Start() {
        GameInput.instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameManager.instance.OnStateChanged += GameManager_OnStateChanged;

        UpdateVisual();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (GameManager.instance.IsCountDownToStartActive()) {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        keyMoveUpText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_up);
        keyMoveDownText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_down);
        keyMoveLeftText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_left);
        keyMoveRightText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_right);
        keyInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        keyAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.InteractAlternate);
        keyPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);
        gamepadInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        gamepadAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlt);
        gamepadPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
    