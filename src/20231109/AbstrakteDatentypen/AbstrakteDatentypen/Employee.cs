using System;

namespace AbstrakteDatentypen
{
    internal abstract class Employee
    {
        public abstract string Name { get; }

        public abstract Guid Id { get; }

        public abstract int BirthYear { get; }

        public abstract decimal CalculateSallery();


        public abstract void ShowInfo();

    }
}
