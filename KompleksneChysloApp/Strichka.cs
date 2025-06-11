using System;

namespace KompleksneChysloApp
{
    public class Strichka : IMyInterface, ICloneable, IComparable
    {
        public string Name { get; set; }

        public Strichka()
        {
            Name = "Базовий об'єкт";
        }
        public virtual string GetText()
        {
            return $"Тип: {this.GetType().Name}, Ім'я: {Name}";
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        // IComparable 
        public virtual int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Strichka otherStrichka = obj as Strichka;
            if (otherStrichka != null)
            {
                return string.Compare(this.Name, otherStrichka.Name, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                throw new ArgumentException($"Об'єкт має бути типу Strichka для порівняння. Отримано: {obj.GetType()}");
            }
        }
    }
}
