﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiChat.Management.Core
{
  public interface IMobiController
  {
    ManagementApplication MobiApplication { get; }
    MobiContext MobiContext { get; }
  }
}
