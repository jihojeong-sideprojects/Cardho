using UnityEngine;
using Cardho;
using System.Collections.Generic;

public class BattleSetupManager : MonoBehaviour
{
    private List<Hero> selectedHeroes = new();

    public void Start()
    {
        foreach (Hero h in PlayerData.Instance.HeroInventory)
        {
            Debug.Log($"[BattleSetupManager][Start] {h.basedata.heroName} loaded)");
        }
    }
    public void SelectHero(Hero hero)
    {
        if (hero == null)
        {
            Debug.LogWarning("[BattleSetupManager][SelectHero] Hero is null");
            return;
        }
        if (selectedHeroes.Contains(hero))
        { 
            Debug.LogWarning("[BattleSetupManager][SelectHero] Hero already selected");
            return;
        }
        selectedHeroes.Add(hero);
    }
    
}
