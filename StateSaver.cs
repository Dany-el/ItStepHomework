using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace ItStepHomework;

public class StateSaver
{
    private FileStream file;
    private DirectoryInfo dir;
    private readonly BinaryFormatter formatter = new BinaryFormatter();
    
    /// <summary>
    /// Saves obj type of StudentsGroup to file which user entered
    /// </summary>
    /// <param name="group">obj to save</param>
    /// <param name="FILE_PATH">file path where you want to save file</param>
    public void Save(StudentsGroup group, string FILE_PATH)
    {
        if (group != null)
        {
            dir = new DirectoryInfo(Path.GetDirectoryName(FILE_PATH));

            if (!dir.Exists)
            {
                dir.Create();
            }
            
            using (file = new FileStream(FILE_PATH,FileMode.Create))
            {
                formatter.Serialize(file, group);
            }
        }
    }

    /// <summary>
    /// Saves obj type of Student to file which user entered
    /// </summary>
    /// <param name="student">obj to save</param>
    /// <param name="FILE_PATH">file path where you want to save file</param>
    public void Save(Student student, string FILE_PATH)
    {
        if (student != null)
        {
            dir = new DirectoryInfo(Path.GetDirectoryName(FILE_PATH));

            if (!dir.Exists)
            {
                dir.Create();
            }
            
            using (file = new FileStream(FILE_PATH,FileMode.Create))
            {
            
                formatter.Serialize(file, student);
            }
        }
    }

    /*public void ReadGroup(string FILE_PATH)
    {
        using (file = File.OpenRead(FILE_PATH))
        {
            StudentsGroup group = (StudentsGroup)formatter.Deserialize(file);
    
            group.Show();
        }
    }
    
    public void ReadStudent(string FILE_PATH)
    {
        using (file = File.OpenRead(FILE_PATH))
        {
            Student student = (Student)formatter.Deserialize(file);
    
            Console.WriteLine(student);
        }
    }*/
}