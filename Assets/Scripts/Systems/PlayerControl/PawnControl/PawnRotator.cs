using System;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Systems.PlayerControl.PawnControl
{
    public class PawnRotator : MonoBehaviour, IPawnWatcher
    {
        private IRotetable _rotetable;
        private float _direction;

        private Rigidbody2D _pawn;

        private void FixedUpdate()
        {
            if(_pawn.gameObject.activeInHierarchy)
                _rotetable?.Rotate(_direction);
        } 

        public void UpdatePawn(Rigidbody2D pawn)
        {
            _pawn = pawn;
            _rotetable = pawn.GetComponent(typeof(IRotetable)) as IRotetable;
        } 
         
        public void UpdateDirection(float newDirection) => _direction = newDirection;
    }
}
