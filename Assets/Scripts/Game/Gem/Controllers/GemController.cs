using UnityEngine;

namespace Assets.Scripts.Game.Gem.Controllers
{
    /// <summary>
    /// Абстрактный класс для задания логики поведения кристалла
    /// </summary>
    public abstract class GemController : MonoBehaviour
    {
        /// <summary>
        /// Возвращает значение, определяющее может ли ПЕРЕМЕСТИТЬСЯ (не атаковать) на данную клетку данная фигура
        /// </summary>
        /// <param name="instance">Инстанс фигуры</param>
        /// <param name="coords">Координаты клетки для перемещения</param>
        public abstract bool CanMove(GemInstance instance, BoardCoord coords);

        /// <summary>
        /// Возвращает значение, определяющее может ли АТАКОВАТЬ (не переместиться) на данную клетку данная фигура
        /// </summary>
        /// <param name="instance">Инстанс фигуры</param>
        /// <param name="coords">Координаты клетки для перемещения</param>
        public abstract bool CanAttack(GemInstance instance, BoardCoord coords);

        /// <summary>
        /// Совершить перемещение на указанную клетку. 
        /// Реализуется конкретный алгоритм движения, для определенного кристалла
        /// </summary>
        public abstract void PerformMove(GemInstance instance, BoardCoord coords);

        /// <summary>
        /// Совершить атаку на определенную клетку
        /// Реализуется конкретный алгоритм атаки. Одни - выстрелят молнией, другие - заминирует клетку, если она под собой
        /// </summary>
        public abstract void PerformAttack(GemInstance instance, BoardCoord coords);
    }
}
