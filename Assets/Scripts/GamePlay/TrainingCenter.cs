using UnityEngine;
using Cardho;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class TrainingCenter : MonoBehaviour
{
    [Header("Hero Pool")]
    [SerializeField] private List<Hero> heroOfferPool = new();

    [Header("Current Sale")]
    [SerializeField] private List<Hero> heroesOnSale = new();
    [SerializeField] private int trainingCenterLevel = 1;
    private int MaxHeroesOnSale => trainingCenterLevel + 2;
    public IReadOnlyList<Hero> HeroesOnSale => heroesOnSale;
    

    public void Start()
    {
        // Initialize the training center with some heroes for sale
        PopulateHeroesForSale();
    }
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
        PlayerData.Instance.AddHero(hero);
        Debug.Log($"[TrainingCenter][HireHero] {hero.basedata.heroName} hired.");
    }

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
    #endregion
    
    #region Debugging
    [ContextMenu("Debug Print Heroes On Sale")]
    private void DebugPrintHeroesOnSale()
    {
        Debug.Log($"[TrainingCenter] Heroes on sale: {heroesOnSale.Count}");

        for (int i = 0; i < heroesOnSale.Count; i++)
        {
            Hero hero = heroesOnSale[i];

            if (hero == null)
            {
                Debug.Log($"[TrainingCenter] Slot {i}: NULL");
                continue;
            }

            Debug.Log($"[TrainingCenter] Slot {i}: {hero.basedata.heroName}");
        }
    }

    [ContextMenu("Debug Hire First Hero")]
    private void DebugHireFirstHero()
    {
        if (heroesOnSale.Count == 0)
        {
            Debug.LogWarning("[TrainingCenter] No heroes on sale.");
            return;
        }

        HireHero(heroesOnSale[0]);

        Debug.Log($"[TrainingCenter] Player hero inventory count: {PlayerData.Instance.HeroInventory.Count}");
    }

    private void Update()
    {
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
    }
    #endregion
   
}
