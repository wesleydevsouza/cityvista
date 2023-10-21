using UnityEngine;
using UnityEngine.UI;

public enum GameState{
    GAMEPLAY, COLLECTION, UPGRADE, CUT
}

public enum rarity { 
    COMUM, RARA, EPICA, LENDARIA
}


public class GameController : MonoBehaviour
{
    public bool isReset;
    
    [Header("Gerenciamento Sprites Hud")]
    public Sprite[] icoCoin;  // 0 Inativa / 1 Ativa
    public Sprite[] slotBg;  // 0 Inativa / 1 Ativa
    public Sprite[] bgUpgradeHud;  // 0 Inativa / 1 Ativa / 2 Maximizado
    public Color[] colorText; // 0 Inativa / 1 Ativa    


    [Header("Hud Gameplay")]
    public GameObject panelFume;
    public Text coinTxt;
    public Text gemsTxt;

    public GameObject panelQuest;
    public Text questTxt;
    public bool isQuest;
    public int idQuest;
    [TextArea]
    public string[] questDesctiption;

    public GameObject btnUpgradeMode;
    public GameObject btnCollectionMode;

    [Header("Scriptables")]
    public Card[] cards;
    public slot[] slots;

    [Header("Prefabs")]
    public GameObject coinPrefab;
    public GameObject textPrefab;

    [Header("Variáveis de Gameplay")]
    public GameState currentState;
    private double gold, goldAccumulated;
    private int gems, gemAccumulated;

    [Header("Bonus de Gameplay")]
    public int multiplierBonus;
    public int multiplierBonusTemp;
    public float reductionBonus;
    public float reductionBonusTemp;

    [SerializeField]
    private SlotController[] _SlotController;

    // Start is called before the first frame update
    void Start()
    {
        if (isReset == true) {
            resete();
        }

        panelFume.SetActive(false);
        panelQuest.SetActive(false);

        if (isQuest) {
            panelQuest.SetActive(true);

        } 

        _SlotController = FindObjectsOfType(typeof(SlotController)) as SlotController[];

        foreach (SlotController s in _SlotController){
            s._GameController = this;
            s.Slot._GameController = this;
            
            s.StartSlot();


        }
        
        
    }

    void Update()
    {
        
    }
    
    public void getGold(double qtd) {
        gold += qtd;

        if (qtd > 0) {
            goldAccumulated += qtd;
        }

        coinTxt.text = currencyConverter(gold);

    }

    public void getGold(int qtd) {
        gems += qtd;

        if (gems > 0) {
            gems += qtd;
        }

        gemsTxt.text = gemsTxt.ToString();

    }

    public string currencyConverter(double valor) { 
        return valor.ToString();    
    }

    private void resete() {
        foreach(Card c in cards) {
            c.reset();
        }

        foreach (slot s in slots) {
            s.reset();

        }
    }

    public bool checkGold(double qtd) {

        bool check = false;

        if ( gold >= qtd) {
                check = true;
        }

        return check;
    }

    public void buySlot(slot s) { 
        
    }
}

