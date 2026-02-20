using SpaceShooter.Health;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter.GameConrtoller
{
    public class LevelManager : MonoBehaviour
    {
        private const string GAME_SCENE = "SampleScene";
        private const string GAMEOVER_SCENE = "GameOver";
        private const string MAIN_MENU_SCENE = "MainMenu";

        private void OnEnable()
        {
            PlayerDeathHandler.OnDeathAction += LoadGameOver;
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(GAME_SCENE);
        }

        public void LoadGameOver()
        {
            SceneManager.LoadScene(GAMEOVER_SCENE);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE);
        }

        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }

        private void OnDisable()
        {
            PlayerDeathHandler.OnDeathAction += LoadGameOver;
        }
    }
}

