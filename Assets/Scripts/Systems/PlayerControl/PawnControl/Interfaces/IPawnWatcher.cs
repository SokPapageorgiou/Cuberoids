using UnityEngine;

namespace Systems.PlayerControl.PawnControl.Interfaces
{
    public interface IPawnWatcher
    {
        public void UpdatePawn(Rigidbody2D pawn);
    }
}