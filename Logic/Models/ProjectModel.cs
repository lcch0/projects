using Storage.Serializable;

namespace Logic.Models
{
    public class ProjectModel
    {
        public enum EType
        {
            Design = 1,
            Mobile = 2,
            Unity = 3
        }

        public ProjectModel()
        {
        }

        public ProjectModel(Project project)
        {
            Id = project.Id;
            ProjectType = GetProjectType(project.ProjectType);
        }

        public int Id { get; set; }
        public EType ProjectType { get; set; }
        public string ProjectDesc => GetProjectDesc(ProjectType);

        public static string GetProjectDesc(EType projectType)
        {
            switch (projectType)
            {
                case EType.Design:
                    return "Design";
                case EType.Mobile:
                    return "Mobile";
                case EType.Unity:
                    return "Unity";
                default:
                    return "Design";
            }
        }

        public static EType GetProjectType(int? value)
        {
            if (value == null)
                return EType.Design;

            if (value == (int) EType.Mobile)
                return EType.Mobile;

            if (value == (int) EType.Design)
                return EType.Design;

            if (value == (int) EType.Unity)
                return EType.Unity;

            return EType.Design;
        }

        public override string ToString()
        {
            return GetProjectDesc(ProjectType);
        }

        public Project GetStorageObject()
        {
            return new Project
            {
                Id = Id,
                ProjectType = (int) ProjectType
            };
        }
    }
}