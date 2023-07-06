using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Views
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        #endregion------------------------

        #region ------------ Private Variables ------------
        #endregion------------------------

        #region ------------ Public Variables ------------
        #endregion------------------------

        #region ------------ Monobehavior Methods ------------
        void Start()
        {
        }

        void Update()
        {

        }
        #endregion------------------------

        #region ------------ Public Methods ------------
        public void OnGameStart()
        {

        }

        public IEnumerator MoveTank()
        {
            print("Move Tank");
            yield break;
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
