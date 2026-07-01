using Cardho;
using UnityEngine;

public class Hero : MonoBehaviour
{
    private const int MAX_SLOTS = 5; 
    public HeroData basedata;
    [HideInInspector]public int currentHP;
    [HideInInspector]public int currentSlots;
    public Card[] equippedCards = new Card[MAX_SLOTS];
    public int Speed => basedata != null ? basedata.baseSpeed : 0;
    public void Start()
    {
        currentSlots = basedata.baseSlots;
        currentHP = basedata.baseHP;
    }

    public void AddCard(Card card, int slotIndex)
    {
        // Check if index is valid
        if (slotIndex < 0 || slotIndex >= MAX_SLOTS)
        {
            Debug.LogWarning($"[AddCard] {slotIndex}does not exist");
            return;
        }

        // Check if has slot
        if (slotIndex >= currentSlots)
        {
            Debug.LogWarning($"[AddCard] {slotIndex} is locked. Max: ({currentSlots})");
            return;
        }

        // clone data for SO management
        Card cardClone = Instantiate(card);
        equippedCards[slotIndex] = cardClone;

        Debug.Log($"[AddCard] '{card.cardName}' {basedata.heroName} slot {slotIndex} ");
    }

        public void RemoveCard(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= MAX_SLOTS) return;

        if (equippedCards[slotIndex] != null)
        {
            //destroy for memory care
            Destroy(equippedCards[slotIndex]); 
            equippedCards[slotIndex] = null; // empty slot
            
            Debug.Log($"[RemoveCard] {basedata.heroName} slot {slotIndex}");
        }
    }
}
