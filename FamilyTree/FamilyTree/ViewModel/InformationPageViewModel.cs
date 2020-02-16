using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FamilyTree
{
    public interface IInformationPageViewModel
    {
        Person GetPerson();
        int numberOfRowsChildren();
        TextCell tableViewChildrenCell(int number);
        int numberOfRowsParents();
        TextCell tableViewParentsCell(int number);
        int numberOfRowsGrandparents();
        TextCell tableViewGrandparentsCell(int number);
        int numberOfRowsSiblings();
        TextCell tableViewSiblingsCell(int number);
        int numberOfRowsCousins();
        TextCell tableViewCousinsCell(int number);
        int numberOfRowsParthners();
        TextCell tableViewParthnersCell(int number);
    }

    public class InformationPageViewModel : IInformationPageViewModel
    {
        Person person;
        List<Person> childrenList;
        List<Person> parentsList;
        List<Person> grandparentsList;
        List<Person> siblingsList;
        List<Person> cousinsList;
        List<Person> parthnersList;

        public InformationPageViewModel(Person person)
        {
            this.person = person;
            childrenList = PersonArchive.humans(Tree.GetChildren(person.id));
            parentsList = PersonArchive.humans(Tree.GetParent(person.id));
            parthnersList = PersonArchive.humans(Tree.GetParthner(person.id));
            grandparentsList = PersonArchive.humans(Tree.GetGrandparent(person.id));
            siblingsList = PersonArchive.humans(Tree.GetSiblings(person.id));
            cousinsList = PersonArchive.humans(Tree.GetCousins(person.id));
        }   

        public Person GetPerson()
        {
            return person;
        }

        public int numberOfRowsChildren()
        {
            return childrenList.Count;
        }

        public int numberOfRowsParents()
        {
            return parentsList.Count;
        }

        public int numberOfRowsGrandparents()
        {
            return grandparentsList.Count;
        }

        public int numberOfRowsSiblings()
        {
            return siblingsList.Count;
        }

        public int numberOfRowsCousins()
        {
            return cousinsList.Count;
        }

        public int numberOfRowsParthners()
        {
            return parthnersList.Count;
        }

        public TextCell tableViewChildrenCell(int number)
        {
            TextCell cell = new TextCell()
            {
                Text = childrenList[number].Sname + " " + childrenList[number].Name,
                TextColor = Color.CadetBlue,
                IsEnabled = false,
            };
            return cell;

        }

        public TextCell tableViewParentsCell(int number)
        {
            TextCell cell = new TextCell()
            {
                Text = parentsList[number].Sname + " " + parentsList[number].Name,
                TextColor = Color.CadetBlue,
                IsEnabled = false,
            };
            return cell;
        }


        public TextCell tableViewParthnersCell(int number)
        {
            TextCell cell = new TextCell()
            {
                Text = parthnersList[number].Sname + " " + parthnersList[number].Name,
                TextColor = Color.CadetBlue,
                IsEnabled = false,
            };
            return cell;
        } 

        public TextCell tableViewGrandparentsCell(int number)
        {
            TextCell cell = new TextCell()
            {
                Text = grandparentsList[number].Sname + " " + grandparentsList[number].Name,
                TextColor = Color.CadetBlue,
                IsEnabled = false,
            };
            return cell;
        }


        public TextCell tableViewSiblingsCell(int number)
        {
            TextCell cell = new TextCell()
            {
                Text = siblingsList[number].Sname + " " + siblingsList[number].Name,
                TextColor = Color.CadetBlue,
                IsEnabled = false,
            };
            return cell;
        }



        public TextCell tableViewCousinsCell(int number)
        {
            TextCell cell = new TextCell()
            {
                Text = cousinsList[number].Sname + " " + cousinsList[number].Name,
                TextColor = Color.CadetBlue,
                IsEnabled = false,
            };
            return cell;
        }

    }

}
