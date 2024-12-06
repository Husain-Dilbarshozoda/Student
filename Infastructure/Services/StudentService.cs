using Npgsql;
using Dapper;
using Infastructure.Models;
namespace Infastructure.Services;

public class StudentService
{
    string mainConnection = "Server=localhost;Port=5432;Database=studentsdb;User Id=postgres;Password=501040477.tj;";

    public bool InsertStudent(Student student)
    {
        using(var connectionString = new NpgsqlConnection(mainConnection))
        {
            var sql = "insert into Students(fullname,age,score) values(@fullname,@age,@score);";
            int res=connectionString.Execute(sql,student);
            return res!=0;
        }
    }

    public List<Student>? GetStudents()
    {
        List<Student> students = new List<Student>();
        using(var connectionString=new NpgsqlConnection(mainConnection))
        {
            var sql="select * from students;";
            List<Student> res=connectionString.Query<Student>(sql).ToList();
            return res;
        }
    }

    public bool UpdateStudent(Student student)
    {
        using(var connectionString=new NpgsqlConnection(mainConnection))
        {
            var sql="update students set fullname=@fullname,age=@age,score=@score where id=@Id;";
            int res=connectionString.Execute(sql,student);
            return res!=0;
        }
    }

    public bool DeleteStudent(int id)
    {
        using(var connectionString=new NpgsqlConnection(mainConnection))
        {
            var sql="delete from students where id=@Id;";
            int res=connectionString.Execute(sql,new {Id=id});
            return res!=0;
        }
    }

    public Student? GetStudentById(int id)
    {
        using(var connectionString=new NpgsqlConnection(mainConnection))
        {
            var sql="select * from students where id=@Id;";
            Student res=connectionString.QuerySingle<Student>(sql,new {Id=id});
            return res;
        }   
    }
}