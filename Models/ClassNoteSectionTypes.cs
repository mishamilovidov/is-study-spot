using System;
using System.Collections.Generic;

namespace ISStudySpot.Models
{
    public partial class ClassNoteSectionTypes
    {
        public ClassNoteSectionTypes()
        {
            ClassNoteSections = new HashSet<ClassNoteSections>();
        }

        public int ClassNoteSectionTypeId { get; set; }
        public string ClassNoteSectionTypeDescription { get; set; }

        public virtual ICollection<ClassNoteSections> ClassNoteSections { get; set; }
    }
}
