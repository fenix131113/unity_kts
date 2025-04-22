using System;
using System.Threading.Tasks;
//using Firebase;
//using Firebase.Auth;
//using Firebase.Database;
using TMPro;
using UnityEngine;

namespace FireBaseKT
{
    public class FBAuthManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField mailInputField;
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private TMP_InputField ageInputField;

        //private DatabaseReference _dbref;
        //private FirebaseAuth _auth;

        private void Awake()
        {
            InitializeFirebase();
        }

        void InitializeFirebase()
        {
            //_auth = FirebaseAuth.DefaultInstance;
            //_dbref = FirebaseDatabase.DefaultInstance.RootReference;
        }

        public async void RegisterUser()
        {
            /*var email = mailInputField.text;
            var password = passwordInputField.text;
            var nameInput = nameInputField.text;
            var age = ageInputField.text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(nameInput) ||
                string.IsNullOrEmpty(age))
            {
                Debug.Log("Поля пустые");
                return;
            }

            if (!int.TryParse(age, out var ageInt))
            {
                Debug.Log("Неверный возраст");
                return;
            }

            try
            {
                var authResult = await _auth.CreateUserWithEmailAndPasswordAsync(email, password);
                var newUser = authResult.User;
                Debug.Log("Пользователь зарегестрирован: " + newUser.Email);

                if (newUser != null)
                    await SaveUserData(newUser.UserId, nameInput, ageInt);
            }
            catch (FirebaseException e)
            {
                var error = (AuthError)e.ErrorCode;
                var mes = "Ошибка регистрации";

                Debug.Log(mes + " - " + error);
                throw;
            }*/
        }

        private async Task SaveUserData(string userid, string userName, int age)
        {
            try
            {
                var userData = new User(userName, age);

                //await _dbref.Child("users").Child(userid).SetRawJsonValueAsync(JsonUtility.ToJson(userData));
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка сохранения данных");
                throw;
            }
        }
    }

    public class User
    {
        public string name;
        public int age;
        public int damage;
        public int hp;

        public User(string name, int age, int damage = 0, int hp = 0)
        {
            this.name = name;
            this.age = age;
            this.damage = damage;
            this.hp = hp;
        }
    }
}