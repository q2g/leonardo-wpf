using leonardo.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<object> TextList { get; set;}
        public ObservableCollection<LuiAccordionItem> ItemList { get; set; }
        public ICommand TestCommand { get; set; } = new RelayCommand((s) => true, (o) =>
             {
                 object tt = o;
             });


        public MainWindow()
        {
            TextList = new ObservableCollection<object>
            {
                new testclass(){HeaderText="Item1" },
                new testclass(){HeaderText="Item2" },
                new TestControl(){ LabelText="Item3"},
                new testclass(){HeaderText="Item4" }
            };

            ItemList = new ObservableCollection<LuiAccordionItem>()
            {
                new LuiAccordionItem(){ Header="Item1", Content=new TestControl(){LabelText="Item1" } },
                new LuiAccordionItem(){ Header="Item2", Content=new testclass(){HeaderText="Item2" } }
            };

           
           
            InitializeComponent();

            DataContext = this;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SingleText.Text = DateTime.Now.ToLongTimeString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextList.Add(new testclass() { HeaderText = "Item neu" });
            
            

        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {

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

        public string HeaderText { get; set; }
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
