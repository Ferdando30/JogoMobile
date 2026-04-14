using Unity.Services.LevelPlay;
using UnityEngine;

public class ADPLAY : MonoBehaviour
{
    [Header("LevelPlay")]
    [SerializeField] private string appKey = "25fc00d3d";
    [SerializeField] private string rewardedAdUnitId = "YOUR_REWARDED_AD_UNIT_ID";

    private LevelPlayRewardedAd rewardedAd;
    private bool isRewardedLoaded = false;

    private void Start()
    {
        LevelPlay.OnInitSuccess += OnInitSuccess;
        LevelPlay.OnInitFailed += OnInitFailed;

        LevelPlay.Init(appKey);
    }

    private void OnInitSuccess(LevelPlayConfiguration config)
    {
        Debug.Log("LevelPlay initialized successfully");

        rewardedAd = new LevelPlayRewardedAd(rewardedAdUnitId);

        rewardedAd.OnAdLoaded += OnRewardedLoaded;
        rewardedAd.OnAdLoadFailed += OnRewardedLoadFailed;
        rewardedAd.OnAdDisplayed += OnRewardedDisplayed;
        rewardedAd.OnAdDisplayFailed += OnRewardedDisplayFailed;
        rewardedAd.OnAdRewarded += OnRewardedRewarded;
        rewardedAd.OnAdClosed += OnRewardedClosed;
        rewardedAd.OnAdClicked += OnRewardedClicked;

        rewardedAd.LoadAd();
    }

    private void OnInitFailed(LevelPlayInitError error)
    {
        Debug.LogError("LevelPlay init failed: " + error);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd != null && isRewardedLoaded)
        {
            rewardedAd.ShowAd();
        }
        else
        {
            Debug.Log("Rewarded ainda não está carregado.");
        }
    }

    private void OnRewardedLoaded(LevelPlayAdInfo adInfo)
    {
        isRewardedLoaded = true;
        Debug.Log("Rewarded carregado.");
    }

    private void OnRewardedLoadFailed(LevelPlayAdError error)
    {
        isRewardedLoaded = false;
        Debug.LogError("Falha ao carregar rewarded: " + error);
    }

    private void OnRewardedDisplayed(LevelPlayAdInfo adInfo)
    {
        Debug.Log("Rewarded exibido.");
    }

    // ESTA É A ASSINATURA CORRETA
    private void OnRewardedDisplayFailed(LevelPlayAdInfo adInfo, LevelPlayAdError error)
    {
        isRewardedLoaded = false;
        Debug.LogError("Falha ao exibir rewarded: " + error);

        // tenta carregar outro
        rewardedAd.LoadAd();
    }

    private void OnRewardedRewarded(LevelPlayAdInfo adInfo, LevelPlayReward reward)
    {
        Debug.Log($"Recompensa recebida: {reward.Name} x{reward.Amount}");

        // Dê a recompensa aqui
        // Exemplo:
        // playerCoins += reward.Amount;
    }

    private void OnRewardedClosed(LevelPlayAdInfo adInfo)
    {
        Debug.Log("Rewarded fechado.");

        isRewardedLoaded = false;

        // já prepara o próximo
        rewardedAd.LoadAd();
    }

    private void OnRewardedClicked(LevelPlayAdInfo adInfo)
    {
        Debug.Log("Rewarded clicado.");
    }

    private void OnDestroy()
    {
        LevelPlay.OnInitSuccess -= OnInitSuccess;
        LevelPlay.OnInitFailed -= OnInitFailed;

        if (rewardedAd != null)
        {
            rewardedAd.OnAdLoaded -= OnRewardedLoaded;
            rewardedAd.OnAdLoadFailed -= OnRewardedLoadFailed;
            rewardedAd.OnAdDisplayed -= OnRewardedDisplayed;
            rewardedAd.OnAdDisplayFailed -= OnRewardedDisplayFailed;
            rewardedAd.OnAdRewarded -= OnRewardedRewarded;
            rewardedAd.OnAdClosed -= OnRewardedClosed;
            rewardedAd.OnAdClicked -= OnRewardedClicked;
        }
    }
}