using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Collection/Card")]

public class Card : ScriptableObject
{
    public int idCard;
    public string cardName;
    public Sprite spriteCard;
    public Sprite shadowCard;
    public rarityCard rarityCard;

    public bool isAvaliable;
    public double production;
    public float timeProduction;
    public int levelCard = 1;

    public int productionMult = 1;
    public float productionRed = 1;

    public bool isMax;

    public void Reset()
    {

        if (idCard == 0)
        {
            isAvaliable = true;

        }
        else
        {
            isAvaliable = false;

        }

        levelCard = 1;
        productionMult = 1;
        productionRed = 1;
        isMax = false;
    }


}
