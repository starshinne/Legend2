using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   public PlayerInputControll inputControll;
   public Vector2 inputDirection;

   private void Awake() {
    inputControll = new PlayerInputControll();
   }

   private void OnEnable() {
    inputControll.Enable();
   }

   private void OnDisable() {
    inputControll.Disable();
   }

   private void Update() {
    inputDirection = inputControll.Gameplay.Move.ReadValue<Vector2>();
   }
}
