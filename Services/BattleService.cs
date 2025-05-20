using StrategyGame.Models;

namespace StrategyGame.Services
{
    public class BattleService : IBattleService
    {
        public UpdatedHealthAfterBatleDto Battle(Hero hero, Monster monster)
        {
            while (hero.Health > 0 && monster.Health > 0)
            {
                
                hero.Health -= MonsterAttacksHero(hero, monster);
                hero.Health = Math.Clamp(hero.Health, 0, 100);
                monster.Health-= HeroAttacksMonster(hero, monster);
                monster.Health = Math.Clamp(monster.Health, 0, 100);

            }

            return new UpdatedHealthAfterBatleDto
            {
                HeroHealth = hero.Health,
                MonsterHealth = monster.Health
            };
        }

        private decimal MonsterAttacksHero(Hero hero,Monster monster)
        {
            var armorDefensePercentage = hero.EquippedArmorNavigation?.DefensePercentage.Value ?? 0;
            var mitigatedMonsterDamage = monster.Damage - (monster.Damage / 100 * armorDefensePercentage);

            return  mitigatedMonsterDamage;
        }

        private decimal HeroAttacksMonster (Hero hero,Monster monster)
        {
            var mitigatedHeroDamage = hero.EquippedWeaponNavigation.Damage - (hero.EquippedWeaponNavigation.Damage / 100 * monster.Defense);
            return  mitigatedHeroDamage;
        }

        
    }
}
