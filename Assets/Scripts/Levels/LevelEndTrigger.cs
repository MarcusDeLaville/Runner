using Cinemachine;
using Doozy.Engine.UI;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _layerPlayer;
    [SerializeField] private ParticleSystem _finishParticleSystem;
    [SerializeField] private CinemachineVirtualCameraBase _playerCamera;
    [SerializeField] private CinemachineVirtualCameraBase _finishCamera;
    [SerializeField] private Transform _character;
    [SerializeField] private UIView _victoryPanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _layerPlayer) != 0)
        {
            _finishParticleSystem.Play(true);
            _playerCamera.enabled = false;
            _finishCamera.enabled = true;
            _character.rotation = Quaternion.Euler(Vector3.zero);
            DelayedCallUtil.DelayedCall(3f, () =>
            {
                _victoryPanel.Show();
            });
        }
    }
}
