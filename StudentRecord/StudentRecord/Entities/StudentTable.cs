using System;
using System.Collections.Generic;

namespace StudentRecord.Entities;

public partial class StudentTable
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentSurname { get; set; }

    public string? StudentMail { get; set; }

    public string? StudentImage { get; set; }

    public string? StudentAddress { get; set; }
}
