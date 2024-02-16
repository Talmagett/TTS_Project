using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HorrorGameRule : MonoBehaviour
{
        [SerializeField] private StarterAssetsInputs input;
        private bool _canMove=true;
 
        public void SetCanMove(bool value)
        {
                _canMove = value;
        }

        private void Update()
        {
                if (input.move != Vector2.zero && !_canMove)
                {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
        }
}