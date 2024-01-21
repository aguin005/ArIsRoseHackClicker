using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class RoseManager : MonoBehaviour
{
    public static RoseManager instance;
    public GameObject MainGameCanvas;
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private TextMeshProUGUI _roseCountText;
    [SerializeField] private TextMeshProUGUI _rosePerSecondText;
    [SerializeField] private GameObject _roseObj;
    public GameObject RoseTextPopup;
    [SerializeField] private GameObject _backgroundObj;

    [Space]
    public RoseUpgrade[] RoseUpgrades;
    [SerializeField] private GameObject _upgradeUIToSpawn;
    [SerializeField] private Transform _upgradeUIParent;
    public GameObject RosePerSecToSpawn;

    public double CurrRoseCount { get; set; }

    public double CurrRosePerSecond { get; set; }

    public double RosePerClickUpgrade { get; set; }

    private InitializeUpgrades _initializeUpgrades;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        UpdateRoseUI();
        UpdateRosePerSecondUI();

        _upgradeCanvas.SetActive(false);
        MainGameCanvas.SetActive(true);

        _initializeUpgrades = GetComponent<InitializeUpgrades>();
        _initializeUpgrades.Initialize(RoseUpgrades, _upgradeUIToSpawn, _upgradeUIParent);
    }

    #region On Rose Clicked

    public void OnRoseClicked()
    {
        IncreaseRose();

        _roseObj.transform.DOBlendableScaleBy(new Vector3(1f, 1f, 1f), 1f).OnComplete(RoseScaleBack);
        _backgroundObj.transform.DOBlendableScaleBy(new Vector3(1f, 1f, 1f), 1f).OnComplete(BackGroundScaleBack);

    }

    private void RoseScaleBack()
    {
        _roseObj.transform.DOBlendableScaleBy(new Vector3(-1f, -1f, -1f), -1f);

    }

    private void BackGroundScaleBack()
    {
        _backgroundObj.transform.DOBlendableScaleBy(new Vector3(-1f, -1f, -1f), -1f);

    }

    public void IncreaseRose()
    {
        CurrRoseCount = CurrRoseCount + 1 + RosePerClickUpgrade;
        UpdateRoseUI();
    }

    #endregion
    #region UI Updates

    private void UpdateRoseUI()
    {
        _roseCountText.text = CurrRoseCount.ToString();
    }

    private void UpdateRosePerSecondUI()
    {
        _rosePerSecondText.text = CurrRosePerSecond.ToString() + " Roses/Sec";
    }


    #endregion
    #region Button Presses
        public void OnUpgradeButtonPress() {
            MainGameCanvas.SetActive(false);
            _upgradeCanvas.SetActive(true);
        }
        public void OnResumeButtonPress() {
            _upgradeCanvas.SetActive(false);
            MainGameCanvas.SetActive(true);
        }

    #endregion
    #region  Simple Increases
    
    public void SimpleRoseIncrease(double amount) {
        CurrRoseCount += amount;
        UpdateRoseUI();
    }

    public void SimpleRosePerSecondIncrease(double amount) {
        CurrRosePerSecond += amount;
        UpdateRosePerSecondUI();
    }
    #endregion
    #region Events
    public void OnUpgradeButtonClick(RoseUpgrade upgrade, UpgradeButtonReferences buttonRef) 
    {
        if (CurrRoseCount >= upgrade.CurrentUpgradeCost)
        {
            upgrade.ApplyUpgrade();

            CurrRoseCount -= upgrade.CurrentUpgradeCost;
            UpdateRoseUI();

            upgrade.CurrentUpgradeCost = Mathf.Round((float)(upgrade.CurrentUpgradeCost * (1 + upgrade.CostIncreaseMultiplierPurchase)));

            buttonRef.UpgradeCostText.text = "Cost: " + upgrade.CurrentUpgradeCost;
        }
    }
    #endregion
}
