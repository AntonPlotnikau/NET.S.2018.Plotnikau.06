using System;

namespace MathExpressions
{
    /// <summary>
    /// Operations with Polynomial
    /// </summary>
    public sealed class Polynomial
    {
        #region Fields
        /// <summary>
        /// The accuracy
        /// </summary>
        private static readonly double Epsilon;

        /// <summary>
        /// The coefficients array
        /// </summary>
        private readonly double[] coefficients = { };

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="Polynomial"/> class.
        /// </summary>
        static Polynomial()
        {
            try
            {
                Epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
            }
            catch (Exception)
            {
                Epsilon = 0.0001;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial" /> class.
        /// </summary>
        /// <param name="coefficients">The coefficients array.</param>
        /// <exception cref="ArgumentNullException">coefficients is null</exception>
        /// <exception cref="ArgumentOutOfRangeException">coefficients length less than 1</exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length < 1) 
            {
                throw new ArgumentOutOfRangeException(nameof(coefficients));
            }

            this.coefficients = new double[coefficients.Length];
            coefficients.CopyTo(this.coefficients, 0);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the degree.
        /// </summary>
        /// <value>
        /// The degree of polynomial.
        /// </value>
        /// <exception cref="ArgumentNullException">coefficients are null</exception>
        public int Degree
        {
            get
            {
                if (this.coefficients == null)
                {
                    throw new ArgumentNullException(nameof(this.coefficients));
                }

                for (int i = this.coefficients.Length - 1; i >= 0; i--) 
                {
                    if (Math.Abs(this.coefficients[i]) >= Epsilon)
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> with the specified number.
        /// </summary>
        /// <value>
        /// The <see cref="System.Double"/>.
        /// </value>
        /// <param name="number">The index of coefficient.</param>
        /// <returns>coefficient at a given index</returns>
        /// <exception cref="ArgumentOutOfRangeException">number is more than degree</exception>
        public double this[int number]
        {
            get
            {
                if (number > this.Degree)
                {
                    throw new ArgumentOutOfRangeException(nameof(number));
                }

                return this.coefficients[number];
            }
        }

        #endregion

        #region Overloading

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="ArgumentNullException">one of the values is null</exception>
        public static Polynomial operator +(Polynomial value1, Polynomial value2)
        {
            if (value1 is null || value2 is null) 
            {
                throw new ArgumentNullException();
            }

            double[] larger = null;
            double[] smaller = null;

            if (value1.coefficients.Length > value2.coefficients.Length)
            {
                larger = new double[value1.coefficients.Length];
                smaller = new double[value2.coefficients.Length];
                value1.coefficients.CopyTo(larger, 0);
                value2.coefficients.CopyTo(smaller, 0);
            }
            else
            {
                larger = new double[value2.coefficients.Length];
                smaller = new double[value1.coefficients.Length];
                value2.coefficients.CopyTo(larger, 0);
                value1.coefficients.CopyTo(smaller, 0);
            }

            for (int i = 0; i < smaller.Length; i++) 
            {
                larger[i] += smaller[i];
            }

            return new Polynomial(larger);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="value">The value for operation.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="ArgumentNullException">value is null</exception>
        public static Polynomial operator -(Polynomial value)
        {
            if (value is null) 
            {
                throw new ArgumentNullException(nameof(value));
            }

            double[] coefficients = new double[value.coefficients.Length];

            for (int i = 0; i < value.coefficients.Length; i++) 
            {
                coefficients[i] = -value.coefficients[i];
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator -(Polynomial value1, Polynomial value2)
            => value1 + -value2;

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="ArgumentNullException">value1 is null</exception>
        public static Polynomial operator *(Polynomial value1, double value2)
        {
            if (value1 is null) 
            {
                throw new ArgumentNullException(nameof(value1));
            }

            double[] coefficients = new double[value1.coefficients.Length];

            for (int i = 0; i < value1.coefficients.Length; i++)
            {
                coefficients[i] = value1.coefficients[i] * value2;
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Polynomial operator *(double value1, Polynomial value2)
        {
            return value2 * value1;
        }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="System.ArgumentException">Can not divide by zero</exception>
        public static Polynomial operator /(Polynomial value1, double value2)
        {
            if (value2 == 0)
            {
                throw new ArgumentException(nameof(value2));
            }

            return value1 * (1 / value2);
        }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        /// <exception cref="ArgumentNullException">value1 or value2 is null</exception>
        public static Polynomial operator *(Polynomial value1, Polynomial value2)
        {
            if (value1 is null || value2 is null)
            {
                throw new ArgumentNullException();
            }

            double[] coefficients = new double[value1.coefficients.Length + value2.coefficients.Length];

            for (int i = 0; i < value1.coefficients.Length; i++)
            {
                for (int j = 0; j < value2.coefficients.Length; j++)
                {
                    coefficients[i + j] += value1.coefficients[i] * value2.coefficients[j];
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Polynomial value1, Polynomial value2)
        {
            if (ReferenceEquals(value1, value2))
            {
                return true;
            }

            if (ReferenceEquals(value1, null))
            {
                return false;
            }

            return value1.Equals(value2);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Polynomial value1, Polynomial value2)
        {
            if (ReferenceEquals(value1, value2))
            {
                return false;
            }

            if (ReferenceEquals(value1, null))
            {
                return true;
            }

            return !value1.Equals(value2);
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// + overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// Sum of two values
        /// </returns>
        public static Polynomial Add(Polynomial value1, Polynomial value2)
            => value1 + value2;

        /// <summary>
        /// - overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// Difference of two objects
        /// </returns>
        public static Polynomial Substruct(Polynomial value1, Polynomial value2)
            => value1 - value2;

        /// <summary>
        /// * overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// Product of two values
        /// </returns>
        public static Polynomial Multiply(Polynomial value1, double value2)
            => value1 * value2;

        /// <summary>
        /// * overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// Product of two values
        /// </returns>
        public static Polynomial Multiply(double value1, Polynomial value2)
            => value1 * value2;

        /// <summary>
        /// / overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// Division of two values
        /// </returns>
        /// <exception cref="System.ArgumentException">Can not divide by zero</exception>
        public static Polynomial Devide(Polynomial value1, double value2)
            => value1 / value2;

        /// <summary>
        /// * overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>
        /// Product of two values
        /// </returns>
        public static Polynomial Multiply(Polynomial value1, Polynomial value2)
            => value1 * value2;

        /// <summary>
        /// Check the specified value for equality.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>true if polynomials equal and false otherwise</returns>
        public bool Equals(Polynomial value)
        {
            if (ReferenceEquals(this, value))
            {
                return true;
            }

            if (ReferenceEquals(value, null))
            { 
                return false;
            }

            if (this.Degree == value.Degree)
            {
                for (int i = 0; i <= value.Degree; i++)
                {
                    if (Math.Abs(this.coefficients[i] - value.coefficients[i]) > Epsilon) 
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        #endregion

        #region System.Object Methods Overloading

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string result = string.Empty;

            for (int i = this.Degree; i >= 0; i--) 
            {
                if (this.coefficients[i] != 0)
                {
                    if (result != string.Empty && this.coefficients[i] >= 0) 
                    {
                        result += "+";
                    }

                    result += $"{this.coefficients[i]}x^{i}";
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.coefficients.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Polynomial polynomial = (Polynomial)obj;

            return this.Equals(polynomial);
        }

        #endregion
    }
}
