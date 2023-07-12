using System.Collections.Generic;
using System.Collections;
using TankGame.Managers;
using TankGame.Models;
using UnityEngine;

namespace TankGame.Views
{
    public class TankView : MonoBehaviour
    {
        #region ------------ Serialize Variables ------------
        [SerializeField] private float movementDuration = 2f;
        [SerializeField] private GunView gunView;
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

        public IEnumerator MoveTank(Vector3 hitPosition)
        {
            if (GameManager.instance.GetTankState() == TankState.MOVING)
            {
                Vector3 newPosition = new Vector3(hitPosition.x, 0f, hitPosition.z);
                float time = 0;
                while (time < movementDuration)
                {
                    transform.position = Vector3.Lerp(transform.position, newPosition, time / movementDuration);
                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = newPosition;
                gunView.CheckForWall();
                GameManager.instance.SetTankState(TankState.REST);
                yield return null;
            }
        }
        #endregion------------------------

        #region ------------ Private Methods ------------
        #endregion------------------------
    }
}
