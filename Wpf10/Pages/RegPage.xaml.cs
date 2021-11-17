using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Wpf10.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            CbGenderReg.ItemsSource = BaseClass.Base.Gender.ToList();
            CbGenderReg.SelectedValuePath = "idGender";
            CbGenderReg.DisplayMemberPath = "Gender1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            Regex r = new Regex("^.*(?=.*[0-9]{2}).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("В пароле менее 2 чисел.", "Регистрация");
            }
            else { x += 1; }
            r = new Regex("^.*(?=.*[A-Z]).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("В пароле менее 1 заглавного символа латинского алфавита.", "Регистрация");
            }
            else { x += 1; }
            r = new Regex("^.*(?=.*[a-z]{3}).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("В пароле менее 3 символов латинского алфавита", "Регистрация");
            }
            else { x += 1; }
            r = new Regex("^.*(?=.*[!@№#$%^&*()?+=]).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("В пароле менее 1 специального символа.", "Регистрация");
            }
            else { x += 1; }
            r = new Regex("^.*(?=.{8,}).*$");
            if (r.IsMatch(TbPasReg.Password.ToString()) == false)
            {
                MessageBox.Show("В пароле менее 8-ми символов.", "Регистрация");
            }
            else { x += 1; }
            if (x == 5)
            {
                int passC = TbPasReg.Password.GetHashCode();
                User UserR = new User()
                {
                    Name = TbNameReg.Text,
                    Lastname = TbSurnameReg.Text,
                    Login = TbLoginReg.Text,
                    Password = passC,
                    idGender = CbGenderReg.SelectedIndex + 1,
                    idRole = 2
                };
                BaseClass.Base.User.Add(UserR);
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Вы зарегистрированы");
                FrameClass.FrameMain.Navigate(new NullPage());
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new NullPage());
        }
    }
}
