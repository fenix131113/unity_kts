using System;
using UnityEngine;
using Zenject;

namespace ZenjectKT.Player
{
    public class PlayerInput : ITickable
    {
        public event Action OnShoot; 
        public event Action<Vector2> OnMouseMove; 
        
        public void Tick()
        {
            ReadShootInput();
            ReadMouseInput();
        }

        private void ReadShootInput()
        {
            if(Input.GetMouseButtonDown(0))
                OnShoot?.Invoke();
        }
        
        private void ReadMouseInput() => OnMouseMove?.Invoke(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
    }
}