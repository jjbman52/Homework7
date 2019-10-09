using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Android.Bluetooth;
using Xamarin.Forms;

namespace Homework7
{
    public class PersonalityViewModel : INotifyPropertyChanged
    {
        public string name;
        public int age;

        public string text = "";
        public bool firstVisible = true;
        public bool secondVisible = false;
        public bool thirdVisible = false;
        public bool fourthVisible = false;
        public bool fifthVisible = false;
        public bool sixthVisible = false;

        public string[] character = { "Kylo", "Luke", "Han", "Vadar", "Yoda" };

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PersonalityViewModel()
        {
            FirstBtnCommand = new Command(() =>
            {
                firstVisible = false;
                secondVisible = true;
                OnPropertyChanged("FirstVisible");
                OnPropertyChanged("SecondVisible");
            });
            SecondBtnCommand = new Command(() =>
            {
                secondVisible = false;
                thirdVisible = true;
                OnPropertyChanged("SecondVisible");
                OnPropertyChanged("ThirdVisible");
            });
            ThirdBtnCommand = new Command(() =>
            {
                thirdVisible = false;
                fourthVisible = true;
                OnPropertyChanged("ThirdVisible");
                OnPropertyChanged("FourthVisible");
            });
            FourthBtnCommand = new Command(() =>
            {
                fourthVisible = false;
                fifthVisible = true;
                OnPropertyChanged("FourthVisible");
                OnPropertyChanged("FifthVisible");
            });
            FifthBtnCommand = new Command(() =>
            {
                fifthVisible = false;
                sixthVisible = true;
                OnPropertyChanged("FifthVisible");
                OnPropertyChanged("SixthVisible");
            });
            SixthBtnCommand = new Command(() =>
            {
                sixthVisible = false;
                firstVisible = true;
                OnPropertyChanged("SixthVisible");
                OnPropertyChanged("FirstVisible");
            });
        }

        public string Name
        {
            set
            {
                if (name != value)
                {
                    name = value;

                    OnPropertyChanged("Name");
                }
            }
            get
            {
                return name;
            }
        }

        public int Age
        {
            set
            {
                if (age != value)
                {
                    age = value;

                    OnPropertyChanged("Age");
                }
            }
            get
            {
                return age;
            }
        }

        public bool FirstVisible { get { return firstVisible; } }
        public bool SecondVisible { get { return secondVisible; } }
        public bool ThirdVisible { get { return thirdVisible; } }
        public bool FourthVisible { get { return fourthVisible; } }
        public bool FifthVisible { get { return fifthVisible; } }
        public bool SixthVisible { get { return sixthVisible; } }


        public ICommand FirstBtnCommand { get; private set; }
        public ICommand SecondBtnCommand { get; private set; }
        public ICommand ThirdBtnCommand { get; private set; }
        public ICommand FourthBtnCommand { get; private set; }
        public ICommand FifthBtnCommand { get; private set; }
        public ICommand SixthBtnCommand { get; private set; }
    }
}