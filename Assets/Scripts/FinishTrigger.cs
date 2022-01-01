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
            Invoke(nameof(OpenRestartUI), 2f);
        }

    }

    public void OpenRestartUI() {
        _restartCanvas.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
