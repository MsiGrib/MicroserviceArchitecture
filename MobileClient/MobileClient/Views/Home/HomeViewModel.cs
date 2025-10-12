using ReactiveUI;
using System.Reactive;
using System;

namespace MobileClient.Views.Home
{
    public class HomeViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        public HomeViewModel()
        {
            RegisterCommand = ReactiveCommand.Create(OnRegister);
            LoginCommand = ReactiveCommand.Create(OnLogin);
        }

        private void OnRegister()
        {
            Console.WriteLine("Нажата кнопка Регистрация");
        }

        private void OnLogin()
        {
            Console.WriteLine("Нажата кнопка Авторизация");
        }
    }
}