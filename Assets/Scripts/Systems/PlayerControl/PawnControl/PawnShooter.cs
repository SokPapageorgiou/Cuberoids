using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Systems.PlayerControl.PawnControl
{
    public class PawnShooter : MonoBehaviour, IPawnWatcher
    {
        private IShootable _shootable;
        private bool _isTriggerPulled;

        private void FixedUpdate()
        {
            if(_isTriggerPulled) _shootable?.Fire();
        }

        public void UpdatePawn(Rigidbody2D pawn) 
            => _shootable = pawn.GetComponent(typeof(IShootable)) as IShootable;
        
        private bool InvertTrigger() => _isTriggerPulled = !_isTriggerPulled;
    }
}