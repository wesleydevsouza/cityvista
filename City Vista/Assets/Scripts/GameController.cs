using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.UI;

public enum GameState{
    GAMEPLAY, COLLECTION, UPGRADE, CUT
}

public enum rarityCard { 
    COMUM, RARA, EPICA, LENDARIA
}


public class GameController : MonoBehaviour
{
    public bool isReset;

    [Header("Gerenciamento Sprites Hud")]
    public Sprite[] icoCoin;  // 0 Inativa / 1 Ativa
    public Sprite[] slotBg;  // 0 Inativa / 1 Ativa
    public Sprite[] bgUpgradeHud;  // 0 Inativa / 1 Ativa / 2 Maximizado


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
    public Card[] Cards;
    public Slot[] Slots;

    [Header("Variáveis de Gameplay")]
    public GameState currentState;
    private double gold, goldAccumulated;
    private int gems, gemAccumulated;

    [Header("Bonus de Gameplay")]
    public int multBonus;
    public int multBonusTemp;
    public float redBonus, redBonusTemp;

    [SerializeField]
    private SlotController[] _SlotController;

    


    // Start is called before the first frame update
    void Start()
    {
        if (isReset == true) {
            Rst();
        }

        panelFume.SetActive(false);

        if (isQuest) {
            panelQuest.SetActive(true);

        }

        _SlotController = FindObjectsOfType(typeof(SlotController)) as SlotController[];

        foreach (SlotController s in _SlotController){
            s._GameController = this;
            s.StartSlot();


        }
        
        
    }

    // Update is called once per frame
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

    private void Rst() { 
        foreach(Card c in Cards) {
            c.Reset();

        }

        foreach (Slot s in Slots) {
            s.Reset();

        }
    }
}

