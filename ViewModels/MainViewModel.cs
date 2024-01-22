using DashBoard_WPF.Models;
using DashBoard_WPF.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DashBoard_WPF.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        // Fields
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount 
        { 
            get => _currentUserAccount; 
            set
            { 
                _currentUserAccount = value; 
                OnPropertyChanged(nameof(CurrentUserAccount));
            } 
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

            if (user != null) {
                CurrentUserAccount.UserName = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not Logged in";
                // Hide chid views
                //Application.Current.Shutdown();
            }
        }
    }
}
