using System;

namespace MathExpressions
{
    /// <summary>
    /// Operations with Polynomial
    /// </summary>
    public class Polynomial
    {
        #region Fields

        /// <summary>
        /// The default capacity of the coefficients array
        /// </summary>
        public const int DefaultCapacity = 32;

        /// <summary>
        /// The coefficients array
        /// </summary>
        private double[] coefficients = new double[DefaultCapacity];

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Polynomial"/> class.
        /// </summary>
        /// <param name="coefficients">The coefficients array.</param>
        /// <exception cref="System.ArgumentNullException">coefficients are null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">coefficients are out of capacity</exception>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException(nameof(coefficients));
            }

            if (coefficients.Length < 1 || coefficients.Length > DefaultCapacity) 
            {
                throw new ArgumentOutOfRangeException(nameof(coefficients));
            }

            Array.Copy(coefficients, this.Coefficients, coefficients.Length);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the coefficients.
        /// </summary>
        /// <value>
        /// The coefficients array.
        /// </value>
        public double[] Coefficients
        {
            get
            {
                return this.coefficients;
            }
        }

        /// <summary>
        /// Gets the degree.
        /// </summary>
        /// <value>
        /// The degree of polynomial.
        /// </value>
        public int Degree
        {
            get
            {
                for (int i = this.Coefficients.Length - 1; i >= 0; i--) 
                {
                    if (Math.Abs(this.Coefficients[i]) >= double.Epsilon)
                    {
                        return i;
                    }
                }

                return -1;
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
        public static Polynomial operator +(Polynomial value1, Polynomial value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++) 
            {
                coefficients[i] = value1.Coefficients[i] + value2.Coefficients[i];
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
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] - value2.Coefficients[i];
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
        public static Polynomial operator *(Polynomial value1, double value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] * value2;
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
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value2.Coefficients[i] * value1;
            }

            return new Polynomial(coefficients);
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

            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] / value2;
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
        public static Polynomial operator *(Polynomial value1, Polynomial value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i <= value1.Degree; i++)
            {
                for (int j = 0; j <= value2.Degree; j++)
                {
                    checked
                    {
                        coefficients[i + j] += value1.Coefficients[i] * value2.Coefficients[j];
                    }
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
            if (value1.Degree == value2.Degree)
            {
                for (int i = 0; i <= value1.Degree; i++) 
                {
                    if (value1.Coefficients[i] != value2.Coefficients[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
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
            if (value1.Degree == value2.Degree)
            {
                for (int i = 0; i <= value1.Degree; i++)
                {
                    if (value1.Coefficients[i] != value2.Coefficients[i])
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }

        #endregion

        #region PublicMethods

        /// <summary>
        /// + overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Sum of two values</returns>
        public static Polynomial Add(Polynomial value1, Polynomial value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] + value2.Coefficients[i];
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// - overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Difference of two objects</returns>
        public static Polynomial Substruct(Polynomial value1, Polynomial value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] - value2.Coefficients[i];
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// * overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Product of two values</returns>
        public static Polynomial Multiply(Polynomial value1, double value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] * value2;
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// * overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Product of two values</returns>
        public static Polynomial Multiply(double value1, Polynomial value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value2.Coefficients[i] * value1;
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// / overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Division of two values</returns>
        /// <exception cref="System.ArgumentException">Can not divide by zero</exception>
        public static Polynomial Devide(Polynomial value1, double value2)
        {
            if (value2 == 0)
            {
                throw new ArgumentException(nameof(value2));
            }

            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                coefficients[i] = value1.Coefficients[i] / value2;
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// * overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Product of two values</returns>
        public static Polynomial Multiply(Polynomial value1, Polynomial value2)
        {
            double[] coefficients = new double[DefaultCapacity];

            for (int i = 0; i < DefaultCapacity; i++)
            {
                for (int j = 0; i < DefaultCapacity; j++)
                {
                    checked
                    {
                        coefficients[i + j] += value1.Coefficients[i] * value2.Coefficients[j];
                    }
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// == overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Comparison result</returns>
        public static bool Equals(Polynomial value1, Polynomial value2)
        {
            if (value1.Degree == value2.Degree)
            {
                for (int i = 0; i <= value1.Degree; i++)
                {
                    if (value1.Coefficients[i] != value2.Coefficients[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// != overloading analog.
        /// </summary>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <returns>Comparison result</returns>
        public static bool Compare(Polynomial value1, Polynomial value2)
        {
            if (value1.Degree == value2.Degree)
            {
                for (int i = 0; i <= value1.Degree; i++)
                {
                    if (value1.Coefficients[i] == value2.Coefficients[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return true;
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
                if (this.Coefficients[i] != 0)
                {
                    if (result != string.Empty && this.Coefficients[i] >= 0) 
                    {
                        result += "+";
                    }

                    result += $"{this.Coefficients[i]}x^{i}";
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
            return this.Coefficients.GetHashCode();
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

            return Equals(this, polynomial);
        }

        #endregion
    }
}
