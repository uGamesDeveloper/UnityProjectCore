using System.Collections.Generic;
using uGames.Interfaces;
using UnityEngine;

namespace uGames.Managers
{
    [CreateAssetMenu(fileName = "ManagerUpdate", menuName = "Managers/ManagerUpdate")]
    public class ManagerUpdate : ManagerBase, IAwake
    {
        [SerializeField]
        private int BUFFER_SIZE = 1000;

        private List<IUpdate> _updates;
        private List<ILateUpdate> _lateUpdates;
        private List<IFixedUpdate> _fixedUpdates;
        
        public void OnAwake()
        {
            _updates = new List<IUpdate>(BUFFER_SIZE);
            _lateUpdates = new List<ILateUpdate>(BUFFER_SIZE);
            _fixedUpdates = new List<IFixedUpdate>(BUFFER_SIZE);
            
            GameObject.Find("[SETUP]").AddComponent<ManagerUpdateComponent>().Setup(this);
        }
        
        public static void AddTo(object updateble)
        {
            ManagerUpdate managerUpdate = ManagerBox.TryGetManager<ManagerUpdate>();
            
            if(!managerUpdate)
                return;
            
            if(updateble is IUpdate)
                managerUpdate._updates.Add(updateble as IUpdate);
            
            if(updateble is IFixedUpdate)
                managerUpdate._fixedUpdates.Add(updateble as IFixedUpdate);
            
            if(updateble is ILateUpdate)
                managerUpdate._lateUpdates.Add(updateble as ILateUpdate);
        }
        
        public static void Remove(object updateble)
        {
            ManagerUpdate managerUpdate = ManagerBox.TryGetManager<ManagerUpdate>();
            
            if(!managerUpdate)
                return;
            
            if(updateble is IUpdate)
                managerUpdate._updates.Remove(updateble as IUpdate);
            
            if(updateble is IFixedUpdate)
                managerUpdate._fixedUpdates.Remove(updateble as IFixedUpdate);
            
            if(updateble is ILateUpdate)
                managerUpdate._lateUpdates.Remove(updateble as ILateUpdate);
        }
        

        public void Update()
        {
            for (int i = 0; i < _updates.Count; i++)
            {
                _updates[i].OnUpdate();
            }
        }
        public void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdates.Count; i++)
            {
                _fixedUpdates[i].OnFixedUpdate();
            }
        }
        public void LateUpdate()
        {
            for (int i = 0; i < _lateUpdates.Count; i++)
            {
                _lateUpdates[i].OnLateUpdate();
            }
        }
    }
}
