//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Program_Computer
    {
        public int IDProgram_Computer { get; set; }
        public int IDProgram { get; set; }
        public int IDComputer { get; set; }
    
        public virtual Computer Computer { get; set; }
        public virtual Program Program { get; set; }
    }
}
