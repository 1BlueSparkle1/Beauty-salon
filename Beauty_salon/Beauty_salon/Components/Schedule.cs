//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beauty_salon.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateSchedule { get; set; }
        public Nullable<System.TimeSpan> TimeStart { get; set; }
        public Nullable<System.TimeSpan> TimeEnd { get; set; }
        public Nullable<int> EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
