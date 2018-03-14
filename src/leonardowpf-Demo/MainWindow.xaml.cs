using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace leonardowpf_Demo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public testclass SingleText { get; set; } = new testclass();
        public List<testclass> TextList { get; set;}
        public ICommand TestCommand { get; set; } = new RelayCommand((s) => true, (o) =>
             {
                 object tt = o;
             });


        public MainWindow()
        {
            TextList = new List<testclass>
            {
                new testclass(),
                new testclass(),
                new testclass()
            };

            InitializeComponent();

            DataContext = this;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingleText.Text = DateTime.Now.ToLongTimeString();
        }
    }




    public class testclass:INotifyPropertyChanged
    {
        private string text;
        private Timer timer;
        public testclass()
        {
            timer = new Timer(new TimerCallback(HandleTimer), null,0, 1000);
        }
        private  void HandleTimer(object o)
        {
            //Application.Current.Dispatcher.Invoke(new Action(() => { Text = DateTime.Now.ToLongTimeString(); }));
            Text = DateTime.Now.ToLongTimeString();
            // timer.Change(1000, Timeout.Infinite);
        }

        public string Text
        {
            get { return text; }            
            set
            {               
                text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
