using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FamilyTree
{

    public interface ISearchPageViewModel
    {
        void Searching(string s);
        void UpdateList(); 
    }

    public class SearchPageViewModel : ISearchPageViewModel
    {

        public ObservableCollection<Person> Persons { get; set; }
        List<Person> allPersons { get; set; }

        public SearchPageViewModel()
        {
            // Persons = new ObservableCollection<Person>();
          
            allPersons = GetList();


            var coco = from current in allPersons
                       orderby current.Sname
                       select current;

            Persons = new ObservableCollection<Person>(coco);
        }

        public void Searching(string s)
        {
            if (s.Length == 0)
            {
                UpdateList();
                return;
            }

            var newList = from current in allPersons
                          where current.Name.ToUpper().IndexOf(s.ToUpper()) > -1 || current.Sname.ToUpper().IndexOf(s.ToUpper()) > -1
                          orderby current.Sname
                          select current;

            Persons.Clear();
            foreach (var cur in newList)
                Persons.Add(cur);
  
        }



        private List<Person> GetList()
        {
            List<Person> lp = new List<Person>();
            foreach (var current in PersonArchive.peopleList)
                foreach (Person currentPerson in current)
                    lp.Add(currentPerson);

            return lp;
        }

        public void UpdateList()
        {
            
             Persons.Clear();

             allPersons = GetList();
            

            var coco = from current in allPersons
                       orderby current.Sname
                       select current;
            foreach(Person person in coco)
                Persons.Add(person);
        }
    }
}