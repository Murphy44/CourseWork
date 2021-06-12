using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWork
{
    public class Galaxy
    {
        public string name;
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string type;
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string age;
        public string Age
        {
            get { return this.age; }
            set
            {
                if (!double.TryParse(value.Remove(value.Length - 1, 1), out _)
                    || char.ToLower(value[^1]) != 'm'
                    && char.ToLower(value[^1]) != 'b')
                {

                    this.age = value;
                }
                else
                {
                    throw new ArgumentException("Please enter a valid age");
                }
            }
        }

        public Galaxy()
        {

        }
    }
}
