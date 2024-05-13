using System.Collections;
using TankGame.Main;
using TankGame.Tank;
using TankGame.UI;
using UnityEngine;

namespace TankGame.Cameras
{
    public class MoveCamController : MonoBehaviour
    {
        [SerializeField] private Transform finalCamPosition;
        [SerializeField] private float movementTime = 2f;

        private Vector3 currentCamPosition;
        private TankService tankService => GameService.Instance.TankService;
        private UIService uIService => GameService.Instance.UIService;
        #region ------------ Public Methods ------------
        public IEnumerator MoveCamera()
        {
            float time = 0f;
            currentCamPosition = transform.position;
            while (time <= movementTime)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(currentCamPosition, finalCamPosition.position, time);
                yield return null;
            }
            transform.position = finalCamPosition.position;
        }
        public IEnumerator ResetCamera()
        {
            float time = 0f;
            while (time <= movementTime)
            {
                time += Time.deltaTime;
                transform.position = Vector3.Lerp(finalCamPosition.position, currentCamPosition, time);
                yield return null;
            }
            transform.position = currentCamPosition;
        }

        public void ShowMineInfo()
        {
            tankService.SetTankState(TankState.DISABLE);
            StartCoroutine(MoveCamera());
            uIService.SetMineInfo(true);
        }

        public void HideMineInfo()
        {
            StartCoroutine(ResetCamera());
            uIService.SetMineInfo(false);
            tankService.SetTankState(TankState.REST);
        }
        #endregion------------------------
    }
}
