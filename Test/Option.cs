using System;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    public class Option
    {
        public Option (string name)
        {
            _name = name ?? string.Empty;
        }

        public string Name { get { return _name; } }
        private readonly string _name;

        public override bool Equals (object obj)
        {
            if (!(obj is Option))
                return false;

            var other = obj as Option;
            return Name == other.Name;
        }

        public override int GetHashCode ()
        {
            return Name.GetHashCode ();
        }

        public static bool operator == (Option option1, Option option2)
        {
            return option1.Equals (option2);
        }
        
        public static bool operator != (Option option1, Option option2)
        {
            return !option1.Equals (option2);
        }
    }

}

