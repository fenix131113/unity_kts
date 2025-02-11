using TMPro;
using UnityEngine;

namespace FireBaseKT
{
    public class LoginView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField emailInput;
        [SerializeField] private TMP_InputField passwordInput;
        [SerializeField] private FirebaseLogin loginManager;

        public void OnLoginClicked() => loginManager.Login(emailInput.text, passwordInput.text);
    }
}