using StrategyGame.Models;

namespace StrategyGame.Services
{
    public interface IBattleService
    {
        UpdatedHealthAfterBatleDto Battle(Hero hero, Monster monster);
    }
}
