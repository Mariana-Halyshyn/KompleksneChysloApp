using System;
using System.Globalization;

namespace KompleksneChysloApp
{
    public class Kompleksne_chyslo : Strichka
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Kompleksne_chyslo(double real, double imaginary) : base()
        {
            Real = real;
            Imaginary = imaginary;
            Name = "Комплексне число";
        }

       
        public Kompleksne_chyslo(string input) : base()
        {
            Name = "Комплексне число (з рядка)";
            Real = 0;
            Imaginary = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string[] parts = input.Split(new[] { 'і', 'i' }, 2, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length == 2)
            {
                string realPartStr = parts[0].Trim();
                string imagPartStr = parts[1].Trim();

                double tempReal, tempImag;

                
                if (double.TryParse(realPartStr.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out tempReal) &&
                    double.TryParse(imagPartStr.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out tempImag))
                {
                    Real = tempReal;
                    Imaginary = tempImag;
                }
            }
        }


        public override string ToString()
        {
            string imagSign = Imaginary >= 0 ? "+" : "-";
            double absImag = Math.Abs(Imaginary);
            return $"{Real.ToString(CultureInfo.InvariantCulture)} {imagSign} {absImag.ToString(CultureInfo.InvariantCulture)}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is Kompleksne_chyslo other)
            {
                return Real == other.Real && Imaginary == other.Imaginary;
            }
            return false;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Real.GetHashCode();
                hash = hash * 23 + Imaginary.GetHashCode();
                return hash;
            }
        }

        public static Kompleksne_chyslo operator +(Kompleksne_chyslo a, Kompleksne_chyslo b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a), "Лівий операнд не може бути null для додавання.");
            if (b is null) throw new ArgumentNullException(nameof(b), "Правий операнд не може бути null для додавання.");
            return new Kompleksne_chyslo(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Kompleksne_chyslo operator -(Kompleksne_chyslo a, Kompleksne_chyslo b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a), "Лівий операнд не може бути null для віднімання.");
            if (b is null) throw new ArgumentNullException(nameof(b), "Правий операнд не може бути null для віднімання.");
            return new Kompleksne_chyslo(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Kompleksne_chyslo operator *(Kompleksne_chyslo a, Kompleksne_chyslo b)
        {
            if (a is null) throw new ArgumentNullException(nameof(a), "Лівий операнд не може бути null для множення.");
            if (b is null) throw new ArgumentNullException(nameof(b), "Правий операнд не може бути null для множення.");
            return new Kompleksne_chyslo(
                a.Real * b.Real - a.Imaginary * b.Imaginary,
                a.Real * b.Imaginary + a.Imaginary * b.Real);
        }

        public override object Clone()
        {
            var cloned = new Kompleksne_chyslo(this.Real, this.Imaginary)
            {
                Name = this.Name + " (клоновано)"
            };
            return cloned;
        }

        public override int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Kompleksne_chyslo other)
            {
                double thisMagnitudeSq = this.Real * this.Real + this.Imaginary * this.Imaginary;
        double otherMagnitudeSq = other.Real * other.Real + other.Imaginary * other.Imaginary;
                return thisMagnitudeSq.CompareTo(otherMagnitudeSq);
            }
            throw new ArgumentException($"Об'єкт для порівняння має бути типу Kompleksne_chyslo. Отримано: {obj.GetType()}");
}

public override string GetText()
        {
            double magnitude = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            return $"Комплексне число: {ToString()}, Модуль: {magnitude:F2}. Ім'я об'єкта: {this.Name}";
        }
    }
}