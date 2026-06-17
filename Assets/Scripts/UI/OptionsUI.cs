using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

    public static OptionsUI instance {  get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAltButton;
    [SerializeField] private Button gamepadInteractButton;
    [SerializeField] private Button gamepadInteractAltButton;
    [SerializeField] private Button gamepadPauseButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI gamepadInteractText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;
    [SerializeField] private Transform pressToBindKeyTransform;

    private Action onCloseButtonAction;

    private void Awake() {
        instance = this;

        soundEffectsButton.onClick.AddListener(() => {
            SoundManager.instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() => {
            MusicManager.instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(() => {
            Hide();
            onCloseButtonAction();
        });

        moveUpButton.onClick.AddListener(() => {RebindBinding(GameInput.Binding.Move_up);});
        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Move_right); });
        interactButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Interact); });
        interactAltButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.InteractAlternate); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Pause); });
        gamepadInteractButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Interact); });
        gamepadInteractAltButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_InteractAlt); });
        gamepadPauseButton.onClick.AddListener(() => { RebindBinding(GameInput.Binding.Gamepad_Pause); });
    }
    private void Start() {
        GameManager.instance.OnGameUnPaused += GameManager_OnGameUnPaused;
        UpdateVisual();

        HidePressToRebindKey();
        Hide();
    }

    private void GameManager_OnGameUnPaused(object sender, System.EventArgs e) {
        Hide();
    }

    private void UpdateVisual() {
        soundEffectsText.text = "Sound Effects: " + Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.instance.GetVolume() * 10f);

        moveUpText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_up);
        moveDownText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_down);
        moveLeftText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_left);
        moveRightText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_right);
        interactText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);
        gamepadInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        gamepadInteractAlternateText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlt);
        gamepadPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Pause);

    }

    public void Show(Action onCloseButtonAction) {
        this.onCloseButtonAction = onCloseButtonAction;

        gameObject.SetActive(true);

        soundEffectsButton.Select();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey() {
        pressToBindKeyTransform.gameObject.SetActive(true);
    }

    private void HidePressToRebindKey() {
        pressToBindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding) {
        ShowPressToRebindKey();
        GameInput.instance.RebindBinding(binding,()=> {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
