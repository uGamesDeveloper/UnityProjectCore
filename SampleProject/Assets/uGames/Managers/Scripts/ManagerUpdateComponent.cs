using System;
using UnityEngine;

namespace uGames.Managers
{
    public class ManagerUpdateComponent : MonoBehaviour
    {
        private ManagerUpdate _managerUpdate;

        public void Setup(ManagerUpdate managerUpdate)
        {
            _managerUpdate = managerUpdate;
        }

        private void Update()
        {
            _managerUpdate.Update();
        }

        private void FixedUpdate()
        {
            _managerUpdate.FixedUpdate();
        }


        private void LateUpdate()
        {
            _managerUpdate.LateUpdate();
        }
        
    }
}
