using System;

namespace Phase1Assessment
{
    [Serializable]
    class TeacherModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassAndSection { get; set; }
    }
}
