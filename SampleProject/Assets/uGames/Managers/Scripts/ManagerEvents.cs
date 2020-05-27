using UnityEngine;

namespace uGames.Managers
{
    [CreateAssetMenu(fileName = "ManagerEvents",menuName = "Managers/ManagerEvents", order = 51)]
    public class ManagerEvents : ManagerBase
    {
        public GameObject gm;
        public void DoingSomething()
        {
            Debug.Log("Doing Something");
        }
    }
}
