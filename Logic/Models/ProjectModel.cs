using Storage.Serializable;
using static Storage.Serializable.Project;

namespace Logic.Models
{
    public class ProjectModel
    {
        public enum EType
        {
            Design = Project.EType.Design,
            Mobile = Project.EType.Mobile,
            Unity = Project.EType.Unity,
            Corning = Project.EType.Corning,
            Internal = Project.EType.Internal,
            Ftth = Project.EType.Ftth,
            NonDev = Project.EType.NonDev,
            Training = Project.EType.Training,
            Vakation = Project.EType.Vakation,
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