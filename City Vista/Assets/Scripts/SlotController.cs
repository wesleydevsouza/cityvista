using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour {

    [HideInInspector]
    public GameController _GameController;

    private Animator animator;

    [Header("HUD Terreno")]
    public GameObject huds;
    public SpriteRenderer bgSlot;
    public SpriteRenderer buildSprite;
    public Transform hudPosition;

    [Header("HUD Compra")]
    public GameObject panelPurchase;
    public Image iconCoinPurchase;
    public Text pricePurchaseTxt;

    [Header("HUD Producao")]
    public GameObject panelProduction;
    public Image icoProd;
    public Image loadBar;
    public Text productionTxt;


    [Header("HUD Upgrade")]
    public GameObject panelUpgrade;
    public Image bgUpgrade;
    public Image progressBar;
    public Text progressTxt;
    public Image icoUp;
    public Text priceUpgradeTxt;
    public Text slotLevelTxt;

    [Header("Gameplay")]
    public slot Slot;
    private double gold;
    private float tempo;
    private float fillAmount;

    private bool isInit;


    public void StartSlot() {
        huds.transform.position = hudPosition.position;
        Slot.startSlotScriptabe();

        animator = GetComponent<Animator>();


        //Gerenciamento HUD
        if (Slot.isPurchased == false) {
            panelProduction.SetActive(false);
            panelUpgrade.SetActive(false);
            panelPurchase.SetActive(true);

            buildSprite.enabled = false;
            pricePurchaseTxt.text = _GameController.currencyConverter(Slot.slotPrice);


        } else {
            panelProduction.SetActive(true);
            panelUpgrade.SetActive(false);
            panelPurchase.SetActive(false);

            buildSprite.sprite = Slot.slotCard.spriteCard;
            buildSprite.enabled = true;

        }

        isInit = true;

    }
    void Update() {

        if (isInit == false) return;

        if (Slot.isPurchased == true) {

            if (gold == 0 && Slot.isAutoProduction == false) {
                goldProduction();

            } else if (Slot.isAutoProduction == true) {
                goldProduction();

            }


        } else {

            if (_GameController.checkGold(Slot.slotPrice) == true) {
                bgSlot.sprite = _GameController.slotBg[1];
                iconCoinPurchase.sprite = _GameController.icoCoin[1];
                pricePurchaseTxt.color = _GameController.colorText[1];

            } else {
                bgSlot.sprite = _GameController.slotBg[0];
                iconCoinPurchase.sprite = _GameController.icoCoin[0];
                pricePurchaseTxt.color = _GameController.colorText[0];
            }
        }

    }


    void goldProduction() {
        tempo += Time.deltaTime;

        if (Slot.slotTimeProduction <= 0.1f) {
            fillAmount = 1;

        } else {
            fillAmount = tempo / Slot.slotTimeProduction;
        }

        loadBar.fillAmount = fillAmount;

        if (tempo >= Slot.slotTimeProduction) {
            tempo = 0;
            gold += Slot.slotProdduction;
            productionTxt.text = _GameController.currencyConverter(Slot.slotProdduction);
            
        }

        if (gold > 0 ) {
            icoProd.gameObject.SetActive(true);

        } else {
            icoProd.gameObject.SetActive(false);

        }
    }

    void goldCollect() {
        if (gold <= 0) {
            return;
        }

        _GameController.getGold(gold);
        gold = 0;
        productionTxt.text = "0"; 

        //instan coin
        GameObject tempCoin = Instantiate(_GameController.coinPrefab, hudPosition.position, hudPosition.localRotation);
        tempCoin.GetComponent<CoinAnimation>().posY = hudPosition.position.y;
        tempCoin.GetComponent<Rigidbody2D>().AddForce(new Vector2(35, 400));
        animator.SetTrigger("collect");

      
        

    }

    private void OnMouseEnter() {                                          
        if (_GameController.currentState == GameState.GAMEPLAY && Slot.isPurchased == true) {
            goldCollect();

        } 
    }

    private void OnMouseDown() {
        if (_GameController.currentState == GameState.GAMEPLAY && Slot.isPurchased == true) {
            goldCollect();

        } else if (_GameController.currentState == GameState.GAMEPLAY && Slot.isPurchased == false) {
            _GameController.buySlot(Slot);

        }
    }
}
