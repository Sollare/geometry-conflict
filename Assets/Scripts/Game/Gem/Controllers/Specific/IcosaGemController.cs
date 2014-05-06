namespace Assets.Scripts.Game.Gem.Controllers
{
    /*
        * Икосаэдр
     
        Передвигается с клетки на клетку путем перекатывания через грани ("как шар")
        Боевой арсенал: путем отскока от игрового поля наскакивает на противника, нанося
        противнику урон, затем отскакивает.
        Зона поражения: 5 клеток впереди.
        Передвигается в разных направлениях.
        Атакует только вперед.
        3 броска, 20% урона каждый
    */

    public class IcosaGemController : GemController 
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
