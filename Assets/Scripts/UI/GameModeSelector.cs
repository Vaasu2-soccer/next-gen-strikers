using UnityEngine;
using UnityEngine.UI;

public class GameModeSelector : MonoBehaviour
{
    [SerializeField] private Button fourVFourButton;
    [SerializeField] private Button eightVEightButton;

    public enum GameMode
    {
        PrivateMode,
        CasualMode,
        RankedMode
    }

    private GameMode selectedGameMode;

    private void Start()
    {
        fourVFourButton.onClick.AddListener(() => SelectTeamSize(4));
        eightVEightButton.onClick.AddListener(() => SelectTeamSize(8));
    }

    private void SelectTeamSize(int teamSize)
    {
        Debug.Log($"Selected {teamSize}v{teamSize} match");
        // Load appropriate game scene
    }
}
