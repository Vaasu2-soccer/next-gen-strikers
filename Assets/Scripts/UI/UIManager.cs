using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// UIManager - Handles all UI elements for NEXT GEN STRIKERS
/// </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Text debugText;
    [SerializeField] private Image powerBarFill;
    [SerializeField] private Text shootPowerText;
    [SerializeField] private Image flowBarFill;
    [SerializeField] private Text flowPercentText;
    [SerializeField] private Text characterNameText;
    [SerializeField] private Text statsText;
    [SerializeField] private Text abilityCooldownText;

    private InputController inputController;
    private GameManager gameManager;

    private void Start()
    {
        inputController = FindObjectOfType<InputController>();
        gameManager = GameManager.Instance;

        // Create UI elements if not assigned
        if (debugText == null)
            CreateDebugUI();
    }

    private void Update()
    {
        UpdateDebugDisplay();
        UpdatePowerBar();
        UpdateFlowBar();
    }

    private void CreateDebugUI()
    {
        if (mainCanvas == null)
        {
            GameObject canvasGO = new GameObject("MainCanvas");
            mainCanvas = canvasGO.AddComponent<Canvas>();
            mainCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        // Create debug text
        GameObject debugGO = new GameObject("DebugText");
        debugGO.transform.SetParent(mainCanvas.transform, false);
        debugText = debugGO.AddComponent<Text>();
        debugText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        debugText.fontSize = 14;
        debugText.alignment = TextAnchor.UpperLeft;
        debugGO.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 400);
    }

    private void UpdateDebugDisplay()
    {
        if (debugText == null) return;

        string debug = "=== NEXT GEN STRIKERS DEBUG ===\n";
        debug += $"Game State: {gameManager.GetGameState()}\n";
        debug += $"Character: {gameManager.GetSelectedCharacter()}\n";
        debug += "\n[CONTROLS]\n";
        debug += "M = Pass\n";
        debug += "Left-Click = Shoot (Hold for power)\n";
        debug += "Q = Dribble\n";
        debug += "E = Tackle\n";
        debug += "Left Shift = Sprint\n";
        debug += "Right Shift = Shift Lock\n";
        debug += "X = Awakening\n";
        debug += "F = Flow Activation\n";
        debug += "Z/V/B/C = Moves 1-4\n";
        debug += "\n[INFO]\n";
        debug += $"FPS: {Mathf.Round(1f / Time.deltaTime)}\n";

        debugText.text = debug;
    }

    private void UpdatePowerBar()
    {
        if (inputController == null || powerBarFill == null) return;

        if (inputController.IsChargingShot())
        {
            powerBarFill.fillAmount = inputController.GetShootPower();
            if (shootPowerText != null)
                shootPowerText.text = $"Power: {inputController.GetShootPower() * 100:F0}%";
        }
        else
        {
            powerBarFill.fillAmount = 0f;
            if (shootPowerText != null)
                shootPowerText.text = "";
        }
    }

    private void UpdateFlowBar()
    {
        if (flowBarFill == null) return;

        // This will be updated when flow system is connected
        flowBarFill.fillAmount = 0.5f; // Placeholder
        if (flowPercentText != null)
            flowPercentText.text = "Flow: 50%";
    }

    public void ShowCharacterStats(string characterName, string stats)
    {
        if (characterNameText != null)
            characterNameText.text = characterName;

        if (statsText != null)
            statsText.text = stats;
    }

    public void UpdateAbilityCooldowns(string cooldowns)
    {
        if (abilityCooldownText != null)
            abilityCooldownText.text = cooldowns;
    }
}
