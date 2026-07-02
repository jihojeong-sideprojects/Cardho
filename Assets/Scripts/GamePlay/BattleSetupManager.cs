using UnityEngine;
using Cardho;
using System.Collections.Generic;
using System.Linq;

public class BattleSetupManager : MonoBehaviour
{
    [SerializeField] private List<Hero> selectedHeroes = new();
    public IReadOnlyList<Hero> SelectedHeroes => selectedHeroes;
    [SerializeField] private int maxSelectedHeroes = 3;

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

        if (selectedHeroes.Count >= maxSelectedHeroes)
        {
            Debug.LogWarning("[BattleSetupManager][SelectHero] Selected hero limit reached");
            return;
        }

        selectedHeroes.Add(hero);

        Debug.Log($"[BattleSetupManager][SelectHero] {hero.basedata.heroName} selected");
    }
    public void DeselectHero(Hero hero)
    {
        if (hero == null)
        {
            Debug.LogWarning("[BattleSetupManager][DeselectHero] Hero is null");
            return;
        }

        if (!selectedHeroes.Contains(hero))
        {
            Debug.LogWarning("[BattleSetupManager][DeselectHero] Hero is not selected");
            return;
        }

        selectedHeroes.Remove(hero);

        Debug.Log($"[BattleSetupManager][DeselectHero] {hero.basedata.heroName} deselected");
    }
    [ContextMenu("Debug Select First Hero")]
    private void DebugSelectFirstHero()
    {
        if (PlayerData.Instance.HeroInventory.Count == 0)
        {
            Debug.LogWarning("[BattleSetupManager] No heroes in inventory");
            return;
        }

        SelectHero(PlayerData.Instance.HeroInventory[0]);
    }
        
}
