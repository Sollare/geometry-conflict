namespace Assets.Scripts.Game.Gem.Controllers
{
    /*
        * Додекаэдр
        Передвигается путем перекатывания через свои грани ("как шар")
        Боевой арсенал: накатывается на противника, как шар в боулинге. Эффект такой же:
        наносит урон фигуре противника и разбрасывает фигуры противника.
        Зона поражения: 4 клетки впереди.
        Передвигается в разных направлениях.
        Атакует только вперед.
        3 броска, 60% урона каждый
     */

    public class DodecaGemController : GemController 
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
