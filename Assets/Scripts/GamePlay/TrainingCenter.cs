using UnityEngine;
using Cardho;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class TrainingCenter : MonoBehaviour
{
    [Header("Hero Pool")]
    [SerializeField] private List<Hero> heroOfferPool = new();

    [Header("Current HeroSale")]
    [SerializeField] private List<Hero> heroesOnSale = new();
    [SerializeField] private int trainingCenterLevel = 1;
    private int MaxHeroesOnSale => trainingCenterLevel + 2;
    public IReadOnlyList<Hero> HeroesOnSale => heroesOnSale;

    [Header("Current CardSale")]
    [SerializeField] private List<CardPoolEntry> cardOfferPool = new();
    [SerializeField] private List<Card> cardsOnSale = new();
    public IReadOnlyList<Card> CardsOnSale => cardsOnSale;
    private int MaxCardsOnSale => trainingCenterLevel*2 + 1;


    public void Start()
    {
        // Initialize the training center with some heroes for sale
        PopulateHeroesForSale();
        SetCardsForSale();
    }
#region HeroSale
    public void PopulateHeroesForSale()
    {
        ClearHeroesOnSale();
        for (int i = 0; i < MaxHeroesOnSale; i++)
        {
            
            Hero prefab = GetRandomHeroPrefab();

            if (prefab == null)
            {
                return;
            }
            Hero newHero = Instantiate(prefab, transform);
            heroesOnSale.Add(newHero);
        }
    }
         
    private Hero GetRandomHeroPrefab()
    {
        if (heroOfferPool == null || heroOfferPool.Count == 0)
        {
            Debug.LogWarning("[TrainingCenter][GetRandomHeroPrefab] Hero pool is empty.");
            return null;
        }

        int index = Random.Range(0, heroOfferPool.Count);
        return heroOfferPool[index];
    }
    public void HireHero(Hero hero)
    {
        if (hero == null)
        {
            Debug.LogWarning("[TrainingCenter][HireHero] Hero is null.");
            return;
        }

        if (!heroesOnSale.Contains(hero))
        {
            Debug.LogWarning("[TrainingCenter][HireHero] Hero is not on sale.");
            return;
        }

        if (!PlayerData.Instance.AddHero(hero))
        {
        Debug.LogWarning($"[TrainingCenter][HireHero] Failed to add {hero.basedata.heroName}.");
        return;
        }
        heroesOnSale.Remove(hero);
        Debug.Log($"[TrainingCenter][HireHero] {hero.basedata.heroName} hired.");
    }
#endregion
#region Cardsale
    public void SetCardsForSale()
    {
        ClearCardsOnSale();

        for (int i = 0; i < MaxCardsOnSale; i++)
        {
            Card card = GetRandomCard();

            if (card == null)
            {
                return;
            }

            cardsOnSale.Add(card);
            Debug.Log($"[TrainingCenter][SetCardsForSale] Card {card.name} added to sale.");
        }
    }
    private Card GetRandomCard()
    {
        int totalWeight = 0;

        foreach (CardPoolEntry entry in cardOfferPool)
        {
            if (entry.Card == null) continue;
            if (entry.unlockLevel > trainingCenterLevel) continue;
            if (entry.weight <= 0) continue;

            totalWeight += entry.weight;
        }

        if (totalWeight <= 0)
        {
            Debug.LogWarning("[TrainingCenter][GetRandomCard] No valid cards in pool.");
            return null;
        }

        int roll = Random.Range(0, totalWeight);

        foreach (CardPoolEntry entry in cardOfferPool)
        {
            if (entry.Card == null) continue;
            if (entry.unlockLevel > trainingCenterLevel) continue;
            if (entry.weight <= 0) continue;

            roll -= entry.weight;

            if (roll < 0)
            {
                return entry.Card;
            }
        }

        return null;
    }
    
    public void BuyCard(Card card)
    {
        if (card == null)
        {
            Debug.LogWarning("[TrainingCenter][BuyCard] Card is null.");
            return;
        }

        if (!cardsOnSale.Contains(card))
        {
            Debug.LogWarning("[TrainingCenter][BuyCard] Card is not on sale.");
            return;
        }

        if (!PlayerData.Instance.AddCard(card))
        {
            Debug.LogWarning($"[TrainingCenter][BuyCard] Failed to add {card.name}.");
            return;
        }

        cardsOnSale.Remove(card);

        Debug.Log($"[TrainingCenter][BuyCard] {card.name} bought.");
    }
#endregion
        

#region helper methods
    private void ClearHeroesOnSale()
    {
        foreach (Hero hero in heroesOnSale)
        {
            if (hero != null)
                Destroy(hero.gameObject);
        }

        heroesOnSale.Clear();
    }
    private void ClearCardsOnSale()
    {
        cardsOnSale.Clear();
    }
#endregion
    
#region Debugging
    private void Update()
    {
        if (Keyboard.current == null) return;
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            if (heroesOnSale.Count > 0)
            {
                HireHero(heroesOnSale[0]);
            }
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            PopulateHeroesForSale();
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            SetCardsForSale();
        }
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            if (cardsOnSale.Count > 0)
            {
                BuyCard(cardsOnSale[0]);
            }
        }
    }
    #endregion
   
}
