using BookRentalWithoudDB.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalWithoudDB.Data
{
    public class StudentRespository
    {

        static List<Student> data = new List<Student> {
            new Student {ID=1, Name="Hüseyin", Surname="Şimşek", BirthDate = new DateTime(1990,1,1) },
            new Student {ID=2, Name="Mehmet", Surname="Yıldız", BirthDate = new DateTime(2001,1,1) },
            new Student {ID=4, Name="Ayşe", Surname="Kaya", BirthDate = new DateTime(2004,1,1) }
        };


        public List<Student> GetAllStudents() { 
            return data;  //"Select * from students";
        }

        public Student GetStudent(int id) { // select * from students where ID=1
            Student result = data.Where(s => s.ID == id).FirstOrDefault();

            return result;
        }

        public void Delete(int id)
        {
             data.RemoveAll(d => d.ID==id);
        }
        public void Insert(Student student)
        {
            data.Add(student);
        }
        public void Update(Student student)
        {
            var studentInDB = data.Where(s => s.ID == student.ID)
                .FirstOrDefault();

            studentInDB.Name = student.Name;
            studentInDB.Surname = student.Surname;
            studentInDB.BirthDate = student.BirthDate;
            
        }

    }
}
