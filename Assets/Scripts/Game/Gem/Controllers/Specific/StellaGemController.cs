namespace Assets.Scripts.Game.Gem.Controllers
{
    /*
        * Звездчатый октаэдр (stella octangula)
     
        Передвигается путем перекатывания через вершины.
        Боевой арсенал: ставит "заграждение", клонируя себя по одной клетки справа и
        слева. Через которую не могут пройти фигуры противника и поражать противника нанося
        урон. Могут стрелять в нее, но только при попадании в центральную фигуру будет наносится
        урон фигуре. Пирамида может "переплюнуть" выстрелом. Подрывается на мине, тогда
        заграждение "не срабатывает" т.к. фигура получила урон.
        Передвигается в разных направлениях.
        Заграждение можно поставить 3 раза, по 10% урона
     */

    public class StellaGemController : GemController 
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
