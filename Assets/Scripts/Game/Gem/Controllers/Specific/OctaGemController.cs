
namespace Assets.Scripts.Game.Gem.Controllers.Specific
{
    /*
        * Октаэдр (кристалл)
     
        Передвигается путем перемещения с клетки на клетку (при этом как-бы парит над
        игровым полем)
        Боевой арсенал: "минирует" клетку под собой, при попадании на которую фигура противника
        получает урон.
        Зона поражения: 1 клетка.
        Передвигается в разных направлениях.
        3 заряда, 60% урона каждый
     */

    public class OctaGemController : GemController 
    {
        public override bool CanMove(GemInstance instance, BoardCoord coords)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanAttack(GemInstance instance, BoardCoord coords)
        {
            throw new System.NotImplementedException();
        }

        public override void PerformMove(GemInstance instance, BoardCoord coords)
        {
            throw new System.NotImplementedException();
        }

        public override void PerformAttack(GemInstance instance, BoardCoord coords)
        {
            throw new System.NotImplementedException();
        }
    }
}
