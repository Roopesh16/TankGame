using UnityEngine;
using TankGame.Views;
using TankGame.Models;
using TankGame.Managers;
using System.Collections;

namespace TankGame.Controllers
{
    public class MoveCamController : MonoBehaviour
    {
        [SerializeField] private Transform finalCamPosition;
        [SerializeField] private float movementTime = 2f;
        [SerializeField] private GameView gameView;

        private Vector3 currentCamPosition;
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
            GameManager.instance.SetTankState(TankState.DISABLE);
            StartCoroutine(MoveCamera());
            gameView.DisplayMineInfo();
        }

        public void HideMineInfo()
        {
            StartCoroutine(ResetCamera());
            gameView.HideMineInfo();
            GameManager.instance.SetTankState(TankState.REST);
        }
        #endregion------------------------
    }
}
