using Assets.Scripts.UI;
using System.Collections;
using TankGame.Main;
using TankGame.Tank;
using UnityEngine;

namespace TankGame.Cameras
{
    public class MoveCamController : MonoBehaviour
    {
        [SerializeField] private Transform finalCamPosition;
        [SerializeField] private float movementTime = 2f;

        private Vector3 currentCamPosition;
        private TankService tankService => GameService.Instance.TankService;
        private GameplayUIService gameplayUIService => GameService.Instance.GameplayUIService;
        #region ------------ Public Methods ------------
        private IEnumerator MoveCamera()
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

        private IEnumerator ResetCamera()
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
            gameplayUIService.SetMineInfo(true);
        }

        public void HideMineInfo()
        {
            StartCoroutine(ResetCamera());
            gameplayUIService.SetMineInfo(false);
            tankService.SetTankState(TankState.REST);
        }
        #endregion------------------------
    }
}
