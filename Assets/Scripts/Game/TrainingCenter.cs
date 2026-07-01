using UnityEngine;
using Cardho;
using System.Collections.Generic;

public class TrainingCenter : MonoBehaviour
{
    public List<Hero> HeroesOnsale = new List<Hero>();
    public int maxHeroesOnSale = 3;
    public int trainingCenterLevel = 1;

    public void Start()
    {
        // Initialize the training center with some heroes for sale
        PopulateHeroesForSale();
    }
    public void PopulateHeroesForSale()
    {
        int currentlevel = trainingCenterLevel;

        HeroesOnsale.Clear();
        if (trainingCenterLevel == 1)
        {
            maxHeroesOnSale = 3;
        }
        else if (trainingCenterLevel == 2)
        {
            maxHeroesOnSale = 4;
        }
        else if (trainingCenterLevel >= 3)
        {
            maxHeroesOnSale = 5;
        }
        for (int i = 0; i < maxHeroesOnSale; i++)
        {
            // Create a new hero instance (you can customize this as needed)
            Hero newHero = Instantiate(Resources.Load<Hero>("Prefabs/Hero")); // Assuming you have a Hero prefab in Resources/Prefabs
            HeroesOnsale.Add(newHero);
        }
    }
    public void hireHero(Hero hero)
    {
        if (hero == null)
        {
            Debug.LogWarning("[TrainingCenter][hireHero] Hero is null");
            return;
        }

        // Add the hero to the player's inventory
        PlayerData.Instance.AcquireHero(hero);

        // Remove the hero from the training center's list
        HeroesOnsale.Remove(hero);

        Debug.Log($"[TrainingCenter][hireHero] {hero.basedata.heroName} hired and added to inventory");
    }

   
}
