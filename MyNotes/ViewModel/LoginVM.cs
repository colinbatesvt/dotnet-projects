using MyNotes.Model;
using MyNotes.ViewModel.Commands;
using MyNotes.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace MyNotes.ViewModel
{
    public class LoginVM : INotifyPropertyChanged
    {
        private bool isShowingRegister = false;

        private User user;

        public User User
        {
            get { return user; }
            set 
            { 
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.LastName,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.LastName,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("Password");
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.LastName,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("Name");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.LastName,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("LastName");
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                User = new User
                {
                    Username = this.Username,
                    Password = this.Password,
                    Name = this.Name,
                    Lastname = this.LastName,
                    ConfirmPassword = this.confirmPassword
                };
                OnPropertyChanged("ConfirmPassword");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler Authenticated;
        
        private Visibility loginVis;
        public Visibility LoginVis
        {
            get { return loginVis; }
            set 
            { 
                loginVis = value;
                OnPropertyChanged("LoginVis");
            }
        }

        private Visibility registerVis;
        public Visibility RegisterVis
        {
            get { return registerVis; }
            set
            {
                registerVis = value;
                OnPropertyChanged("RegisterVis");
            }
        }

        public RegisterCommand RegisterCommand { get; set; }
        public LoginCommand LoginCommand { get; set; }
        public ShowRegisterCommand ShowRegisterCommand { get; set; }

        public LoginVM()
        {
            LoginVis = Visibility.Visible;
            RegisterVis = Visibility.Collapsed;
            RegisterCommand = new RegisterCommand(this);
            ShowRegisterCommand = new ShowRegisterCommand(this);
            LoginCommand = new LoginCommand(this);

            User = new User();
        }

        public void SwitchViews()
        {
            isShowingRegister = !isShowingRegister;

            if(isShowingRegister)
            {
                RegisterVis = Visibility.Visible;
                LoginVis = Visibility.Collapsed;
            }
            else
            {
                RegisterVis = Visibility.Collapsed;
                LoginVis = Visibility.Visible;
            }
        }

        public async void Login()
        {
            bool result =  await FirebaseAuthHelper.Login(User);

            if(result)
            {
                Authenticated?.Invoke(this, new EventArgs());
            }
        }

        public async void Register()
        {
            bool result = await FirebaseAuthHelper.Register(User);

            if (result)
            {
                Authenticated?.Invoke(this, new EventArgs());
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
