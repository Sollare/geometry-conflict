namespace Assets.Scripts.Game.Gem.Controllers
{
    /*
            * Пирамида (тетраэдр)
     
            Передвигается путем перемещения с клетки на клетку (при перемещении парит над
            клетками).
            Боевой арсенал: луч плазмы, выстреливающий из вершины и поражающий фигуру
            противника сверху.
            Зона поражения: 5 клеток вокруг.
            Передвигается в разных направлениях.
            Атакует в разных направлениях.
            3 заряда, 40% урона каждый
    */

    public class TetraGameController : GemController 
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
