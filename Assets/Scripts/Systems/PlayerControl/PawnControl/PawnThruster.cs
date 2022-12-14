using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Systems.PlayerControl.PawnControl
{
    public class PawnThruster : MonoBehaviour , IPawnWatcher
    {
        private IThrustable _thrustable;
        private float _throttle;

        private Rigidbody2D _pawn;

        private void FixedUpdate()
        {
            if (_pawn.gameObject.activeInHierarchy && _throttle > 0)
                _thrustable?.Accelerate(_throttle);
        }

        public void UpdatePawn(Rigidbody2D pawn)
        {
            _pawn = pawn;
            _thrustable = pawn.GetComponent(typeof(IThrustable)) as IThrustable;
        } 
        
        public void UpdateThrottle(float newThrottle) => _throttle = newThrottle;
    }
}
