//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AcademyApp.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Journal
    {
        public int Id { get; set; }
        public int IdStudent { get; set; }
        public int IdDiscipline { get; set; }
        public int Evaluation { get; set; }
        public int IdNameGroup { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        public virtual NameGroup NameGroup { get; set; }
        public virtual Student Student { get; set; }
    }
}
