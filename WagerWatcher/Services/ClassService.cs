using WagerWatcher.Repositories;

namespace WagerWatcher.Services
{
    public class ClassService
    {
        public static Class BuildClassForDB(string classDesc)
        {
            if (classDesc == null) classDesc = "NOT SPECIFIED";
            var newClass = new Class
                {
                    ClassDesc = classDesc
                };
            return newClass;
        }

        public static Class GetClass(string desc = "NOT SPECIFIED")
        {
            if (desc == null) desc = "description";
            return ClassRepository.GetByDesc(desc);
        }
    }
}
