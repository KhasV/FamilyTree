using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Xamarin.Forms;

namespace FamilyTree
{

    public interface IAddPersonPargeViewModel
    {
        void createNewPerson(string Name, string Sname, string DateOfBirth, bool Sex);
    }

    class AddPersonPageViewModel : IAddPersonPargeViewModel
    {

        Person parent;
        CarouselPage carPage;
 
        public AddPersonPageViewModel(Person parent)
        {
            this.parent = parent;
            this.carPage = FirstPage.carousel;
        }

        public void createNewPerson(string Name, string Sname, string DateOfBirth, bool Sex)
        {
            
            if(PersonArchive.peopleList.Count  <= parent.Generation + 1)
            {
                PersonArchive.peopleList.Add(new ObservableCollection<Person>());
                carPage.Children.Add(new ShablonPage(new MainViewModel(parent.Generation + 1)));
            }
            Person person = new Person(Name, Sname, Sex, DateOfBirth, parent.Generation + 1 );
            Tree.AddChild(parent.id, person.id);
            PersonArchive.peopleList[person.Generation].Add(person);
            (carPage.Children[person.Generation] as ShablonPage).UpdateList();
        }
    }

    class AddPartnerPageViewModel : IAddPersonPargeViewModel
    {

        Person parthner;
        CarouselPage carPage;

        public AddPartnerPageViewModel(Person parthner)
        {
            this.parthner = parthner;
            this.carPage = FirstPage.carousel; 
        }

        public void createNewPerson(string Name, string Sname, string DateOfBirth, bool Sex)
        {

            Person person = new Person(Name, Sname, Sex, DateOfBirth, parthner.Generation);
            Tree.AddParthner(parthner.id, person.id);
            PersonArchive.peopleList[person.Generation].Add(person);
            (carPage.Children[person.Generation] as ShablonPage).UpdateList();
        }
    }
}
