using Cardho;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private const int MAX_SLOTS = 5; 
    public HeroData basedata;
    [HideInInspector]public int currentHP;
    [HideInInspector]public int currentSlots;
    public Card[] eqquipedCards = new Card[MAX_SLOTS];
    public void Start()
    {
        currentSlots = basedata.baseSlots;
        currentHP = basedata.baseHP;
    }

    public void addCard()
    {
        
    }
    public void removeCard()
    {
        
    }
}
