namespace Assets.Scripts.Game.Gem.Controllers
{
    /*
        * Куб (гексаэдр)
     
        Передвигается путем перемещения с клетки на клетку.
        Боевой арсенал: выстрел лазерным лучом или лучом плазмы.
        Зона поражения: 4 клетки впереди
        Передвигается в разных направлениях.
        Атакует только вперед.
        3 заряда, 20% урона каждый
     */

    public class HexaGemController : GemController 
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
