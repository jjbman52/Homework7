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

        public bool questionVisible = true;
        public bool resultsVisible = false;

        public string characterName = "Error";

        public int count = 0;
        public int question = 0;

        public string[] character = { "Kylo", "Luke", "Han", "Vadar", "Yoda"};
        public string[] questions = { "Do you like to party?", "Would you rather stay home?", "Is your idea the best?", "Do you like to be the Leader?", "Would you rather blend into the crowd?" };

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public PersonalityViewModel()
        {
            YesBtnCommand = new Command(() =>
            {
                if (question < 4)
                {
                    count++;
                    
                    OnPropertyChanged("LabelText");
                    
                    question++;
                    
                }
                else
                {
                    questionVisible = false;
                    resultsVisible = true;
                    OnPropertyChanged("QuestionVisible");
                    OnPropertyChanged("ResultsVisible");
                    OnPropertyChanged("CharacterName");
                }
            });
            NoBtnCommand = new Command(() =>
            {
                if (question < 4)
                {
                    
                    OnPropertyChanged("LabelText");
                    question++;
                }
                else
                {
                    questionVisible = false;
                    resultsVisible = true;
                    OnPropertyChanged("QuestionVisible");
                    OnPropertyChanged("ResultsVisible");
                    OnPropertyChanged("CharacterName");
                }
            });
            ResultsBtnCommand = new Command(() =>
            {
                questionVisible = true;
                resultsVisible = false;
                count = 0;
                question = 0;
                OnPropertyChanged("QuestionVisible");
                OnPropertyChanged("ResultsVisible");
            });
        }

        public bool QuestionVisible { get { return questionVisible; } }
        public bool ResultsVisible { get { return resultsVisible; } }
        public string LabelText { get { return questions[question]; } }
        public string CharacterName { get { return character[count]; } }


        public ICommand YesBtnCommand { get; private set; }
        public ICommand NoBtnCommand { get; private set; }
        public ICommand ResultsBtnCommand { get; private set; }
    }
}