using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Systems.PlayerControl.PawnControl
{
    public class PawnShooter : MonoBehaviour, IPawnWatcher
    {
        private IShootable _shootable;
        private bool _isTriggerPulled;

        private Rigidbody2D _pawn;

        private void FixedUpdate()
        {
            if(_pawn.gameObject.activeInHierarchy)
                _shootable?.Fire(_isTriggerPulled); 
        } 

        public void UpdatePawn(Rigidbody2D pawn)
        {
            _pawn = pawn;
            _shootable = pawn.GetComponent(typeof(IShootable)) as IShootable;
        }
             
        
        public void UpdateTrigger(bool isTriggerPulled) => _isTriggerPulled = isTriggerPulled;
    }
}