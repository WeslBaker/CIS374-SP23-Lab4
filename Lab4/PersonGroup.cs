

namespace Lab4
{
    public class PersonGroup
    {
        public List<Person> Persons { get; set; } = new List<Person>();

        public char? StartingLetter {
            get {
                // if Persons is SORTED
                return Persons[0].FirstName[0];
            }
        }

        // TODO
        public char? EndingLetter {
            get
            {
                //if Persons is SORTED
                return Persons[-1].FirstName[0];
            }
        }

        public int Count => Persons.Count;

        public Person this[int i]
        {
            get
            {
                if (Persons == null)
                    throw new NullReferenceException("Persons is null");

                if (i < 0 || i > Persons.Count)
                    throw new IndexOutOfRangeException();

                Persons.Sort();
                return Persons[i];
            }
        }

        public PersonGroup(List<Person> persons = null)
        {
            if( persons != null)
            {
                foreach(var p in persons)
                {
                    Persons.Add(p);
                }
            }

            Persons.Sort();
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Persons)+ "]";
        }


        // TODO
        public static List<PersonGroup> GeneratePersonGroups(List<Person> persons, int distance)
        {
            var personGroups = new List<PersonGroup>();
            for(int i = 0; i < 26 / distance; i++)
            {
                personGroups.Add(default(PersonGroup));
            }

            persons.Sort();
            foreach(var person in persons)
            {
                var upper = char.ToUpper(person.FirstName[0]);
                person.FirstName = upper + person.FirstName.Substring(1);
            }

           foreach(var person in persons)
           {
                for(int i = 0; i < personGroups.Count; i++)
                {
                    if (personGroups[i][0].Equals(default(PersonGroup)))
                    {
                        personGroups[i][0].FirstName = person.FirstName;
                        personGroups[i][0].LastName = person.LastName;
                    }
                    else if (personGroups[i].StartingLetter < person.FirstName[0] && personGroups[i].StartingLetter + distance > person.FirstName[0])
                    {
                        personGroups[i].Persons.Add(person);
                        break;
                    }
                }
           }

            return personGroups;
        }

    }
}
