using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Collection/Card")]

public class Card : ScriptableObject
{
    public int idCard;
    public string cardName;
    public Sprite spriteCard;
    public Sprite shadowCard;
    public rarity rarityCard;

    public double production;
    public int levelCard = 1;
    public bool isAvaliable;
    public float timeProduction;

    public int productionMultiplier = 1;
    public float productionReduction = 1;

    public bool isMax;

    public void reset() {
        if (idCard == 0 ) {
            isAvaliable = true;
        }else {
            isAvaliable = false;
        }

        productionMultiplier = 1;
        productionReduction = 1;
        levelCard = 1;
        isMax = false;

    }


    



}
