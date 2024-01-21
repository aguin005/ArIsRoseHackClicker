using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rose Upgrade/Roses Per Second", fileName = "Roses per Second")]
public class RoseUpgradePerSecond : RoseUpgrade
{
    public override void ApplyUpgrade() 
    {
        GameObject go = Instantiate(RoseManager.instance.RosePerSecToSpawn, Vector3.zero, Quaternion.identity);
        go.GetComponent<RosePerSecondTimer>().RosePerSecond = UpgradeAmount;

        RoseManager.instance.SimpleRosePerSecondIncrease(UpgradeAmount);
    }
}