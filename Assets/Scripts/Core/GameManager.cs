using UnityEngine;

/// <summary>
/// NEXT GEN STRIKERS - Complete Game Manager
/// Orchestrates all systems and manages game flow
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private InputController inputController;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BallPhysics ballPhysics;
    [SerializeField] private UIManager uiManager;

    private VaasuJohnsonStyle currentVaasuStyle;
    private AalokStyle currentAalokStyle;
    private KingdomAbsoluteSovereignFlow vaasuFlow;
    private ConstellationSyncFlow aalokFlow;

    private GameState currentGameState = GameState.Menu;
    private PlayerCharacter selectedCharacter = PlayerCharacter.None;

    public enum GameState { Menu, CharacterSelect, Loading, InGame, Paused, GameOver }
    public enum PlayerCharacter { None, VaasuJohnson, Aalok }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeSystems();
        SetGameState(GameState.Menu);
    }

    private void InitializeSystems()
    {
        Debug.Log("=== NEXT GEN STRIKERS - Initializing Systems ===");
        
        if (inputController == null)
            inputController = GetComponent<InputController>();
        
        if (playerController == null)
            playerController = FindObjectOfType<PlayerController>();
        
        if (ballPhysics == null)
            ballPhysics = FindObjectOfType<BallPhysics>();
        
        if (uiManager == null)
            uiManager = FindObjectOfType<UIManager>();

        Debug.Log("✓ All systems initialized");
    }

    public void SetGameState(GameState newState)
    {
        currentGameState = newState;
        Debug.Log($"[GAME STATE] {newState}");
    }

    public void SelectCharacter(PlayerCharacter character)
    {
        selectedCharacter = character;
        Debug.Log($"[CHARACTER SELECT] {character}");

        if (character == PlayerCharacter.VaasuJohnson)
        {
            currentVaasuStyle = FindObjectOfType<VaasuJohnsonStyle>();
            vaasuFlow = FindObjectOfType<KingdomAbsoluteSovereignFlow>();
            Debug.Log("🎮 Loaded: VAASU JOHNSON - ABSOLUTE SOVEREIGN");
        }
        else if (character == PlayerCharacter.Aalok)
        {
            currentAalokStyle = FindObjectOfType<AalokStyle>();
            aalokFlow = FindObjectOfType<ConstellationSyncFlow>();
            Debug.Log("🎮 Loaded: AALOK - ETERNAL APEX");
        }

        SetGameState(GameState.InGame);
    }

    public GameState GetGameState() => currentGameState;
    public PlayerCharacter GetSelectedCharacter() => selectedCharacter;
}
