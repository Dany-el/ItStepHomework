using System.Collections;

namespace Project;

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

public class StudentsGroup : ICloneable, IComparable, IEnumerable<Student>
{
    #region Fields

    public List<Student> Group { get; set; }
    public int StudentsAmount { get; private set; }
    public String GroupName { get; set; }
    public String CourseNumber { get; set; }
    public String GroupSpecialization { get; set; }

    #endregion

    #region Constructors

    public StudentsGroup(int studentsAmount = 8, String groupName = "AC-227", String courseNumber = "1",
        String groupSpecialization = "ICS")
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
                    studentGroup[i].GradeFinalExams,studentGroup[i].GradeTermPapers,studentGroup[i].GradeCredits));
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
    /// Create new object with random values
    /// </summary>
    /// <returns>object type 'Student'</returns>
    private Student RandomStudentInfo()
    {
        String[] names = new String[]
            { "Artur", "Valeria", "Vladislav", "Lena", "Artem", "Daniel", "Viktoria", "Olga" };
        String[] surnames = new String[]
            { "Boyko", "Kovalenko", "Melnik", "Shevchenko", "Savchuk", "Harchenko", "Ponomarenko", "Karpenko" };

        String[] patronymics = new string[]
        {
            "Arturovich", "Vladimirovich", "Valeriovich", "Danilovich", "Alexandrovich", "Grygoryevich", "Sergeyovich",
            "Pavlovich"
        };

        int randomNameIndex = new Random().Next(0, 8);
        int randomSurnameIndex = new Random().Next(0, 8);
        int randomPatronymicIndex = new Random().Next(0, 8);

        int randomDay = new Random().Next(1, 30);
        int randomMonth = new Random().Next(1, 12);
        int randomYear = new Random().Next(2000, 2005);

        int randomPhoneNumber = new Random().Next(1_000_000, 9_999_999);

        int[] finalExam = new[] { (new Random().Next(1, 6)),(new Random().Next(1, 6)) };
        int[] credits = new[] { (new Random().Next(1, 6)),(new Random().Next(1, 6)),(new Random().Next(1, 6)),(new Random().Next(1, 6)) };
        int[] termPapers = new[] { (new Random().Next(1, 6)),(new Random().Next(1, 6)),(new Random().Next(1, 6)) };

        return new Student(names[randomNameIndex], surnames[randomSurnameIndex], patronymics[randomPatronymicIndex],
            "068" + randomPhoneNumber.ToString(),
            "st.Gde-to 93",
            randomYear, randomMonth, randomDay, 2, 3, 4, finalExam, termPapers, credits);
    }

    /// <summary>
    /// Show group
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
    /// Add student
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
                CourseNumber = info;
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
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
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
    /// <param name="student">who will be transferred</param>
    /// <param name="dest">where student will be transferred</param>
    public void MoveStudentToGroup(Student student, ref StudentsGroup dest)
    {
        if (student == null || dest == null)
        {
            throw new Exception("The argument is null");
        }

        dest.AddStudent(student);
        RemoveStudentByIndex(FindStudentIndex(student));
    }

    /// <summary>
    /// Find student's index in array
    /// </summary>
    /// <param name="student">student to find</param>
    /// <returns></returns>
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
    /// Remove student by index
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
    /// Remove students if grade is lower than 60
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
        RemoveStudentByIndex(studentIndex);
    }

    /// <summary>
    /// Find student with low grades
    /// </summary>
    /// <returns>index or -1 if there are not grades lower than 60</returns>
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
    /// Test expections
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

    #endregion

    #region Operators

    public static bool operator ==(StudentsGroup first, StudentsGroup second)
    {
        return first.StudentsAmount == second.StudentsAmount;
    }

    public static bool operator !=(StudentsGroup first, StudentsGroup second)
    {
        return first.StudentsAmount != second.StudentsAmount;
    }

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
}