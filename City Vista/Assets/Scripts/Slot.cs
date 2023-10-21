using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Collection/Slot")]

public class slot : ScriptableObject {
[HideInInspector]
    public GameController _GameController;
    public int idSlot;

    public Card slotCard;
    public Card initialcard;

    public bool isPurchased;
    public bool isMas;
    public bool isAutoProduction;

    public double slotPrice;
    public int slotLevel = 1;
    public int upgrades;
    public int totalUpgrades;

    public double upgradePrice;

    public double slotProdduction;
    public float slotTimeProduction;

    public int slotProductionMultiplier = 1;    public float slotProductionReduction = 1;

    public void reset() {

        if (idSlot == 0) {
            isPurchased = true;

        } else {
            isPurchased = false;
        }

        slotCard = initialcard;
        slotLevel = 1;
        upgrades = 0;
        totalUpgrades = 1;
        slotProductionMultiplier = 1;
    }
    


    public void startSlotScriptabe() {

        int mult = 1;

        if (totalUpgrades > 0) {
            mult = totalUpgrades;

                 
        }

        slotProdduction = slotCard.production * slotCard.productionMultiplier * slotProductionMultiplier * mult * _GameController.multiplierBonus * _GameController.multiplierBonusTemp;
        slotTimeProduction = slotCard.timeProduction / slotCard.productionReduction / slotProductionReduction / _GameController.reductionBonus / _GameController.reductionBonusTemp;

        upgradePrice = slotProductionReduction * slotProductionMultiplier * mult * 1.5f;

    }  
}