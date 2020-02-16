using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using FamilyTree.ViewModel;

namespace FamilyTree
{

    public interface IMainViewModel
    {
        Person GetPersonOfIndex(int index);
        int getIndex();
        void DeletePerson(Person selPerson);
        void UpdateList();
    }

    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        int index;
        public ObservableCollection<Person> Persons { get; set; }
        

        public MainViewModel(int index)
        {
            Persons = new ObservableCollection<Person>( PersonArchive.peopleList[index]);
            this.index = index;

        }
        
        
       /* public ObservableCollection<Person> Persons
        {
            get => _persons;
            set
            {
                _persons = value;
                OnPropertyChanged("Persons");
            }
        }*/

        public Person GetPersonOfIndex(int index)
        {
            return Persons[index];
        }

        public int getIndex()
        {
            return index;
        }

        public void DeletePerson (Person selPerson)
        {
            PersonArchive.peopleList[selPerson.Generation].Remove(selPerson);
        }

        public void UpdateList()
        {

            Persons.Clear();
            foreach(Person person in PersonArchive.peopleList[index])
               Persons.Add(person);
        }
    } 
}