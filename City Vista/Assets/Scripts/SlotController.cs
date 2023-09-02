using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GameController _GameController;

    [Header("HUD Terreno")]
    public GameObject huds;
    public SpriteRenderer bgSlot;
    public SpriteRenderer buildSprite;
    public Transform hudPosition;

    [Header("HUD Compra")]
    public GameObject panelPurchase;
    public Image icoBuy;
    public Text pricePurchaseTxt;

    [Header("HUD Producao")]
    public GameObject panelProduction;
    public Image icoProd;
    public Image productionnBar;
    public Text productionTxt;


    [Header("HUD Upgrade")]
    public GameObject panelUpgrade;
    public Image bgUpgrade;
    public Image progressBar;
    public Text progressTxt;
    public Image icoUp;
    public Text priceUpgradeTxt;
    public Text slotLevelTxt;

    [Header("Slots")]
    public Slot Slot;



    public void StartSlot()
    {
        huds.transform.position = hudPosition.position;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
