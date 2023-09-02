using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Collection/Slot")]

public class Slot : ScriptableObject
{
    [HideInInspector]
    public GameController _GameController;
   
    public int idSlot;

    public Card slotCard;
    public Card initialCard;
    
    public bool isPurchased, isMax, isAutoProduction;

    public double slotPrice = 1;
    public double upgradePrice, slotProduction, slotTimeProduction;

    public int slotLevel, upgrades, totalUpgrades;
    public int slotProductionMultiplier = 1;

    public float slotProductionReduction = 1;

    public void Reset() {
        if (idSlot == 0) {
            isPurchased = true;

        }else{
            isPurchased=false;

        }

        slotCard = initialCard;
        slotLevel = 1;
        upgrades = 0;
        totalUpgrades = 0;
        slotProductionMultiplier = 1;
        slotProductionReduction = 1;
    }

    public void StartSlot() {
        int mult = 1;

        if (totalUpgrades > 0) {
            mult = totalUpgrades;

        }

        slotPrice = slotCard.production * slotCard.productionMult * slotProductionMultiplier * mult * _GameController.multBonus * _GameController.multBonusTemp;
        slotTimeProduction = slotCard.timeProduction / slotCard.productionRed / slotProductionReduction * _GameController.redBonus * _GameController.redBonusTemp;
    }

}
