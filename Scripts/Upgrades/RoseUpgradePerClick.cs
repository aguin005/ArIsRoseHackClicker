using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rose Upgrade/Rose Per Click", fileName = "Roses Per Click")]
public class RoseUpgradePerClick : RoseUpgrade
{
    public override void ApplyUpgrade()
    {
        RoseManager.instance.RosePerClickUpgrade += UpgradeAmount;
    }
}
