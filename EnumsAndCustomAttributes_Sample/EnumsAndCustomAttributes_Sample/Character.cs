using System;
using System.Collections.Generic;

namespace EnumsAndCustomAttributes_Sample
{
    public class Character
    {
        /// <summary>
        /// All the directions that are possible, no
        /// you can't move diagnoly, why would you
        /// want to?
        /// </summary>
        public enum DIRECTION
        {
            [AlternateValue("North")]
            North,
            [AlternateValue("North West")]
            NorthWest,
            [AlternateValue("West")]
            West,
            [AlternateValue("South West")]
            SouthWest,
            [AlternateValue("South")]
            South,
            [AlternateValue("South East")]
            SouthEast,
            [AlternateValue("East")]
            East,
            [AlternateValue("North East")]
            NorthEast
        }

        /// <summary>
        /// Contains all of the moves
        /// </summary>
        public List<DIRECTION> Moves { get; private set; } = new List<DIRECTION>();

        /// <summary>
        /// Add a move to the Moves list
        /// </summary>
        public void AddMove(DIRECTION Direction)
        {
            this.Moves.Add(Direction);
        }

        /// <summary>
        /// Loop through the moves and
        /// do something
        /// </summary>
        public void DoMove()
        {
            foreach (DIRECTION Direction in Moves)
                Console.WriteLine(Direction.GetAlternateValue());
        }
    }
}
