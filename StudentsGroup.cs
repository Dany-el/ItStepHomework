using System.Collections;

namespace ItStepHomework;

#region Exceptions

public class GroupIsEmpty : ApplicationException
{
    public GroupIsEmpty(string message) : base(message)
    {
    }
}

public class GroupIsFull : ApplicationException
{
    public GroupIsFull(string message) : base(message)
    {
    }
}

#endregion

[Serializable]
public class StudentsGroup : ICloneable, IComparable, IEnumerable<Student>
{
    #region Fields

    public List<Student> Group { get; set; }
    public int StudentsAmount { get; private set; }
    public String GroupName { get; set; }
    public int CourseNumber { get; set; }
    public String GroupSpecialization { get; set; }

    public delegate void GroupHandler(string msg);
    public event GroupHandler UpdateCourse;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor with|out params
    /// </summary>
    /// <param name="studentsAmount">amount of students in group (default 8)</param>
    /// <param name="groupName">group name</param>
    /// <param name="courseNumber">current course number</param>
    /// <param name="groupSpecialization">specialization of group</param>
    /// <exception cref="Exception">Argument is null</exception>
    public StudentsGroup(int studentsAmount = 8, String groupName = "Undefined", int courseNumber = 0,
        String groupSpecialization = "Undefined")
    {
        if (studentsAmount < 0)
        {
            throw new Exception("The argument is less than 0");
        }

        StudentsAmount = studentsAmount;

        if (groupName == null || courseNumber == null || groupSpecialization == null)
        {
            throw new Exception("The argument is null");
        }

        GroupName = groupName;
        CourseNumber = courseNumber;
        GroupSpecialization = groupSpecialization;

        Group = new List<Student>();
        for (int i = 0; i < StudentsAmount; i++)
        {
            Group.Add(RandomStudentInfo());
        }
    }

    /*public StudentsGroup(List<Student> group)
    {
        if (group != null)
        {
            group.CopyTo(Group);
            for (int i = 0; i < group.Length; i++)
            {
                Group[i] = new Student(
                    group[i].Name, group[i].Surname, group[i].Patronymic,
                    group[i].PhoneNumber,
                    group[i].HomeAddress,
                    group[i].Birthday.Year, group[i].Birthday.Month, group[i].Birthday.Day);
            }
        }
        else
        {
            throw new Exception("Group has 0 students");
        }
    }*/

