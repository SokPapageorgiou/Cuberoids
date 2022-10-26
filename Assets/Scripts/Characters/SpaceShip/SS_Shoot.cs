using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Characters.SpaceShip
{
    public class SS_Shoot : MonoBehaviour , IShootable
    {
        public void Fire()
        {
            Debug.Log("Spaceship is shooting!");
        }
    }
}
