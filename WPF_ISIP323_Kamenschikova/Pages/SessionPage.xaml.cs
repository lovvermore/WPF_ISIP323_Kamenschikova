using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ISIP323_Kamenschikova.Pages
{
    /// <summary>
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        public Film SessionShow { get; set; }


        public SessionPage(Session session)
        {
            InitializeComponent();
            SessionShow = session;
            List<Session> sessions = new List<Session>();
            sessions.Add(session);
            SeatChoose.ItemsSource = sessions;
        }

    }
}
