using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;

namespace FireBaseKT
{
    public class FirebaseLogin : MonoBehaviour
    {
        [SerializeField] private TMP_Text damageLabel;
        [SerializeField] private TMP_Text hpLabel;

        private FirebaseAuth _auth;
        private DatabaseReference _dbref;

        private void Awake()
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                if (task.Result == DependencyStatus.Available)
                {
                    _auth = FirebaseAuth.DefaultInstance;
                    _dbref = FirebaseDatabase.DefaultInstance.RootReference;
                }
                else
                {
                    Debug.Log("Dependency Error");
                }
            });
        }

        public void Login(string email, string password)
        {
            _auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
            {
                if (!task.IsCanceled && !task.IsFaulted)
                    if (task.Exception != null)
                    {
                        Debug.Log(task.Exception.ToString());
                        return;
                    }


                var result = task.Result;
                var user = result.User;
                Debug.Log("Пользователь успешно залогинился!");
                GetUserData(user.UserId);
            });
        }

        private void GetUserData(string userId)
        {
            _dbref.Child("users").Child(userId).GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.Log("DB Error");
                    return;
                }

                var snapshot = task.Result;

                if (snapshot.Exists)
                {
                    var userName = snapshot.Child("name")?.Value?.ToString() ?? "N/A";
                    var age = snapshot.Child("age")?.Value?.ToString() ?? "N/A";

                    damageLabel.text = "Damage: " + snapshot.Child("damage")?.Value;
                    hpLabel.text = "Hp: " + snapshot.Child("hp")?.Value;
                    Debug.Log($"User Data: {userName} {age}");
                }
                else
                {
                    Debug.Log("No user data");
                }
            });
        }
    }
}