using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HomeMenuUI : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Text titleText;
    [SerializeField] private InputField usernameInput;
    [SerializeField] private InputField passwordInput;
    [SerializeField] private Button loginButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button claimDailyGiftButton;
    [SerializeField] private Button shopButton;
    [SerializeField] private Button profileButton;

    [SerializeField] private Color titleFlashColor = Color.cyan;
    [SerializeField] private float titleFlashInterval = 2f;
    [SerializeField] private ParticleSystem lightningVFX;

    private bool titleFlashing = false;
    private Color originalTitleColor;

    private void Start()
    {
        // Set black background
        backgroundImage.color = Color.black;

        // Store original title color
        originalTitleColor = titleText.color;

        // Start title flash
        StartCoroutine(FlashTitle());

        // Setup button listeners
        loginButton.onClick.AddListener(OnLoginClicked);
        playButton.onClick.AddListener(OnPlayClicked);
        claimDailyGiftButton.onClick.AddListener(OnClaimDailyGift);
        shopButton.onClick.AddListener(OnShopClicked);
        profileButton.onClick.AddListener(OnProfileClicked);
    }

    private IEnumerator FlashTitle()
    {
        while (true)
        {
            // Flash to cyan
            titleText.color = titleFlashColor;
            TriggerLightningVFX();
            yield return new WaitForSeconds(0.3f);

            // Flash back to normal
            titleText.color = originalTitleColor;
            yield return new WaitForSeconds(titleFlashInterval - 0.3f);
        }
    }

    private void TriggerLightningVFX()
    {
        if (lightningVFX != null)
        {
            lightningVFX.Play();
        }
    }

    private void OnLoginClicked()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        // Authenticate user
        Debug.Log($"Logging in: {username}");
        // Call authentication system
    }

    private void OnPlayClicked()
    {
        // Show game mode selection
        Debug.Log("Opening game mode menu");
    }

    private void OnClaimDailyGift()
    {
        // Award 1500 Bucks
        Debug.Log("Daily gift claimed: +1500 Bucks");
    }

    private void OnShopClicked()
    {
        // Open shop menu
        Debug.Log("Opening shop");
    }

    private void OnProfileClicked()
    {
        // Open player profile
        Debug.Log("Opening profile");
    }
}
