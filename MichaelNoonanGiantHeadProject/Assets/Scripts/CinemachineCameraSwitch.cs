using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineCameraSwitch : MonoBehaviour
{
    [SerializeField] private InputAction input;

    [SerializeField] private CinemachineVirtualCamera virtualCamera1;
    [SerializeField] private CinemachineVirtualCamera virtualCamera2;
    [SerializeField] private CinemachineVirtualCamera virtualCamera3;

    private bool defaultCamera = true;
    private bool head1Camera = false;
    private bool head2Camera = false;

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        input.performed += _ => SwitchPriority();
    }

    private void SwitchPriority()
    {
        if (defaultCamera && !head1Camera)
        {
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 1;
            virtualCamera3.Priority = 0;
        }
        else
        {
            virtualCamera1.Priority = 1;
            virtualCamera2.Priority = 0;
            virtualCamera3.Priority = 0;
        }

        if(head1Camera && !head2Camera)
        {
            virtualCamera1.Priority = 0;
            virtualCamera2.Priority = 0;
            virtualCamera3.Priority = 1;
        }
        defaultCamera = !defaultCamera;
        head1Camera = !head1Camera;
        head2Camera = !head2Camera;
    }

    void Update()
    {
        
    }
}
