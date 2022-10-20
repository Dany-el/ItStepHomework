namespace Project;

    #region Exceptions

    public class StudentIsNewException : ApplicationException
    {
        public StudentIsNewException(string message) : base(message)
        {
        }
    }

    public class StudentHasNoInternetException : ApplicationException
    {
        public StudentHasNoInternetException(string message) : base(message)
        {
        }
    }

    public class StudentHasNoHomeworkException : ApplicationException
    {
        public StudentHasNoHomeworkException(string message) : base(message)
        {
        }
    }

    public class StudentIsIllException : ApplicationException
    {
        public StudentIsIllException(string message) : base(message)
        {
        }
    }

    #endregion
    
    public class Student : Person, ICloneable, IComparable
    {
        #region Fields

        public string PhoneNumber { get; set; }

        public string HomeAddress { get; set; }

        private int[] gradeFinalExams;

        public int[]? GradeFinalExams
        {
            get => gradeFinalExams;
            set
            {
                if (value == null)
                {
                    throw new Exception("The array is null");
                }
                else
                {
                    gradeFinalExams = new int[value.Length];
                    for (int i = 0; i < gradeFinalExams.Length; i++)
                    {
                        gradeFinalExams[i] = value[i];
                    }
                }
            }
        }

        private int[] gradeTermPapers;

        public int[]? GradeTermPapers
        {
            get => gradeTermPapers;
            set
            {
                if (value == null)
                {
                    throw new Exception("The array is null");
                }
                else
                {
                    gradeTermPapers = new int[value.Length];
                    for (int i = 0; i < gradeTermPapers.Length; i++)
                    {
                        gradeTermPapers[i] = value[i];
                    }
                }
            }
        }

        private int[] gradeCredits;

        public int[]? GradeCredits
        {
            get => gradeCredits;
            set
            {
                if (value == null)
                {
                    throw new Exception("The array is null");
                }
                else
                {
                    gradeCredits = new int[value.Length];
                    for (int i = 0; i < gradeCredits.Length; i++)
                    {
                        gradeCredits[i] = value[i];
                    }
                }
            }
        }

        #endregion

        #region Constructors

        public Student(
            string name = "Undefined",
            string surname = "Undefined",
            string patronymic = "Undefined",
            string phoneNumber = "Undefined",
            string homeAddress = "Undefined",
            int year = 1,
            int month = 1,
            int day = 1,
            int finalExamsAmount = 1,
            int termPapersAmount = 1,
            int creditsAmount = 1,
            int[]? finalExamGrades = null,
            int[]? termPapersGrades = null,
            int[]? creditsGrades = null
        ) : base(name, surname, patronymic, day, month, year)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            HomeAddress = homeAddress;
            PhoneNumber = phoneNumber;

            SetBirthday(day, month, year);
            if (finalExamGrades == null)
            {
                GradeFinalExams = new int[finalExamsAmount];
                GradeFinalExams[0] = new Random().Next(1, 6);
            }
            else
            {
                GradeFinalExams = finalExamGrades;
            }

            if (termPapersGrades == null)
            {
                GradeTermPapers = new int[termPapersAmount];
                GradeTermPapers[0] = new Random().Next(1, 6);
            }
            else
            {
                GradeTermPapers = termPapersGrades;
            }

            if (creditsGrades == null)
            {
                GradeCredits = new int[creditsAmount];
                GradeCredits[0] = new Random().Next(1, 6);
            }
            else
            {
                GradeCredits = creditsGrades;
            }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string info = base.ToString() +
                          $"Phone number: {PhoneNumber}\n" +
                          $"Home address: {HomeAddress}\n";
            return info;
        }


        /// <summary>
        /// Takes value from CompareTo() method and reverse its value
        /// The cause - in the end the first will be min value and the last max value
        /// </summary>
        /// <param name="value"> Integer from CompareTo()</param>
        /// <returns> 
        /// zero             - This instance is equal to value
        /// negative integer - This instance is less than value
        /// positive integer - This instance is greater than value
        /// </returns>
        private int ReversedCompareTo(int value)
        {
            if (value < 0)
            {
                return 1;
            }
            else if (value > 0)
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo(object? obj)
        {
            if (obj is Student)
            {
                Student student = obj as Student;

                // It compares from min to max 
                int value = AvgCredit().CompareTo(student.AvgCredit());

                // Reversing
                return ReversedCompareTo(value);
            }
            else
            {
                throw new ArgumentException("Wrong parameter's type!");
            }
        }

        public object Clone()
        {
            Student copy = new Student(Name, Surname, Patronymic,
                PhoneNumber, HomeAddress, Birthday.Year, Birthday.Month, Birthday.Day,
                1, 2, 3,
                GradeFinalExams, GradeTermPapers, GradeCredits);

            return copy;
        }

        public void ShowGrades()
        {
            Console.WriteLine("====Grades====");

            Console.Write("Final exams: ");
            foreach (var item in GradeFinalExams)
            {
                Console.Write($" {item} ");
            }

            Console.Write("\nTerm papers: ");
            foreach (var item in GradeTermPapers)
            {
                Console.Write($" {item} ");
            }

            Console.Write("\nCredits    : ");
            foreach (var item in GradeCredits)
            {
                Console.Write($" {item} ");
            }

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Test exceptions
        /// </summary>
        /// <param name="value">1 - is ill | 2 - is new | 3 - no hw | 4 - no internet</param>
        /// <exception cref="StudentIsIllException"></exception>
        /// <exception cref="StudentIsNewException"></exception>
        /// <exception cref="StudentHasNoHomeworkException"></exception>
        /// <exception cref="StudentHasNoInternetException"></exception>
        public void TestException(int value)
        {
            switch (value)
            {
                case 1:
                    throw new StudentIsIllException("Student is ill");
                case 2:
                    throw new StudentIsNewException("Student is new");
                case 3:
                    throw new StudentHasNoHomeworkException("Student has no homework");
                case 4:
                    throw new StudentHasNoInternetException("Student has no internet");
            }
        }

        private double AvgCredit()
        {
            double avg = 0;

            foreach (var item in gradeCredits)
            {
                avg += item;
            }

            return avg / gradeCredits.Length;
        }

        #endregion

        #region Operators

        public static bool operator >(Student first, Student second)
        {
            double avgFirst = first.AvgCredit();
            double avgSecond = second.AvgCredit();

            return avgFirst > avgSecond;
        }

        public static bool operator <(Student first, Student second)
        {
            double avgFirst = first.AvgCredit();
            double avgSecond = second.AvgCredit();

            return avgFirst < avgSecond;
        }

        public static bool operator ==(Student first, Student second)
        {
            double avgFirst = first.AvgCredit();
            double avgSecond = second.AvgCredit();

            return avgFirst == avgSecond;
        }

        public static bool operator !=(Student first, Student second)
        {
            double avgFirst = first.AvgCredit();
            double avgSecond = second.AvgCredit();

            return avgFirst != avgSecond;
        }

        #endregion
    }

    public static class TestExtension
    {
        public static bool IsOdd(this int value)
        {
            if (value % 2 != 0)
            {
                return true;
            }

            return false;
        }
    }
