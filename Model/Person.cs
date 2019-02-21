using System;
using MessagePack;

namespace Model
{
    [MessagePackObject]
    public class Person
    {
        [Key(0)]
        public int No { get; set; }

        [Key(1)]
        public string Name { get; set; }

        [Key(2)]
        public int Age { get; set; }

        [Key(3)]
        public Gender Sex { get; set; }

        [Key(4)]
        public DateTime Birthday { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}