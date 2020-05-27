using System.Collections.Generic;
using uGames.Managers;
using UnityEngine;

namespace uGames
{
    /// <summary>
    /// Класс является стартером - передает список менеджеров в ManagerBox
    /// </summary>
    public class Starter : MonoBehaviour
    {
        public List<ManagerBase> managers = new List<ManagerBase>();

        private void Awake()
        {
            foreach (var managerBase in managers)
            {
                ManagerBox.Add(managerBase);
            }
        }
    }
}
