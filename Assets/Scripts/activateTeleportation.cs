using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class activateTeleportation : MonoBehaviour
{
    public GameObject teleporter;
    public InputActionProperty activate;
    public InputActionProperty teleportToBall;
    public InputActionProperty openMenu;
    public InputActionProperty resetButton;
    public InputActionProperty changeClubButton;
    public Transform TeleportBall;
    public GameObject OpenMenu;
    public XRRayInteractor ray;
    public int activeClub = 0;
    public ActiveClub club;
    bool clicked = false;
    // Update is called once per frame
    void Update()
    {
        bool menuHover = ray.TryGetHitInfo(out Vector3 pos, out Vector3 norm, out int num, out bool overMenu);
        if(activate.action.ReadValue<float>() > 0.1f && !overMenu)
            teleporter.SetActive(true);
        else teleporter.SetActive(false);
        if(teleportToBall.action.ReadValue<float>() >= .7f)
        {
            transform.position = TeleportBall.position;
        }
        if (openMenu.action.ReadValue<float>() >= .7f)
        {
            OpenMenu.SetActive(true);
        }
        else
        {
            OpenMenu.SetActive(false);
        }
        if (changeClubButton.action.ReadValue<float>() >= .7f && clicked == false)
        {
            clicked = true;
            activeClub = (activeClub + 1) % 3;
        }
        else if(changeClubButton.action.ReadValue<float>() < .7f)
        {
            clicked = false;
        }
        if (resetButton.action.ReadValue<float>() >= .7f)
        {
            BallInHole.ResetGame();
        }
        club.setClub(activeClub);
    }
}
