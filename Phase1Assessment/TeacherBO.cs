using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Phase1Assessment
{
    class TeacherBO
    {
        public List<TeacherModel> teachers = new List<TeacherModel>();
        public List<TeacherModel> GetAllTeachers() => teachers;
        public TeacherModel GetTeacherById(int id)
        {
            TeacherModel? ret = null;
            try { ret = teachers.Single(x => x.ID == id); }
            catch (Exception ex)
            {
            }
            return ret;
        }
        public void AddTeacher(TeacherModel t) => teachers.Add(t);
        public void EditTeacher(TeacherModel t)
        {
            int index = teachers.FindIndex(x => x.ID == t.ID);
            teachers[index] = t;
        }
        public void DeleteTeacher(TeacherModel t)
        {
            int index = teachers.FindIndex(x => x.ID == t.ID);
            teachers.RemoveAt(index);
        }
    }
}
