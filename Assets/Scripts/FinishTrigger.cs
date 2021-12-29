using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _restartCanvas;


    private void OnTriggerEnter(Collider collider) {
        MoveTrain moveTrain = collider.attachedRigidbody?.GetComponent<MoveTrain>();

        if (moveTrain) {
            moveTrain.Speed = 0f;
            Debug.Log("TrainStopped");
            _restartCanvas.SetActive(true);
            //Invoke(nameof(RestartScene), 8f);
        }

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