    /// <summary>
    /// Copy-constructor
    /// which copy data from another group
    /// </summary>
    /// <param name="studentGroup">group to copy</param>
    /// <exception cref="Exception">arrays with grades are null</exception>
    public StudentsGroup(StudentsGroup studentGroup)
    {
        GroupName = studentGroup.GroupName;
        CourseNumber = studentGroup.CourseNumber;
        GroupSpecialization = studentGroup.GroupSpecialization;
        StudentsAmount = studentGroup.StudentsAmount;

        Group = new List<Student>();
        for (int i = 0; i < studentGroup.StudentsAmount; i++)
        {
            var finalExamsGrades = studentGroup.Group[i].GradeFinalExams;
            var creditsGrades = studentGroup.Group[i].GradeCredits;
            var termPapersGrades = studentGroup.Group[i].GradeTermPapers;

            if (finalExamsGrades != null && creditsGrades != null && termPapersGrades != null)
            {
                Group.Add(new Student(
                    studentGroup[i].Name, studentGroup[i].Surname, studentGroup[i].Patronymic,
                    studentGroup[i].PhoneNumber,
                    studentGroup[i].HomeAddress,
                    studentGroup[i].Birthday.Year, studentGroup[i].Birthday.Month,
                    studentGroup[i].Birthday.Day,
                    finalExamsGrades.Length,
                    termPapersGrades.Length,
                    creditsGrades.Length,
                    studentGroup[i].GradeFinalExams, studentGroup[i].GradeTermPapers,
                    studentGroup[i].GradeCredits));
            }
            else
            {
                throw new Exception("The argument (array with grades) is null");
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates new object with random values
    /// </summary>
    /// <returns>object type 'Student'</returns>
    public Student RandomStudentInfo()
    {
        String[] names = new String[]
            { "Artur", "Valeria", "Vladislav", "Lena", "Artem", "Daniel", "Viktoria", "Olga" };
        String[] surnames = new String[]
            { "Boyko", "Kovalenko", "Melnik", "Shevchenko", "Savchuk", "Harchenko", "Ponomarenko", "Karpenko" };

        String[] patronymics = new string[]
        {
            "Arturovich", "Vladimirovich", "Valeriovich", "Danilovich", "Alexandrovich", "Grygoryevich",
            "Sergeyovich",
            "Pavlovich"
        };

        int randomNameIndex = new Random().Next(0, 8);
        int randomSurnameIndex = new Random().Next(0, 8);
        int randomPatronymicIndex = new Random().Next(0, 8);

        int randomDay = new Random().Next(1, 30);
        int randomMonth = new Random().Next(1, 12);
        int randomYear = new Random().Next(2000, 2005);

        int randomPhoneNumber = new Random().Next(1_000_000, 9_999_999);

        int[] finalExam = new[] { (new Random().Next(1, 6)), (new Random().Next(1, 6)) };
        int[] credits = new[]
        {
            (new Random().Next(1, 6)), (new Random().Next(1, 6)), (new Random().Next(1, 6)),
            (new Random().Next(1, 6))
        };
        int[] termPapers = new[]
            { (new Random().Next(1, 6)), (new Random().Next(1, 6)), (new Random().Next(1, 6)) };

        return new Student(names[randomNameIndex], surnames[randomSurnameIndex], patronymics[randomPatronymicIndex],
            "068" + randomPhoneNumber.ToString(),
            "st.Gde-to 93",
            randomYear, randomMonth, randomDay, 2, 3, 4, finalExam, termPapers, credits);
    }

    /// <summary>
    /// Shows group
    /// </summary>
    public void Show()
    {
        Console.WriteLine("================================================");
        Console.WriteLine($"Course №{CourseNumber}");
        Console.WriteLine($"Group name: {GroupName}");
        Console.WriteLine($"Specialization: {GroupSpecialization}");
        Console.WriteLine("================================================");

        int i = 1;
        foreach (var item in Group)
        {
            Console.WriteLine("#" + i++ + "\n" + item);
            item.ShowGrades();
        }

        Console.WriteLine("================================================");
    }

    /// <summary>
    /// Adds student to group
    /// </summary>
    /// <param name="student">student to add</param>
    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new Exception("Object with type 'Student' is null");
        }

        StudentsAmount++;

        Group.Add(student);
    }

    /// <summary>
    /// 1 - Group's name
    /// 2 - Group's specialization
    /// 3 - Course number
    /// </summary>
    /// <param name="index"></param>
    /// <param name="info"></param>
    public void EditGroupInfo(int index, String info)
    {
        if (index < 0)
        {
            throw new Exception("Index is less than 0");
        }

        if (info == null)
        {
            throw new Exception("The argument is null");
        }

        switch (index)
        {
            case 1:
                Console.WriteLine("Group's name was changed");
                GroupName = info;
                break;
            case 2:
                Console.WriteLine("Group's specialization was changed");
                GroupSpecialization = info;
                break;
            case 3:
                Console.WriteLine("Course number was changed");
                CourseNumber = int.Parse(info);
                break;
        }
    }

    /// <summary>
    /// Change student's info (except of birthday)
    /// </summary>
    /// <param name="studentIndex">from 1</param>
    /// <param name="willChange">1 - name. 2 - surname. 3 - patronymic. 4 - home address. 5 - phone number</param>
    /// <param name="info"></param>
    public void EditStudentInfo(int studentIndex, int willChange, String info)
    {
        studentIndex--;
        if ((studentIndex >= 0 || studentIndex < StudentsAmount) && (willChange > 0 || willChange <= 5))
        {
            switch (willChange)
            {
                case 1:
                    Group[studentIndex].Name = info;
                    break;
                case 2:
                    Group[studentIndex].Surname = info;
                    break;
                case 3:
                    Group[studentIndex].Patronymic = info;
                    break;
                case 4:
                    Group[studentIndex].HomeAddress = info;
                    break;
                case 5:
                    Group[studentIndex].PhoneNumber = info;
                    break;
            }
        }
        else
        {
            throw new Exception("Student's index or WillChange is out of range");
        }
    }

    /// <summary>
    /// Change student's birthday
    /// </summary>
    /// <param name="index">from 1</param>
    /// <param name="day">day of birth</param>
    /// <param name="month">month of birth</param>
    /// <param name="year">year of birth</param>
    public void EditStudentInfo(int index, int day, int month, int year)
    {
        index--;
        if (index >= 0 || index < StudentsAmount)
        {
            Group[index].SetBirthday(day, month, year);
        }
        else
        {
            throw new Exception("Index is out of range");
        }
    }

    /// <summary>
    /// Move student to another group
    /// </summary>
    /// <param name="student">source</param>
    /// <param name="dest">destination</param>
    public void MoveStudentToGroup(Student student, ref StudentsGroup dest)
    {
        if (student == null || dest == null)
        {
            throw new Exception("The argument is null");
        }

        dest.AddStudent(student);
        RemoveStudent(FindStudentIndex(student));
    }

    /// <summary>
    /// Remove student from group by 
    /// </summary>
    /// <param name="student">student to remove</param>
    /// <exception cref="Exception">object is null</exception>
    public void RemoveStudent(Student student)
    {
        if (student == null)
        {
            throw new Exception("The argument is null");
        }

        RemoveStudent(FindStudentIndex(student));
    }
    
    /// <summary>
    /// Remove student from group by index
    /// </summary>
    /// <param name="index">student's index</param>
    /// <exception cref="Exception">index is out of range</exception>
    public void RemoveStudent(int index)
    {
        index--;
        if (index < 0 || index >= Group.Count)
        {
            throw new Exception("Out of range");
        }

        Group.RemoveAt(index);
    }

    /**
     * Find student's index in array
     * Returns -1 if student does not exist in the list
     */
    private int FindStudentIndex(Student student)
    {
        int studentIndex = Group.IndexOf(student);

        if (studentIndex != -1)
        {
            return studentIndex;
        }

        return -1;
    }

    /// <summary>
    /// Removes student by index
    /// </summary>
    /// <param name="studentIndex">student's index</param>
    private void RemoveStudentByIndex(int studentIndex)
    {
        if (studentIndex < 0 || studentIndex >= StudentsAmount)
        {
            return;
        }

        Group.RemoveAt(studentIndex);
    }

    /// <summary>
    /// Removes students if grade is lower than 60
    /// Working only 1 time
    /// It will be fixed after adding kinda 'container'
    /// </summary>
    public void RemoveStudentByMinGrades()
    {
        int studentIndex = FindIndexOfStudentWithMinGrades();
        if (studentIndex == -1)
        {
            return;
        }

        Console.WriteLine(Group[studentIndex].Name + " " + Group[studentIndex].Surname +
                          " was removed from group by low grades");
        RemoveStudent(studentIndex);
    }

    /**
     * Finds student with low grades.
     * Returns index or -1 if there are not grades lower than 60
     */
    private int FindIndexOfStudentWithMinGrades()
    {
        for (int i = 0; i < StudentsAmount; i++)
        {
            int minGradeStudentIndex = i;
            for (int j = 0; j < Group[i].GradeCredits.Length; j++)
            {
                var creditsGrades = Group[j].GradeCredits;
                if (creditsGrades != null && creditsGrades[j] < 3)
                {
                    return minGradeStudentIndex;
                }
            }

            for (int j = 0; j < Group[i].GradeFinalExams.Length; j++)
            {
                var finalExamsGrades = Group[j].GradeFinalExams;
                if (finalExamsGrades != null && finalExamsGrades[j] < 3)
                {
                    return minGradeStudentIndex;
                }
            }

            for (int j = 0; j < Group[i].GradeTermPapers.Length; j++)
            {
                var termPapersGrades = Group[j].GradeTermPapers;
                if (termPapersGrades != null && termPapersGrades[j] < 3)
                {
                    return minGradeStudentIndex;
                }
            }
        }

        return -1;
    }

    /// <summary>
    /// Tests exceptions
    /// </summary>
    /// <param name="value">1 - group is full | 2 - group is empty-</param>
    /// <exception cref="GroupIsFull"></exception>
    /// <exception cref="GroupIsEmpty"></exception>
    public void TestException(int value)
    {
        switch (value)
        {
            case 1:
                throw new GroupIsFull("Group is full");
            case 2:
                throw new GroupIsEmpty("Group is empty");
        }
    }
    
    /// <summary>
    /// Updates group course
    /// </summary>
    public void CourseUpdate()
    {
        if (UpdateCourse != null)
        {
            CourseNumber++;
            UpdateCourse($"Current course {CourseNumber}");
        }
    }

    #endregion

    #region Operators

    // public static bool operator ==(StudentsGroup first, StudentsGroup second)
    // {
    //     return first.StudentsAmount == second.StudentsAmount;
    // }
    //
    // public static bool operator !=(StudentsGroup first, StudentsGroup second)
    // {
    //     return first.StudentsAmount != second.StudentsAmount;
    // }

    #endregion

    #region Indexator

    private void InRange(int index)
    {
        if (index < 0 || index >= StudentsAmount)
        {
            throw new Exception("Out of range");
        }
    }

    public Student this[int index]
    {
        get
        {
            InRange(index);
            return Group[index];
        }
        set
        {
            InRange(index);
            Group[index] = value;
        }
    }

    #endregion

    #region Interfaces' Methods

    public object Clone()
    {
        StudentsGroup copy = new StudentsGroup(this);

        return copy;
    }

    /// <summary>
    /// Sort group in list by amount of students 
    /// </summary>
    public void Sort()
    {
        Group.Sort();
    }

    public int CompareTo(object? obj)
    {
        if (obj is StudentsGroup)
        {
            StudentsGroup group = obj as StudentsGroup;

            return StudentsAmount.CompareTo(group.StudentsAmount);
        }
        else
        {
            throw new ArgumentException("Wrong parameter's type");
        }
    }

    public IEnumerator<Student> GetEnumerator()
    {
        for (int i = 0; i < Group.Count; i++)
        {
            yield return Group[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}

public static class TestExtension2
{
    public static bool IsEven(this int value)
    {
        if (value % 2 == 0)
        {
            return true;
        }

        return false;
    }
}