using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;
using System.IO;

namespace FamilyTree
{
    public class Person
    {
        public string Name { get; set; }
        public string Sname { get; set; }
        public bool Sex { get; set; }
        public string Birth { get; set; }
        public int Generation { get; set; }
        public Guid id { get; set; }

        public Person(string name, string sname, bool sex, string bitrh, int generation)
        {
            this.Name = name;
            this.Sname = sname;
            this.Sex = sex;
            this.Birth = bitrh;
            this.Generation = generation;
            this.id = Guid.NewGuid();
        }

        /*
        //load Peron
        public Person(string s){

        }
        */

    }

    class PersonArchive : ObservableCollection<Person>
    {
        //public static ObservableCollection<Person> people;
        public static List<ObservableCollection<Person>> peopleList;

        public static Person getPerson(Guid id)
        {

            foreach (Person person in peopleList[0])

                if (person.id == id) return person;

            return null;
            
        }

        public static List<Person> humans (List<Guid> id)
        {
            List<Person> peopleFromId = new List<Person>();

            foreach (Guid currentId in id)
                foreach (ObservableCollection<Person> currentList in peopleList)
                    foreach (Person currentPerson in currentList)
                        if (currentPerson.id == currentId) peopleFromId.Add(currentPerson);

            return peopleFromId;
        }
    }


    public class JsonPersonArchive
    {

        public List<ObservableCollection<Person>> peopleList;

        public static void Save()
        {
            JsonPersonArchive json = new JsonPersonArchive
            {
                peopleList = PersonArchive.peopleList
            };
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "allPersons.json");
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(json);
            File.WriteAllText(fileName, output);
        }

        public static void Load()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "allPersons.json");
            string info = File.ReadAllText(fileName);
            JsonPersonArchive set = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonPersonArchive>(info);
            PersonArchive.peopleList = set.peopleList;
        }
    }

    public class Node
    {
        public Guid personId;
        public List<Guid> childrenId;
        public Guid parentId;
        public List<Guid> parthnerId;
        public bool isParthner = false;

        public Node()
        {

        }

        public Node(Guid personId, Guid parentId)
        {
            this.personId = personId;
            this.parentId = parentId;
            this.childrenId = new List<Guid>();
            this.parthnerId = new List<Guid>();
        }

        public Node (Guid personId)
        {
            this.personId = personId;
            isParthner = true;
            this.childrenId = new List<Guid>();
            this.parthnerId = new List<Guid>();
        }
    }

    public class JsonTree
    {
        public Dictionary<Guid, Node> tree;
        public Guid rootId;
        string fileName1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "persons.txt");
        public static void Save()
        {
            JsonTree json = new JsonTree
            {
                tree = Tree.tree,
                rootId = Tree.rootId
            };
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "derevo.json");
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(json);
            File.WriteAllText(fileName, output);
        }

        public static void Load()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "derevo.json");
            string info = File.ReadAllText(fileName);
            JsonTree set = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonTree>(info);
            Tree.tree = set.tree;
            Tree.rootId = set.rootId;
        }

    }

    static class Tree
    {

        public static Dictionary<Guid, Node> tree;

        public static Guid rootId;

        public static Guid initTree()
        {
            tree = new Dictionary<Guid, Node>();
            rootId = Guid.NewGuid();
            Node root = new Node(rootId, Guid.NewGuid());
            tree.Add(rootId, root);
            return rootId;
        }

        public static void AddParthner (Guid Person1_id, Guid Person2_id)
        {
            if (!tree.ContainsKey(Person1_id)) return;
            tree[Person1_id].parthnerId.Add(Person2_id);
            Node parthner = new Node(Person2_id);
            tree.Add(Person2_id, parthner);
            tree[Person2_id].parthnerId.Add(Person1_id);
        }

        public static void AddChild(Guid parentId, Guid childId)
        {
            if (!tree.ContainsKey(parentId)) return;
            tree[parentId].childrenId.Add(childId);
            Node newNode = new Node(childId, parentId);
            tree.Add(childId, newNode);
        }

        public static List<Guid> GetChildren(Guid parentId)
        {
            if (!tree.ContainsKey(parentId)) return null;

            List<Guid> allChildren = new List<Guid>(tree[parentId].childrenId);

            foreach (Guid parthner in tree[parentId].parthnerId)
                foreach (Guid children in tree[parthner].childrenId)
                    allChildren.Add(children);

            return allChildren;
        }

        public static List<Guid> GetParent(Guid childID)
        {
            if (tree[childID].isParthner)
                return new List<Guid>();
            
              List<Guid> allParents = new List<Guid>();
                   allParents.Add(tree[childID].parentId);
               foreach (Guid current in tree[tree[childID].parentId].parthnerId)
                   allParents.Add(current);
               return allParents;
           
        }

        public static List<Guid> GetGrandparent(Guid personID)
        {
            List<Guid> allGrandparents = new List<Guid>();

            foreach (Guid current in GetParent(personID))
                foreach (Guid cur in GetParent(current))
                    allGrandparents.Add(cur);
        
            return allGrandparents;
        }

        public static List<Guid> GetSiblings(Guid personID)
        {
            List<Guid> allSiblings = new List<Guid>();

            foreach (Guid current in GetParent(personID))
                foreach (Guid cur in GetChildren(current))
                {
                    if (tree[cur] == tree[personID])
                        continue;
                    allSiblings.Add(cur);
                }
            return allSiblings;
        }

        public static List<Guid> GetCousins(Guid personID)
        {
            List<Guid> allCouisins = new List<Guid>();
            foreach (Guid current in GetParent(personID))
                foreach (Guid cur in GetSiblings(current))
                    foreach (Guid pim in GetChildren(cur))
                        allCouisins.Add(pim);

            return allCouisins;
        }

        public static List<Guid> GetParthner(Guid personID)
        {
            List<Guid> allParthners = new List<Guid>();
            foreach (Guid current in tree[personID].parthnerId)
                allParthners.Add(current);


            return allParthners;
        }


    }

}
