using System;
using System.Collections.Generic;
using uGames.Interfaces;
using UnityEngine;

namespace uGames.Processors
{
    /// <summary>
    /// Класс предоставляет возможность Update, FixedUpdate, LateUpdate
    /// </summary>
    public class ProcessorUpdate : MonoBehaviour
    {
        //TODO: Доделать добавление удаления для Fixed и Late Update
        
        [SerializeField] private int countUpdate;
        [SerializeField] private int countFixedUpdate;
        [SerializeField] private int countLateUpdate;

        private void Update()
        {
            countUpdate = MonoCached.updates.Count;
            for (int i = 0; i < MonoCached.updates.Count; i++)
            {
                MonoCached.updates[i].Tick();
            }
        }

        private void FixedUpdate()
        {
            countFixedUpdate = MonoCached.updatesFixed.Count;
            for (int i = 0; i < MonoCached.updates.Count; i++)
            {
                MonoCached.updates[i].FixedTick();
            }
        }

        private void LateUpdate()
        {
            countLateUpdate = MonoCached.updatesLate.Count;
            for (int i = 0; i < MonoCached.updates.Count; i++)
            {
                MonoCached.updates[i].LateTick();
            }
        }
    }
}
