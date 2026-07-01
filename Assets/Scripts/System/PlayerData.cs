using UnityEngine;
using Cardho;
using System.Collections.Generic;

public class PlayerData : Singleton<PlayerData>
{
    [SerializeField] private List<Hero> heroInventory = new();
    [SerializeField] private List<Card> cardInventory = new();
    [SerializeField] private Hero startHero1Prefab; // Default = Squire (can change via reincarnation progression)
    [SerializeField] private Hero startHero2Prefab; // Default = Theif (can change via reincarnation progression)
    [SerializeField] private Hero startHero3Prefab; // Default = Mage (can change via reincarnation progression)
    public IReadOnlyList<Hero> HeroInventory => heroInventory;
    public IReadOnlyList<Card> CardInventory => cardInventory;
     protected override void Awake()
    {
      base.Awake();
      //TODO: Save/Load or initialize starting deck. 
      AddStartingDeck();
    }
    
    public bool AddHero(Hero hero)
    {
        if (hero == null)
        {
            Debug.LogWarning("[AddHero] Hero is null");
            return false;
        }
        heroInventory.Add(hero);
        Debug.Log($"[AddHero] {hero.basedata.heroName} added to inventory");
        return true;
    }
    public bool AddCard(Card card)
    {
        if (card == null)
        {
            Debug.LogWarning("[AddCard] Card is null");
            return false;
        }
        cardInventory.Add(card);
        Debug.Log($"[AddCard] {card.cardName} added to inventory");
        return true;
    }
    public bool RemoveHero(Hero hero)
    {
        if (!heroInventory.Contains(hero))
        {
            Debug.LogWarning($"[RemoveHero] {hero.basedata.heroName} not in inventory");
            return false;
        }
        heroInventory.Remove(hero);
        Debug.Log($"[RemoveHero] {hero.basedata.heroName} removed from inventory");
        return true;
    }
    public bool RemoveCard(Card card)
    {
        if (!cardInventory.Contains(card))
        {
            Debug.LogWarning($"[RemoveCard] {card.cardName} not in inventory");
            return false;
        }
        cardInventory.Remove(card);
        Debug.Log($"[RemoveCard] {card.cardName} removed from inventory");
        return true;
    }
    public Hero AcquireHero(Hero prefab)
    {
        
        if (prefab == null)
        {
            Debug.LogError("[CreateHero] Hero prefab is null.");
            return null;
        }
        Hero hero = Instantiate(prefab, transform);
        if (!AddHero(hero))
        {
            Destroy(hero.gameObject);
            return null;
        }

        return hero;
    }
  
    private void AddStartingDeck()
    {
        // Initialize the starting deck here
        AcquireHero(startHero1Prefab);
        AcquireHero(startHero2Prefab);
        AcquireHero(startHero3Prefab);
    }

}
