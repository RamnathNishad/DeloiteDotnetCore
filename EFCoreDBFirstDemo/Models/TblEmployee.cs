﻿using System;
using System.Collections.Generic;

namespace EFCoreDBFirstDemo.Models;

public partial class TblEmployee
{
    public int Ecode { get; set; }

    public string? Ename { get; set; }

    public int? Salary { get; set; }

    public int? Deptid { get; set; }
}
